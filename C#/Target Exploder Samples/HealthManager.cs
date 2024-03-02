using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 3;
    public int damage = 1;

    private int currentHealth;
    private TextMeshProUGUI healthText;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (healthText == null)
        {
            healthText = GameObject.FindWithTag("Health").GetComponent<TextMeshProUGUI>();
        }

        if (gameManager == null)
        {
            gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        }

        currentHealth = startingHealth;
        healthText.text = "Lives: " + startingHealth;
    }

    public void UpdateHealth()
    {
        currentHealth -= damage;

        if (currentHealth < 1)
        {
            gameManager.GameOver();
        }

        healthText.text = "Lives: " + currentHealth;
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth;
        healthText.text = "Lives: " + currentHealth;
    }
}
