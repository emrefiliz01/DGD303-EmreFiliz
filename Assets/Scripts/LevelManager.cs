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
    [SerializeField] private Camera mainCamera;

    [SerializeField] private float defaultCameraSize = 5f;
    [SerializeField] private float bossLevelCameraSize = 7f;

    void Start()
    {
        mainMenuCanvas.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadSavedLevel();

        if (targetLevel == 4)
        {
            backgroundBehaviour.SetBossLevel(true);
            Camera.main.orthographicSize = bossLevelCameraSize;
        }
        else
        {
            Camera.main.orthographicSize = defaultCameraSize;
        }
    }

    private void LoadLevel()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            if (i == targetLevel)
            {
                levelList[i].SetActive(true);
            }
            else
            {
                levelList[i].SetActive(false);
            }
        }
    }

    public void NextLevel()
    {
        playerMovement.HideWinUI();

        targetLevel++;

        if (targetLevel >= levelList.Count)
        {
            targetLevel = 0;
        }

        PlayerPrefs.SetInt("SavedLevel", targetLevel);
        PlayerPrefs.Save();

        LoadLevel();

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

        Time.timeScale = 1;
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteKey("SavedLevel");
        targetLevel = 0;
        LoadLevel();
    }

    public void LoadSavedLevel()
    {
        targetLevel = PlayerPrefs.GetInt("SavedLevel", 0);
        LoadLevel();
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        mainMenuCanvas.SetActive(false);
        LoadLevel();
        Time.timeScale = 1;
    }
}
