using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPosition : MonoBehaviour
{

    public Particle receiver;

    void Update()
    {
        receiver.SetPosition(transform);
    }
}
