using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button restartButton;

    private PlayerStats playerStats;
    private float maxHealth;
    private float currentHealth;

    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();

        if (playerStats != null)
        {
            maxHealth = playerStats.maxHealth;
        }
        else
        {
            Debug.LogWarning("PlayerStats not found! Using default max health.");
            maxHealth = 100f;
        }

        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int bulletDamage)
    {
        currentHealth -= bulletDamage;
        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (fillImage != null)
        {
            fillImage.fillAmount = currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(true);
        }

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);
    }
}
