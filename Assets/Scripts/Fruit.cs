﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public AudioClip pop;
    public int value { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        value = CalculateValue();
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameState.GameOver) value = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BottomWall")
        {
            // End game
            HandleFruitOutOfBounds();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    internal void PlayPop()
    {
        AudioSource.PlayClipAtPoint(pop, transform.position);
    }

    private void HandleFruitOutOfBounds()
    {
        if (GameManager.Instance.gameState == GameState.GameStarted)
        {
            GameManager.Instance.StopGame();
        }
        Destroy(gameObject);
    }

    private int CalculateValue()
    {
        return (int) GameManager.Instance.gameTime + 1;
    }
}
