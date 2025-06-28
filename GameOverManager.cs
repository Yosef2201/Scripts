using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject restartButton;

    void Start()
    {
        if (restartButton != null)
            restartButton.SetActive(false);
    }

    public void ShowRestartButton()
    {
        if (restartButton != null)
            restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
