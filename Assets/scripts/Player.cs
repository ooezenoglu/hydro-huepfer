using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius;

    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung
    public float jumpForce = 12f; // Sprungkraft
    public static bool PlayerIsAlive = true;
    private bool _isFacingRight = true;
    private float _moveInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckifGrounded();

        Walk();

        Jump();

        ManageAnimations();
    }

    private void Walk()
    {
        _moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(_moveInput * moveSpeed, rb.velocity.y);

        switch (_isFacingRight)
        {
            case false when _moveInput > 0:
            case true when _moveInput < 0:
                Flip(); 
                break;
        }
    }

    private void Jump()
    {
        if (!isGrounded) return; 

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void ManageAnimations()
    {
        if (rb.velocity.x != 0 && isGrounded)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Standing", false);
            animator.SetBool("Jumping", false);
        }
        else if (!isGrounded)
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Standing", false);
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Standing", true);
            animator.SetBool("Jumping", false);
            animator.SetBool("Walking", false);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
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
