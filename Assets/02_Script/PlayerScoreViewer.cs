using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreViewer : MonoBehaviour
{
    Player player;
    Text textScore;
    void Start()
    {
        textScore = GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score : " + player.Score;
    }
}
