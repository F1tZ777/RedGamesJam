using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highscore;
    public TMP_Text scoreText, highscoreText, duraText, moneyText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        duraText.text = PlayerData.instance.currentDurability.ToString();
        moneyText.text = PlayerData.instance.money.ToString();
        // highscoreText.text = highscore.ToString();

        if (score > highscore)
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
