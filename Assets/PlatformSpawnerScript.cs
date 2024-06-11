using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platform;
    private int platformHight;
    private int playerPos;

    //ladder activated maybe?
    bool needToGenerate = false;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player");

        /*
        var pos = playerPos.transform.position.x;
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (needToGenerate)
        {

        }   

       
    }


    void GeneratePlatform(int x, int y)
    {
        Instantiate(platform, new Vector3(x, y, 0), Quaternion.identity);
    }



}
