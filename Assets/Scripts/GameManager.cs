using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState = GameState.GameOver;

    public int score = 0;
    public Text scoreText;
    public Text clickToStartText;
    public float gameTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        StopGame();
    }

    private void Update()
    {
        if (gameState == GameState.GameOver && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }

        if (gameState == GameState.GameStarted)
        {
            gameTime += Time.deltaTime;
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void StopGame()
    {
        Debug.Log("Game Over");
        gameState = GameState.GameOver;
        FruitController.Instance.StopSpawningFruit();
        clickToStartText.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        gameState = GameState.GameStarted;
        FruitController.Instance.StartSpawningFruit();
        clickToStartText.gameObject.SetActive(false);

        ClearFruits();

        gameTime = 0f;
        score = 0;
        UpdateScoreText();
    }

    private void ClearFruits()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}

public enum GameState
{
    GameOver,
    GameStarted
}