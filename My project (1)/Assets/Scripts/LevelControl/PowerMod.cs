using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMod : MonoBehaviour
{
    // Variables
    private Vector3 direction = Vector2.down;
    private float speed = 4;

    // Update (Always go down)
    void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

}
