using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;
    public Transform focalPoint;
    public GameObject powerUpIndicator;

    public float playerSpeed = 10;
    public bool isPowered = false;
    public float powerUpStrength = 15;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.forward * playerSpeed * vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            isPowered = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine("PowerUpCountDownRoutine", 5);
        }
    }

    IEnumerator PowerUpCountDownRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        isPowered = false;
        powerUpIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPowered)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 forceDirection = collision.gameObject.transform.position - gameObject.transform.position;

            enemyRb.AddForce(forceDirection * powerUpStrength, ForceMode.Impulse);
        }
    }
}
