using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBirdDark : MonoBehaviour
{
    public GameObject PrefabEnemy; // Prefab genérico del enemigo
    public Transform player; // Referencia al jugador (asígnalo desde el Inspector)

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
        // Genera una posición aleatoria para el enemigo dentro del rango especificado
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-range, range));
        GameObject newEnemy = Instantiate(PrefabEnemy, spawnPosition, Quaternion.identity);

        
        BirdDark birdScript = newEnemy.GetComponent<BirdDark>();
        if (birdScript != null)
        {
            // Si es un BirdMontain, asigna la referencia del jugador
            birdScript.SetPlayer(player);
        }

        // Destruye al enemigo después de 10 segundos
        Destroy(newEnemy, 10f);
    }
}
