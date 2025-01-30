using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject upgradeMenuUI;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Text coinCountText;

    private bool isInShop = false;

    void Start()
    {
        shopCanvas.SetActive(false);
        upgradeMenuUI.SetActive(false);
        LoadPlayerStats();
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
            UpdateCoinUI();
            Debug.Log("Shop Panel is now visible!");
        }
        else
        {
            Debug.LogWarning("Upgrade Menu UI is not assigned.");
        }
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

    public void UpdateCoinUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + playerStats.coins.ToString();
        }
        else
        {
            Debug.LogWarning("Coin Count Text UI is not assigned.");
        }
    }

    public void BuyUpgrade(string upgradeType)
    {
        int cost = 0;
        bool purchased = false;

        switch (upgradeType)
        {
            case "Damage":
                cost = 30;
                if (playerStats.coins >= cost)
                {
                    playerStats.coins -= cost;
                    playerStats.damage += 5;
                    purchased = true;
                    Debug.Log("Damage upgrade purchased! New Damage: " + playerStats.damage);
                }
                else
                {
                    Debug.Log("Not enough coins for damage upgrade!");
                }
                break;

            case "Health":
                cost = 50;
                if (playerStats.coins >= cost)
                {
                    playerStats.coins -= cost;
                    playerStats.maxHealth += 10;
                    purchased = true;
                    Debug.Log("Health upgrade purchased! New Max Health: " + playerStats.maxHealth);
                }
                else
                {
                    Debug.Log("Not enough coins for health upgrade!");
                }
                break;

            case "MovementSpeed":
                cost = 100;
                if (playerStats.coins >= cost)
                {
                    playerStats.coins -= cost;
                    playerStats.moveSpeed += 1;
                    purchased = true;
                    Debug.Log("Movement speed upgrade purchased! New Speed: " + playerStats.moveSpeed);
                }
                else
                {
                    Debug.Log("Not enough coins for movement speed upgrade!");
                }
                break;

            default:
                Debug.LogWarning("Unknown upgrade type: " + upgradeType);
                break;
        }

        if (purchased)
        {
            SavePlayerStats();
        }
        else
        {
            PlayerPrefs.SetInt("Coins", playerStats.coins);
            PlayerPrefs.Save();
        }

        UpdateCoinUI();
    }

    public void SavePlayerStats()
    {
        PlayerPrefs.SetInt("Coins", playerStats.coins);
        PlayerPrefs.SetInt("Damage", playerStats.damage);
        PlayerPrefs.SetInt("MaxHealth", playerStats.maxHealth);
        PlayerPrefs.SetFloat("MovementSpeed", playerStats.moveSpeed);

        PlayerPrefs.Save();
        Debug.Log("Player stats saved! Coins: " + playerStats.coins);
    }

    public void LoadPlayerStats()
    {
        playerStats.coins = PlayerPrefs.GetInt("Coins", 0);
        playerStats.damage = PlayerPrefs.GetInt("Damage", 10);
        playerStats.maxHealth = PlayerPrefs.GetInt("MaxHealth", 100);
        playerStats.moveSpeed = PlayerPrefs.GetFloat("MovementSpeed", 5f);

        Debug.Log($"Player stats loaded! Coins: {playerStats.coins}, Damage: {playerStats.damage}, Health: {playerStats.maxHealth}, Speed: {playerStats.moveSpeed}");
    }
}
