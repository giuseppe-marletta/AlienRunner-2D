using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] GameObject enemy;
    [SerializeField] GameObject[] enemyList;
    [SerializeField] int enemyLength;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeToSpawn;

    
    float tEnemySpawn;

    int enemyCounter = 0 ;

    private void Awake() {
        enemyList = new GameObject[enemyLength];
        for(int i = 0 ; i < enemyLength ; i++) {
            enemyList[i] = Instantiate(enemy,spawnPoint.position,spawnPoint.rotation);
            enemyList[i].SetActive (false);
        }
    }

    private void Update() {
        tEnemySpawn += Time.deltaTime;
        if(tEnemySpawn  >= timeToSpawn)
            SpawnEnemy();
    }

    void SpawnEnemy() 
    {
        tEnemySpawn = 0 ;
        for(int i = enemyCounter ; i < enemyLength ; i++)
        {
            if(!enemyList[i].activeInHierarchy)
            {
                enemyList[i].GetComponent<Enemy>().Spawn(spawnPoint);
                enemyCounter = i + 1;
                break;
            }
            if(enemyCounter == enemyLength)
                enemyCounter = 0 ;
        }
    }
}
