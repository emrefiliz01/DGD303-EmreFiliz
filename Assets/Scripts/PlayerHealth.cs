using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fillImage;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button restartButton;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        fillImage.fillAmount = 1f;
    }
    public void TakeDamage(int bulletDamage)
    {

        currentHealth = currentHealth - bulletDamage;

        fillImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if(deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        if(gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        if(restartButton!= null)
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
