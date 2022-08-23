using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    public delegate void DelegateEvent(int numberOfPappers);
    public event DelegateEvent OnTrashEvent;

    int counter;

    private void Start()
    {
        counter = 0;
    }

    public int GetCounter()
    {
        return counter;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Papper Trash"))
        {
            counter++;
            OnTrashEvent?.Invoke(counter);
        }
    }
}
