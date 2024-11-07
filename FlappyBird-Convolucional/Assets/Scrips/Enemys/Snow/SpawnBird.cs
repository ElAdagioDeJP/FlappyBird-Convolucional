using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBird : MonoBehaviour
{
    public GameObject PrefabEnemy1;
    public GameObject PrefabEnemy2;

    public float range = 0.5f;
    public float maxTime = 1f;

    private float timer;
    private bool toggle;

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

        if (toggle)
        {
            newPipe = Instantiate(PrefabEnemy1, spawnPosition, Quaternion.identity);
        }
        else
        {
            newPipe = Instantiate(PrefabEnemy2, spawnPosition, Quaternion.identity);
        }

        toggle = !toggle;

        Destroy(newPipe, 10f);
    }
}