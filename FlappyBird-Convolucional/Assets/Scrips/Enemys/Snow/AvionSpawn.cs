using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvionSpawn : MonoBehaviour
{
    public GameObject AvionPrefabGreen;
    public GameObject AvionPrefabRed;

    public float range = 0.5f;

    public float maxTime = 5f;

    private float timer;
    private float timerComparation;
    void Start()
    {
        SpawnPipe();
    }


    void Update()
    {
        timer += Time.deltaTime;
        timerComparation = Mathf.FloorToInt(timer);
        if (timerComparation == maxTime)
        {
            SpawnPipe();
        }
    }

    public void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-range * 0, range * 0));
        GameObject newPlaneGreen;
        GameObject newPlaneRed;
        newPlaneGreen = Instantiate(AvionPrefabGreen, spawnPosition, Quaternion.identity);
        newPlaneRed = Instantiate(AvionPrefabGreen, spawnPosition, Quaternion.identity);

        Destroy(newPlaneRed, 30f);
        Destroy(newPlaneRed, 30f);
    }
}
