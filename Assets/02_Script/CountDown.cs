using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class CountDown : MonoBehaviour
{
    [SerializeField] Text countText;
    public int time = 60;
    int min;
    int sec;
    GameObject boss;
    Text bossText;
    Text score;
    GameObject image;
    Image playerHp;
    Text imageText;
    public GameObject gamePanel;
    //public GameObject explosion;
    float ntime = 0f;
    float ftime = 1f;
    public Image Panel;
    //public GameObject player_1;
    int a = 0;
    Player player_2;    

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        image = GameObject.Find("Image");
        playerHp = GameObject.Find("PlayerHp").GetComponent<Image>();
        imageText = GameObject.Find("5/10").GetComponent<Text>(); 
        a = 0;
        boss = GameObject.Find("Boss");
        bossText = GameObject.Find("BossText").GetComponent<Text>();
        StartCoroutine("Count");
        player_2 = GameObject.Find("Player").GetComponent<Player>();
    }
    IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time += -1;
            min = time / 60;
            sec = time % 60;
            if (sec >= 10)
                countText.text = min.ToString() + " : " + sec.ToString();
            else if (sec < 10)
            {
                countText.color = Color.red;
                countText.text = min.ToString() + " : 0" + sec.ToString();
                yield return new WaitForSeconds(0.33f);
                countText.color = Color.white;
                yield return new WaitForSeconds(0.33f);
                countText.color = Color.red;
                yield return new WaitForSeconds(0.33f);
                countText.color = Color.white;

            }

            if(time == 0)
            {
                player_2.gameObject.layer = 10;
                PlayerPrefs.SetInt("Health", player_2.health);
                PlayerPrefs.SetInt("Score3", player_2.Score);
                if(player_2.transform.position.x <= 28.5 || transform.position.x >= -28.5)
                {
                     PlayerPrefs.SetFloat("positionX", player_2.transform.position.x);
                }
                   
                else if (player_2.transform.position.x > 28.5f)
                {
                    PlayerPrefs.SetFloat("positionX", 28.5f);
                }
                else if (player_2.transform.position.x < -28.5f)
                {
                    PlayerPrefs.SetFloat("positionX", -28.5f);
                }
                if (player_2.transform.position.y <= 28.5 || transform.position.y >= -28.5)
                {
                    PlayerPrefs.SetFloat("positionY", player_2.transform.position.y);
                }
                else if (player_2.transform.position.y > 28.5)
                {
                    PlayerPrefs.SetFloat("positionY", 28.5f);
                }
                else if (player_2.transform.position.y < -28.5)
                {
                    PlayerPrefs.SetFloat("positionY", -28.5f);
                }
                Panel.gameObject.SetActive(true);
                //bossText.enabled =false;
                //countText.enabled = false;
                //score.enabled = false;
                //image.SetActive(false);
                //imageText.enabled = false;


                

                
                Color alpha = Panel.color;
                while (alpha.a < 1f)

                {

                    ntime += Time.deltaTime / ftime;
                    alpha.a = Mathf.Lerp(0.0f, 1, ntime);
                    Panel.color = alpha;
                    yield return null;
                }

                yield return new WaitForSeconds(1f);
                //gamePanel.SetActive(true);
                //player_1.SetActive(true);

            }
            if (time <= -1)
            {
                player_2.gameObject.layer = 11;
                SceneManager.LoadScene("BossScene");
                break;
            }
        }

    }

    private void Update()
    {

    }
}
