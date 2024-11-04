using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScore;
    public GameObject Montain;
    public GameObject MontainSpawn;
    public GameObject Desert;
    public GameObject DesertSpawn;
    public GameObject Snow;
    public GameObject SnowSpawn;
    public GameObject Dark;
    public GameObject DarkSpawn;
    private int score;
    int j = 0;
    int i = 0;
    float ChangeBiome = 3.5f;
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
        j = Random.Range(1, 100);
        
        if( j > 0 && j < 5)
        {
            i++;
            StartCoroutine(CambioBioma());
            if(i == 4)
            {
                i = 0;
            }
            
        }

        score++;
        scoreText.text = score.ToString();
        UpdateBestScore();
    }
    IEnumerator CambioBioma()
    {
        if (i == 0 || i > 3)
        {
            Dark.SetActive(false);
            DarkSpawn.SetActive(false);
            Montain.SetActive(true);
            yield return new WaitForSeconds(ChangeBiome);
            MontainSpawn.SetActive(true);
        }
        else if (i == 1)
        {
            Montain.SetActive(false);
            MontainSpawn.SetActive(false);
            Desert.SetActive(true);
            yield return new WaitForSeconds(ChangeBiome);
            DesertSpawn.SetActive(true);
        }
        else if (i == 2)
        {
            Desert.SetActive(false);
            DesertSpawn.SetActive(false);
            Snow.SetActive(true);
            yield return new WaitForSeconds(ChangeBiome);
            SnowSpawn.SetActive(true);
        }
        else if (i == 3)
        {
            Snow.SetActive(false);
            SnowSpawn.SetActive(false);
            Dark.SetActive(true);
            yield return new WaitForSeconds(ChangeBiome);
            DarkSpawn.SetActive(true);
        }
        

    }
}
