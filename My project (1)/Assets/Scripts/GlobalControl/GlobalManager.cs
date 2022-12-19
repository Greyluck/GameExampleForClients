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


	// This add value to the score.
	public static int addScore (){
		actualScore++;
		return actualScore;
	}

	public static int restLife (){
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




}
