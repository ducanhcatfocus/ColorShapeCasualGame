using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance => instance;
    private int score = 0;
    private int incscore = 0;
    public ObjectSpawner spawner;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            score = 0;
            PlayerPrefs.SetInt("BestScore", 0);

            PlayerPrefs.SetInt("FirstPlay", 0);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        incscore += amount;
        if(incscore >= 100 && score <= 400) {
            incscore = 0;
            IncreaseGameLv();
        }
        UIManager.Instance.UpdateScoreText(score);
       
    }

    private void IncreaseGameLv()
    {
        spawner.IncreaseLv();
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }

    public void SetBestScore()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore");
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        SetBestScore();
        UIManager.Instance.DisplayGameOver(score, GetBestScore());
    }
}
