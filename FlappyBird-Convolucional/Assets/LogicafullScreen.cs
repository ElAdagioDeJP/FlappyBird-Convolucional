using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Full screen usando toggle
public class LogicafullScreen : MonoBehaviour
{
    public Toggle toggle;
    
    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
    }

    void Update()
    {

    }

    public void ActivarPantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
}
