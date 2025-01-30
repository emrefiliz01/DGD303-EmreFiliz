using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        if (audioManager != null)
        {
            audioManager.PlayBackgroundMusic();
        }

        exitButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(ShowCredits);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && creditsPanel.activeSelf)
        {
            HideCredits();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !creditsPanel.activeSelf)
        {
            ReturnToMainMenu();
        }
    }

    public void ShowCredits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        if (audioManager != null)
        {
            audioManager.StopBackgroundMusic();
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
