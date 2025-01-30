using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
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
