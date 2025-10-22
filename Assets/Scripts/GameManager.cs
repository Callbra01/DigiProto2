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

    public int lives = 3;
    public int ballHitCount = 0;

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
        if (lives <= 0)
        {
            PlayerPrefs.SetInt("Score", playerScore);
            SceneManager.LoadScene("Score Scene");
        }

        scoreTextReference.text = $"Lives: {lives} | Score: {playerScore}";


        HandleSlowDown();

    }

    public void HandleSlowDown()
    {
        if (powerSlider.value >= 0.3f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (powerSlider.value >= 0.1f)
                {
                    timeModifier = 0.5f;
                }
                powerSlider.value -= 0.2f * Time.deltaTime;
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
        lives--;
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
