using System.Collections;
using UnityEngine;

public class Mosca : MonoBehaviour
{
    CapsuleCollider2D capsule;
    public float forwardDistance = 5f;
    public float sineAmplitude = 1f;
    public float sineFrequency = 1f;
    public float sineSpeed = 2f;

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

        float time = 0f;
        while (true)
        {
            float x = targetPosition.x + sineSpeed * time;
            float y = targetPosition.y + Mathf.Sin(time * sineFrequency) * sineAmplitude * Timer.Dificultad;
            transform.position = new Vector2(x, y);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
