using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private Text coinCountText;

    public void AddCoin(int amount)
    {
        if (playerStats != null)
        {
            playerStats.coins += amount;
            Debug.Log("Coins: " + playerStats.coins);
            UpdateCoinUI();
        }
        else
        {
            Debug.LogError("PlayerStats is not assigned in CoinManager.");
        }
    }


    private void UpdateCoinUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + playerStats.coins.ToString();
        }
        else
        {
            Debug.LogError("Coin Count Text UI is not assigned.");
        }
    }
}
