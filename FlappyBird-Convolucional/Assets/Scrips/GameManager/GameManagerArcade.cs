using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerArcade : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winGreenCanvas;
    public GameObject winRedCanvas;
    public GameObject FlappyRedFather;
    public GameObject FlappyGreenFather;
    public GameObject Count;
    public AudioSource clipMontain;
    public AudioSource clipDesert;
    public AudioSource clipSnow;
    public AudioSource clipDark;
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Ready());
    }


    private void FixedUpdate()
    {
        if (FlappyGreenFather.transform.childCount == 0)
        {
            gameOverCanvas.SetActive(true);
            clipDark.Stop();
            clipDesert.Stop();
            clipMontain.Stop();
            clipSnow.Stop();
            Time.timeScale = 0;
        }
        else if (FlappyRedFather.transform.childCount == 0)
        {
            gameOverCanvas.SetActive(true);
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
    IEnumerator Ready()
    {
        yield return new WaitForSeconds(3.8f);
        Count.SetActive(false);
        FlappyRedFather.SetActive(true);
        FlappyGreenFather.SetActive(true);
        clipMontain.enabled = true;
    }
}