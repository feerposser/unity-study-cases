using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    Rigidbody targetRB;
    GameManager gameManager;

    public int point;

    public ParticleSystem explosionParticle;

    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").gameObject.GetComponent<GameManager>();

        targetRB.AddForce(Vector3.up * Random.Range(12, 19), ForceMode.Impulse);
        targetRB.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        transform.position = new Vector3(Random.Range(-4, 4), -3);
    }

    private void OnMouseDown()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        gameManager.UpdateScore(point);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
        {
            Debug.Log("game oooooover");
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
}
