using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rig;
    public float velocity = 5;
    public int damage = 20;
    public bool isRight;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            rig.velocity = Vector2.right * velocity;
        } else
        {
            rig.velocity = Vector2.left * velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.Damage(damage);
            Destroy(gameObject);
        }
    }
}
