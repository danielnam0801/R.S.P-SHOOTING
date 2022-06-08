using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    public Transform[] spawnPoints;
    public float maxSpawnTime;
    public float curSpawnTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curSpawnTime += Time.deltaTime;
        
        if(curSpawnTime > maxSpawnTime)
        {
            SpawnEnemy();
            maxSpawnTime = Random.Range(0.5f, 3f);
            curSpawnTime = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0 , 3);
        int ranPoint = Random.Range(0 , 9);
        GameObject enemy = Instantiate(enemies[ranEnemy] , spawnPoints[ranPoint].position  , spawnPoints[ranPoint].rotation);
        Rigidbody2D rigid = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();

        if(ranPoint == 5 || ranPoint == 6)
        {
            enemy.transform.Rotate(Vector3.back * 90);
            rigid.velocity = new Vector2(enemyLogic.speed * (-1), -1);
        }
        else if(ranPoint == 7 || ranPoint == 8)
        {
            enemy.transform.Rotate(Vector3.forward * 90);
            rigid.velocity = new Vector2(enemyLogic.speed, -1);
        }
        else
        {
            rigid.velocity = new Vector2(0, enemyLogic.speed*(-1));
        }
    }
}
