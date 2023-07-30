using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highscore;
    public TMP_Text scoreText, highscoreText, duraText, moneyText, repairkitText;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        moneyText.text = PlayerData.instance.money.ToString();
        repairkitText.text = PlayerData.instance.repairkit.ToString();
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

    public void repair()
    {
        if (PlayerData.instance.repairkit >= 1)
        {
            PlayerData.instance.repairkit -= 1;
            PlayerData.instance.currentDurability += 30;
            if (PlayerData.instance.currentDurability > PlayerData.instance.maxDurability)
            {
                PlayerData.instance.currentDurability = PlayerData.instance.maxDurability;
            }
        }
    }
}
