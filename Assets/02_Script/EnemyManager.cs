using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    [SerializeField]
    GameObject[] enemies;
    //[SerializeField]
    //public Transform[] spawnPoints;
    public float maxSpawnTime = 5f;
    public float curSpawnTime;
    bool active;
    GameObject player;
    Vector2 degree;
    CountDown count;
    bool gameActive;

    // Start is called before the first frame update
    void Start()    
    {
        count = GameObject.Find("Time").GetComponent<CountDown>();
        player = GameObject.Find("Player");
        //active = false;
        gameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(count.time <= 1)
        {
            gameActive = true;
        }
        if (gameActive == false)
        {
            degree = player.transform.position - transform.position;
            if (degree.magnitude >= 30)
            {
                active = true;

            }
            else
            {
                active = false;

            }

            if (active == true)
            {
                curSpawnTime += Time.deltaTime;
                if (curSpawnTime > maxSpawnTime)
                {
                    SpawnEnemy();
                    maxSpawnTime = Random.Range(3f, 5f);
                    curSpawnTime = 0;
                }
            }
        }
        
        
    }

    void SpawnEnemy()
    {
        int normalEnemy = Random.Range(6, 9);
        int gunEnemy = Random.Range(3, 6);
        int specialEnemy = Random.Range(0, 3);
        int spawnPercent = Random.Range(0, 100);

        if(spawnPercent < 80)
        {
            GameObject enemy = Instantiate(enemies[normalEnemy], transform.position, Quaternion.identity);
        }
        else if(spawnPercent < 90)
        {
            GameObject enemy = Instantiate(enemies[gunEnemy], transform.position, Quaternion.identity);
        }
        else
        {
            GameObject enemy = Instantiate(enemies[specialEnemy], transform.position, Quaternion.identity);
        }
        
    }
}
