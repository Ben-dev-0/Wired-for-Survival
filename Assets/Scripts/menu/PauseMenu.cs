using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; // Reference to the pause menu UI
    public static PauseMenu Instance { get; private set; } // Singleton instance

    private bool isPaused; // Tracks whether the game is paused

    private void Awake()
    {
        // Ensure only one instance of PauseMenu exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Optional: Keep this object alive across scenes
    }

    public bool IsPaused() {  return isPaused; }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
