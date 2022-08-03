using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    
    public void SetPosition(Transform position)
    {
        transform.position = position.position;
    }
}
