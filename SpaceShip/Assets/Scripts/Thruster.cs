using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(TrailRenderer))]
public class Thruster : MonoBehaviour {
	TrailRenderer tr;
	Light thrusterLight;


	void Awake () {
		tr = GetComponent<TrailRenderer> ();
		thrusterLight = GetComponent<Light> ();
	}

	public void activate(bool activate=true){
		if (activate) {
			tr.enabled = true;
			thrusterLight.enabled = true;
		} else {
			tr.enabled = false;
			thrusterLight.enabled = false;
		}
	}
}
