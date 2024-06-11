using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung

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

        // Berechnung der Bewegung basierend auf der Tasteneingabe
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed * Time.deltaTime;

        // Bewegung anwenden
        transform.Translate(movement);
    }
}
