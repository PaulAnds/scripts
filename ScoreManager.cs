using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float score;
    public static int intscore;
    public Text highscore;
    public Text scoreText;
    public Movement dead;
    public Text numberChocolate;
    public Pause_menu pause;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        dead = FindObjectOfType<Movement>();
        pause = FindObjectOfType<Pause_menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.GameIsPaused == false)
        {
            score += .5f;
            intscore = Mathf.RoundToInt(score);
            
        }

        scoreText.text = intscore + "";
        highscore.text = PlayerPrefs.GetInt("highscore") + "";
        numberChocolate.text = dead.chocolate + "";

        if ( PlayerPrefs.GetInt("highscore") < intscore)
        {
            PlayerPrefs.SetInt("highscore", intscore);
            highscore.text = intscore + "";

            Debug.Log(PlayerPrefs.GetInt("highscore"));
        }
    }


}
