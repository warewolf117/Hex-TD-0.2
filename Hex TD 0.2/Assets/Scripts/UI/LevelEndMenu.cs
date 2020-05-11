
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEndMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject nextLevelButton;
    public Text levelClearedFailedText;

    public string menuSceneName = "MainMenu";
    ScreenFader screenFader;

    //public ScreenFader screenFader;
    //public string menuSceneName = "MainMenu";

    public void Victory()
    {
        ui.SetActive(true); 
        levelClearedFailedText.text = "Cleared";
        nextLevelButton.SetActive(true);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    public void Defeat()
    {
        ui.SetActive(true);
        levelClearedFailedText.text = "Failed";
        nextLevelButton.SetActive(false);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        //scenemanager.loadscene() selects the scene to load, in this we load the current scene
        screenFader.FadeTo(SceneManager.GetActiveScene().name);
        WaveSpawnerTopRight_Main.startFirstWave = 0;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        screenFader.FadeTo(menuSceneName);
    }
}
