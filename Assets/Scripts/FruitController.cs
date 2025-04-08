using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    public static FruitController Instance;

    public GameObject fruit;
    const float INITIAL_DELAY = 1.5F;
    const float MIN_DELAY = .1F;
    const float CONSTANT = .03F;

    private float timeSinceLastSpawn = 0f;
    public float timeToSpawnNextFruit;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        timeToSpawnNextFruit = CalculateDelay();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (GameManager.Instance.gameState != GameState.GameStarted) return;

        if (timeSinceLastSpawn > timeToSpawnNextFruit)
        {
            timeSinceLastSpawn = 0f;
            SpawnFruit();
            float delay = CalculateDelay();
            timeToSpawnNextFruit = delay;
        }
    }

    private void SpawnFruit()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height));
        Instantiate(fruit, pos, Quaternion.identity);
    }

    private float CalculateDelay()
    {
        float delay = Mathf.Max(MIN_DELAY, INITIAL_DELAY + (-GameManager.Instance.gameTime * CONSTANT));
        return delay;
    }
}
