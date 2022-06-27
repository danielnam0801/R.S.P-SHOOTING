using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DotWin : MonoBehaviour
{

    [SerializeField]
    Ease ease;

    [SerializeField]
    Text textScore;
    [SerializeField]
    Text text;
    [SerializeField]
    Text text2;
    [SerializeField]
    Button button;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine("Dot");
        
    }
    IEnumerator Dot()
    {
        text.transform.DORotate(new Vector3(0, 0, 24), 1.5f);
        text.transform.DOMove(new Vector3(550, 900, 0), 1.5f, true).SetEase(ease);
        
        
        yield return new WaitForSeconds(1.5f);
        text2.transform.DOMove(new Vector3(700, 550, 0), 2f, true).SetEase(ease);
        yield return new WaitForSeconds(2f);
        text.transform.DORotate(new Vector3(0, 0, 360), 1.5f);
        text.transform.DOMove(new Vector3(600, 900, 0), 1.5f, true).SetEase(ease);
        //text.transform.DOMove(new Vector3(900, 950, 0), 1.5f, true);
        text2.transform.DOMove(new Vector3(600, 600, 0), 2f, true);
        yield return new WaitForSeconds(1f);
        textScore.DOFade(0, 0);
        textScore.DOFade(1, 2f);
        textScore.text = "Score : " + PlayerPrefs.GetInt("LastScore");
        
        yield return new WaitForSeconds(1.5f);
        button.transform.DORotate(new Vector3(0, 0, 0), 1.5f);
        button.transform.DOMove(new Vector3(950, 150, 0), 2f, true).SetEase(ease);
        
    }
}
    