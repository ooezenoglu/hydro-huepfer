using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteract : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Puddle"))
        {
            AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.Play();
            }

            Player.PlayerIsAlive = false;
            Destroy(gameObject);
        }
    }
}
