using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{
    public static GuiManager instance;

    [SerializeField] Image LightningNormal;
    [SerializeField] Image LightningSuper;

    [SerializeField] Text timer;

    [SerializeField] float countdown;

    


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LightningNormal.enabled = false;
        LightningSuper.enabled = false;
        StartCoroutine(TimerManager());
        
    }

    private void Update()
    {

    }


    public IEnumerator TimerManager()   //gestione del timer
    {
        while (true)
        {
            if (countdown > 0 && true)
                countdown -= Time.deltaTime;
            int b = (int)countdown;
            timer.text = b.ToString();
            if (countdown < 0)
                break;
            yield return null;
        }
        PlayerManager.instance.TakeGameOver();
    }

    public void stopTimer() 
    {
        StopAllCoroutines();
        int points = int.Parse(timer.text);
        PointManager.instance.AddPoints(points);

    }

    public void ShowInformation<T>(T lightning)     //mostra l'immagine del power up corretta nella gui 
    {
        string type = lightning.GetType().ToString();

        switch (type)
        {
            case "NormalLightningPickup":
                NormalLightningPickup normalPickup = lightning as NormalLightningPickup;
                LightningNormal.enabled = true;
                break;

            case "SuperLightningPickup":
                SuperLightningPickup superPickup = lightning as SuperLightningPickup;
                LightningSuper.enabled = true;
                break;
        }
    }

    public void StopShowInformation<T>(T lightning)   //elimina correttamente l'immagine del power up nella gui 
    {
        string type = lightning.GetType().ToString();

        switch (type)
        {
            case "NormalLightningPickup":
                NormalLightningPickup normalPickup = lightning as NormalLightningPickup;
                LightningNormal.enabled = false;
                break;

            case "SuperLightningPickup":
                SuperLightningPickup superPickup = lightning as SuperLightningPickup;
                LightningSuper.enabled = false;
                break;
        }
    }

}
