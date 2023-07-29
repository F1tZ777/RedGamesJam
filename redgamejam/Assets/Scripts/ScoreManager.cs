using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score, highscore;
    public TMP_Text scoreText, highscoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();

        if(score > highscore)
        {
            highscore = score;
        }
    }
    public void AddScore(int amount)
    {
        score += amount;
    }
    public void SubtractScore(int amount)
    {
        score -= amount;
    }
    public void Save()
    {
        PlayerPrefs.SetInt("score", score);

        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void Load()
    {
        score = PlayerPrefs.GetInt("score");
        highscore = PlayerPrefs.GetInt("highscore");
    }
}
