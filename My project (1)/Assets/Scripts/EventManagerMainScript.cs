using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerMainScript : MonoBehaviour
{
    public int destroyedEnemies = 0;

    private void Awake(){

        //Whenever the delegated gets invoket the function will be executed
        //Asteroid.killed += EnemyKilled;
    }

    private void EnemyKilled(){
        destroyedEnemies++;
        Debug.Log("The total number of enemies killed is " + destroyedEnemies);
    }

}
