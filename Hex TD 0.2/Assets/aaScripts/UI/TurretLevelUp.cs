using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretLevelUp : MonoBehaviour
{
    int standardLevelUpCost = 10;
    int poisonLevelUpCost = 11;
    int laserLevelUpCost = 12;
    int minigunLevelUpCost = 13;
    int aoeLevelUpCost = 14;

    public Text upgradeCurrencyText;

    public Text standardTurretLevelText;
    public Text poisonTurretLevelText;
    public Text laserTurretLevelText;
    public Text minigunTurretLevelText;
    public Text aoeTurretLevelText;

    public Text standardLevelUpCostText;
    public Text poisonLevelUpCostText;
    public Text laserLevelUpCostText;
    public Text minigunLevelUpCostText;
    public Text aoeLevelUpCostText;

    public Button standardButton;
    public Button poisonButton;
    public Button laserButton;
    public Button minigunButton;
    public Button aoeButton;

    bool[] standardUpgradeLevel = {true, false, false, false, false, false, false, false, false, false};
    bool[] poisonUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] laserUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] minigunUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };
    bool[] aoeUpgradeLevel = { true, false, false, false, false, false, false, false, false, false };

    int standardPreviousUpgradeLevel = -1;
    int poisonPreviousUpgradeLevel = -1;
    int laserPreviousUpgradeLevel = -1;
    int minigunPreviousUpgradeLevel = -1;
    int aoePreviousUpgradeLevel = -1;

    int standardUpgradeLevelNumber = 0;
    int poisonUpgradeLevelNumber = 0;
    int laserUpgradeLevelNumber = 0;
    int minigunUpgradeLevelNumber = 0;
    int aoeUpgradeLevelNumber = 0;

    bool startupUpdate = false;

    public static int upgradeCurrency = 50000;

    public void LevelUpStandard()
    {
        if (upgradeCurrency >= standardLevelUpCost && standardPreviousUpgradeLevel < standardUpgradeLevelNumber
        && (upgradeCurrency - standardLevelUpCost) >= 0 && standardUpgradeLevelNumber < 9)
        {
            standardUpgradeLevel[standardUpgradeLevelNumber] = true;
            upgradeCurrency -= standardLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            standardLevelUpCost += standardLevelUpCost;
            standardLevelUpCostText.text = "Level Up\n$ " + standardLevelUpCost;
            standardPreviousUpgradeLevel = standardUpgradeLevelNumber;
            standardUpgradeLevelNumber++;
            standardTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);
        }
        if (standardUpgradeLevelNumber == 9)
        {
            standardLevelUpCostText.text = "Max level";
            standardButton.interactable = false;
        }
            

    }

    public void LevelUpPoison()
    {
        if (upgradeCurrency >= poisonLevelUpCost && poisonPreviousUpgradeLevel < poisonUpgradeLevelNumber
        && (upgradeCurrency - poisonLevelUpCost) >= 0 && poisonUpgradeLevelNumber < 9)
        {
            poisonUpgradeLevel[poisonUpgradeLevelNumber] = true;
            upgradeCurrency -= poisonLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            poisonLevelUpCost += poisonLevelUpCost;
            poisonLevelUpCostText.text = "Level Up\n$ " + poisonLevelUpCost;
            poisonPreviousUpgradeLevel = poisonUpgradeLevelNumber;
            poisonUpgradeLevelNumber++;
            poisonTurretLevelText.text = "LVL. " + (poisonUpgradeLevelNumber + 1);
        }
        if (poisonUpgradeLevelNumber == 9)
        {
            poisonLevelUpCostText.text = "Max level";
            poisonButton.interactable = false;
        }
            
    }

    public void LevelUpLaser()
    {
        if (upgradeCurrency >= laserLevelUpCost && laserPreviousUpgradeLevel < laserUpgradeLevelNumber
        && (upgradeCurrency - laserLevelUpCost) >= 0 && laserUpgradeLevelNumber < 9)
        {
            laserUpgradeLevel[laserUpgradeLevelNumber] = true;
            upgradeCurrency -= laserLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            laserLevelUpCost += laserLevelUpCost;
            laserLevelUpCostText.text = "Level Up\n$ " + laserLevelUpCost;
            laserPreviousUpgradeLevel = laserUpgradeLevelNumber;
            laserUpgradeLevelNumber++;
            laserTurretLevelText.text = "LVL. " + (laserUpgradeLevelNumber + 1);
        }
        if (laserUpgradeLevelNumber == 9)
        {
            laserLevelUpCostText.text = "Max level";
            laserButton.interactable = false;
        }
            
    }

    public void LevelUpMinigun()
    {
        if (upgradeCurrency >= minigunLevelUpCost && minigunPreviousUpgradeLevel < minigunUpgradeLevelNumber
        && (upgradeCurrency - minigunLevelUpCost) >= 0 && minigunUpgradeLevelNumber < 9)
        {
            minigunUpgradeLevel[minigunUpgradeLevelNumber] = true;
            upgradeCurrency -= minigunLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            minigunLevelUpCost += minigunLevelUpCost;
            minigunLevelUpCostText.text = "Level Up\n$ " + minigunLevelUpCost;
            minigunPreviousUpgradeLevel = minigunUpgradeLevelNumber;
            minigunUpgradeLevelNumber++;
            minigunTurretLevelText.text = "LVL. " + (minigunUpgradeLevelNumber + 1);
        }
        if (minigunUpgradeLevelNumber == 9)
        { 
            minigunLevelUpCostText.text = "Max level";
            minigunButton.interactable = false;
        }
    }
    

    public void LevelUpAoe()
    {
        if (upgradeCurrency >= aoeLevelUpCost && aoePreviousUpgradeLevel < aoeUpgradeLevelNumber
        && (upgradeCurrency - aoeLevelUpCost) >= 0 && aoeUpgradeLevelNumber < 9)
        {
            aoeUpgradeLevel[aoeUpgradeLevelNumber] = true;
            upgradeCurrency -= aoeLevelUpCost;
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            aoeLevelUpCost += aoeLevelUpCost;
            aoeLevelUpCostText.text = "Level Up\n$ " + aoeLevelUpCost;
            aoePreviousUpgradeLevel = aoeUpgradeLevelNumber;
            aoeUpgradeLevelNumber++;
            aoeTurretLevelText.text = "LVL. " + (aoeUpgradeLevelNumber + 1);
        }
        if (aoeUpgradeLevelNumber == 9)
        {
            aoeLevelUpCostText.text = "Max level";
            aoeButton.interactable = false;
        }
    }

    private void Update()
    {
        if (startupUpdate == false)
        {
            upgradeCurrencyText.text = upgradeCurrency.ToString();
            standardLevelUpCostText.text = "Level Up\n$ " + standardLevelUpCost;
            poisonLevelUpCostText.text = "Level Up\n$ " + poisonLevelUpCost;
            laserLevelUpCostText.text = "Level Up\n$ " + laserLevelUpCost;
            minigunLevelUpCostText.text = "Level Up\n$ " + minigunLevelUpCost;
            aoeLevelUpCostText.text = "Level Up\n$ " + aoeLevelUpCost;

            startupUpdate = true;
        }
    }
}
