using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour {

	// It creates the public value of the score and the text to be used
	public static int actualScore = 0;
	private GameObject scoreText;

	// This add value to the score.
	public static int addScore (){
		actualScore++;
		Debug.Log ("se aumento el score en 1");
		return actualScore;
	}




}
