using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.down;
    private float speed = 5;
    
    // Update (Always go down)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // This is to make the asteroid dissapear
    private void OnTriggerEnter2D (Collider2D collider2D){
        //this.killed.invoke();
        Destroy(this.gameObject);
    }

}
