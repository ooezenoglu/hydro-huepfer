using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteract : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Puddle"))
        {
            Player.PlayerIsAlive = false;
            Destroy(gameObject);
        }
    }
}
