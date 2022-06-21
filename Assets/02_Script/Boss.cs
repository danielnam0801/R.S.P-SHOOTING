using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum BossType { Dash, Fire1, Fire2, Fire3 }

public class Boss : MonoBehaviour
{
    [SerializeField]
    GameObject[] BbEnemy;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    int bossHp = 100;
    [SerializeField]
    int score = 10000;
    int r;
    int a = 0;
    BossWeapon bossweapon;
    float currentTime;

    Rigidbody2D rb;
    //SpriteRenderer spriteRenderer;
    Transform targetTrm;
    Vector3 dir;
    Vector3 degree;
    Player player;
    //CountDown count;
    bool isRotate = false;

    private void Awake()
    {
        bossweapon = GetComponent<BossWeapon>();
        //gameObject.SetActive(false);
        //count = GameObject.Find("Time").GetComponent<CountDown>();
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        targetTrm = GameObject.Find("Player").GetComponent<Transform>();
        //rEnemyPooler = GameObject.Find("EnemySpawner").GetComponent<ObjectPooler>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //StartCoroutine("BossAttack");

    }

    private void Start()
    {
        StartCoroutine(Phase1());
    }
    //IEnumerator BossAttack()
    //{

    //    int x = random.Range(0, 3);

    //}

    void Update()
    {
        if (a == 0)
        {
            transform.Rotate(0, 0, 3f);
        }
        
        if (bossHp <= 50)
        {
            StopCoroutine("Phase1");
            StartCoroutine(Phase2());
        }
        //BossMove();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -28,28), Mathf.Clamp(transform.position.y, -28, 28));
    }


    IEnumerator Phase1()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            BossMove();
            int x = Random.Range(0, 6);
            switch (x)
            {
                case 0:
                case 1:
                    Debug.Log(1);
                    a = 1;
                    StartCoroutine(Rotate());
                    yield return new WaitForSeconds(1f);
                    degree = targetTrm.position - transform.position;
                    StartCoroutine(Dash(degree));
                    yield return new WaitForSeconds(0.5f);
                    rb.velocity = Vector3.zero;
                    a = 0;
                    yield return new WaitForSeconds(2f);
                    
                    break;
                case 2:
                case 3:
                    //BossMove();
                    StartCoroutine("Attack1");
                    yield return new WaitForSeconds(1f);
                    break;
                case 4:
                case 5:
                    //BossMove();
                    StartCoroutine("Attack2");
                    yield return new WaitForSeconds(10f);
                    break;
            }
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator Phase2()
    {
        int x = Random.Range(0, 5);
        switch (x)
        {
            case 0:
            case 1:
                StartCoroutine(Dash(degree));
                yield return new WaitForSeconds(7f);
                break;
            case 2:
            case 3:
                
                StartCoroutine("Attack1");
                yield return new WaitForSeconds(1f);
                break;
            case 4:
            case 5:
                
                StartCoroutine("Attack2");
                yield return new WaitForSeconds(1f);
                break; ;
        }
    }

    void BossMove()
    {
        degree = targetTrm.position - transform.position;
        if (degree.magnitude >= 5)
        {
            rb.velocity = degree.normalized * speed;
        }
        //else if (degree.magnitude < 3)
        //{
        //    rb.velocity = Vector3.zero;
        //    yield return new WaitForSeconds(1f) ;

        //    StartCoroutine(Dash(degree));
        //}

    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(10f);
        r = Random.Range(0, 5);
    }




    IEnumerator Dash(Vector3 degree)
    {
        yield return new WaitForSeconds(0.1f);

        rb.AddForce(degree.normalized * 20, ForceMode2D.Impulse);


    }
    IEnumerator Attack1()
    {
        for(int i = 0; i < 4; i++)
        {
            int z = Random.Range(0, 3);
            GameObject Bbenemy1 = Instantiate(BbEnemy[z], transform.position, transform.rotation);
            BbEnemy[z].GetComponent<Enemy>().sSpeed = 4;
            BbEnemy[z].GetComponent<Enemy>().health = 2;
            BbEnemy[z].GetComponent<Enemy>().sScore = 300;
            yield return new WaitForSeconds(0.5f);
        }
        
        yield return new WaitForSeconds(3f);
    }

    IEnumerator Attack2()
    {
        bossweapon.StartFiring();
        yield return new WaitForSeconds(5f);
    }
    //IEnumerator SpawnEnemy()
    //{

    //}
    IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitUntil(() => a == 1);
            currentTime += 0.3f;
            transform.Rotate(new Vector3(0, 0, 10 * currentTime) * 10 * Time.deltaTime);
            if (currentTime >= 10)
            {
                currentTime = 10;
                // yield return new WaitForSeconds(3f);
            }
        }
    }






}
