using UnityEngine;
using UnityEngine.UI;
using TMPro;  // Add this for TextMeshPro support
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverCanvas;  // The Canvas with the Game Over UI
    public TextMeshProUGUI gameOverText;  // Change from Text to TextMeshProUGUI
    public Button retryButton;         // The Button component for retry

    void Start()
    {
        // Ensure the Game Over UI is hidden at the start of the game
        gameOverCanvas.SetActive(false);

        // Set up the retry button to reload the scene
        retryButton.onClick.AddListener(ReloadScene);
    }

    // This method will be called when the ball is destroyed
    public void ShowGameOverScreen()
    {
        // Activate the Game Over UI
        gameOverCanvas.SetActive(true);

        // Set the "Game Over" text
        gameOverText.text = "Game Over";  // TextMeshPro uses .text
    }

    // This method is called to reload the scene when the retry button is pressed
    void ReloadScene()
    {
        // Unpause the game
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
