using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Transform playerTransform;
    [SerializeField] float speed;   
    [SerializeField] protected float strength;

    [SerializeField]  float attackSpeed = 4;
    [SerializeField]  float attackDistance;
    [SerializeField]  float bufferDistance;


    bool shouldMove = true;


    float t = 0;

    protected Animator anim;

    public float rayDist;

    public Transform groundDetect;

    private bool movingRight;

    public void Spawn(Transform spawnPoint)
    {
        transform.Spawn(spawnPoint);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }


    void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)  //nemico causa danno al player
    {
        if (other.gameObject.layer == 8)
        {
            PlayerManager.instance.StartTakeDamage(strength);


        }
    }

    private void OnTriggerStay2D(Collider2D other)  //alternativa vincente: ontriggerSTAY
    {
        if (other.gameObject.layer == 8)
        {
            PlayerManager.instance.TakeDamage(strength);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 8)
        {
            PlayerManager.instance.StopTakeDamage();

        }
    }



    private void OnCollisionEnter2D(Collision2D other)    //gestione animazioni e caduta del nemico
    {
        if (other.gameObject.layer == 8)
        {
            shouldMove = false;
            anim.SetBool("isWalk", false);
            PlayerManager.instance.TakeDamage(strength);
        }
        if (other.gameObject.tag == "PlatformDeath")
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        shouldMove = true;
        anim.SetBool("isWalk", true);
    }


    private void Update()
    {
        
        if (shouldMove)
        {
                transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
                RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist);   //raycast che gestisce il movimento del nemico all'interno della piattaforma
                if (groundCheck.collider == false)
                {
                    if (movingRight)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                } 
            

        }
    }
}