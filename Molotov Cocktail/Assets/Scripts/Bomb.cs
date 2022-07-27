using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
