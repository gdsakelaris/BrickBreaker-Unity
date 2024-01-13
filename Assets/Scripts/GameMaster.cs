using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    private int lives;
    public TextMeshProUGUI livesText;

    public int playerLife = 3;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);

        lives = 3;
        UpdateLives(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLife <= 0)
        {
            //game over
            SceneManager.LoadScene("GameOver");
        }


    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd;
        livesText.text = "Lives: " + lives;
    }
}
