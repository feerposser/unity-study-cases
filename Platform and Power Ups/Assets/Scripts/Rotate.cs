using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed;
    void Update()
    {
        transform.Rotate(transform.position, rotateSpeed);
    }
}
