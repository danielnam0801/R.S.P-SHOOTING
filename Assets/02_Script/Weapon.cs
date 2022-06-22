using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public enum Type {rockBullet, scissorBullet, paperBullet};
    public Type type;
    public float rate;
    public GameObject rock;
    public GameObject scissor;
    public GameObject paper;
    public float bulletSpeed = 5f;
    //ObjectPooler bulletPooler;
    GameObject bulletFactory;
    public Transform firePosition;
    Vector3 dir;
    Camera cam;
    ObjectPooler Rpooler;
    ObjectPooler Spooler;
    ObjectPooler Ppooler;
    //ObjectPooler_Advance objectPooler;

    private void Awake()
    {
        cam = Camera.main;
        Rpooler = GameObject.Find("RockBulletPos").GetComponent<ObjectPooler>();
        Spooler = GameObject.Find("ScissorBulletPos").GetComponent<ObjectPooler>();
        Ppooler = GameObject.Find("PaperBulletPos").GetComponent<ObjectPooler>();
    }
    private void Update()
    {
        dir = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -cam.transform.position.z));
        dir = dir - transform.position;
    }
    public void Use()
    {
        
        if (type == Type.rockBullet)
        {
            StopCoroutine("RockSpawn");
            StartCoroutine("RockSpawn");
        }
        if (type == Type.scissorBullet)
        {
            StopCoroutine("ScissorSpawn");
            StartCoroutine("ScissorSpawn");
        }
        if (type == Type.paperBullet)
        {
            StopCoroutine("PaperSpawn");
            StartCoroutine("PaperSpawn");
        }
    }

    IEnumerator RockSpawn()
    {
        //GameObject obj = objectPooler.GetObject(rock);
        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;

        //bulletFactory = Instantiate(rock, firePosition.transform.position, Quaternion.identity);
        bulletFactory = Rpooler.SpawnObject(transform.position , Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator ScissorSpawn()
    {
        bulletFactory = Spooler.SpawnObject(transform.position, Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator PaperSpawn()
    {
        bulletFactory = Ppooler.SpawnObject(transform.position, Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }
}
