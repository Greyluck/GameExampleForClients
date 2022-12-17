using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


	public static int actualScore = 0;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {	
	}

	public static int addScore (){
		actualScore++;
		Debug.Log ("se aumento el score en 1");
		return actualScore;
	
	}




}
