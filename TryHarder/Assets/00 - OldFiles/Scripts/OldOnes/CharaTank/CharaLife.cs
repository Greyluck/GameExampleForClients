using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CharaLife : MonoBehaviour {

	int life = 100;
	GameObject lifeBar;	//Declara cual sera la barra de vida
	GameObject lifeText; //Declara cual sera el texto sobre la barra de vida

	public GameObject myDeadMenu;

	// Use this for initialization
	void Start () {
		lifeText = GameObject.Find ("Txt_LifeBarText");	
		lifeBar = GameObject.Find ("Sld_LifeBar");//Barra vida

		myDeadMenu.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	}

	//Hcerse daño
	void TakeDamage (){			// el dmg NO deberia estar harcodeado, deberia recibirlo del bicho que le pega.
		life-=10;	
		lifeText.GetComponent<Text> ().text = life + "" ;
		lifeBar.GetComponent<Slider> ().value = life; //Barra de vida
		if (life<=0){CharaDeath();
		}
	}

	//Morir
	void CharaDeath (){	
		Time.timeScale = 0;
		myDeadMenu.SetActive(true);
	}

}
