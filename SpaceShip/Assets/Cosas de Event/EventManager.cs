using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {
	public delegate void someDelegate(bool dir); 	//declaracion del delegate
	public static someDelegate onMyEvent;			//variable del tipo someDelegate
	//ES ESTATICO PUEDO AGREGARLE FUNCIONES DESDE CUALQUIER LADO!!

	public static void myEvent(bool dir){ 	//esto los estoy llamando en _InputManager
		if (onMyEvent != null) {			// si tiene alguien suscripto, no returna null
			onMyEvent (dir); 				//si alguien se suscribio, los llama
		
		}
	}
}
