using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingLightning : MainLightning
{

    [SerializeField] GameObject[] lightningNormalList;
    [SerializeField] int lightningNormalLength;

    [SerializeField] GameObject[] lightningSuperList;

    [SerializeField] int lightningSuperLength;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject lightning;

    [SerializeField] GameObject lightningSuper;

    [SerializeField] int normalLightningCounter = 0;

    [SerializeField] int superLightningCounter = 0;

    [SerializeField] protected Text normalLightningLengthText;

    [SerializeField] protected Text superLightningLengthText;


    bool lightningFound = false;
    int countNormalLightningLengthText;

    int countSuperLightningLengthText;

    bool isNormalShoot = false;

    bool isSuperShoot = false;


    // Start is called before the first frame update
    void Awake()       //creazione del pool di fulmini
    {
        lightningNormalList = new GameObject[lightningNormalLength];
        for (int i = 0; i < lightningNormalLength; i++)
        {
            lightningNormalList[i] = Instantiate(lightning);
            lightningNormalList[i].GetComponent<HitLightning>().SetLightningType((int)myNormalLightning);
            lightningNormalList[i].SetActive(false);
        }
        countNormalLightningLengthText = lightningNormalLength;

        lightningSuperList = new GameObject[lightningSuperLength];
        for (int i = 0; i < lightningSuperLength; i++)
        {
            lightningSuperList[i] = Instantiate(lightningSuper);
            lightningSuperList[i].GetComponent<HitLightning>().SetLightningType((int)mySuperLightning);
            lightningSuperList[i].SetActive(false);
        }
        countSuperLightningLengthText = lightningSuperLength;
    }

    IEnumerator NormalShoot()  //comportamento allo sparo del fulmine normale
    {
        isNormalShoot = true;
        if (isSuperShoot == true)
        {
            DisableSuperLightningHUD();
            isSuperShoot = false;
        }
        spawnNormalLightning();
        yield return new WaitForSeconds(5);
    }

    IEnumerator SuperShoot() //commportamento allo sparo del super fulmine
    {
        isSuperShoot = true;
        if (isNormalShoot == true)
        {
            DisableNormalLightningHUD();
            isNormalShoot = false;
        }
        spawnSuperLightning();
        yield return new WaitForSeconds(5);
    }

    void spawnNormalLightning()   //spawn fulmine normale 
    {
        {

            if (countNormalLightningLengthText > 0)
            {
                lightningNormalList[normalLightningCounter].GetComponent<Lightning>().Spawn(spawnPoint);
                normalLightningCounter++;
                countNormalLightningLengthText--;
                normalLightningLengthText.text = countNormalLightningLengthText.ToString();
                if (countNormalLightningLengthText == 0)
                {
                    DisableNormalLightningHUD();
                }


            }

        }
    }


    void spawnSuperLightning() //spawn super fulmine 
    {
        if (countSuperLightningLengthText > 0)
        {
            lightningSuperList[superLightningCounter].GetComponent<Lightning>().Spawn(spawnPoint);
            superLightningCounter++;
            countSuperLightningLengthText--;
            superLightningLengthText.text = countSuperLightningLengthText.ToString();
            if (countSuperLightningLengthText == 0)
            {
                DisableSuperLightningHUD();
            }

        }
    }

    public void DisableNormalLightningHUD()    //gestione dell'HUD relativo ai fulmini 
    {
        NormalLightningPickup nlp = new NormalLightningPickup();
        DisableImage(nlp);
        normalLightningLengthText.enabled = false;
    }

    public void DisableSuperLightningHUD()
    {
        SuperLightningPickup slp = new SuperLightningPickup();
        DisableImage(slp);
        superLightningLengthText.enabled = false;
    }

    public void DisableImage<T>(T param)
    {
        SendStopInformation(param);
    }

}
