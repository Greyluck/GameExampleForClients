using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour {

	public 	GameObject theProjectile;
	private Transform theProjectilePos;
	public 	int Score;


	public float shootSpeed;

	void Start () {
		theProjectilePos = transform.Find ("ProjectilePos");
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject Bullet = Instantiate (theProjectile, theProjectilePos.position, Quaternion.identity);
			Bullet.GetComponent<Rigidbody> ().AddForce (transform.forward * shootSpeed);
		}
	}
}
