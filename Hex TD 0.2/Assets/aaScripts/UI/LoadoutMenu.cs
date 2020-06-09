using UnityEngine;
using UnityEngine.UI;

public class LoadoutMenu : MonoBehaviour
{

    public Button[] turretSelectButtons;

    public static int turretQuantity = 3;
    public static int turretsSelected = 0;
    private int previousTurretsSelected = 0;

    public Text numberTurretsSelectedText;

    public static LevelEndMenu levelProgress;

    private void Start()
    {
    }

    public void selectTurrets()
    {
        if (turretsSelected < (turretQuantity + turretsSelected))
        {
            turretsSelected++;
            turretQuantity--;
        }
    }

   public void deselectTurrets()
    {
        if (turretsSelected > 0)
        {
            turretsSelected--;
            turretQuantity++;
        }
    }

    private void Update()
    {
        if (turretsSelected != previousTurretsSelected)
        {
            numberTurretsSelectedText.text = turretQuantity.ToString();
            previousTurretsSelected = turretsSelected;
        }
    }



}