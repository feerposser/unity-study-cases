using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private PlayerController playerControllerScript;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2, 2);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(obstacle, transform.position, transform.rotation);
        }
        
    }
}
