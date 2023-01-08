using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public bool birdIsAlive = true;
    public GameObject bird;
    public AudioSource audioSource;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioSource.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        birdIsAlive = true;
    }
    public void gameOver(bool destroy)
    {
        gameOverScreen.SetActive(true);
        birdIsAlive = false;

        if (destroy)
        {
            Destroy(bird);
        }
    }
}
