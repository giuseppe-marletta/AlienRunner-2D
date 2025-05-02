using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLightning : MonoBehaviour
{
    public enum LightningType { Lightning = 1, SuperLightning = 3 }    //enums per il danno dei fulmini
    public LightningType myNormalLightning;

    public LightningType mySuperLightning;

    public void SendInformation<T> (T param)  //mandare le informazioni sul fulmine raccolto affinchè si possa far visualizzare l'immagine corretta nella GUI
    {
        GuiManager.instance.ShowInformation(param);    
    }

    public void SendStopInformation<T> (T param)
    {
        GuiManager.instance.StopShowInformation(param);
    }
}
