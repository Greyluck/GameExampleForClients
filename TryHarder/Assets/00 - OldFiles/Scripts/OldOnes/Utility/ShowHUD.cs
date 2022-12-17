using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowHUD : MonoBehaviour {

	public Text playerNameTxt;
	public Button btn_MainMenu;

	void Start () {
	
		//Guarda el nombre ingresado en el main
		string key = MainMenuCanvas.playerNameKey; 
		if (PlayerPrefs.HasKey (key)) {	playerNameTxt.text = PlayerPrefs.GetString (key);}
		else { playerNameTxt.text = "Melvin";}

		//Control de escenas (Botones)
		btn_MainMenu.onClick.AddListener (goMainScreen);
	}

	public void goMainScreen(){
		SceneManager.LoadScene ("MenuScreen"); //Carga la escena
	}

}
