using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_sprite : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0, 2, 0);
        }
    }
}
