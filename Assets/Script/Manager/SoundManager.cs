using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour       //gestione di tutti i suoni 
{
    public static SoundManager instance;
    private AudioSource musicSource, enemySource , playerSource , itemSource;
    [SerializeField] AudioClip soundTrack, lightningLaunches , hitLightning , jumpPlayer;  


    private void Awake() 
    {
        instance = this ;
    }

    private void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = SaveGame.GetMusic();
        musicSource.clip = soundTrack;
        musicSource.Play();


        enemySource = gameObject.AddComponent<AudioSource>();
        enemySource.volume = SaveGame.GetSound();

        playerSource = gameObject.AddComponent<AudioSource>();
        playerSource.volume =  SaveGame.GetSound();

        itemSource = gameObject.AddComponent<AudioSource>();  
        itemSource.volume = SaveGame.GetSound();
    }

    public void PlayLightningLaunches() 
    {
        playerSource.clip = lightningLaunches;
        playerSource.Play();
    }

    public void PlayJumpPlayer()
    {
        playerSource.clip = jumpPlayer;
        playerSource.Play();
    }

    public void PlayHitLightning() 
    {
        enemySource.clip = hitLightning;
        enemySource.Play();
    }
}
