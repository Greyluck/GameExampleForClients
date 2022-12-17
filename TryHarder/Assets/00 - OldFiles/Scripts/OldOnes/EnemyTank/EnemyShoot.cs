using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject theProjectile;
	private Transform theProjectilePos;

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
