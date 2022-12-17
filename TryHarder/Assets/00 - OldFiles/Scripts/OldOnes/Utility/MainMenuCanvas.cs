using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour {

	public Button btnStart;
	public Text playerInputField;

	public static string playerNameKey = "PlayerName";

	void Awake(){
		if (PlayerPrefs.HasKey (playerNameKey)) 
		{	Debug.Log ("Value: " + PlayerPrefs.GetString (playerNameKey));	} 
		else 
		{	Debug.Log ("No hay key: " + playerNameKey);		}
	}

	void Start(){
		btnStart.onClick.AddListener (OnStartGame);//Esta atento a que se aprete el boton
	}

	public void OnStartGame()	{
		// El usuario ingreaso al menos una letra.
		if (playerInputField.text.Length != 0)	{	PlayerPrefs.SetString (playerNameKey, playerInputField.text);	}
		SceneManager.LoadScene ("Level01"); //Carga la escena
	}

	// Estos estas desde el inspector
	public void OnDeleteKey(string key)	{	PlayerPrefs.DeleteKey (key);	}
	public void OnDeleteAll()			{	PlayerPrefs.DeleteAll ();		}
}
