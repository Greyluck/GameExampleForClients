using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCollideWithPlayer : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		//Debug.Log ("Impacte contra: " + col.gameObject.name);
		if (col.gameObject.name == "Player")
		{
			Destroy (this.gameObject);
			//Debug.Log ("Me destruyo por culpa de: " + col.gameObject.name);
		}
		
	}
}
