using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuInGame : MonoBehaviour {

	bool pause = false;

	public GameObject myPauseMenu;
	public GameObject myDeadMenu;
	public GameObject myWinMenu;

	public Button btnOpenMenu;
	public Button btnBackToGame;

	public Button btnQuitGame;

	public Button btnRestart;
	public Button btnRestart2;

	void Start(){
		Time.timeScale = 1;
		btnOpenMenu.onClick.AddListener (OpenMenu);//Esta atento a que se aprete el boton
		btnBackToGame.onClick.AddListener (OpenMenu);//Esta atento a que se aprete el boton
		btnQuitGame.onClick.AddListener (Application.Quit);
		btnRestart.onClick.AddListener (ReturnToMainMenu);//Esta atento a que se aprete el boton
		btnRestart2.onClick.AddListener (ReturnToMainMenu);//Esta atento a que se aprete el boton
	}

	void ReturnToMainMenu(){
		SceneManager.LoadScene ("MenuScreen");
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P))
			OpenMenu ();
	}

	//(pause == false) ? (Time.timeScale = 0) : (Time.timeScale = 1);
	void OpenMenu () {
		myPauseMenu.SetActive(!pause);
		if (pause == false)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
		pause = !pause;
	}

	void Win(){
		myWinMenu.SetActive (true);
		Time.timeScale = 0;
	}

}
