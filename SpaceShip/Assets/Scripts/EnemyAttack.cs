using UnityEngine;
using System.Collections;


public class EnemyAttack : MonoBehaviour {
	public Transform target;
	public Laser laser;
	Vector3 hitPosition;

	void Update(){
		inFront ();
		haveLineOfSightRayCast ();

		if (haveLineOfSightRayCast () && inFront ()) {
			print ("Fire Laser!!!!");
		}
	}

	bool inFront( ){

		Vector3 directionToTarget = transform.position - target.position;
		float angle = Vector3.Angle (transform.forward, directionToTarget);
		if(Mathf.Abs(angle)>90 && Mathf.Abs(angle)<270){
		//	Debug.DrawLine(transform.position,target.position, Color.green); 
			return true;
		}
	//	Debug.DrawLine(transform.position,target.position, Color.cyan); 
		return false;
	}

	bool haveLineOfSightRayCast(){
		RaycastHit hit;
		Vector3 direction = target.position - transform.position;
		//Debug.DrawRay (laser.transform.position, direction, Color.blue);
		if(Physics.Raycast(laser.transform.position,direction,out hit)){
			if (hit.transform.CompareTag("Player")) { 
				hitPosition = hit.transform.position;
				fireLaser ();
				return true; 
			}

		}
		return false;
	}

	void fireLaser(){
		laser.fireLaser (hitPosition, target);
	}
}
