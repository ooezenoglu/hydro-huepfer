using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteract : MonoBehaviour
{
    public GameController GameController;
    private Rigidbody2D rb;
    public float jumpForce = 12f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Monster"))
        {
            ContactPoint2D[] contactPoints = collision.contacts;

            foreach (ContactPoint2D contactPoint in contactPoints)
            {
                if (contactPoint.normal.y > 0.5f && rb.velocity.y < 0)
                {
                    Destroy(collision.gameObject);

                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                    return;
                }
            }

            Player.PlayerIsAlive = false;
            GameController.GameOver();
        }
        else if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Puddle"))
        {
            AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Play();
            }

            Player.PlayerIsAlive = false;
            //Destroy(gameObject);
            GameController.GameOver();
        }
    }
}
