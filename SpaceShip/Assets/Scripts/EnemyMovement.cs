using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public Transform target;
	public float speed = 10f;
	public float rotationalDamp=.5f;
	public float _rayCastOffset=2.5f;
	public float detectionDistance=20f;
	public float deleteMe = 4f;

	void Update(){
		
		pathFinding ();
		move ();

	}
	void turn(){
		Vector3 pos = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation (pos);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*rotationalDamp);
	}

	void move(){
		transform.position += transform.forward * Time.deltaTime * speed;
	}

	void pathFinding(){
		Vector3 rayCastOffset = Vector3.zero;

		Vector3 left = transform.position - transform.right * _rayCastOffset;
		Vector3 right= transform.position + transform.right * _rayCastOffset;
		Vector3 up= transform.position - transform.up * _rayCastOffset;
		Vector3 down= transform.position + transform.up * _rayCastOffset;

	//	Debug.DrawRay (transform.position, transform.forward*detectionDistance, Color.cyan);
		//Debug.DrawRay (transform.position, transform.up * 5,Color.blue);
	//	Debug.DrawRay (transform.position, transform.up *-5,Color.blue);
	//	Debug.DrawRay (transform.position, transform.right * 5,Color.blue);
	//	Debug.DrawRay (transform.position, transform.right *-5,Color.blue);

		Debug.DrawRay (left,transform.forward*detectionDistance,Color.cyan);
		Debug.DrawRay (right,transform.forward*detectionDistance,Color.cyan);
		//Debug.DrawRay (transform.position + transform.up * rayCastOffset, transform.forward * detectionDistance);
		//Debug.DrawRay (transform.position+transform.up*-rayCastOffset,transform.forward*detectionDistance,Color.cyan);
		Debug.DrawRay (up, transform.forward * detectionDistance);
		Debug.DrawRay (down, transform.forward * detectionDistance);
		RaycastHit hit;

		if (Physics.Raycast (left, transform.forward, out hit, detectionDistance)) {
			rayCastOffset += Vector3.right;
		}else
		if (Physics.Raycast (right, transform.forward, out hit, detectionDistance)) {
				rayCastOffset -= Vector3.right;
		}

		if (Physics.Raycast (up, transform.forward, out hit, detectionDistance)) {
			rayCastOffset -= Vector3.up;
		}else
			if (Physics.Raycast (down, transform.forward, out hit, detectionDistance)) {
				rayCastOffset += Vector3.up;
			}

		if (rayCastOffset != Vector3.zero) {
			transform.Rotate (rayCastOffset *150f * Time.deltaTime);
		} else {
			turn ();
		}
	}

	}
