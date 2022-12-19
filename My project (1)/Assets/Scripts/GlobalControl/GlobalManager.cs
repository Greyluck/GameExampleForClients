using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour {

	// It creates the public value of the score and the text to be used
	public static int actualScore = 0;
	private GameObject scoreText;

	public static int actualLife = 3;
	private GameObject lifeText;

	public static int actualAmmo = 15;
	private GameObject ammoText;

	public static bool shield = false;
	public static bool nausea = false;
	
	// This add value to the score.
	public static int addScore (){
		actualScore++;
		return actualScore;
	}

	public static int restLife (){
		actualLife--;
		return actualLife;
	}

	public static int rest2Life (){
		actualLife -= 2;
		return actualLife;
	}

	public static int addLife (){
		actualLife--;
		return actualLife;
	}

	public static int restAmmo (){
		actualAmmo--;
		return actualAmmo;
	}

	public static int reloadAmmo (int bullets){
		actualAmmo=bullets;
		return actualAmmo;
	}

	public static bool activateShield (){
		//TODO: Do something
		return shield;
	}
	
	public static bool activateNausea (){
		//TODO: Do something
		return  nausea;
	}




}
