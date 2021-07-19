using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoretext;
    int score = 10;
    public void Decrement()
    {
        score--;
        scoretext.text = "Score : " + score;
        if (score == 0)
        {
            scoretext.text = "Level-1 completed";
        }
    }
}
