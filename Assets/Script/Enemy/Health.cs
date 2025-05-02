using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IKillable<int>
{
    [SerializeField] int points;

    [SerializeField] float maxHealth;

    [SerializeField] Image lifeBar;

    [SerializeField] ParticleSystem ParticleDeath;

    private float health; 

    private void OnEnable()
    {
        health = maxHealth;    
    }

    public void Hit(int damage)    //gestione del colpo subito dal nemico
    {
        Debug.Log("Hit");
        SoundManager.instance.PlayHitLightning();
        health -= damage;
        float fill = health / maxHealth;
        lifeBar.fillAmount = fill;
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill() //gestione della morte del nemico
    {
        PointManager.instance.AddPoints(points);
        ParticleDeath.Play();
        gameObject.SetActive(false);
        
    }
}
