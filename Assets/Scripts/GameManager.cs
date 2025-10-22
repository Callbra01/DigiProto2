using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    int boundPenalty = 50;

    public Slider powerSlider;

    public float timeModifier = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
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
        if (playerScore < 0 || hasGameEnded)
        {
            PlayerPrefs.SetInt("Score", playerScore);
            SceneManager.LoadScene("Score Scene");
        }

        scoreTextReference.text = $"Score: {playerScore}";

        if (!hasGameEnded)
        {
            storedBallPos = ballReference.transform.position;
            storedPaddlePos = paddleReference.transform.position;
        }

        HandleSlowDown();

    }

    public void HandleSlowDown()
    {
        if (powerSlider.value >= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timeModifier = 0.5f;
                powerSlider.value -= 0.3f;
            }
            else
            {
                timeModifier = 1f;
            }
        }
    }
    public void BallHitBounds()
    {
        playerScore -= boundPenalty;
        ballReference.gameObject.transform.position = Vector3.zero;
    }

    public void IncrementScore()
    {
        playerScore += scoreIncreaseAmt * streakModifier;
        if (powerSlider.value < 1)
        {
            powerSlider.value += 0.1f;
        }
    }
}
