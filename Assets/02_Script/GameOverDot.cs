using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOverDot : MonoBehaviour
{
    [SerializeField]
    Ease ease;
    [SerializeField]
    Text GameOver;
    [SerializeField]
    Image button;
    [SerializeField]
    Text text;
    [SerializeField]
    Button button2;
    // Start is called before the first frame update
    private void Awake()
    {
        //text = GameObject.Find("Text").GetComponent<Text>();
        //button2 = GameObject.Find("MainMenu").GetComponent<Button>();
    }
    void Start()
    {
        StartCoroutine(GameOver1());

    }
    
    IEnumerator GameOver1()
    {
        button.DOFade(1, 2f);
        GameOver.DOText("Game Over...", 3f);
        yield return new WaitForSeconds(3f);
        text.DOFade(0, 0);
        text.text = "Score : " + PlayerPrefs.GetInt("Score3");
        text.DOFade(1, 2f);
        yield return new WaitForSeconds(1.5f);
        button2.transform.DORotate(new Vector3(0, 0, 0), 1.5f);
        button2.transform.DOMove(new Vector3(1080, 200, 0), 2f, true).SetEase(ease);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
