using System.Collections;	
using System.Collections.Generic;
using UnityEngine;

public class Attack: MonoBehaviour {

	void OnCollisionEnter(Collision col){
		Debug.Log ("Impacte contra un gil");
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage ("TakeDamage");
			//CharaLife.TakeDamage (); //Para que funcione hay que hacer una funcion estatica
		}
	}

}
