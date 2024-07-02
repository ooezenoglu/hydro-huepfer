using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTriggerScript : MonoBehaviour
{
    public LogicScript logic;
    private bool wasTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wasTriggered) return;
        else if (collision.gameObject.layer == 6)
        {
            logic.addScore(1);
            wasTriggered = true;

        }
        
    }
}
