using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.XR;

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
    private int[] weirdYoffsets = { 8, -7, 8, 8, -10 };
    private int[] weirdXoffsets = { -3, 2, -3, -3, -1};
    private int platformWidth = 14;
    public GameObject monsterPrefab; 


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

            GenerateMonster(lastSpawnPositionX + xOffset, lastSpawnPositionY + platformDistance);
            GenerateMonster(lastSpawnPositionX + xOffset - platformWidth, lastSpawnPositionY + platformDistance);

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
        var yOffset = 0;

        var x_temp = x;
        var x_temp_Mirror = x - mirrorOffset;
        while (x_temp < x + platformWidth)
        {
            var rand = Random.Range(0, blocks.Length);
            var block = blocks[rand];
            var blockDistance = Random.Range(1, 1.7f);
            Instantiate(block, new Vector3(x_temp+ weirdXoffsets[rand], y + yOffset + weirdYoffsets[rand], 0), Quaternion.identity);
            if(rand == 4) {
                block.transform.GetChild(1).transform.position = new Vector3(x_temp + 1, y - 15);
            }
            x_temp += block.transform.GetChild(0).GetComponent<Tilemap>().size.x + blockDistance;

            //mirror on the left
            x_temp_Mirror -= block.transform.GetChild(0).GetComponent<Tilemap>().size.x;
            Instantiate(block, new Vector3(x_temp_Mirror + weirdXoffsets[rand], y + yOffset + weirdYoffsets[rand], 0), Quaternion.identity);
            if (rand == 4)
            {
                block.transform.GetChild(1).transform.position = new Vector3(x_temp_Mirror + 1, y - 15);
            }
            x_temp_Mirror -= blockDistance;

            yOffset += 2;
        }

        var rand2 = Random.Range(0, blocks.Length);
        yOffset -= 4;
        Instantiate(blocks[rand2], new Vector3(x_temp + weirdXoffsets[rand2], y + yOffset + weirdYoffsets[rand2], 0), Quaternion.identity);
        x_temp_Mirror -= blocks[rand2].transform.GetChild(0).GetComponent<Tilemap>().size.x;
        Instantiate(blocks[rand2], new Vector3(x_temp_Mirror + weirdXoffsets[rand2], y + yOffset + weirdYoffsets[rand2], 0), Quaternion.identity);

    }

    void GenerateMonster(float x, float y)
    {
        Vector3 spawnPosition = new Vector3(x, y, 0); 
        Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
    }
}
