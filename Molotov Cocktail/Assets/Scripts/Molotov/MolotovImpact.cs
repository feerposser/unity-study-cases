using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovImpact : MonoBehaviour
{

    Animator anim;

    public GameObject explosion;

    public bool throwning;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (throwning)
        {
            throwning = false;
            anim.SetTrigger("throw");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
