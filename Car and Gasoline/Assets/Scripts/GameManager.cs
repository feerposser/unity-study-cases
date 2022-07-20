using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private float fuel;
    private Image fuelImage;

    public bool freeze = false;
    public GameObject gameOver;
    public static GameManager instance;

    void Start()
    {
        instance = this;
        fuelImage = GameObject.Find("Gas Status").GetComponent<Image>();

        fuel = fuelImage.fillAmount;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 && !freeze)
        {
            float input = Input.GetAxis("Horizontal");
            float value = input / 5000;

            if (input > 0)
            {
                value = -value;
            }
            
            UpdateFuel(value);
        }

        if (fuel <= 0)
        {
            freeze = true;
        }
        else
        {
            freeze = false;
        }
    }

    private void UpdateFuel(float value)
    {
        fuel += value;
        UpdateImage();
    }

    private void UpdateImage()
    {
        fuelImage.fillAmount = fuel;
    }

    public void AddGas(float value)
    {
        UpdateFuel(value);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
