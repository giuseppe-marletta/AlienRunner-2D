using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour  //salto del player
{

    bool onFloor;

    Animator animPlayer;

   

    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
    }

    private void Start()
    {
        onFloor = true;
    }

    void OnCollisionEnter2D(Collision2D collision)   //comportamenti annessi alle varie animazioni 
    {
        if (collision.gameObject.tag == "Enemy")
        {
            animPlayer.SetBool("Grounded", true);

        }
        if (collision.gameObject.tag == "PlatformDeath")
        {
            animPlayer.SetBool("Hurt", true);
            PlayerManager.instance.TakeGameOver();
        }
        if (collision.gameObject.tag == "Enemy")
        {

            animPlayer.SetBool("Hurt", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            onFloor = true;
            animPlayer.SetBool("Grounded", true);
        }
    }
    private void Update()   //comando del salto 
    {
            if (Input.GetKeyDown(KeyCode.Space) && onFloor == true )
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 115), ForceMode2D.Impulse);
                SoundManager.instance.PlayJumpPlayer();
                onFloor = false;
                animPlayer.SetBool("Grounded", false);
            }
           
    }

    


}
