using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Hex TD Base 0.2";

    public ScreenFader screenFader;

    public void Play()
    {
        //Debug.Log("Loading Level");
        screenFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        //Debug.Log("Exiting");
        Application.Quit();
    }
}
