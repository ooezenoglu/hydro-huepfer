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
        Debug.Log("found logic");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        //logic.addScore(1);

        
        if (collision.gameObject.layer == 6 && !wasTriggered)
        {
            logic.addScore(1);
            wasTriggered = true;

        }
        
    }
}
