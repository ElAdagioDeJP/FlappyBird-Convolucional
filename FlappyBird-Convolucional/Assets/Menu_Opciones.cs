using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Controla volumen y pantalla completa
public class Menu_Opciones : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void CambiarVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
        
    }

}
