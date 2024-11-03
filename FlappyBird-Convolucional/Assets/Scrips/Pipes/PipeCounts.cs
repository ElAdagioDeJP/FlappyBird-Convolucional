using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCounts : MonoBehaviour
{
    public AudioSource clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clip.Play();
            FindAnyObjectByType<Score>().UpdateScore();
        }
    }
}
