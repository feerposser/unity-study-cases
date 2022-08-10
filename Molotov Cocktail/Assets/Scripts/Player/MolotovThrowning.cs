using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovThrowning : MonoBehaviour
{

    [SerializeField] private GameObject aim;
    [SerializeField] private float launchForce;
    Vector2 direction;

    GameObject[] points;

    public GameObject molotov;
    public Transform shotPosition;

    public int numberOfPoints;
    public float spaceBetweenPoints;

    void Start()
    {
        points = new GameObject[numberOfPoints];
        for (int i=0; i<points.Length; i++)
        {
            points[i] = Instantiate(aim, shotPosition.position, Quaternion.identity);
        }
    }
        
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - (Vector2)transform.position;
        transform.right = direction;

        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = AimPosition(i * spaceBetweenPoints);
        }

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

    Vector2 AimPosition(float t)
    {
        Vector2 position = (Vector2) shotPosition.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }
}
