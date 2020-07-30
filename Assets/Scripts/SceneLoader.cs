using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // config params
    public static bool GameIsPaused = false;

    // cached references
    public GameObject pauseMenuUI;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause(); 
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    

    public void LoadStartingScene()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(0);
        GameIsPaused = false;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Continue()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    public void Restart()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }
}
