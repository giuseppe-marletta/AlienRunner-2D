using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    Animator animPlayerHurt;

    [SerializeField] Image key;

    [SerializeField] CanvasGroup WinScreen;

    private void Awake() 
    {
        animPlayerHurt = GetComponent<Animator>();    
    }
    
    private void OnCollisionEnter2D(Collision2D other)     //gestione animazioni quando il player viene colpito
    {
        if(other.gameObject.layer == 11 )
        {
            animPlayerHurt.SetBool("Hurt",true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.layer == 11)
        {
            animPlayerHurt.SetBool("Hurt",false);
        }    
    } 

    private void OnTriggerEnter2D(Collider2D other)     //i comportamenti che deve avere il player in base a cosa va incontro:
    {
        if(other.gameObject.layer == 16 && key.enabled == true)     //bandiera fine livello 
        {
            gameObject.SetActive(false);
            GuiManager.instance.stopTimer();
            Debug.Log("WIN!");
            WinScreen.alpha = 1;
            WinScreen.blocksRaycasts = true;
            WinScreen.interactable = true;
        }
        else if(other.gameObject.layer == 17)     //power up 
        {
            GetComponent<PlayerShoot>().StartCoroutine("AllowNormalShoot");
            GetComponent<PlayerShoot>().StopCoroutine("AllowSuperShoot");
            GetComponent<ShootingLightning>().DisableSuperLightningHUD();

        }
        else if(other.gameObject.layer == 20) //power up super 
        {
            GetComponent<PlayerShoot>().StartCoroutine("AllowSuperShoot");
            GetComponent<PlayerShoot>().StopCoroutine("AllowNormalShoot");
            GetComponent<ShootingLightning>().DisableNormalLightningHUD();


        }
        else if(other.gameObject.layer == 16 && key.enabled == false)   //bandiera ma senza la chiave 
        {
            animPlayerHurt.SetBool("Hurt",true);
        } 
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer == 16)
        {
            animPlayerHurt.SetBool("Hurt",false);
        }   
    }

    
    
}
