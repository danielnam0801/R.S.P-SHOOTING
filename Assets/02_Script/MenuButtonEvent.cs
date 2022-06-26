using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MenuButtonEvent : MonoBehaviour
{
    [SerializeField]
    Image Panel;
    [SerializeField]
    Button close;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TipButtonClick()
    {
        Panel.gameObject.SetActive(true);
        Panel.gameObject.transform.DOScale(1, 1);
    }

    void CloseButtonClick()
    {
        StartCoroutine("Close");
    }
    IEnumerator Close()
    {
        Panel.gameObject.transform.DOScale(0, 1);
        yield return new WaitForSeconds(0.8f);
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
