using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebirdClasic : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb2d;
    public float rotationSpeed = 25;
    public AudioSource clipDeath;
    public AudioSource clipMontain;
    public AudioSource clipDesert;
    public AudioSource clipSnow;
    public AudioSource clipDark;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            rb2d.velocity = Vector2.up * speed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * rotationSpeed * Time.deltaTime * 100);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        clipDark.Stop();
        clipDesert.Stop();
        clipMontain.Stop();
        clipSnow.Stop();
        clipDeath.Play();
        FindAnyObjectByType<GameManagerClasic>().GameOver();
    }
}
