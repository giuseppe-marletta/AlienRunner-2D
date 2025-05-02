using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour  //movimento del player 
{
    [SerializeField] float speed;

    protected Animator animPlayer;


    bool allowMove = true;

    public int Control = 0;

    string controls;

    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
    }

    private void Start() {
       
    }


    void Update()  //comandi di movimento
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            animPlayer.SetBool("isWalkPlayer", true);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0 )
        {
            transform.Translate(Vector2.left * -speed * Time.deltaTime, Space.Self);
            animPlayer.SetBool("isWalkPlayer", true);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animPlayer.SetBool("isWalkPlayer", false);
        }
    }

}
