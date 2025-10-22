using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform paddleTransform;

    Vector2 intendedDir = Vector2.up;

    public float ballSpeed = 4f;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = intendedDir * ballSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            intendedDir = CalcDir();
        }
    }

    private Vector2 CalcDir()
    {
        Vector2 position = this.transform.position;

        Vector2 result = new Vector2(position.x - paddleTransform.position.x, position.y - paddleTransform.position.y);

        return result.normalized;
    }
}
