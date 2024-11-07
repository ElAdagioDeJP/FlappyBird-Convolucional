using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject PrefabEnemy;

    public float range = 0.5f;

    public float maxTime = 0.25f;

    private float timer;
    void Start()
    {
        SpawnEnemy();
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-range, range));
        GameObject newPipe;

        newPipe = Instantiate(PrefabEnemy, spawnPosition, Quaternion.identity);

        Destroy(newPipe, 10f);
    }
}
