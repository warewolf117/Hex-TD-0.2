﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject nextLevelButton;
    public Text levelClearedFailedText;

    bool endCheck = false;
    bool defeat = false;

    /*public string menuSceneName = "MainMenu";
    ScreenFader screenFader;

    public ScreenFader screenFader;
    public string menuSceneName = "MainMenu";*/

    public void Victory()
    {
        if(defeat == false)
        {
            Debug.Log("UI goes here");
            ui.SetActive(true);
            levelClearedFailedText.text = "Cleared";
            nextLevelButton.SetActive(true);
        }
        
        
    }
    public void Defeat()
    {
        ui.SetActive(true);
        levelClearedFailedText.text = "Failed";
        nextLevelButton.SetActive(false);
        if (ui.activeSelf)
        {
            if (endCheck == false)
            {
                // Time.timeScale = 0f;
                defeat = true;
                endCheck = true;
            }
            
        }
    }
}
