using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // Variables
    public Asteroid asteroidPrefab;
    private float asteroidDelay;
    
    public PowerMod powerUpPrefab1_Clean;
    public PowerMod powerUpPrefab2_Shield;
    public PowerMod powerUpPrefab3_Life;
    private PowerMod theChosenPrefab;

    
    private float powerUpDelay;

    // Start 
    void Start(){
        //This will start a loop that creates the asteroids.
        Invoke(nameof(AsteroidGeneratorMethod), 2);   
        Invoke(nameof( PowerUpGeneratorMethod), 1);   
    }

    private void AsteroidGeneratorMethod(){
        // Randomized the X position of the asteroid and then used it to determines where it will be created.
        float randomXPosition = Random.Range(-9.0f, 9.0f); 
        Vector3 finalCreationPosition = new Vector3 (randomXPosition, this.transform.position.y, 0);
    
        // Create the asteroid, set a new random wait for the nextone and start again the loop.
        Instantiate (this.asteroidPrefab, finalCreationPosition, Quaternion.identity);
        asteroidDelay = Random.Range(2.0f, 9.0f);
        Invoke(nameof(AsteroidGeneratorMethod), asteroidDelay);
        Debug.Log("Waiting " + asteroidDelay + " seconds until new asteroid");
    }

    private void PowerUpGeneratorMethod(){
        // Randomized the type of power up that will be send
        int theChosenValue = Random.Range(1,4);
        switch (theChosenValue){
        case 1:
            theChosenPrefab = powerUpPrefab1_Clean;
            break;
        case 2:
            theChosenPrefab = powerUpPrefab2_Shield;
            break;
        case 3:
            theChosenPrefab = powerUpPrefab3_Life;
            break;
        }

        // Randomized the X position of the power up and then used it to determines where it will be created.
        float randomXPosition = Random.Range(-9.0f, 9.0f); 
        Vector3 finalCreationPosition = new Vector3 (randomXPosition, this.transform.position.y, 0);
    
        // Create the power up, set a new random wait for the nextone and start again the loop.
        Instantiate (this.theChosenPrefab, finalCreationPosition, Quaternion.identity);
        powerUpDelay = Random.Range(1.0f, 2.0f);
        Invoke(nameof(PowerUpGeneratorMethod), powerUpDelay);
        Debug.Log("Waiting " + powerUpDelay + " seconds until new PowerUp");
    }

    

}
