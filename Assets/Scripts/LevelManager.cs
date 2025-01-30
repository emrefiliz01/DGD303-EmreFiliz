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

    void Start()
    {
        mainMenuCanvas.SetActive(true);
        winBossLevelUI.SetActive(false);
        LoadSavedLevel();
    }

    public void StartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadSavedLevel();
        LoadLevel();
        AdjustCameraAndBackground();
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
        PlayerPrefs.Save();
    }

    private void LoadSavedLevel()
    {
        targetLevel = PlayerPrefs.GetInt("SavedLevel", 0);
    }

    public void RestartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadSavedLevel();
        LoadLevel();
        AdjustCameraAndBackground();
        Time.timeScale = 1;
    }
}
