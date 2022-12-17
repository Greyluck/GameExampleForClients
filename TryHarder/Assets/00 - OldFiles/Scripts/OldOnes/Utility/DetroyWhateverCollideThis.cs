using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyWhateverCollideThis : MonoBehaviour {
	
	void OnCollisionEnter(Collision col){
		Debug.Log ("Gameobject con el que colisione: " + col.gameObject.name);
		Destroy (col.gameObject);
		Debug.Log ("El Gameobject que se destruyo: " + col.gameObject.name);

	}

}
