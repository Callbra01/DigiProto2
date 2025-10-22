using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public static Ball instance {  get; private set; }

    public Transform paddleTransform;

    Vector2 intendedDir = Vector2.up;

    public float ballSpeed = 4f;

    Rigidbody2D rb;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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

        if (collision.gameObject.tag == "Bound")
        {
            GameManager.instance.BallHitBounds();
        }
    }

    private Vector2 CalcDir()
    {
        Vector2 position = this.transform.position;

        Vector2 result = new Vector2(position.x - paddleTransform.position.x, position.y - paddleTransform.position.y);

        return result.normalized;
    }
}
