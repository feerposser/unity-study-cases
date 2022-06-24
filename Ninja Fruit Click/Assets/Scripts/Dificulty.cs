using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dificulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    private GameObject dificultyOptions;

    public int dificulty;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dificultyOptions = GameObject.Find("Dificulty");
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDificultylistener);
    }

    private void SetDificultylistener()
    {
        Debug.Log(gameObject.name + " was clicked.");
        dificultyOptions.SetActive(false);
        gameManager.StartGame(dificulty);
    }
}
