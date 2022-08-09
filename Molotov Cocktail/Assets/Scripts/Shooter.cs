using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public float launchForce;
    public GameObject molotov;
    public Transform shotPosition;

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject molotov = Instantiate(this.molotov, shotPosition.position, shotPosition.rotation);
        molotov.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        molotov.GetComponent<MolotovImpact>().throwning = true;
    }
}
