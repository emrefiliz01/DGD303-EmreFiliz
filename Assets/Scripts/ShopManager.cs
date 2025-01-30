using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject upgradeMenuUI;

    [SerializeField] private Button closeButton;
    [SerializeField] private Button damageUpgradeButton;
    [SerializeField] private Button healthUpgradeButton;
    [SerializeField] private Button speedUpgradeButton;

    [SerializeField] private Text coinCountText;
    [SerializeField] private PlayerStats playerStats;

    private bool isInShop = false;

    void Start()
    {
        shopCanvas.SetActive(false);
        upgradeMenuUI.SetActive(false);

        closeButton.onClick.AddListener(CloseShop);
        damageUpgradeButton.onClick.AddListener(UpgradeDamage);
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        speedUpgradeButton.onClick.AddListener(UpgradeSpeed);

        UpdateCoinUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered the shop!");
            isInShop = true;
            Time.timeScale = 0;
            ShowUpgradeMenu();
        }
    }

    void ShowUpgradeMenu()
    {
        if (upgradeMenuUI != null)
        {
            shopCanvas.SetActive(true);
            upgradeMenuUI.SetActive(true);
            Debug.Log("Shop Panel is now visible!");
        }
        else
        {
            Debug.LogWarning("Upgrade Menu UI is not assigned.");
        }
    }

    void CloseShop()
    {
        HideUpgradeMenu();
    }

    public void HideUpgradeMenu()
    {
        if (upgradeMenuUI != null)
        {
            upgradeMenuUI.SetActive(false);
            shopCanvas.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Shop Panel is now hidden.");
        }
        else
        {
            Debug.LogWarning("Upgrade Menu UI is not assigned.");
        }
    }

    void UpgradeDamage()
    {
        if (playerStats.coins >= 50)
        {
            playerStats.coins -= 50;
            playerStats.damage += 5;

            UpdateCoinUI();
            Debug.Log("Damage Upgraded! Current Damage: " + playerStats.damage);
        }
        else
        {
            Debug.Log("Not enough coins for damage upgrade!");
        }
    }

    void UpgradeHealth()
    {
        if (playerStats.coins >= 100)
        {
            playerStats.coins -= 100;
            playerStats.maxHealth += 10;

            UpdateCoinUI();
            Debug.Log("Health Upgraded! Current Health: " + playerStats.maxHealth);
        }
        else
        {
            Debug.Log("Not enough coins for health upgrade!");
        }
    }

    void UpgradeSpeed()
    {
        if (playerStats.coins >= 200)
        {
            playerStats.coins -= 200;
            playerStats.moveSpeed += 1f;

            UpdateCoinUI();
            Debug.Log("Speed Upgraded! Current Speed: " + playerStats.moveSpeed);
        }
        else
        {
            Debug.Log("Not enough coins for speed upgrade!");
        }
    }

    void UpdateCoinUI()
    {
        coinCountText.text = "Coins: " + playerStats.coins.ToString();
    }
}
