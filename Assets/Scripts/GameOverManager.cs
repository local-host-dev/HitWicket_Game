using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the Game Over UI
    public float fallThreshold = -7f; // Y-position below which the game is considered over

    private bool isGameOver = false;

    void Update()
    {
        // Check if the Doofus has fallen below the fallThreshold
        if (transform.position.y < fallThreshold && !isGameOver)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true); // Display the Game Over UI
        Time.timeScale = 0f; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
