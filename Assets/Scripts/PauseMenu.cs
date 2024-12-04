using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; // Assign the pause menu panel in the Inspector
    private bool isPaused = false;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true); // Show the pause menu
            Time.timeScale = 0f; // Pause the game
            isPaused = true;
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Hide the pause menu
            Time.timeScale = 1f; // Resume the game
            isPaused = false;
        }
        else
        {
            Debug.LogError("PauseMenuUI is not assigned in the Inspector!");
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f; // Ensure normal game time
        SceneManager.LoadScene(0); // Load the Main Menu (assumes it's at index 0)
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure normal game time
        Application.Quit(); // Quit the game

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exit Play Mode in the Editor
#endif
    }
}

