using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject Montain;
    public GameObject Desert;
    public GameObject Snow;
    public GameObject Dark;
    public float timer;
    int bioma = 0;
    float timeBiome = 30;
    public static int Dificultad = 1;
    public static float DificultadSpawn = 0.1f;
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        int newBioma = Mathf.FloorToInt(timer / timeBiome) % 4;

        if (newBioma != bioma)
        {
            bioma = newBioma;
            CambioBioma();
        }
    }

    private void CambioBioma()
    {
        Montain.SetActive(false);
        Desert.SetActive(false);
        Snow.SetActive(false);
        Dark.SetActive(false);

        if (bioma == 1)
        {
            Desert.SetActive(true);
        }
        else if (bioma == 2)
        {
            Snow.SetActive(true);
        }
        else if (bioma == 3)
        {
            Dark.SetActive(true);
        }
        else if (bioma == 0)
        {
            Montain.SetActive(true);
            DificultadSpawn = 0.1f;
            Dificultad = 1;
            
        }
    }
}
