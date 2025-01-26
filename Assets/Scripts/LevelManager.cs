using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelList;
    [SerializeField] private int targetLevel = 0;
    [SerializeField] private PlayerMovement playerMovement;


    void Start()
    {
        targetLevel = PlayerPrefs.GetInt("SavedLevel", 0);
        LoadLevel();
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
        
        if(targetLevel >= levelList.Count)
        {
            targetLevel= 0;
        }

        PlayerPrefs.SetInt("SavedLevel", targetLevel);
        PlayerPrefs.Save();

        LoadLevel();

        Time.timeScale = 1;
    }

    public void ResetProgress()
    {
        // Kaydý sýfýrlamak için
        PlayerPrefs.DeleteKey("SavedLevel");
        targetLevel = 0;
        LoadLevel();
    }
}
