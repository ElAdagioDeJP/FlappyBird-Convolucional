using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{

    public TextMeshProUGUI time;
    public GameObject Montain;
    public GameObject Desert;
    public GameObject Snow;
    public GameObject Dark;
    public float timer;
    private float sometimes;
    int bioma = 0;
    float timeBiome = 30;
    public static int Dificultad = 1;
    public static float DificultadSpawn = 0.1f;
    float acountTime;

    private void Start()
    {
        if(time != null)
        {
            time.text = sometimes.ToString();
        }
        
    }
    private void Update()
    {
        if(time != null)
        {
            acountTime += Time.deltaTime;
            sometimes = (int)acountTime;
            time.text = sometimes.ToString();
        }
        
    }
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
