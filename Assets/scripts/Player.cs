using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius;

    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung
    public float jumpForce = 0.1f; // Sprungkraft
    public static bool PlayerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckifGrounded();
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
            animator.SetTrigger("Stand"); // Standbild setzen, wenn keine Pfeiltasten gedrückt werden
        }

        // Berechnung der Bewegung basierend auf der Tasteneingabe
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Bewegung anwenden
        transform.Translate(movement);

        // Sprungaktion hinzufügen
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            animator.SetTrigger("JumpRight");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Überprüfung auf Bodenberührung
    private void CheckifGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
