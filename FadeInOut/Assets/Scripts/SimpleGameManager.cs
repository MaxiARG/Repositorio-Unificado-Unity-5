using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleGameManager : MonoBehaviour {

	public static SimpleGameManager Instance=null;
	string scene1="Escena1";
	string scene2="EScena2";
	string targetScene;
	CanvasGroup canvasGroup;
	public float transitionSmoothTime=0.1f;

	void Awake () {
		
		if (Instance == null) { 
			Instance = this;
			canvasGroup = GetComponent<CanvasGroup> ();
		}
		 else if (Instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		SceneManager.sceneLoaded += EscenaCargada; //es un metodo, como un evento.
	}

	void OnQuit(){
		SceneManager.sceneLoaded -= EscenaCargada;
	}

	void EscenaCargada(Scene s, LoadSceneMode lsm){
		
	}

	void Update () {
		inputCheck ();
	}


    void transitionToScene(string sceneName){
        if (SceneManager.GetActiveScene().name == sceneName)
            return;
        targetScene = sceneName;
        StopCoroutine("TransitionWithAlpha");
        StartCoroutine("TransitionWithAlpha", 1);
    }

    IEnumerator TransitionWithAlpha(float targetAlpha)
    {
        float diff = Mathf.Abs(canvasGroup.alpha - targetAlpha);
        float transitionRate = 0;

        while(diff > 0.025f)
        {
            canvasGroup.alpha = Mathf.SmoothDamp(canvasGroup.alpha,
                targetAlpha, ref transitionRate,
                transitionSmoothTime);
            diff = Mathf.Abs(canvasGroup.alpha - targetAlpha);
            yield return new WaitForSeconds(Time.deltaTime);
        }
		canvasGroup.alpha = targetAlpha;
		if (targetAlpha == 1) {
			StartCoroutine ("miLoadScene");
		}
	}

	IEnumerator miLoadScene(){
		SceneManager.LoadScene (targetScene);
		string activeScene = SceneManager.GetActiveScene ().name;

		while (activeScene != targetScene) {
			activeScene = SceneManager.GetActiveScene ().name;
			yield return new WaitForSeconds (Time.deltaTime);
		}
		StartCoroutine ("TransitionWithAlpha", 0);

	}

	public void loadPrimerNivel(){
		transitionToScene ("Escena1");
	}
	public void salir(){
		Application.Quit ();
	}

	void inputCheck(){
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if(!SceneManager.GetActiveScene().name.Equals("MenuPrincipal"))
			transitionToScene(scene2);
		}

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(!SceneManager.GetActiveScene().name.Equals("MenuPrincipal"))
			transitionToScene(scene1);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			transitionToScene("MenuPrincipal");
		}


	}
}

