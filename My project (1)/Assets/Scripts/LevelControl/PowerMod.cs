using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMod : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.down;
    private float speed = 4;

    //Type of Power Up/Down
    public int typeOfMod;
    /*
    --------- UP ---------
    1 Limpiador (UP):
    2 Invencibilidad (Up)
    3 Curador (UP)
    --------- DOWN ---------
    4 Descontrol (Down)
    5 Aniquilador (Down)
    */
    
    // Update (Always go down)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    // This is to make the asteroid dissapear
    private void OnTriggerEnter2D (Collider2D collider2D){
        Destroy(this.gameObject);
    }

}
