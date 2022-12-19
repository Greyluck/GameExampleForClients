using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCommet: MonoBehaviour
{
    // Variables
    private GameObject lifeText;
	public int newLife = 0;
	public GameObject myCanvas;

	void Start(){
		lifeText = GameObject.Find ("Txt_Life");
		myCanvas = GameObject.Find ("Canvas");
	}

    // This is to make the asteroid dissapear and hwal
    private void OnTriggerEnter2D (Collider2D collider2D){
        if (collider2D.gameObject.tag == "Player")  {
			newLife = GlobalManager.addLife();
			lifeText.GetComponent<Text> ().text = "Life: " + newLife;
        }
        if (newLife < 1){
            //myCanvas.SendMessage("Lose");
		}
        Destroy(this.gameObject);
    }

}
