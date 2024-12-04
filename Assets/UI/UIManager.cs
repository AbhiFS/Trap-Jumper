using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    //Activate game over screen
    public void GameOver()
    {
        Debug.Log("GameOver called."); // Add this log
        if (gameOverScreen == null)
        {
            Debug.LogError("GameOverScreen is not assigned in the Inspector!");
            return;
        }

        gameOverScreen.SetActive(true);

        if (SoundManager.instance == null)
        {
            Debug.LogError("SoundManager instance is null!");
            return;
        }

        SoundManager.instance.PlaySound(gameOverSound);
    }
    //Game over functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(); //Quits the game (only works on build)
        UnityEditor.EditorApplication.isPlaying = false;

    }

}
