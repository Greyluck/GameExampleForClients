using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorruptCommet: MonoBehaviour
{
    // This is to make the asteroid dissapear
    private void OnTriggerEnter2D (Collider2D collider2D){
        Destroy(this.gameObject);
    }

}
