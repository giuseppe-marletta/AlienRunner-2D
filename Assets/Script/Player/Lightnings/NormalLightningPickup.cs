using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NormalLightningPickup : ShootingLightning
{
    
    private void Start() 
    {
        
        normalLightningLengthText.enabled = false;    
    }


    private void OnTriggerEnter2D(Collider2D other)  //comportamento del power up "fulmine normale" quando viene prese all'interno del livello 
    {
        if(other.gameObject.layer == 8) 
        {
            gameObject.SetActive(false);
            SendInformation(this);
            normalLightningLengthText.enabled = true;   
        }
    }
}
