using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D carRb;
    Rigidbody2D rightWhellRb;
    Rigidbody2D leftWhellRb;

    public enum InputState { NONE, RIGHT, LEFT }

    public InputState inputState = InputState.NONE;

    public float xMovement;
    public float torque;
    public float speed;

    void Start()
    {
        carRb = GameObject.Find("Body").GetComponent<Rigidbody2D>();
        rightWhellRb = GameObject.Find("Right Whell").GetComponent<Rigidbody2D>();
        leftWhellRb = GameObject.Find("Left Whell").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ComputeMovement();
    }

    void FixedUpdate()
    {
        ExecuteMovement();
        Debug.Log(rightWhellRb.velocity);
    }

    protected void ComputeMovement()
    {
        xMovement = Input.GetAxisRaw("Horizontal");

        if (xMovement > 0)
        {
            inputState = InputState.RIGHT;
        }
        else if (xMovement < 0)
        {
            inputState = InputState.LEFT;
        }
        else
        {
            inputState = InputState.NONE;
        }
    }

    protected void ExecuteMovement()
    {
        if (inputState != InputState.NONE && !GameManager.instance.freeze)
        {
            Move();
        } else if (GameManager.instance.freeze)
        {
            if (rightWhellRb.velocity.x <= 0)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    protected void Move()
    {
        //https://www.youtube.com/watch?v=8PZdY_VfOOI&list=WL&index=14&ab_channel=CrieSeusJogos
        carRb.AddTorque(-xMovement * torque * Time.fixedDeltaTime);
        rightWhellRb.AddTorque(-xMovement * speed * Time.fixedDeltaTime);
        leftWhellRb.AddTorque(-xMovement * speed * Time.fixedDeltaTime);
    }
}
