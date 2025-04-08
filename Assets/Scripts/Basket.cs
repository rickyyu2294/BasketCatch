using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPoint.y = transform.position.y;
        transform.position = mouseWorldPoint;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Fruit fruit = other.GetComponent<Fruit>();
        if (fruit != null)
        {
            if (GameManager.Instance.gameState == GameState.GameStarted)
            {
                GameManager.Instance.AddScore(fruit.value);
                
            }
            Destroy(other.gameObject);
        }
    }
}
