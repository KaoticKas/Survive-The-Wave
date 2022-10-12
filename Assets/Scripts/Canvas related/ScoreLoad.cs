using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour
{
    public Text score;
    public int defaultScore = 0;

    void Start()
    {
        score.text = "YOUR SCORE:" + PlayerPrefs.GetInt("Score").ToString();
        PlayerPrefs.SetInt("Score", defaultScore);
    }


}
