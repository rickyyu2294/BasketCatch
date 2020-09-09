using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    public GameObject fruit;
    public float spawnDelay = 1.5F;
    public float minSpawnMod = .2F;
    public float maxSpawnMod = 1.2F;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = spawnDelay + UnityEngine.Random.Range(minSpawnMod, maxSpawnMod);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > spawnDelay)
        {
            float width = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelWidth, 0)).x;
            Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Random.Range(0, Screen.width), Screen.height));
            Instantiate(fruit, pos, Quaternion.identity);
            spawnDelay = spawnDelay + UnityEngine.Random.Range(minSpawnMod, maxSpawnMod);
        }
    }
}
