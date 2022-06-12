using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossExplosion : MonoBehaviour
{
    private Player player;
    private string SceneName;
    private int currentScore;
    private int besScore;

    public void SetUp(Player player, string sceneName)
    {
        this.player = player;
        this.SceneName = sceneName;
        player.Score += 10000;
        //PlayerPrefs.SetInt("Score", currentScore);
        //if (currentScore > besScore)
        //{
        //    besScore = currentScore;
        //    PlayerPrefs.SetInt("Best Score", besScore);
        //}
        SceneManager.LoadScene(SceneName);
    }

    private void OnDestroy()
    {

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
