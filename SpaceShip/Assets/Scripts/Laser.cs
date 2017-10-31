using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {
	LineRenderer lr;
	Light laserLight;
	public float laserOffTime=.5f;
	public float maxDistance=300f;
	public float fireDelay;
	bool canFire;


	void Start(){
		lr.enabled = false;
		laserLight.enabled = false;
		canFire = true;
	}

	// Use this for initialization
	void Awake () {
		lr = GetComponent<LineRenderer> ();
		laserLight = GetComponent<Light> ();
	}

	void Update(){
	//	Debug.DrawRay (transform.position,transform.TransformDirection(Vector3.forward)*maxDistance,Color.yellow);
	}

	Vector3 castRay(){
		RaycastHit hit;
		Vector3 fwd= transform.TransformDirection (Vector3.forward) * maxDistance;
		if (Physics.Raycast (transform.position,fwd,out hit)) {
			Debug.Log ("We hit.."+ hit.transform.name);

			spawnExplosion (hit.point, hit.transform);
			
			return hit.point;
		}

		return transform.position + transform.forward * maxDistance;
	}

	void spawnExplosion(Vector3 hitPosition, Transform target){
		Explosion tempExplosion = target.GetComponent<Explosion> ();
		if (!tempExplosion)
			print ("Es null");
		if (tempExplosion != null) {
			{

				tempExplosion.iveBeenHit (hitPosition);
				print ("dfas");
				tempExplosion.addForce (hitPosition, transform);
			}

		}
	}

	public void fireLaser(){
		Vector3 pos = castRay ();
		fireLaser (pos);
	}

	public void fireLaser(Vector3 targetPosition, Transform target=null){
		if (canFire) { 
			if(target!=null)
				spawnExplosion (targetPosition, target);
			
			lr.SetPosition (0, transform.position);
			lr.SetPosition (1, targetPosition);
			lr.enabled = true;
			laserLight.enabled = true;
			canFire = false;
			Invoke ("TurnOffLaser", laserOffTime);
			Invoke ("CanFire", fireDelay); 
		}

	}
	void TurnOffLaser(){
		lr.enabled = false;
		laserLight.enabled = false;
		//canFire = true;
	}

	public float Distance(){
		return maxDistance;
	}

	void CanFire(){
		canFire = true;
	}
}
