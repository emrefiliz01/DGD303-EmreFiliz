using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fillImage;

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
            Destroy(gameObject);
        }
    }
}
