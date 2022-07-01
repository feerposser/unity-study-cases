using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerPosition : MonoBehaviour
{

    private Transform playerPosition;

    void Start()
    {
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf)
        {
            transform.position = playerPosition.position;
            /*transform.rotation = Quaternion.Euler(new Vector3(0, 1, 0) * 2);*/
        } else
        {
            Debug.Log("Inactive");
        }
    }
}
