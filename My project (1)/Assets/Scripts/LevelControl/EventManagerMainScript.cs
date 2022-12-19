using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerMainScript : MonoBehaviour
{
    public int destroyedEnemies = 0;

    private void Awake(){

        //TODO: //Whenever the delegated gets invoke the function will be executed
        //TODO: //Asteroid.killed += EnemyKilled;
    }

    private void EnemyKilled(){
        destroyedEnemies++;
        Debug.Log("The total number of enemies killed is " + destroyedEnemies);
    }

}
