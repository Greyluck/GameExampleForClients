using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

	private Rigidbody myRigidbody;

	public float movementSpeed;
	public float rotationSpeed;

	// Cuando van a tener un GetComponent en el Update() es mejor guardarse la referencia en una variable privada.
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();	
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			myRigidbody.velocity = transform.forward * Time.deltaTime * movementSpeed;
		}
		if (Input.GetKey (KeyCode.S)) {
			myRigidbody.velocity = transform.forward * Time.deltaTime * -movementSpeed;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime);		
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (Vector3.down * rotationSpeed * Time.deltaTime);		
		}
	}
}
