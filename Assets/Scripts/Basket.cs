using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousWorldPos.y = transform.position.y;
        transform.position = mousWorldPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.name == "BottomWall")
        {
            Destroy(collision.gameObject);
        }
    }
}
