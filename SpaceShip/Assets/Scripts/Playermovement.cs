using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {

	public float movementSpeed=30f;
	public float turnSpeed=55f;
	public Transform myT;
	public Thruster [] thruster;

	void Awake(){
		myT = transform;
	}
	void Update () {
		turn ();
		thrust ();
	}

	void turn(){
		transform.Rotate (turnSpeed * Time.deltaTime * Input.GetAxis ("Pitch"), turnSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"), turnSpeed * Time.deltaTime * Input.GetAxis ("Roll"));
	

	}

	void thrust(){
		if(Input.GetAxis("Vertical")>0)
		myT.position += myT.forward *movementSpeed * Time.deltaTime * Input.GetAxis ("Vertical");

		if (Input.GetKey (KeyCode.W)) {
			foreach (Thruster t in thruster) {
				t.activate ();
			}
			
		} else {
			if (Input.GetKeyUp (KeyCode.W)) {
				foreach (Thruster t in thruster) {
					t.activate (false);
				}
				
			}
		}
	}
}
