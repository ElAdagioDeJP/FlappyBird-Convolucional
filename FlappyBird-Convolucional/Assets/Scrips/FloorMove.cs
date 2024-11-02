using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    public float speed;

    public float width = 6f;

    public SpriteRenderer spriteRenderer;

    private Vector2 startSize;
    void Start()
    {
        startSize = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
    }


    void Update()
    {
        spriteRenderer.size = new Vector2(spriteRenderer.size.x + speed * Time.deltaTime, spriteRenderer.size.y);
        if(spriteRenderer.size.x > width)
        {
            spriteRenderer.size = startSize;
        }
    }
}