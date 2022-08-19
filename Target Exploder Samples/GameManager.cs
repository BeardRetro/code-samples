using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject player;

    private bool gameIsOver = false;
    private ScoreManager scoreManager;
    private HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        gameIsOver = false;

        if (gameOverScreen == null)
        {
            gameOverScreen = GameObject.FindWithTag("Game Over");
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
            player.SetActive(true);
        }

        scoreManager = gameObject.GetComponent<ScoreManager>();
        healthManager = gameObject.GetComponent<HealthManager>();
    }

    //Displays the Game Over screen and disables the player
    public void GameOver()
    {
        gameIsOver = true;

        gameOverScreen.SetActive(true);
        player.SetActive(false);
    }

    public void RestartGame()
    {
        gameIsOver = false;

        gameOverScreen.SetActive(false);
        player.SetActive(true);

        scoreManager.ResetScore();
        healthManager.ResetHealth();
    }
}
