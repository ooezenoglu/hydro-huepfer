using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y + 1, -10);
    }
}
