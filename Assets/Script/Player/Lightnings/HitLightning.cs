using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLightning : MonoBehaviour
{
    int damage;

    public void SetLightningType(int damageAmount)
    {
        damage = damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)   //il comportamento del fulmine quando colpisce un nemico e cosa ciò comporta
    {
        if (other.gameObject.layer == 11  ) 
        {
            Debug.Log("hit");
            other.GetComponent<Health>().Hit(damage);
            gameObject.SetActive(false);
        } 
        else if ( other.gameObject.layer == 9)
        {
            gameObject.SetActive(false);
        }
         
    }

    private void OnBecameInvisible() {
        gameObject.SetActive(false);
    }

}
