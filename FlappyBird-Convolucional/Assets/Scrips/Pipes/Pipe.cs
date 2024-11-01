using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 100000000000f;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
