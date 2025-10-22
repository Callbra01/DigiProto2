using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance { get; private set; }

    float playerInput = 0;
    public float paddleSpeed = 10;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(0, 0, paddleSpeed * -playerInput);

        if (playerInput == -1)
        {
            
        }
        
        if (playerInput == 1)
        {

        }


    }
}
