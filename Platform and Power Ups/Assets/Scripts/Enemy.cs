using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;

    Rigidbody enemyRb;
    Transform player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
        FallDetection();
    }

    void FallDetection()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    void FollowPlayer()
    {
        enemyRb.AddForce((player.position - transform.position).normalized * speed);
    }
}
