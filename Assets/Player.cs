using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;

    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung
    public float jumpForce = 0.1f; // Sprungkraft

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bewegung in horizontaler Richtung basierend auf der Pfeiltaste
        float moveHorizontal = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("WalkLeft");
            moveHorizontal = -1f; // Bewegung nach links
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("WalkRight");
            moveHorizontal = 1f; // Bewegung nach rechts
        }
        else
        {
            animator.SetTrigger("Stand"); // Standbild setzen, wenn keine Pfeiltasten gedr�ckt werden
        }

        // Berechnung der Bewegung basierend auf der Tasteneingabe
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Bewegung anwenden
        transform.Translate(movement);

        // Sprungaktion hinzuf�gen
        if (Input.GetKeyDown(KeyCode.UpArrow) /*&& isGrounded*/)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // �berpr�fung auf Bodenber�hrung
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
