using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{

    Player2 player;
    [SerializeField]
    GameObject[] bossExplosion;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    GameObject playercam;
    //[SerializeField]
    //GameObject bosss;
    float x;
    float y;

    private void Start()
    {
        
    }

    private void Awake()
    {
        playercam.gameObject.SetActive(false);
        cam.gameObject.SetActive(true);
        
        player = GameObject.Find("Player").GetComponent<Player2>();
        x = PlayerPrefs.GetFloat("BossPositionX", 100);
        y = PlayerPrefs.GetFloat("BossPositionY", 100);
        PlayerPrefs.SetInt("LastScore", PlayerPrefs.GetInt("Score3")+ 200000);
        cam.GetComponent<Camera>().transform.position = new Vector3(x,y,-10);
        //cam.transform.position = new Vector3(x, y, 0);
        StartCoroutine(explosion());
    }
    public void Update()
    {
        transform.Rotate(0, 0, 5f);
        transform.position = new Vector3(x, y, 0);
    }
    IEnumerator explosion()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("ehoehoehoheo");
        Instantiate(bossExplosion[0], new Vector3(transform.position.x + 2, transform.position.y - 2, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bossExplosion[1], new Vector3(transform.position.x - 2, transform.position.y + 2, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bossExplosion[2], new Vector3(transform.position.x + 0, transform.position.y  -2, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bossExplosion[0], new Vector3(transform.position.x + 1, transform.position.y - 1, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bossExplosion[1], new Vector3(transform.position.x - 1, transform.position.y, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(bossExplosion[2], new Vector3(transform.position.x + 1, transform.position.y + 1, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Clear");
    }
    
}
