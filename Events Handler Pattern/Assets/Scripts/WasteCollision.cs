using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteCollision : MonoBehaviour
{

    public event Action<int> OnWaste;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Papper Trash"))
        {
            OnWaste?.Invoke(1);
        }
    }
}
