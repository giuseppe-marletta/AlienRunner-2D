using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    [SerializeField] Image keyFull;
    [SerializeField] Image keyEmpty;


    private void Start() 
    {
        keyFull.enabled = false;
        keyEmpty.enabled = true;    
    }

    private void OnTriggerEnter2D(Collider2D other)  //chiave all'interno del livello 
    {
        if(other.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
            keyFull.enabled = true;
            keyEmpty.enabled = false;
        }    
    }
}
