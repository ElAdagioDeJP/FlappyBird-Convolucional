using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogicaCalidad : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Dropdown para seleccionar la calidad
    public int calidad; // Variable para almacenar el nivel de calidad

    void Start()
    {
        // Cargar la calidad guardada o establecer 3 por defecto
        calidad = PlayerPrefs.GetInt("numerodeCalidad", 3);
        dropdown.value = calidad; // Establecer el valor del dropdown

        // Agregar listener para cambios en el dropdown
        dropdown.onValueChanged.AddListener(delegate { AjustarCalidad(); });

        // Ajustar la calidad al inicio
        AjustarCalidad();
    }

    public void AjustarCalidad()
    {
        // Cambiar la calidad gráfica
        QualitySettings.SetQualityLevel(dropdown.value);
        
        // Guardar la calidad seleccionada
        PlayerPrefs.SetInt("numerodeCalidad", dropdown.value);
        
        // Guardar los cambios inmediatamente (opcional)
        PlayerPrefs.Save();
    }
}