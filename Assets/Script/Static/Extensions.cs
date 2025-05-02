using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void Spawn(this Transform trans, Transform spawnPoint) {  //extension di spawn 
        {
            trans.position = spawnPoint.position;
            trans.rotation = spawnPoint.rotation;
            trans.gameObject.SetActive (true);
        }
    }
}
