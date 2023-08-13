using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager Instance => instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreEndGame;
    public TextMeshProUGUI bestScore;


    public GameObject gameOverUI;


    private void Start()
    {
        scoreText.text = 0.ToString();
    }

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
    }


    public void UpdateScoreText(int amount)
    {
        scoreText.text = amount.ToString();
    }

    public void DisplayGameOver(int score, int best)
    {
        gameOverUI.SetActive(true);
        scoreEndGame.text = "Score: " + score.ToString();
        bestScore.text = "Score: " + best.ToString();


    }
}
