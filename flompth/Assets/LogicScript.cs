using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public bool gameEnded = false;
    private int score = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public static float moveSpeed = 6;

    public void addScore(int score)
    {
        if (!gameEnded)
        {
            this.score += score;
            scoreText.text = this.score.ToString();
        }
    }

    public void newGame()
    {
        score = 0;
        gameEnded = false;
        moveSpeed = 6;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameEnded = true;
        gameOverScreen.SetActive(true);
    }
}
