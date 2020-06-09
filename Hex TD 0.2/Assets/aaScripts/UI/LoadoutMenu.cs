using UnityEngine;
using UnityEngine.UI;

public class LoadoutMenu : MonoBehaviour
{
    public ScreenFader screenFader;

    public Button[] turretSelectButtons;

    public int turretQuantity = 3;
    private int turretsSelected = 0;

    public Text numberTurretsSelected;

    public static LevelEndMenu levelProgress;

    private void Start()
    {
        selectableTurrets();      
    }

    void selectableTurrets()
    {
        turretsSelected ++;
    }

    private void Update()
    {
        
    }

    public void SelectLevel(string levelName)
    {
        screenFader.FadeTo(levelName);
    }


}