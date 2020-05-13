using UnityEngine;
using UnityEngine.UI;

public class LevelEndMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject nextLevelButton;
    public Text levelClearedFailedText;

    /*public string menuSceneName = "MainMenu";
    ScreenFader screenFader;

    public ScreenFader screenFader;
    public string menuSceneName = "MainMenu";*/

    public void Victory()
    {
        Debug.Log("UI goes here");
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
}
