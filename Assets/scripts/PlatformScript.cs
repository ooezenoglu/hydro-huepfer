using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public int destructionDistance = 20;
    public GameObject player;
    public float playerPos;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.PlayerIsAlive) return;
        playerPos = player.transform.position.y;
        if (playerPos - destructionDistance > transform.position.y)
        {
            Debug.Log("platform deleted");
            Object.Destroy(gameObject);
        }
    }
}
