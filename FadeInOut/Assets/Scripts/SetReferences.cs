using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//-------------------------------------------------------------------------------------------------------------------
//Esta clase sirve para bindear at runtime los botones con los metodos del objeto que persiste al cambiar de escena
//-------------------------------------------------------------------------------------------------------------------
// Podria crear un enum con las diferentes opciones del menu, cada opcion iria de 0-N, que lo haria corresponder con el indice de la escena. Probar..
public class SetReferences : MonoBehaviour {

	SimpleGameManager ss;
	void Start () {
		GameObject sceneStateGO = GameObject.FindWithTag ("GameController");
		if (sceneStateGO) {
			ss = sceneStateGO.GetComponent<SimpleGameManager> ();
			if (ss != null) {
				print ("No null");
				Button b = gameObject.GetComponent<Button>();
				if (b) {
					if(gameObject.name.Equals("salir"))
						b.onClick.AddListener (ss.salir);

					if(gameObject.name.Equals("loadPrimerNivel"))
						b.onClick.AddListener (ss.loadPrimerNivel);
				}
			}

		}

	}
}
