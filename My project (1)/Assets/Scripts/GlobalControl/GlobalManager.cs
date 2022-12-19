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

	// This add value to the score.
	public static int addScore (){
		actualScore++;
		Debug.Log ("+1 score");
		return actualScore;
	}

	public static int restLife (){
		actualLife--;
		Debug.Log ("-1 life");
		return actualLife;
	}



}
