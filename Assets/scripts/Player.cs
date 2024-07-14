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

    // Audio
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip thumpSound;

    private bool wasGrounded;

    //Lader
    private float speed = 5f;
    private bool isClimbing = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        PlayerIsAlive = true;
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

        if (!isGrounded)  return;

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSound);
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

    private void CheckifGrounded()
    {
        bool previouslyGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (!previouslyGrounded && isGrounded)
        {
            audioSource.PlayOneShot(thumpSound);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            if (rb.velocity.y > 0 && !isClimbing) return;

            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0, speed);
                isClimbing = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
               rb.velocity = new Vector2(0, -speed);
                isClimbing = true;
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                isClimbing = false;
            }
        }
    }
}
