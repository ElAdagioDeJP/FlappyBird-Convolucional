using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar escenas
using UnityEngine.UI; // Necesario si quieres interactuar con UI

public class Menu_Play: MonoBehaviour
{
    // Método para cargar una escena por su nombre
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}