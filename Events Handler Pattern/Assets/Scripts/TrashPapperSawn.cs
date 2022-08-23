using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPapperSawn : MonoBehaviour
{
    [SerializeField]
    GameObject Button;
    Button button;

    public GameObject Trash;

    private void Start()
    {
        button = Button.GetComponent<Button>();
        button.OnMouseClickEvent += OnMouseClick;
    }

    public void OnMouseClick(object sender, Button.OnMouseClickEventArgs args)
    {
        CheckUnsubscribe(args.clicks);
        CreateTrash();
    }

    void CheckUnsubscribe(int numberOfClicks)
    {
        if (numberOfClicks > 20)
        {
            button.OnMouseClickEvent -= OnMouseClick;
        }
    }

    private void CreateTrash()
    {
        Instantiate(Trash, transform.position, transform.rotation);
    }
}
