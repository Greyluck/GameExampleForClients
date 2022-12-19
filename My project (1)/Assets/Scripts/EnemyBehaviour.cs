using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D missile)
    {
        //this.killed.invoke();
        Destroy(this.gameObject);
    }

    //public System.Action killed;
}
