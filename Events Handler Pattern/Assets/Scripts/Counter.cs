using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public GameObject TrashObject;

    Text textCounter;

    private void Start()
    {
        Trash trash = TrashObject.GetComponent<Trash>();
        trash.OnTrashEvent += OnPapperOnTrash;

        textCounter = GetComponent<Text>();
    }

    void OnPapperOnTrash(int pappers)
    {
        textCounter.text = "# " + pappers;
    }
}
