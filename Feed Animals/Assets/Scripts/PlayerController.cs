using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange = 24;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, 0, 0);          
        }

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, 0, 0);
        }

        float xMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * xMove);

    }
}
