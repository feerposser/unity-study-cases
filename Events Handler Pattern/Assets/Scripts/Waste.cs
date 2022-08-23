using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waste : MonoBehaviour
{
    [SerializeField]
    GameObject WastingEvent;

    public int counter;
    public Text text;

    private void Start()
    {
        counter = 0;

        text = GetComponent<Text>();

        WasteCollision waste = WastingEvent.GetComponent<WasteCollision>();
        waste.OnWaste += OnWaste;
    }

    void OnWaste(int number)
    {
        counter += number;
        text.text = "Waste: " + counter;
    }
}
