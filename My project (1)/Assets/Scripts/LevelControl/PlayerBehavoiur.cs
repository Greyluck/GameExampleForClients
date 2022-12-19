using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class manages the movement, shooting and reloading of the player
public class PlayerBehavoiur : MonoBehaviour
{
    // variables 
    private float characterSpeed = 5.0f;
    
    public Proyectile bulletPrefab;
    private int bulletInStash = 15;
    
    
    // Start is called before the first frame update
    void Start (){
         Debug.Log("PlayerBehavoiur has started");
    }

    // Update is calles once per frame
    void Update (){
        // Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * this.characterSpeed * Time.deltaTime; 
            Debug.Log("Moving left");
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * this.characterSpeed * Time.deltaTime; 
            Debug.Log("Moving right");
        }

        // Shoot
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)){
            if (bulletInStash>0){
                bulletInStash--;
                Shoot();
            } else {
                Debug.Log("NO AMMO! Reload needed!");
            }   
        }

        // Reload
        if (Input.GetKey(KeyCode.R) || Input.GetMouseButtonDown(1)){
            Reload();
        }
    }

    private void Shoot(){
        Instantiate (this.bulletPrefab, this.transform.position, Quaternion.identity);
        Debug.Log("We Have Shoot! - " + bulletInStash + " bullets remaining" );
    }

    private void Reload(){
        bulletInStash=15;
        Debug.Log("We Have Reloaded! We have " + bulletInStash + " now");
        
    }
}
