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
        // �berpr�fen, ob die linke Pfeiltaste gedr�ckt wurde
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("WalkLeft");
        }
        // �berpr�fen, ob die rechte Pfeiltaste gedr�ckt wurde
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("WalkRight");
        }
    }
}
