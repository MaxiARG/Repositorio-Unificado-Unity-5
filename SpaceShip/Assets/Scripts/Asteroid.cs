using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	public float maxScale=2.5f;
	public float minScale=1f;
	float rotationLimit=100f;

	Vector3 scale;
	Vector3 rotation;
	Transform myT;

	void Awake(){
		myT = transform;
	}


	// Use this for initialization
	void Start () {
		scale = Vector3.one;
		scale.x = Random.Range (minScale, maxScale);
		scale.y = Random.Range (minScale, maxScale);
		scale.z = Random.Range (minScale, maxScale);

		myT.localScale = scale;

		rotation.x = Random.Range (-rotationLimit, rotationLimit);
		rotation.y = Random.Range (-rotationLimit, rotationLimit);
		rotation.z = Random.Range (-rotationLimit, rotationLimit);

	}
	
	// Update is called once per frame
	void Update () {
		myT.Rotate (rotation * Time.deltaTime);
	}



}
