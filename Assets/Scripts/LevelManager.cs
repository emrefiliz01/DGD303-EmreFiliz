using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelList;
    [SerializeField] private int targetLevel = 0;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private BackgroundBehaviour backgroundBehaviour;
    [SerializeField] private GameObject winBossLevelUI;

    [SerializeField] private float defaultCameraSize = 5f;
    [SerializeField] private float bossLevelCameraSize = 7f;

    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private PlayerStats playerStats;

    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        winBossLevelUI.SetActive(false);
        shopCanvas.SetActive(false);
        shopPanel.SetActive(false);

        LoadProgress();
        LoadSavedLevel();
    }

    public void StartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadSavedLevel();
        LoadProgress();
        LoadLevel();
        AdjustCameraAndBackground();

        audioManager.PlayBackgroundMusic();
    }

    private void LoadLevel()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            levelList[i].SetActive(i == targetLevel);
        }
    }

    public void NextLevel()
    {
        playerMovement.HideWinUI();
        targetLevel++;

        if (targetLevel >= levelList.Count)
        {
            ShowWinUI();
            return;
        }

        SaveProgress();
        LoadLevel();
        AdjustCameraAndBackground();
        Time.timeScale = 1;
    }

    private void AdjustCameraAndBackground()
    {
        if (targetLevel == 4)
        {
            backgroundBehaviour.SetBossLevel(true);
            Camera.main.orthographicSize = bossLevelCameraSize;
        }
        else
        {
            backgroundBehaviour.SetBossLevel(false);
            Camera.main.orthographicSize = defaultCameraSize;
        }
    }

    public void ShowWinUI()
    {
        Debug.Log("Boss Defeated! You won the game!");
        winBossLevelUI.SetActive(true);
        PlayerPrefs.DeleteKey("SavedLevel");
        PlayerPrefs.Save();
        Time.timeScale = 0;

        audioManager.StopBackgroundMusic();
    }

    public void ExitGame()
    {
        Debug.Log("Exiting Game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("SavedLevel", targetLevel);
        PlayerPrefs.SetInt("Coins", playerStats.coins);
        PlayerPrefs.SetInt("Damage", playerStats.damage);
        PlayerPrefs.SetInt("MaxHealth", playerStats.maxHealth);
        PlayerPrefs.SetFloat("MovementSpeed", playerStats.moveSpeed);
        PlayerPrefs.Save();
        Debug.Log("Progress Saved!");
    }

    private void LoadProgress()
    {
        targetLevel = PlayerPrefs.GetInt("SavedLevel", 0);
        playerStats.coins = PlayerPrefs.GetInt("Coins", playerStats.coins);
        playerStats.damage = PlayerPrefs.GetInt("Damage", playerStats.damage);
        playerStats.maxHealth = PlayerPrefs.GetInt("MaxHealth", playerStats.maxHealth);
        playerStats.moveSpeed = PlayerPrefs.GetFloat("MovementSpeed", playerStats.moveSpeed);

        Debug.Log("Progress Loaded!");
    }

    private void LoadSavedLevel()
    {
        targetLevel = PlayerPrefs.GetInt("SavedLevel", 0);
    }

    public void RestartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadSavedLevel();
        LoadProgress();
        LoadLevel();
        AdjustCameraAndBackground();
        Time.timeScale = 1;

        audioManager.PlayBackgroundMusic();
    }

    public void ShowShopCanvas()
    {
        if (shopCanvas != null && shopPanel != null)
        {
            shopCanvas.SetActive(true);
            shopPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Shop Canvas is now visible.");
        }
        else
        {
            Debug.LogWarning("Shop Canvas or Shop Panel not assigned!");
        }
    }

    public void HideShopCanvas()
    {
        if (shopCanvas != null && shopPanel != null)
        {
            shopCanvas.SetActive(false);
            shopPanel.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Shop Canvas is now hidden.");
        }
        else
        {
            Debug.LogWarning("Shop Canvas or Shop Panel not assigned!");
        }
    }
}
