using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Script : MonoBehaviour
{
    public void ExitGame()
    {
        //Imprimir en consola que se ha salido del juego
        Debug.Log("Se ha salido del juego");

        
    
        Application.Quit();
    }
}
