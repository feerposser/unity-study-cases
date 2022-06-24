using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rigidBody;
    Animator anim;
    public GameObject bow;
    public Transform bowSpawm;

    public float velocity = 5;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Bow();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.velocity = Vector2.right * velocity;
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigidBody.velocity = Vector2.left * velocity;
            anim.SetBool("isRunning", true);
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
            anim.SetBool("isRunning", false);
        }
    }

    void Bow()
    {
        StartCoroutine("BowFire");
        
    }

    IEnumerator BowFire()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("isBowing");
            bow.GetComponent<Arrow>().isRight = true;

            GameObject BowObject = Instantiate(bow, bowSpawm.position, bowSpawm.rotation);

            yield return new WaitForSeconds(1f);

        }
        
    }
}
