using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 11 ) {}
          //  Debug.Log(other.tag);
    }

}
