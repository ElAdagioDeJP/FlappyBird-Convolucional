using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Referencia al dropdown de resoluciones
    private Resolution[] resolutions; // Almacenar las resoluciones disponibles

    void Start()
    {
        // Obtener todas las resoluciones disponibles
        resolutions = Screen.resolutions;

        // Limpiar opciones existentes en el dropdown
        resolutionDropdown.ClearOptions();

        // Crear una lista para almacenar las opciones de resolución
        List<string> options = new List<string>();

        // Agregar cada resolución a la lista de opciones
        foreach (Resolution res in resolutions)
        {
            // Asegurarse de agregar solo resoluciones únicas
            string option = res.width + " x " + res.height;
            if (!options.Contains(option))
            {
                options.Add(option);
            }
        }

        // Agregar las opciones al dropdown
        resolutionDropdown.AddOptions(options);

        // Establecer el valor del dropdown a la resolución actual
        int currentResolutionIndex = GetCurrentResolutionIndex(resolutions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue(); // Actualizar la visualización del dropdown

        // Agregar listener para manejar cambios en el dropdown
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChanged(); });
    }

    private int GetCurrentResolutionIndex(Resolution[] resolutions)
    {
        // Obtener la resolución actual de la pantalla
        Resolution currentResolution = Screen.currentResolution;

        // Buscar el índice de la resolución actual en la lista de resoluciones disponibles
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                return i; // Retornar el índice si se encuentra
            }
        }
        
        return 0; // Retornar 0 si no se encuentra, por defecto a la primera opción
    }

    public void OnResolutionChanged() // Asegúrate de que esta función sea pública
    {
        // Cambiar la resolución de la pantalla según la selección del usuario
        Resolution selectedResolution = resolutions[resolutionDropdown.value];
        
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }
}