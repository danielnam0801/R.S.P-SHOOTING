using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private Vector3 direction;
    private float speed = 12f;
    float angle;
    Vector2 target, mouse;

    private void Start()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2((mouse.y -transform.position.y), (mouse.x - transform.position.x)) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    public void Shoot(Vector3 dir)
    {
        direction = dir;
        direction.Normalize();
        //Debug.Log($"{direction.x} {direction.y}");
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
         
    }


    //void OnHit()
    //{

    //}
}
