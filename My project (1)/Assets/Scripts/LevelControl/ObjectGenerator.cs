using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Variables
    public Asteroid asteroidPrefab;
    private float asteroidDelay;
    
    // Start 
    void Start(){
        //This will start a loop that creates the asteroids.
        Invoke(nameof(AsteroidGeneratorMethod), 2);         
    }

    private void AsteroidGeneratorMethod(){
        // Randomized the X position of the asteroid and then used it to determines where it will be created.
        float asteroidRandomXPosition = Random.Range(-9.0f, 9.0f); 
        Vector3 asteroidCreationPosition = new Vector3 (asteroidRandomXPosition, this.transform.position.y, 0);
    
        // Create the asteroid, set a new random wait for the nextone and start again the loop.
        Instantiate (this.asteroidPrefab, asteroidCreationPosition, Quaternion.identity);
        asteroidDelay = Random.Range(2.0f, 9.0f);
        Invoke(nameof(AsteroidGeneratorMethod), asteroidDelay);
        Debug.Log("Waiting " + asteroidDelay + "seconds until new asteroid");
    }

}
