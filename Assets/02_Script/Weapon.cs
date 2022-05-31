using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Type {rockBullet, scissorBullet, paperBullet};
    public Type type;
    public int damage;
    public float rate;
    public GameObject rock;
    public GameObject scissor;
    public GameObject paper;
    //public Transform firePosition;


    public void Use()
    {
        //GameObject bulletFactory = Instantiate(bullet, firePosition.transform.position, Quaternion.identity);
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
        GameObject bulletFactory = Instantiate(rock, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator ScissorSpawn()
    {
        GameObject bulletFactory = Instantiate(scissor, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(rate);
    }

    IEnumerator PaperSpawn()
    {
        GameObject bulletFactory = Instantiate(paper, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(rate);
    }
}
