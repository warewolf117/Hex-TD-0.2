using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for loading and reloading scenes

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject pauseButton;
    public ScreenFader screenFader;
    public string menuSceneName = "MainMenu";

    public void TogglePause()
    {
        ui.SetActive(true);
        pauseButton.SetActive(false);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    public void ToggleResume()
    {
        ui.SetActive(false);
        pauseButton.SetActive(true);
        if (!ui.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        //scenemanager.loadscene() selects the scene to load, in this we load the current scene
        screenFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Exit ()
    {
        screenFader.FadeTo(menuSceneName);
    }

    void Update ()
    {

    }
}
