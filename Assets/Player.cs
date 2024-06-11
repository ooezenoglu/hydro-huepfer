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

    // Update is called once per frame
    void Update()
    {
        // Überprüfen, ob die linke Pfeiltaste gedrückt wurde
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("WalkLeft");
        }
        // Überprüfen, ob die rechte Pfeiltaste gedrückt wurde
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("WalkRight");
        }
    }
}
