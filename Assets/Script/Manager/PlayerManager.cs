using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour, TakeableDamage<float>
{
    public static PlayerManager instance;
    [SerializeField] public float health;

    [SerializeField] Image[] heartsFull;

    [SerializeField] Image[] heartsEmpty;

    [SerializeField] GameObject player;

    [SerializeField] CanvasGroup GameOverScreen;



    float timer = 0;

    public float damageTime = 3; //subisci danni ogni 3 secondi

    [SerializeField] float invincibilityTime ; //invincibilità dopo aver subito danni per n secondi

    bool invincibility = false;

    private void Awake()
    {
        instance = this;
        for (int i = 0; i < health; i++)
            heartsEmpty[i].enabled = false;

    }

    public void StartTakeDamage(float damage)   //prendere danno 
    {
        if (invincibility == false)
        {
            health -= damage;
            heartsFull[(int)health].enabled = false;
            heartsEmpty[(int)health].enabled = true;
            if (health <= 0)
            {
              TakeGameOver();
            }
            StartCoroutine(Invulnerability());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

    }


    public void TakeDamage(float damage)   //conituare a prendere danno ogni 3 secondi se rimango attaccato al nemico
    {
        if (timer >= damageTime)
        {
            timer -= damageTime;
            health -= damage;
            heartsFull[(int)health].enabled = false;
            heartsEmpty[(int)health].enabled = true;
            if (health <= 0)
            {
                TakeGameOver();
            }
        }
        timer += Time.deltaTime;
    }

    public void StopTakeDamage()
    {
        timer = 0;
    }

    IEnumerator Invulnerability()   //gestione invulnerabilità temporanea
    {
        invincibility = true;
        yield return new WaitForSecondsRealtime(invincibilityTime);
        invincibility = false;
    }


    public void TakeGameOver()    //andare in  game over
    {
        player.SetActive(false);
        PointManager.instance.zeroPoints();
        Debug.Log("GAME OVER");
        GameOverScreen.alpha = 1;
        GameOverScreen.interactable = true;
        GameOverScreen.blocksRaycasts = true;
    }


}
