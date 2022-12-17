using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	public 	GameObject[] patrolPoints;	//El array de puntos
	private Vector3 actualDestination; 	//Lugar seteados
	private NavMeshAgent agent;			//El objeto que se movera


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		//Busca los puntos para llenar el array
		patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");

	}

	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance <= 1){
			SetRandomDestination ();
		}
	}

	void SetRandomDestination (){
		actualDestination = patrolPoints [Random.Range(0,patrolPoints.Length)].transform.position; //Deberia ser un vector3
		agent.SetDestination (actualDestination);
	}



}
