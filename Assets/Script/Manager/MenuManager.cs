using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider, musicSlider;
    [SerializeField] Dropdown resolution;

    [SerializeField] Dropdown controls;


    private void Awake()
    {
        soundSlider.value = SaveGame.GetSound();
        musicSlider.value = SaveGame.GetMusic();
        resolution.value = SaveGame.GetResolution();
        controls.value = SaveGame.GetControls();
    }

    public void PlayNewGame(int i)   //caricamento partita
    {
        SceneManager.LoadScene(i);
        AsyncOperation op = SceneManager.LoadSceneAsync(i); //schermata di caricamento

    }

    public void PlayNewGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SaveSoundVolume()     //salvare il sound
    {
        SaveGame.SaveSoundVolume(soundSlider.value);
    }

    public void SaveMusicVolume()  //salvare la musica
    {
        SaveGame.SaveMusicVolume(musicSlider.value);
    }

    public void SaveResolution()  // salvare la risoluzione
    {
        switch (resolution.value)
        {
            case 0:
                Screen.SetResolution(800, 600, true);
                SaveGame.SaveResolution(0);
                break;
            case 1:
                Screen.SetResolution(1024, 768, true);
                SaveGame.SaveResolution(1);
                break;
            case 2:
                Screen.SetResolution(1280, 720, true);
                SaveGame.SaveResolution(2);
                break;
            case 3:
                Screen.SetResolution(1440, 900, true);
                SaveGame.SaveResolution(3);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, true);
                SaveGame.SaveResolution(4);
                break;
        }

        //SaveGame.SaveResolution(resolution.value,)    
    }

    public void SaveControls()  //salvare il set di comandi
    {
        switch (controls.value)
        {
            case 0:
                SaveGame.SaveControls(0);
                break;
            case 1:
                SaveGame.SaveControls(1);
                break;
        }
    }

    public void Exit() //uscire dal gioco
    {
        Application.Quit();
    }
}
