using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavoiur : MonoBehaviour
{
    // variables 
    private float speed = 5.0f;
    
    // Start is called before the first frame update
    void Start (){
         Debug.Log("PlayerBehavoiur has started");
    }

    // Update is calles once per frame
    void Update (){
        // Movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * this.speed * Time.deltaTime; 
            Debug.Log("Moving left");
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * this.speed * Time.deltaTime; 
            Debug.Log("Moving right");
        }

        // Shoot
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)){
            Shoot();
        }

        // Reload
        if (Input.GetKey(KeyCode.R) || Input.GetMouseButtonDown(1)){
            Reload();
        }
    }

    private void Shoot(){
        Debug.Log("We Have Shoot!");
    }

    private void Reload(){
        Debug.Log("We Have Reloaded!");
    }
}
