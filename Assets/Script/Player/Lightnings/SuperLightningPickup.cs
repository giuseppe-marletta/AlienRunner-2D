using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperLightningPickup : ShootingLightning
{
    private void Awake() 
    {
        superLightningLengthText.enabled = false;    
    }
    private void Start() 
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)  //comportamento del power up super fulmine quando viene preso all'interno del livello 
    {
        if(other.gameObject.layer == 8) 
        {
            gameObject.SetActive(false);
            SendInformation(this);
            superLightningLengthText.enabled = true;   
        }
            

    }
    
}
