using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.up;
    private float speed = 10;
    
    // Update (Always go up)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // This will trigger every time the proyectile colides with any item
    private void OnTriggerEnter2D (Collider2D other){
        Destroy(this.gameObject);
        Debug.Log("Bullet Destroyed");
    }
}
