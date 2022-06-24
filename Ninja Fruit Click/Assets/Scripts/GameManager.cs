using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public int score;
    public bool isGameActive = false;
    public float spawnRate = 2;

    private void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score;
    }

    IEnumerator SpawnObjects()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, gameObjects.Count);
            Instantiate(gameObjects[index]);
        }
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int dificulty)
    {
        isGameActive = true;
        StartCoroutine("SpawnObjects");
        UpdateScore(0);
        spawnRate /= dificulty;
    }
}
