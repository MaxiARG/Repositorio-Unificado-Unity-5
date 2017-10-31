using UnityEngine;
using System.Collections;

public class GreenCube : MonoBehaviour { //Solo se autoagrega al event manager

	void OnEnable(){
		EventManager.onMyEvent += moveUp;

	}

	void OnDisable(){
		EventManager.onMyEvent -= moveUp;
	}

	void moveUp(bool dir){

		if (dir) {
			transform.position +=  transform.up;
		} else {
			transform.position -=  transform.up;
		}


		print("llamando");
	}
}
