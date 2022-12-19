using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillScore : MonoBehaviour {

	private GameObject thisGameObject;

	private GameObject scoreText;
	public int newScore;
	public GameObject myCanvas;
	public int winScore = 10;

	void Start(){
		//find the actual score.
		scoreText = GameObject.Find ("Txt_Score");
		myCanvas = GameObject.Find ("Canvas");
		thisGameObject = transform.gameObject;

	}

	void OnCollisionEnter(Collision col){
		//Debug.Log ("Impacte contra " + col.gameObject.name);
		if (col.gameObject.tag == "Enemy")  {
			newScore = ScoreManager.addScore();
			scoreText.GetComponent<Text> ().text = "Score: " + newScore;
			Destroy (col.gameObject);
			if (newScore == winScore){
				CharaWin ();
			}
				
		}
		Destroy (thisGameObject);
	}

	void OnDestroy(){
		Debug.Log ("Explotar");

	}

	void CharaWin (){
		myCanvas.SendMessage("Win");
	}
}
