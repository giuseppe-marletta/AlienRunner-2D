using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject enemy;

    

    private void Awake() {
        
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 8 )
        {
           target = other.gameObject; 
          
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.layer == 8) 
        {
            target = null;
        }
    }

}
