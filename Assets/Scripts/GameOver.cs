using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool isGameOver = false;

    public GameObject gameOverUI;

    void Update()
    {
        if (isGameOver)
        {
            showGameOverUI();
        }
        else
        {
            hideGameOverUI();
        }
    }

    void showGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        isGameOver = true;
    }

    void hideGameOverUI()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

    public void retry()
    {
        isGameOver = false;
        GameManager.restartGame();
        SceneManager.LoadScene(1);
    }

    public void loadMenu()
    {
        isGameOver = false;
        SceneManager.LoadScene(0);
    }
}
