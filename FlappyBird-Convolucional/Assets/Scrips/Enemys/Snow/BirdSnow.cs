using System.Collections;
using UnityEngine;

public class BirdSnow : MonoBehaviour
{
    CapsuleCollider2D capsule;
    public float forwardDistance = 5f;
    public float forwardSpeed = 2f;
    public float zigZagAmplitude = 1f;
    public float zigZagFrequency = 2f;

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
        Vector2 targetPosition = startPosition + new Vector2(forwardDistance, 0);
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        while (true)
        {
            float zigZagOffset = Mathf.Sin(Time.time * zigZagFrequency) * zigZagAmplitude;
            transform.position += Vector3.right * forwardSpeed * Time.deltaTime + Vector3.up * zigZagOffset * Time.deltaTime;

            float angle = Mathf.Atan2(zigZagOffset, forwardSpeed) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            yield return null;
        }
    }
}
