using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { CircleFire = 0, SingleFireToCenterPosition }
public class BossWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyProjectile;


    public void StartFiring()
    {
        StartCoroutine(CircleFire());
    }

    public void StopFiring()
    {
        StopCoroutine(CircleFire());
    }

    private IEnumerator CircleFire()
    {
        float attackRate = 0.5f;
        int count = 15;
        float intervalAngle = 360 / count;
        float weightAngle = 0;
        
        Debug.Log(1);
        
        for(int j = 0; j<count; j++)
        {
            int rand = Random.Range(-2,2);
            for (int i = 0; i < 24; i++)
            {
                int ran = Random.Range(0, 3);
                GameObject clone = Instantiate(enemyProjectile[ran], transform.position, Quaternion.identity);
                float angle = weightAngle * 15 * i;
                clone.transform.position = transform.position;
                clone.transform.rotation = Quaternion.Euler(0,0,angle);
               
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