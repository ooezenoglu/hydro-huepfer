using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteract : MonoBehaviour
{
    public GameController GameController;
    public float jumpForce = 12f;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip boingSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
                    audioSource.PlayOneShot(boingSound);

                    BackgroundMusic2.Instance.StopGrowling();

                    Destroy(collision.gameObject);

                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                    return;
                }
            }

            MonsterMovement monsterMovement = collision.gameObject.GetComponent<MonsterMovement>();

            if (monsterMovement != null)
            {
                monsterMovement.PlayAttackSound();
            }

            BackgroundMusic2.Instance.StopGrowling();
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
            BackgroundMusic2.Instance.StopGrowling();
            //Destroy(gameObject);
            GameController.GameOver();
        }
    }
}
