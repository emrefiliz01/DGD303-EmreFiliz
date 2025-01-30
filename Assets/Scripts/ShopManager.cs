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

        switch (upgradeType)
        {
            case "Damage":
                cost = 30;
                if (playerStats.coins >= cost)
                {
                    playerStats.coins -= cost;
                    playerStats.damage += 5;
                    Debug.Log("Damage upgrade purchased!");
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
                    Debug.Log("Health upgrade purchased!");
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
                    Debug.Log("Movement speed upgrade purchased!");
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

        UpdateCoinUI();
    }
}
