using UnityEngine;
using System.Collections;

public class _InputManager : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			EventManager.myEvent(true);
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			EventManager.myEvent(false);
		}
	}
}
