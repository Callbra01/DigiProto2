using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance {  get; private set; }

    private GameObject ballReference;
    private GameObject paddleReference;
    public TextMeshProUGUI scoreTextReference;

    Vector2 storedBallPos = Vector2.zero;
    Vector2 storedPaddlePos = Vector2.zero;

    bool hasGameEnded = false;

    int playerScore = 0;
    int scoreIncreaseAmt = 100;
    int streakModifier = 1;

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
        ballReference = Ball.instance.gameObject;
        paddleReference = Paddle.instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTextReference.text = $"Score: {playerScore}";

        if (!hasGameEnded)
        {
            storedBallPos = ballReference.transform.position;
            storedPaddlePos = paddleReference.transform.position;
        }
    }

    public void BallHitBounds()
    {
        hasGameEnded = true;
    }

    public void IncrementScore()
    {
        playerScore += scoreIncreaseAmt * streakModifier;
    }
}
