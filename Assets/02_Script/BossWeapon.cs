using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyProjectile;
    [SerializeField]
    private GameObject[] enemy2Projectile;


    public void StartFiring()
    {
        StartCoroutine(CircleFire());
    }

    public void StopFiring()
    {
        StopCoroutine(CircleFire());
    }

    public void Start2Firing()
    {
        StartCoroutine(FireToPlayer());
    }

    public void Start3Firing()
    {
        StartCoroutine(Fire());
    }
    public void Stop2Firing()
    {
        StartCoroutine(FireToPlayer());
    }

    IEnumerator Fire()
    {
        float attackRate = 0.7f;
        int count = 15;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        Debug.Log("wpqkfehlfkds");

        for (int j = 0; j < 7; j++)
        {
            int rand = Random.Range(-1, 1);
            for (int i = 0; i < 15; i++)
            {
                int ran = Random.Range(0, 3);
                GameObject clone = Instantiate(enemyProjectile[ran], transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;
                clone.transform.position = transform.position;
                //clone.transform.position = new Vector2(Mathf.Cos(angle * Mathf.PI / 180.0f), Mathf.Sin(angle * Mathf.PI));
                clone.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
            weightAngle += rand;
            yield return new WaitForSeconds(attackRate);
        }

    }
    IEnumerator FireToPlayer()
    {
        float attackRate = 0.5f;
        int count = 24;
        float intervalAngle = 360 / count;
        float weightAngle = 0;

        Debug.Log("wpqkfehlfkds");

        for (int j = 0; j < 12; j++)
        {
            int rand = Random.Range(-10, 10);
            for (int i = 0; i < 24; i++)
            {
                int ran = Random.Range(0, 3);
                GameObject clone = Instantiate(enemy2Projectile[ran], transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;
                clone.transform.position = transform.position;
                //clone.transform.position = new Vector2(Mathf.Cos(angle * Mathf.PI / 180.0f), Mathf.Sin(angle * Mathf.PI));
                clone.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
            weightAngle += rand;
            yield return new WaitForSeconds(attackRate);
        }

    }
    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f;
        int count = 24;
        float intervalAngle = 360 / count;
        float weightAngle = 0;
        
        Debug.Log(1);
        
        for(int j = 0; j<10; j++)
        {
            int rand = Random.Range(0,4);
            for (int i = 0; i < 24; i++)
            {
                int ran = Random.Range(0, 3);
                GameObject clone = Instantiate(enemyProjectile[ran], transform.position, Quaternion.identity);
                float angle = weightAngle + intervalAngle * i;
                clone.transform.position = transform.position;
                //clone.transform.position = new Vector2(Mathf.Cos(angle * Mathf.PI / 180.0f), Mathf.Sin(angle * Mathf.PI));
                clone.transform.rotation = Quaternion.Euler(0, 0, angle);

            }
            weightAngle += rand;
            yield return new WaitForSeconds(attackRate);   
        }
        
         
    }
        
    

    // Start is called before the first frame update
    void Start()
    {
        //StartFiring(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}