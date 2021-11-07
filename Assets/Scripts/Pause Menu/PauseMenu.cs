using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject settingsMenu;
    public GameObject gamecontroller;

    public static bool GameIsPaused = false;

    public void ExitToMainMenu()
    {
        PlayerPrefs.SetInt("currentLVL", SceneManager.GetActiveScene().buildIndex);
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void GameSettings()
    {
        settingsMenu.SetActive(true);
        gamecontroller.SetActive(false);
        gameObject.SetActive(false);
    }
    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(GameIsPaused)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
    }
}
