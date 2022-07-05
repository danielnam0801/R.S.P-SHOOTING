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
        text.transform.DORotate(new Vector3(0, 0, 17), 1.5f);
        text.transform.DOMove(new Vector3(100, 740, 0), 1.5f, true).SetEase(ease);
        
        
        yield return new WaitForSeconds(2f);
        text2.transform.DOMove(new Vector3(700, 700, 0), 2f, true).SetEase(ease);
        yield return new WaitForSeconds(2f);
        text.transform.DORotate(new Vector3(0, 0, 360), 1.5f);
        //text.transform.DOMove(new Vector3(200, 1050, 0), 2f, true).SetEase(ease);
        text.transform.DOMove(new Vector3(80, 750, 0), 1.5f, true);
        text.transform.DOScale(1.4f, 2);
        text2.transform.DOMove(new Vector3(600, 700, 0), 2f, true);
        text2.transform.DOScale(1.1f,2);
        yield return new WaitForSeconds(1.5f);
        textScore.DOFade(0, 0);
        textScore.DOFade(1, 2f);
        textScore.text = "Score : " + PlayerPrefs.GetInt("LastScore");
        
        yield return new WaitForSeconds(1.5f);
        button.transform.DORotate(new Vector3(0, 0, 0), 1.5f);
        button.transform.DOMove(new Vector3(1080, 200, 0), 2f, true).SetEase(ease);

        yield return new WaitForSeconds(3f);
        textScore.DOFade(0, 2f);    
        
    }
}
    