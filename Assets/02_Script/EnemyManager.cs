using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    public Transform[] spawnPoints;
    public float maxSpawnTIme;
    public float curSpawnTIme;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnTIme += Time.deltaTime;
        
        if(curSpawnTIme > maxSpawnTIme)
        {
            SpawnEnemy();
            maxSpawnTIme = Random.Range(0.5f, 3f);
            curSpawnTIme = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0 , 3);
        int ranPoint = Random.Range(0 , 5);
        Instantiate(enemies[ranEnemy] , spawnPoints[ranPoint].position  , spawnPoints[ranPoint].rotation);
    }
}
