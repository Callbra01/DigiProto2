using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePaddle : MonoBehaviour
{

    public int direction = 1;

    Rigidbody2D rb;
    public float speed = 2.0f;
    bool isFlipped = false;

    public bool reverse = false;

    GameManager gameManagerRef = GameManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipDir();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(0, direction * speed * gameManagerRef.timeModifier);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bound")
        {
            isFlipped = !isFlipped;
        }
    }

    void FlipDir()
    {
        if (reverse)
        {
            if (isFlipped)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
        }
        else
        {
            if (isFlipped)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
        }

    }
}
