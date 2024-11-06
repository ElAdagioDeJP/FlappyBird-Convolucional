using System.Collections;
using UnityEngine;

public class AvionMove : MonoBehaviour
{
    public float initialMoveDistance = 5f;
    public float yFollowSpeed = 2f;
    public float pauseTime = 2f;
    public Transform player;

    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(FollowPlayer());
        StartCoroutine(DisableAfterTime(30f));
    }

    IEnumerator FollowPlayer()
    {
        Vector2 targetPosition = new Vector2(transform.position.x + initialMoveDistance, transform.position.y);
        float elapsedTime = 0f;
        float moveDuration = 1f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        while (true)
        {
            if (player == null)
            {
                yield break;
            }

            Vector2 yTargetPosition = new Vector2(transform.position.x, player.position.y);

            while (Mathf.Abs(transform.position.y - player.position.y) > 0.1f)
            {
                if (player == null)
                {
                    yield break;
                }

                transform.position = Vector2.MoveTowards(transform.position, yTargetPosition, yFollowSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(pauseTime);
        }
    }

    IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Move to initial position over less than 1 second
        float elapsedTime = 0f;
        float moveDuration = 0.9f; // Less than 1 second

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(transform.position, initialPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition;

        // Disable the GameObject
        gameObject.SetActive(false);
    }
}