using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] Image key;

    [SerializeField] GameObject openDoor;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 8 &&  key.enabled == true)
        {
            gameObject.SetActive(false);
            openDoor.SetActive(true);
        }    
    }
}
