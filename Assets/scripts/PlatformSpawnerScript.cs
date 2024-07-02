using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    private int platformHight;
    private GameObject player;

    private int lastSpawnPositionY = 0;
    private int lastSpawnPositionX = 0;
    public int platformDistance = 20;
    public int xOffset = 0;
    private int[] offsets = {-20, 20};

    //ladder activated maybe?
    bool needToGenerate = false;

    public float PlayerPos;


    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player");
        PlayerPos = player.transform.position.y;
        Instantiate(platform, new Vector3(0, 20, 0), Quaternion.identity);
        lastSpawnPositionY = 20;
        lastSpawnPositionX = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.PlayerIsAlive) return;
        PlayerPos = player.transform.position.y;
        var distanceFromNextPlatform = lastSpawnPositionY - PlayerPos;

        if(distanceFromNextPlatform < 15)
        {
            xOffset = offsets[Random.Range(0, offsets.Length)];
            GeneratePlatform(lastSpawnPositionX + xOffset, lastSpawnPositionY + platformDistance);
            lastSpawnPositionY += platformDistance;
            lastSpawnPositionX += xOffset;
        }

       
    }


    void GeneratePlatform(int x, int y)
    {
        Instantiate(platform, new Vector3(x, y, 0), Quaternion.identity);
    }



}
