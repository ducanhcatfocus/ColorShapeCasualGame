using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("FirstPlay"))
        {
            scoreText.text = 0.ToString();
            PlayerPrefs.SetInt("BestScore", 0);

            PlayerPrefs.SetInt("FirstPlay", 0);
        }
        else
            scoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void LoadPlayScene()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

}
