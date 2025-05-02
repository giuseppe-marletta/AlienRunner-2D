using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectsDeath : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.transform.position;  //particelle partono al punto di morte del nemico
    }
}
