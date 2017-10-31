using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform target;
	public Vector3 defaultDistance = new Vector3 (0f, 2f, -10f);
	public float distanceDamp=37f;
	public float rotationalDamp=10f;
	public Vector3 velocity= Vector3.one *3;
	Transform myT;

	// Use this for initialization
	void Awake () {
		myT = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		followTarget2 ();
	
	}
	void followTarget2(){
		
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.SmoothDamp (myT.position, toPos, ref velocity,0.4f, distanceDamp);
		myT.position = curPos;

		myT.LookAt (target, target.up);
	}

	void followTargetOld(){
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.Lerp (myT.position, toPos, distanceDamp * Time.deltaTime);
		myT.position = curPos;

		Quaternion toRot = Quaternion.LookRotation (target.position - myT.position, target.up);
		Quaternion curRot = Quaternion.Slerp (myT.rotation, toRot, rotationalDamp * Time.deltaTime);
		myT.rotation = curRot;
	}
}
