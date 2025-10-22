using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    int playerScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = PlayerPrefs.GetInt("Score");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Final Score: {playerScore}";
    }
}
