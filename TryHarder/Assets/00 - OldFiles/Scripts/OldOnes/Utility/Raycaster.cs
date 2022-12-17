using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour {

	private float width = 0;
	private float height = 0;

	private Vector2 from = Vector2.zero;
	private Vector2 to = Vector2.zero;

	public float bottomDistance = 1f;

	// CUANDO ESTA EN PLAY
	void Start(){
		width = transform.localScale.x;
		height = transform.localScale.y;
	}

	void Update(){
		CalculateVectors ();
		RaycastHit2D hit = Physics2D.Linecast(from, to);
		if (hit.collider != null) {
			//Debug.Log ("hit: " + hit.transform.name);
		}
	}

	void CalculateVectors()	{
		from = new Vector2 (transform.position.x +1 - width, transform.position.y - height);
		to =   new Vector2 (transform.position.x +1 - width, transform.position.y - height - bottomDistance);
	}

	/*----------------------------------------------------------------------------------------
	 * cuando se termina de probar y se sabe que anda bien, se comenta toda la función 
	 ----------------------------------------------------------------------------------------*/ 

	// CUANDO NO ESTA Y ESTA EN PLAY
	void OnDrawGizmosSelected() {
		width = transform.localScale.x;
		height = transform.localScale.y;

		CalculateVectors ();

		Gizmos.color = Color.red;
		Gizmos.DrawLine(from, to);
	}

}

