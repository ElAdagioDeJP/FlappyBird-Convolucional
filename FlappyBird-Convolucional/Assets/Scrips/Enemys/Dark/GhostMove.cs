using System.Collections;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Visibility());
    }
    IEnumerator Visibility()
    {
        yield return new WaitForSeconds(1.9f);
        sprite.enabled = false;
        yield return new WaitForSeconds(1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(1.9f);
        sprite.enabled = false;
        yield return new WaitForSeconds(1f);
        sprite.enabled = true;


    }

}
