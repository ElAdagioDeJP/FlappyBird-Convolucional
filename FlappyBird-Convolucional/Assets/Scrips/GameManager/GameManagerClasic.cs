using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerClasic : MonoBehaviour
{
    public GameObject gameOverCanvas;
    
    void Start()
    {
        Time.timeScale = 1;
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
    
}
