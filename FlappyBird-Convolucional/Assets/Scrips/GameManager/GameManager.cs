using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winGreenCanvas;
    public GameObject winRedCanvas;
    public GameObject FlappyRedFather;
    public GameObject FlappyGreenFather;
    public AudioSource clipMontain;
    public AudioSource clipDesert;
    public AudioSource clipSnow;
    public AudioSource clipDark;
    bool WinnerGrenn;
    bool WinnerRed;
    void Start()
    {
        Time.timeScale = 1;
    }


    private void FixedUpdate()
    {
        if(FlappyGreenFather.transform.childCount == 0)
        {
            winRedCanvas.SetActive(true);
            clipDark.Stop();
            clipDesert.Stop();
            clipMontain.Stop();
            clipSnow.Stop();
            Time.timeScale = 0;
        }
        else if (FlappyRedFather.transform.childCount == 0)
        {
            winGreenCanvas.SetActive(true);
            clipDark.Stop();
            clipDesert.Stop();
            clipMontain.Stop();
            clipSnow.Stop();
            Time.timeScale = 0;
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void WinGreen()
    {
        
    }
    public void WinRed()
    {

    }
}
