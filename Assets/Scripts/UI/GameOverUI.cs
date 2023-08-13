using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void PlayAgainScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
