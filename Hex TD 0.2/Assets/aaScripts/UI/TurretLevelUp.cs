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

    private void Awake()
    {
        upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
    }

    public void LevelUpStandard()
    {       
            if (PlayerStats.upgradeCurrency >= standardLevelUpCost && standardPreviousUpgradeLevel < standardUpgradeLevelNumber
            && (PlayerStats.upgradeCurrency - standardLevelUpCost) >= 0 && standardUpgradeLevelNumber < 9)
            {   
                standardUpgradeLevel[standardUpgradeLevelNumber] = true;
                PlayerStats.upgradeCurrency -= standardLevelUpCost;
                upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
                standardLevelUpCost += standardLevelUpCost;     
                standardPreviousUpgradeLevel = standardUpgradeLevelNumber;
                standardUpgradeLevelNumber++;
                standardTurretLevelText.text = "LVL. " + (standardUpgradeLevelNumber + 1);

            
                Debug.Log("upgrade level: " + standardUpgradeLevel[standardUpgradeLevelNumber -1]);
                Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
            }
        else if (standardUpgradeLevelNumber >= 9)
        {
            Debug.Log("max level reached");
        }
        else if (PlayerStats.upgradeCurrency < standardLevelUpCost || (PlayerStats.upgradeCurrency - standardLevelUpCost) < 0)
                {
                    Debug.Log("Insufficient funds");
                }
            

    }

    public void LevelUpPoison()
    {
        if (PlayerStats.upgradeCurrency >= poisonLevelUpCost && poisonPreviousUpgradeLevel < poisonUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - poisonLevelUpCost) >= 0 && poisonUpgradeLevelNumber < 9)
        {
            poisonUpgradeLevel[poisonUpgradeLevelNumber] = true;
            PlayerStats.upgradeCurrency -= poisonLevelUpCost;
            upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
            poisonLevelUpCost += poisonLevelUpCost;
            poisonPreviousUpgradeLevel = poisonUpgradeLevelNumber;
            poisonUpgradeLevelNumber++;
            poisonTurretLevelText.text = "LVL. " + (poisonUpgradeLevelNumber + 1);

            Debug.Log("upgrade level: " + poisonUpgradeLevel[poisonUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpLaser()
    {
        if (PlayerStats.upgradeCurrency >= laserLevelUpCost && laserPreviousUpgradeLevel < laserUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - laserLevelUpCost) >= 0 && laserUpgradeLevelNumber < 9)
        {
            laserUpgradeLevel[laserUpgradeLevelNumber] = true;
            PlayerStats.upgradeCurrency -= laserLevelUpCost;
            upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
            laserLevelUpCost += laserLevelUpCost;
            laserPreviousUpgradeLevel = laserUpgradeLevelNumber;
            laserUpgradeLevelNumber++;
            laserTurretLevelText.text = "LVL. " + (laserUpgradeLevelNumber + 1);

            Debug.Log("upgrade level: " + laserUpgradeLevel[laserUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpMinigun()
    {
        if (PlayerStats.upgradeCurrency >= minigunLevelUpCost && minigunPreviousUpgradeLevel < minigunUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - minigunLevelUpCost) >= 0 && minigunUpgradeLevelNumber < 9)
        {
            minigunUpgradeLevel[minigunUpgradeLevelNumber] = true;
            PlayerStats.upgradeCurrency -= minigunLevelUpCost;
            upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
            minigunLevelUpCost += minigunLevelUpCost;
            minigunPreviousUpgradeLevel = minigunUpgradeLevelNumber;
            minigunUpgradeLevelNumber++;
            minigunTurretLevelText.text = "LVL. " + (minigunUpgradeLevelNumber + 1);

            Debug.Log("upgrade level: " + minigunUpgradeLevel[minigunUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpAoe()
    {
        if (PlayerStats.upgradeCurrency >= aoeLevelUpCost && aoePreviousUpgradeLevel < aoeUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - aoeLevelUpCost) >= 0 && aoeUpgradeLevelNumber < 9)
        {
            aoeUpgradeLevel[aoeUpgradeLevelNumber] = true;
            PlayerStats.upgradeCurrency -= aoeLevelUpCost;
            upgradeCurrencyText.text = PlayerStats.upgradeCurrency.ToString();
            aoeLevelUpCost += aoeLevelUpCost;
            aoePreviousUpgradeLevel = aoeUpgradeLevelNumber;
            aoeUpgradeLevelNumber++;
            aoeTurretLevelText.text = "LVL. " + (aoeUpgradeLevelNumber + 1);

            Debug.Log("upgrade level: " + aoeUpgradeLevel[aoeUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }
}
