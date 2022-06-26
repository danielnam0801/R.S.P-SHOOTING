using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    //[SerializeField]
    //private StageData stageData;
    //private Movement movement;
    public Image weapon1;
    public Image weapon2;
    public Image weapon3;
    public Image num;
    public Image num1;
    public Image num2;
    public GameObject[] weapons;
    public Text score1;
    Weapon equipWeapon;
    SpriteRenderer spriteRenderer;
    PlayerAction action;
    //int equipWeaponIndex = -1;
    bool sDown1;
    bool sDown2;
    bool sDown3;
    bool fireDown;
    bool isFireReady = true;
    bool isDamage;
    bool fireDown1;
    float fireDelay;
    int rightClick;

    private int health = 7;
    //public int maxHealth = 7;
    public Text playerHealthTxt;

    int score;

    public int Score
    {
        get => score;
        set => score = Mathf.Max(0, value);
    }

    private void Awake()
    {
        rightClick = 0;
        gameObject.layer = 11;
        transform.position = new Vector3(PlayerPrefs.GetFloat("positionX"), PlayerPrefs.GetFloat("positionY"),0);
        health = PlayerPrefs.GetInt("Health");
        spriteRenderer = GetComponent<SpriteRenderer>();
        action = GameObject.Find("Player").GetComponent<PlayerAction>();
        Debug.Log(PlayerPrefs.GetInt("Score3"));
        num.color = new Color(0.5f, 0.5f, 0.5f, 1);
        num1.color = new Color(0.5f, 0.5f, 0.5f, 1);
        num2.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    void Update()
    {
        Swap();
        Attack();

        GetInput();
        if (health <= 0)
        {

        }
    }
    private void LateUpdate()
    {
        playerHealthTxt.text = ": " + health.ToString();
        score1.text = "Score : " + ((int)PlayerPrefs.GetInt("Score3") + score).ToString();
    }
    void GetInput()
    {
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
        fireDown = Input.GetButtonDown("Fire1");
        //fireDown1 = Input.GetButton("Fire1");
    }

    void Swap()
    {
        if (Input.GetMouseButtonDown(1))
        {
            rightClick++;
            if (rightClick > 3)
            {
                rightClick = 1;
            }
        }
        int weaponIndex = -1;
        if (sDown1 || rightClick == 1)
        {
            weaponIndex = 0;
            weapon1.color = new Color(1, 1, 1, 1);
            weapon2.color = new Color(0.5f, 0.5f, 0.5f, 1);
            num.color = new Color(1, 1, 1, 1);
            num1.color = new Color(0.5f, 0.5f, 0.5f, 1);
            num2.color = new Color(0.5f, 0.5f, 0.5f, 1);
            weapon3.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        if (sDown2 || rightClick == 2)
        {
            weaponIndex = 1;
            num1.color = new Color(1, 1, 1, 1);
            num.color = new Color(0.5f, 0.5f, 0.5f, 1);
            num2.color = new Color(0.5f, 0.5f, 0.5f, 1);
            weapon2.color = new Color(1, 1, 1, 1);
            weapon1.color = new Color(0.5f, 0.5f, 0.5f, 1);
            weapon3.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        if (sDown3 || rightClick == 3)
        {
            weaponIndex = 2;
            num2.color = new Color(1, 1, 1, 1);
            num1.color = new Color(0.5f, 0.5f, 0.5f, 1);
            num.color = new Color(0.5f, 0.5f, 0.5f, 1);
            weapon3.color = new Color(1, 1, 1, 1);
            weapon1.color = new Color(0.5f, 0.5f, 0.5f, 1);
            weapon2.color = new Color(0.5f, 0.5f, 0.5f, 1);
        }


        if (sDown1 || sDown2 || sDown3 || Input.GetMouseButtonDown(1))
        {
            if (equipWeapon != null)
                equipWeapon.gameObject.SetActive(false);

            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);
        }
    }

    void Attack()
    {
        if (equipWeapon == null)
        {
            return;
        }

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if ((fireDown) && isFireReady)
        {
            equipWeapon.Use();
        }
        fireDelay = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boss")
        {
            CircleCollider2D boss = collision.gameObject.GetComponent<CircleCollider2D>();
            if (collision == boss)
            {
                StopCoroutine("OnDamage");
                StartCoroutine(OnDamage());
            }

        }
        if (collision.tag == "EnemyBullet")
        {
            {

                StopCoroutine("OnDamage");
                StartCoroutine(OnDamage());

            }
        }
        if (collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
            StopCoroutine("OnDamage");
            StartCoroutine("OnDamage");
        }
        if (collision.gameObject.layer == 14)
        {
            Destroy(collision.gameObject);
            StopCoroutine("OnDamage");
            StartCoroutine("OnDamage");
        }
        if (collision.gameObject.layer == 15)
        {
            Destroy(collision.gameObject);
            StopCoroutine("OnDamage");
            StartCoroutine("OnDamage");
        }
        if (collision.gameObject.layer == 19)
        {
            Destroy(collision.gameObject);
            StopCoroutine("OnDamage");
            StartCoroutine("OnDamage");
        }
    }
    public void DieEvent()
    {
        SceneManager.LoadScene("Clear");
        PlayerPrefs.SetInt("Score", score);
    }

    IEnumerator OnDamage()
    {
        gameObject.layer = 10;
        action.speed = 5f;
        health -= 1;
        Debug.Log(health);
        if (health <= 0)
        {
            DieEvent();
        }
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.2f);
        }
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = new Color(1, 1, 1, 1);

        action.speed = 4f;
        gameObject.layer = 11;

    }

    //void Move()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float y = Input.GetAxisRaw("Vertical");

    //    movement.MoveTo(new Vector3 (x, y, 0));
    //}



    //private void LateUpdate()
    //{
    //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
    //                                     Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));   
    //}
}
