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

    private Coroutine spawnRoutine;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartSpawningFruit()
    {
        spawnRoutine = StartCoroutine(SpawnFruit());
    }

    public void StopSpawningFruit()
    {
        StopCoroutine(spawnRoutine);
    }

    private IEnumerator SpawnFruit()
    {
        while (true)
        {
            float delay = CalculateDelay();
            yield return new WaitForSeconds(delay);

            Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height));
            Instantiate(fruit, pos, Quaternion.identity);
        }
    }

    private float CalculateDelay()
    {
        float delay = Mathf.Max(MIN_DELAY, INITIAL_DELAY + (-GameManager.Instance.gameTime * CONSTANT));
        return delay;
    }
}
