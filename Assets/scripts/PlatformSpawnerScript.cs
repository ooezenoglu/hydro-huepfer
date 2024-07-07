using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    private int platformHight;
    private GameObject player;

    private int lastSpawnPositionY = 0;
    private int lastSpawnPositionX = 0;
    public int platformDistance = 15;
    public int xOffset = 0;
    private int[] offsets = {-20, 20};

    public float PlayerPos;


    //Jump and Run
    [SerializeField] private GameObject[] blocks;
    public int mirrorOffset = 6;
    private int[] weirdYoffsets = {1, -14, 1, 1};
    private int[] weirdXoffsets = { -3, 2, -3, -3};


    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindWithTag("Player");
        PlayerPos = player.transform.position.y;
        Instantiate(platform, new Vector3(0, 20, 0), Quaternion.identity);
        GenerateJumpAndRun(0 + xOffset, 20);
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
            GenerateJumpAndRun(lastSpawnPositionX + xOffset, lastSpawnPositionY + platformDistance);

            lastSpawnPositionY += platformDistance;
            lastSpawnPositionX += xOffset;
        }

       
    }


    void GeneratePlatform(int x, int y)
    {
        Instantiate(platform, new Vector3(x, y, 0), Quaternion.identity);
    }

    void GenerateJumpAndRun(float x, float y)
    {
        var platformWidth = 13;
        var yOffset = 7;
        //var xOffset = 15;

        var x_temp = x;
        var x_temp_Mirror = x - mirrorOffset;
        while (x_temp < x + platformWidth)
        {
            var rand = Random.Range(0, blocks.Length - 1);
            var block = blocks[rand];
            Instantiate(block, new Vector3(x_temp+ weirdXoffsets[rand], y + yOffset + weirdYoffsets[rand], 0), Quaternion.identity);
            x_temp += block.transform.GetChild(0).GetComponent<Tilemap>().size.x + 1;


            x_temp_Mirror -= block.transform.GetChild(0).GetComponent<Tilemap>().size.x;
            Instantiate(block, new Vector3(x_temp_Mirror + weirdXoffsets[rand], y + yOffset + weirdYoffsets[rand], 0), Quaternion.identity);
            x_temp_Mirror--;

            yOffset += 2;

        }

    }
}
