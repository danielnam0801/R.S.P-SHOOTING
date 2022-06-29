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
    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TipButtonClick()
    {
        click.Play();
        StartCoroutine(Panel2());
    }
    IEnumerator Panel2()
    {
        yield return new WaitForSeconds(0.1f);
        Panel.gameObject.SetActive(true);
        Panel.gameObject.transform.DOScale(0.95f, 0.7f);
    }
    public void CloseButtonClick()
    {
        click.Play();
        StartCoroutine("Close");
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(0.1f);
        Panel.gameObject.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        Panel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
