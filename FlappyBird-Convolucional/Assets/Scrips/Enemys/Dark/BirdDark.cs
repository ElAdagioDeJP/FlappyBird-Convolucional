using System.Collections;
using UnityEngine;

public class BirdDark : MonoBehaviour
{
    CapsuleCollider2D capsule;
    public float forwardDistance = 5f;
    public float forwardSpeed = 2f;
    SpriteRenderer sprite;

    private Transform player; // Cambiamos el acceso a privado y lo asignaremos desde el spawner
    private Vector2 startPosition;
    private Vector2 initialDirection;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void SetPlayer(Transform playerTransform) // Nueva función para asignar el jugador
    {
        player = playerTransform;
    }

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        // Movimiento inicial hacia adelante en X
        Vector2 targetPosition = startPosition + new Vector2(forwardDistance, 0);
        float elapsedTime = 0f;

        while (elapsedTime < 2f)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        // Si el jugador ha sido asignado, calcula la dirección inicial hacia él
        if (player != null)
        {
            initialDirection = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(initialDirection.y, initialDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            sprite.flipX = false;
            sprite.flipY = true;
        }

        // Movimiento continuo en la dirección inicial
        while (true)
        {
            transform.position += (Vector3)initialDirection * forwardSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
