using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;
    private int score;

    void Start()
    {
        scoreText.text = score.ToString();
        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    
    public void UpdateBestScore()
    {
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestScore.text = score.ToString();
        }
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        UpdateBestScore();
    }
}
