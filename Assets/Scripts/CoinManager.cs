using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private Text coinCountText;

    private int coinCount = 0;

    void Start()
    {
        UpdateCoinCountUI();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinCountUI();
    }

    private void UpdateCoinCountUI()
    {
        coinCountText.text = "Coins: " + coinCount.ToString();
    }
}
