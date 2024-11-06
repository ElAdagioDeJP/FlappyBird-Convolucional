using System.Collections;
using UnityEngine;

public class MoveBala : MonoBehaviour
{
    public float forwardDistance = 5f;
    public float forwardSpeed = 2f;

    private Vector2 startPosition;


    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        Vector2 targetPosition = startPosition + new Vector2(forwardDistance, 0);
        float elapsedTime = 0f;

        while (elapsedTime < 0.1f)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        while (true)
        {
            transform.position += Vector3.right * forwardSpeed * Time.deltaTime;
            yield return null;
        }
    }
}
