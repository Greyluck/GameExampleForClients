using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootExplotion : MonoBehaviour {

	public float radius;
	public float explosionForce;

	public GameObject explosion;

	void OnDestroy () {
		Instantiate (explosion, transform.position, Quaternion.identity);
	}
}
