using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    private Text scoreText; 

    private void Start()
    {
        scoreText = GetComponent<Text>();
        if (PlayerPrefs.GetInt("score") < 0)
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("score", score);
        }
    }

    private void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "" + score;
        PlayerPrefs.SetInt("score", score);
    }

    public static void AddPoints(int _pointstoAdd)
    {
        score += _pointstoAdd;
    }
}
