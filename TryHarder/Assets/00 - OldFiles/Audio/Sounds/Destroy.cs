﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	public GameObject theDestroyedObject;

	void Start () {
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player")
		{	
			Destroy (theDestroyedObject);
		}



	}//End Collision

}
