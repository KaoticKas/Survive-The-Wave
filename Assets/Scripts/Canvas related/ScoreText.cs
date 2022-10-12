using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{

    public static int scoreVal;
    public Text totalScore;

    private void Start()
    {
        scoreVal = PlayerPrefs.GetInt("Score");
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {

            totalScore.text = "Score: " + scoreVal;
        }
        else
        {
            PlayerPrefs.SetInt("Score", scoreVal);
        }
    }
}
