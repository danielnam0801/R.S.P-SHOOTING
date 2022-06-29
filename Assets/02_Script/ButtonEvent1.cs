using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonEvent1 : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void LoadScene(string sceneName)
    {
        audioSource.Play();
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
