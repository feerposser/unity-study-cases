using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 40;
    Animator anim;
    Transform playerPosition;
    Rigidbody2D enemyRB;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        enemyRB.AddForce((playerPosition.position - transform.position).normalized, ForceMode2D.Force);
        enemyRB.velocity = Vector2.left;
    }

    public void Damage(int damage)
    {
        health -= damage;
        anim.SetTrigger("getHit");

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
