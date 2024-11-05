using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movebird : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D rb2d;
    private CapsuleCollider2D boxCollider2D;
    public float rotationSpeed = 25;
    public AudioSource clipDeath;

    // Variable para controlar si el jugador puede moverse
    private bool canMove = true;

    void Start()
    {
        boxCollider2D = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        // Solo permite el movimiento si canMove es verdadero
        if (canMove && Input.GetKey(KeyCode.Z))
        {
            rb2d.velocity = Vector2.up * speed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rb2d.velocity.y * rotationSpeed * Time.deltaTime * 100);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // Desactiva el movimiento
        canMove = false;
        StartCoroutine(Death());
    }

    IEnumerator Death()
    {
        clipDeath.Play();
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
