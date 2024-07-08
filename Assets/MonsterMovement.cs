using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float speed = 1000000f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool MoveRight = true;

    private float lastXPosition;
    private float stuckTime;
    private float stuckThreshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckStuck();
    }

    void Move()
    {
        Vector2 movement = new Vector2(speed , rb.velocity.y);
        rb.velocity = MoveRight ? movement : new Vector2(-movement.x, movement.y);

        animator.SetBool("MoveRight", MoveRight);
    }

    void CheckStuck()
    {
        float currentXPosition = transform.position.x;

        if (Mathf.Approximately(currentXPosition, lastXPosition))
        {
            stuckTime += Time.deltaTime;
        }
        else
        {
            stuckTime = 0f;
        }

        if (stuckTime >= stuckThreshold)
        {
            MoveRight = !MoveRight;
            Flip();
            stuckTime = 0f;
        }

        lastXPosition = currentXPosition;
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
