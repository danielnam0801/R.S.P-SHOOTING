using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public enum BossType { Dash, Fire1, Fire2, Fire3 }

public class Boss : MonoBehaviour
{
    [SerializeField]
    GameObject[] BbEnemy;
    [SerializeField]
    GameObject[] B2bEnemy;
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float bossHp = 100;
    float maxHp;
    [SerializeField]
    int score = 10000;
    int r;
    int d = 0;
    BossWeapon bossweapon;
    float currentTime;
    bool isPhase2;
    bool isPhase1;
    int b = 0;
    Rigidbody2D rb;
    //SpriteRenderer spriteRenderer;
    Transform targetTrm;
    Vector3 dir;
    Vector3 degree;
    Player player;
    public RectTransform bossGroup;
    public RectTransform bossHealthBar;
    //CountDown count;
    bool isRotate = false;
    SpriteRenderer change;
    float ntime = 0f;
    float ftime = 1f;
    public Image Panel;
    int animeStart = 0;
    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    Tilemap tilemap;

    private void Awake()
    {
        d = 0;
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPhase1 = true;
        isPhase2 = false;
        bossweapon = GetComponent<BossWeapon>();
        change = GetComponent<SpriteRenderer>();
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
        animeStart = 1; 
        maxHp = bossHp;
        StartCoroutine(Phase1());
        StartCoroutine(Phase2());
    }
    //IEnumerator BossAttack()
    //{

    //    int x = random.Range(0, 3);

    //}

