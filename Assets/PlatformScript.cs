using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int destructionDistance = 20;
    public gameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        var pos = playerPos.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos - destructionDistance > transform.position.y)
        {
            Debug.Log("platform deleted");
            Object.Destroy(gameObject);
        }
    }
}
