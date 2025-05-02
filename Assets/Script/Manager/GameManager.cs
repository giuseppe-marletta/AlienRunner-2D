using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake() {
        instance = this ;
    }


    public void SelectScene(int i)   //caricamento delle scene 
    {
        SceneManager.LoadScene(i);
        
    }

    public void SelectScene(string name)
    {
        SceneManager.LoadScene(name);
    }



}
