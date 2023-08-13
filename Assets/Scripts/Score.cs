using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI textScore;
    public int score;
    void Start()
    {
        textScore.text = 0.ToString();
    }

    public void AddScore(int add)
    {
        score += add;
        textScore.text = score.ToString();
    }
}
