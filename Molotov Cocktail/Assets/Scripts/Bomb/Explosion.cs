using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private Animator anim;

    public float destroyTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        anim.SetTrigger("explode");
        Destroy(gameObject, destroyTime);
    }
}
