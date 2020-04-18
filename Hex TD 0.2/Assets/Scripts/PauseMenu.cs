using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//for loading and reloading scenes

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject pauseButton;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu ()
    {

    }

    void Update ()
    {

    }
}
