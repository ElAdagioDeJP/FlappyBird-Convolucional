using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerClasic : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject Count;
    public GameObject Flappy;
    public GameObject SpawnMontain;
    public AudioSource InitClip;
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(Ready());
    }


    private void FixedUpdate()
    {
       
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
        yield return new WaitForSeconds(3.6f);
        Count.SetActive(false);
        Flappy.SetActive(true);
        SpawnMontain.SetActive(true);
        InitClip.enabled = true;
    }
}
