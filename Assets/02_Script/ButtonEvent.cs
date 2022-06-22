using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public Image Panel;
    public GameObject gamePanel;
    public GameObject player;
    float time = 0;
    float ftime = 1f;
    Image Button;
    Image image;
    Text text;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
        
    }

    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Button = GameObject.Find("Button").GetComponent<Image>();
        Button.enabled = false;
        image = GameObject.Find("Image").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Text").GetComponent<Text>();
        text.enabled = false;
        Color alpha = Panel.color;
        while (alpha.a < 1f)

        {
            
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(0.3f, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        
        yield return new WaitForSeconds(1f);
        
        gamePanel.SetActive(true);
        player.SetActive(true);

        time = 0f;
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / ftime;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }

        Panel.gameObject.SetActive(false);
        
        
        
        
        
    }
}
