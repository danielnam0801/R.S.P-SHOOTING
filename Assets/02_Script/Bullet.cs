using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private Vector3 direction;

    public void Shoot(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
        Debug.Log($"{direction.x} {direction.y}");
    }

    private void Update()
    {
        transform.position += direction * 14 * Time.deltaTime; 
    }

    //void OnHit()
    //{
        
    //}
}
