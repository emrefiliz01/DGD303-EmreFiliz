using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject upgradeMenuUI;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button damageUpgradeButton;
    [SerializeField] private Button healthUpgradeButton;
    [SerializeField] private Button movementSpeedUpgradeButton;
    [SerializeField] private Text coinCountText;
    [SerializeField] private PlayerStats playerStats;

    private bool isInShop = false;

    void Start()
    {
        upgradeMenuUI.SetActive(false);

        closeButton.onClick.AddListener(CloseShop);
        damageUpgradeButton.onClick.AddListener(UpgradeDamage);
        healthUpgradeButton.onClick.AddListener(UpgradeHealth);
        movementSpeedUpgradeButton.onClick.AddListener(UpgradeSpeed);
    }

    void Update()
    {
        if (isInShop && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInShop = true;
            ShowUpgradeMenu();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInShop = false;
            HideUpgradeMenu();
        }
    }

    void ShowUpgradeMenu()
    {
        upgradeMenuUI.SetActive(true);
    }

    void HideUpgradeMenu()
    {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1;
    }

    void CloseShop()
    {
        HideUpgradeMenu();
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
