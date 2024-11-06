using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawn : MonoBehaviour
{
    public GameObject MoscaSpawn;
    public GameObject BirdSpawn;
    public GameObject SnakeSpawn;
    public GameObject SnakeBrownSpawnUp;
    public GameObject SnakeBrownSpawnDown;
    public GameObject BirdSpawnDesert;
    public GameObject BeeSpawn;
    public GameObject BirdSpawnSnow;
    public GameObject BirdSpawnSnowReverse;
    public GameObject PlaneGreen;
    public GameObject PlaneRed;
    public float timer;
    int bioma = 0;
    float timeBiome = 30;

    private void Start()
    {
        StartCoroutine(SpawnReady());
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        int newBioma = Mathf.FloorToInt(timer / timeBiome) % 4;

        if (newBioma != bioma)
        {
            bioma = newBioma;
            StartCoroutine(ActivarSpawn());
        }
    }

    private void CambioBioma()
    {
        MoscaSpawn.SetActive(false);
        BirdSpawn.SetActive(false);
        SnakeSpawn.SetActive(false);
        SnakeBrownSpawnDown.SetActive(false);
        SnakeBrownSpawnUp.SetActive(false);
        BirdSpawnDesert.SetActive(false);
        BeeSpawn.SetActive(false);
        BirdSpawnSnowReverse.SetActive(false);
        BirdSpawnSnow.SetActive(false);
        PlaneRed.SetActive(false);
        PlaneGreen.SetActive(false);

        if (bioma == 1)
        {
            SnakeBrownSpawnDown.SetActive(true);
            SnakeBrownSpawnUp.SetActive(true);
            BirdSpawnDesert.SetActive(true);
            BeeSpawn.SetActive(true);
        }
        else if (bioma == 2)
        {
            BirdSpawnSnowReverse.SetActive(true);
            BirdSpawnSnow.SetActive(true);
            //PlaneRed.SetActive(true);
            PlaneGreen.SetActive(true);
        }
        else if (bioma == 3)
        {

        }
        else if (bioma == 0)
        {
            MoscaSpawn.SetActive(true);
            BirdSpawn.SetActive(true);
            SnakeSpawn.SetActive(true);
        }
    }
    IEnumerator ActivarSpawn()
    {
        yield return new WaitForSeconds(5f);
        CambioBioma();
    }
    IEnumerator SpawnReady()
    {
        yield return new WaitForSeconds(5f);
        MoscaSpawn.SetActive(true);
        BirdSpawn.SetActive(true);
        SnakeSpawn.SetActive(true);
    }
}

