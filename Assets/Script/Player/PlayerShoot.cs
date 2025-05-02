using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    int control;

    private void Start()
    {
        control = SaveGame.GetControls();
    }


    IEnumerator AllowNormalShoot()    //attivazione e comando di sparo fulmine normale
    {
        while (true)
        {
            if (control == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.instance.PlayLightningLaunches();
                    GetComponent<ShootingLightning>().StartCoroutine("NormalShoot");
                }

                if (Input.GetMouseButtonUp(0))
                    GetComponent<ShootingLightning>().StopAllCoroutines();
            }
            else if (control == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SoundManager.instance.PlayLightningLaunches();
                    GetComponent<ShootingLightning>().StartCoroutine("NormalShoot");
                }

                if (Input.GetKeyUp(KeyCode.Return))
                    GetComponent<ShootingLightning>().StopAllCoroutines();
            }

            yield return 0;
        }

    }

    IEnumerator AllowSuperShoot()  //attivazione e comando di sparo super fulmine 
    {
        while (true)
        {
            if (control == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.instance.PlayLightningLaunches();
                    GetComponent<ShootingLightning>().StartCoroutine("SuperShoot");
                }

                if (Input.GetMouseButtonUp(0))
                    GetComponent<ShootingLightning>().StopAllCoroutines();
            }
            else if (control == 1)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SoundManager.instance.PlayLightningLaunches();
                    GetComponent<ShootingLightning>().StartCoroutine("SuperShoot");
                }

                if (Input.GetKeyUp(KeyCode.Return))
                    GetComponent<ShootingLightning>().StopAllCoroutines();
            }

            yield return 0;
        }

    }

}
