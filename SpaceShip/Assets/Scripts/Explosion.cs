using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour {
	public GameObject explosion;
	public Rigidbody rigidBody;
	public float laserHitModifier = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void iveBeenHit(Vector3 pos){
		GameObject go = Instantiate (explosion, pos, Quaternion.identity) as GameObject;

		Destroy (go, 6f);

	}
	void OnCollisionEnter(Collision col){
		foreach (ContactPoint t in col.contacts) {
			iveBeenHit (t.point);
		
		}
	}

	public void addForce(Vector3 hitPosition, Transform hitSource){
		Debug.Log ("LLAMADO");
		if (rigidBody == null) {
			print ("Es null");
			return;

		}
		Debug.Log ("NO ES NULL");
		Vector3 direction = hitSource.position - transform.position;
		rigidBody.AddForceAtPosition(direction.normalized * laserHitModifier, hitPosition, ForceMode.Impulse);
	}
}
