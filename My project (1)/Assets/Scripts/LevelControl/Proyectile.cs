using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Proyectile : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.up;
    private float speed = 10;
    
	private GameObject scoreText;
	public int newScore = 0;
	public GameObject myCanvas;
	public int winScore = 10;

	void Start(){
		//find the actual text where the score is showed
		scoreText = GameObject.Find ("Txt_Score");
		myCanvas = GameObject.Find ("Canvas");
	}

    // Update (Always go up)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // This will trigger every time the proyectile colides with any item
    private void OnTriggerEnter2D (Collider2D collider2D){
        if (collider2D.gameObject.tag == "Asteroid")  {
			newScore = GlobalManager.addScore();
			scoreText.GetComponent<Text> ().text = "Score: " + newScore;
        }
        if (newScore == winScore){
            //myCanvas.SendMessage("Win");
		}
        Destroy(this.gameObject);
    }
}

