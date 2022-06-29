using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossGameManager : MonoBehaviour
{
    [SerializeField]
    AudioSource bossStart;
    public GameObject gamePanel;
    //public GameObject explosion;
    float time = 0f;
    float ftime = 1f;
    public Image Panel;
    public GameObject player_1;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        //gamePanel.SetActive(true);
        //player_1.SetActive(true);

        //Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        //while (alpha.a < 1f)

        //{

        //    time += Time.deltaTime / ftime;
        //    alpha.a = Mathf.Lerp(0.3f, 1, time);
        //    Panel.color = alpha;
        //    yield return null;
        //}

        //yield return new WaitForSeconds(1f);
        // gamePanel.SetActive(true);
        //player_1.SetActive(true);
        time = 0f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        bossStart.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
