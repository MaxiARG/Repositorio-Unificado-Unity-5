using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class InputManager : MonoBehaviour {

	public Laser[] laser;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (Laser l in laser) {
				//Vector3 pos = transform.position + transform.forward * l.Distance(); print ("llamadoooo");
				l.fireLaser ();
			}
		}
	}
}
