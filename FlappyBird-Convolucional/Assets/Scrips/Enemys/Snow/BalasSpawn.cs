using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasSpawn : MonoBehaviour
{
    public GameObject balaPrefab;         // Prefab de la bala
    public int cantidadBalasPorLote = 5;  // Número de balas en cada lote
    public float intervaloEntreLotes = 4f; // Tiempo entre cada lote de balas
    public float intervaloEntreBalas = 0.1f; // Tiempo entre balas en el mismo lote
    public float rangoVertical = 0.5f;    // Rango de dispersión vertical de las balas

    private void Start()
    {
        // Iniciar la coroutine que genera un lote de balas cada 4 segundos
        StartCoroutine(GenerarLotesDeBalas());
    }

    private IEnumerator GenerarLotesDeBalas()
    {
        while (true) // Bucle infinito para generar lotes constantemente
        {
            for (int i = 0; i < cantidadBalasPorLote; i++)
            {
                // Generar cada bala dentro del lote con una pequeña separación
                Vector3 posicionGeneracion = transform.position + new Vector3(0, Random.Range(-rangoVertical, rangoVertical));
                GameObject nuevaBala = Instantiate(balaPrefab, posicionGeneracion, Quaternion.identity);
                Destroy(nuevaBala, 4f);  // Destruir la bala después de 4 segundos

                // Esperar el tiempo entre balas antes de generar la siguiente
                yield return new WaitForSeconds(intervaloEntreBalas);
            }

            // Esperar el tiempo entre lotes antes de generar el siguiente lote de balas
            yield return new WaitForSeconds(intervaloEntreLotes);
        }
    }
}
