using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;

    public float range = 0.5f;

    public float maxTime = 0.25f;

    private float timer;
    void Start()
    {
        SpawnPipe();
    }

   
    void Update()
    {
        timer += Time.deltaTime;
        if(timer> maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    public void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-range, range));
        GameObject newPipe;

        newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);

        Destroy(newPipe, 10f);
    }
}
