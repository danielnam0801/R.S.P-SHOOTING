using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public Sprite[] sprites;
    Rigidbody2D rb;
    //SpriteRenderer spriteRenderer;
    Transform targetTrm;


    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetTrm = GameObject.Find("Player").GetComponent<Transform>();
        //rEnemyPooler = GameObject.Find("EnemySpawner").GetComponent<ObjectPooler>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 degree = targetTrm.position - transform.position;
        if (degree.magnitude >= 1)
        {
            rb.velocity = degree.normalized * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    void OnHit(int dmg)
    {
        health -= dmg;
       // spriteRenderer.sprite = sprites[1];
        //Invoke("ReturnSprite", 0.1f);
        if(health <= 0)
        {
            //rEnemyPooler.ReturnObject(gameObject);
            Destroy(gameObject);
        } 
    }

    void ReturnSprite()
    {
       // spriteRenderer.sprite = sprites[0];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Square")
        {
            Destroy(gameObject);
        }
        else if(gameObject.tag == "REnemy"){
            if(collision.gameObject.tag == "PBullet")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                OnHit(bullet.damage);
            }
            else if(collision.gameObject.tag == "SBullet"){
                health += 1;
            }
        }
        else if (gameObject.tag == "PEnemy")
        {
            if (collision.gameObject.tag == "SBullet")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                OnHit(bullet.damage);
            }
            else if (collision.gameObject.tag == "RBullet")
            {
                health += 1;
            }
        }
        else if (gameObject.tag == "SEnemy")
        {
            if (collision.gameObject.tag == "RBullet")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                OnHit(bullet.damage);
            }
            else if (collision.gameObject.tag == "PBullet")
            {
                health += 1;
            }
        }

    }

}
