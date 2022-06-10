using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //ObjectPooler_Advance objectPooler;

    private void Awake()
    {
        cam = Camera.main;
        //objectPooler = FindObjectOfType<ObjectPooler_Advance>();
        
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
        
        bulletFactory = Instantiate(rock, firePosition.transform.position, Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator ScissorSpawn()
    {
        bulletFactory = Instantiate(scissor, firePosition.transform.position, Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator PaperSpawn()
    {
        bulletFactory = Instantiate(paper, firePosition.transform.position, Quaternion.identity);
        bulletFactory.gameObject.GetComponent<Bullet>().Shoot(dir);
        yield return new WaitForSeconds(rate);
    }
}
