using System.Collections;
using UnityEngine;

public class Bee : MonoBehaviour
{
    CapsuleCollider2D capsule;
    public float circleRadius = 1f;
    public float circleSpeed = 2f;
    public float forwardSpeed = 0.5f; // Velocidad de avance constante

    private Vector2 startPosition;

    private void Awake()
    {
        capsule = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        float angle = 0f;

        while (true)
        {
            float x = startPosition.x + forwardSpeed * angle;  // Movimiento hacia adelante en el eje x
            float y = startPosition.y + Mathf.Sin(angle) * circleRadius;  // Movimiento circular en el eje y

            transform.position = new Vector2(x, y);

            angle += circleSpeed * Time.deltaTime;  // Incremento constante del ángulo
            yield return null;
        }
    }
}
