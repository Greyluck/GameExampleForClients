using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMissiles : MonoBehaviour {

	public GameObject missile;

	void Start () {
		InvokeRepeating ("CreateMissile", 0.5f, 1.0f);
	}

	void CreateMissile()
	{
		Vector3 pos = new Vector3 ();
		pos.x = Random.Range (-10f, 10f);
		pos.y = 10;
		pos.z = Random.Range (-10f, 10f);
		Instantiate (missile, pos, Quaternion.identity);
	}
}
