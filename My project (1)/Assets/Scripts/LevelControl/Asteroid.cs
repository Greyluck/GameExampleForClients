using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.down;
    private float speed = 5;

    private GameObject lifeText;
	public int newLife = 0;
	public GameObject myCanvas;

	void Start(){
		//find the actual text where the score is showed
		lifeText = GameObject.Find ("Txt_Life");
		myCanvas = GameObject.Find ("Canvas");
	}

    // Update (Always go down)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // This is to make the asteroid dissapear
    private void OnTriggerEnter2D (Collider2D collider2D){
        if (collider2D.gameObject.tag == "Player")  {
			newLife = GlobalManager.restLife();
			lifeText.GetComponent<Text> ().text = "Life: " + newLife;
        }
        if (newLife == 0){
            //myCanvas.SendMessage("Lose");
		}
        Destroy(this.gameObject);
    }

}
