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


    void Start()
    {
        boss = GameObject.Find("Boss");
        bossText = GameObject.Find("BossText").GetComponent<Text>();
        StartCoroutine("Count");

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

            if (time <= 0)
            {
                SceneManager.LoadScene("BossScene");
                break;
            }
        }

    }

    private void Update()
    {

    }
}
