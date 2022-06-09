using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private Vector3 direction;
    private float speed = 12f;

    public void Shoot(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
        Debug.Log($"{direction.x} {direction.y}");
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime; 
    }

    //void OnHit()
    //{
        
    //}
}