    void Update()
    {
        if (d == 0)
        {
            transform.Rotate(0, 0, 0.3f);
 
                       
        }
        if (bossHp <= 50)
        {
            //작동안함
            if(animeStart == 1)
            {
                StartCoroutine(FadeFlow());
            }
            if(animeStart == 0)
            {
                StopCoroutine("FadeFlow");
            }
            spriteRenderer.sprite = sprites[1];
            tilemap.color = new Color(1, 0.246f, 0, 1);
            isPhase1 = false;
            StopCoroutine(Phase1());
            Debug.Log("Phase2");
            isPhase2 = true;    
            transform.Rotate(0, 0, 0.5f);
        }
        
        //BossMove();
    }
    private void LateUpdate()
    {
        bossHealthBar.localScale = new Vector3((bossHp / maxHp), 1, 1);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -45,45), Mathf.Clamp(transform.position.y, -45, 45));
    }


    IEnumerator Phase1()
    {
        yield return new WaitForSeconds(2.5f);
        while (isPhase1 == true)
        {
            BossMove();
            int x = Random.Range(0, 7);
            switch (x)
            {
                case 0:
                case 1:
                case 2:
                    Debug.Log("입력");
                    if (degree.magnitude <= 8)
                    {
                        Debug.Log(1);
                        d = 1;
                        StartCoroutine(Rotate());
                        yield return new WaitForSeconds(1f);
                        degree = targetTrm.position - transform.position;
                        StartCoroutine(Dash(degree));
                        yield return new WaitForSeconds(0.5f);
                        rb.velocity = Vector3.zero;
                        d = 0;
                        yield return new WaitForSeconds(2f);
                    }

                    break;
                case 3:
                case 4:
                    //BossMove();
                    StartCoroutine("Attack1");
                    yield return new WaitForSeconds(1f);
                    break;
                case 5:
                case 6:
                    //BossMove();
                    StartCoroutine("Attack2");
                    yield return new WaitForSeconds(10f);
                    break;
            }
            yield return new WaitForSeconds(3f);
        }
    }
    IEnumerator Phase2()
    {
       
        yield return new WaitUntil(() => isPhase2 == true);
        Debug.Log("wpqkdsjf");
        while (isPhase2)    
        {
            BossMove();
            int x = Random.Range(1, 8);
            switch (x)
            {
                case 1:
                case 2:
                    if (degree.magnitude <= 8)
                    {
                        Debug.Log(1);
                        b = 1;
                        StartCoroutine(Rotate2());
                        yield return new WaitForSeconds(1f);
                        degree = targetTrm.position - transform.position;
                        StartCoroutine(Dash(degree));
                        yield return new WaitForSeconds(0.5f);
                        rb.velocity = Vector3.zero;
                        yield return new WaitForSeconds(1f);
                        degree = targetTrm.position - transform.position;
                        StartCoroutine(Dash(degree));
                        yield return new WaitForSeconds(0.5f);
                        rb.velocity = Vector3.zero;
                        yield return new WaitForSeconds(1f);
                        degree = targetTrm.position - transform.position;
                        StartCoroutine(Dash(degree));
                        yield return new WaitForSeconds(0.5f);
                        rb.velocity = Vector3.zero;

                        b = 0;
                        yield return new WaitForSeconds(1f);
                    }

                    break;
                case 3:
                case 4:
                    
                    StartCoroutine("Attack3");
                    yield return new WaitForSeconds(4f);
                    break;
                case 5:
                case 6:
                    
                    StartCoroutine("Attack4");
                    yield return new WaitForSeconds(8f);
                    break;
                case 7:
                    b = 1;
                    StartCoroutine(Rotate2());
                    StartCoroutine("Attack5");
                    degree = targetTrm.position - transform.position;

                    yield return new WaitForSeconds(1f);
                    
                    StartCoroutine(Dash2(degree));
                    yield return new WaitForSeconds(3f);
                    rb.velocity = Vector3.zero;
                    b = 0;
                    yield return new WaitForSeconds(3f);
                    
                    break;
                    
            }
       
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
    IEnumerator Dash2(Vector3 degree)
    {
        yield return new WaitForSeconds(0.1f);

        rb.AddForce(degree.normalized * 300, ForceMode2D.Force);


    }
    IEnumerator Attack1()
    {
        for(int i = 0; i < 4; i++)
        {
            int z = Random.Range(0, 3);
            GameObject Bbenemy1 = Instantiate(BbEnemy[z], transform.position, transform.rotation);
            yield return new WaitForSeconds(0.7f);
        }
        
        yield return new WaitForSeconds(3f);
    }

    IEnumerator Attack2()
    {
        bossweapon.StartFiring();
        yield return new WaitForSeconds(5f);
    }

    IEnumerator Attack3()
    {
        for (int i = 0; i < 6; i++)
        {
            int z = Random.Range(0, 3);
            GameObject Bbenemy2 = Instantiate(B2bEnemy[z], transform.position, transform.rotation);
            //적 프리팹으로 새로 만들예정
            //B2bEnemy[z].GetComponent<Enemy>().sSpeed = 3;
            //B2bEnemy[z].GetComponent<Enemy>().health = 2; 
            //B2bEnemy[z].GetComponent<Enemy>().sScore = 300;
            yield return new WaitForSeconds(0.8f);
        }
    }
    IEnumerator Attack4()
    {
        bossweapon.Start2Firing();
        yield return new WaitForSeconds(5f);
    }
    IEnumerator Attack5()
    {
        bossweapon.Start3Firing();
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Rotate()
    {
        while (true)
        {
            yield return new WaitUntil(() => d == 1);
            currentTime += 0.3f;
            transform.Rotate(new Vector3(0, 0, 10 * currentTime) * 10 * Time.deltaTime);
            if (currentTime >= 10)
            {
                currentTime = 10;
                // yield return new WaitForSeconds(3f);
            }
        }

        
    }
    IEnumerator Rotate2()
    {
        while (true)
        {
            yield return new WaitUntil(() => b == 1);
            currentTime += 0.5f;
            transform.Rotate(new Vector3(0, 0, 10 * currentTime) * 10 * Time.deltaTime);
            if (currentTime >= 10)
            {
                currentTime = 10;
                // yield return new WaitForSeconds(3f);
            }
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.layer == 18)
        {
            Debug.Log(bossHp);
            Destroy(collision.gameObject);
            OnDamageBoss();
        }
    }

    public void OnDamageBoss()
    {
        bossHp -= 1;
        //StopAllCoroutines();
        StopCoroutine(spritehChange());
        StartCoroutine(spritehChange());
        //if(bossHp == 50)
        //{
        //    PlayerPrefs.SetFloat("BossHp", bossHp);
        //    PlayerPrefs.SetInt("PlayerHP", player.health);
        //    StartCoroutine(FadeFlow());
        //}
        if(bossHp == 0)
        {
            bossHealthBar.localScale = new Vector3((bossHp / maxHp), 1, 1);
            isPhase2 = false;
            StopCoroutine(Phase2());
            
            Destroy(gameObject);
        }
    }
    IEnumerator FadeFlow()
    {
        
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            ntime += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(0.0f, 1, ntime);
            Panel.color = alpha;
            yield return null;
        }
        animeStart = 0;
        yield return new WaitForSeconds(1f);
        
    }
    IEnumerator spritehChange()
    {
        change.color = Color.yellow;
        yield return new WaitForSeconds(0.08f);

        change.color = Color.white;
    }





}
