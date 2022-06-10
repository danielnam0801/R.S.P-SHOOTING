using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    [SerializeField]
    GameObject[] enemies;
    //[SerializeField]
    //public Transform[] spawnPoints;
    public float maxSpawnTime;
    public float curSpawnTime;
    bool active;
    GameObject player;
    Vector3 degree;


    // Start is called before the first frame update
    void Start()    
    {
        player = GameObject.Find("Player");
        gameObject.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        degree = player.transform.position - transform.position;
        if (degree.magnitude<= 15)
        {
            active = true;
            gameObject.SetActive(true);
            
        }
        else
        {
            active = false;
            gameObject.SetActive(false);
        }

        if(active == true)
        {
            curSpawnTime += Time.deltaTime;
            if(curSpawnTime > maxSpawnTime)
            {
                SpawnEnemy();
                maxSpawnTime = Random.Range(0.5f, 3f);
                curSpawnTime = 0;
            }
        }
        
    }

    void SpawnEnemy()
    {
        int normalEnemy = Random.Range(0, 3);
        int gunEnemy = Random.Range(0, 3);
        int specialEnemy = Random.Range(0, 3);
        int spawnPercent = Random.Range(0, 100);

        if(spawnPercent <= 60)
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
