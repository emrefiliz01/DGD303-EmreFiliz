using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        if (audioManager == null)
        {
            Debug.LogError("AudioManager is NOT assigned in MainMenuManager!");
        }
        else
        {
            Debug.Log("AudioManager is assigned!");
        }

        musicButton.onClick.AddListener(ToggleMusic);
        soundButton.onClick.AddListener(ToggleSound);
    }

    void ToggleMusic()
    {
        audioManager.ToggleMusic();
    }

    void ToggleSound()
    {
        audioManager.ToggleSound();
    }

    void StartGame()
    {
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
        }
        else
        {
            Debug.LogError("AudioManager is NULL in StartGame!");
        }

        SceneManager.LoadScene("GameScene");
    }

    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit(); // Quits the game in a build
#endif
    }
}
