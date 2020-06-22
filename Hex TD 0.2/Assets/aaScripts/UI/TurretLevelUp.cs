using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLevelUp : MonoBehaviour
{
    int standardLevelUpCost = 10;
    int poisonLevelUpCost = 11;
    int laserLevelUpCost = 12;
    int minigunLevelUpCost = 13;
    int aoeLevelUpCost = 14;

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


    public void LevelUpStandard()
    {       
            if (PlayerStats.upgradeCurrency >= standardLevelUpCost && standardPreviousUpgradeLevel < standardUpgradeLevelNumber
            && (PlayerStats.upgradeCurrency - standardLevelUpCost) >= 0 && standardUpgradeLevelNumber < 11)
            {   
                standardUpgradeLevel[standardUpgradeLevelNumber] = true;
                standardLevelUpCost += standardLevelUpCost;
                PlayerStats.upgradeCurrency -= standardLevelUpCost;
                standardPreviousUpgradeLevel = standardUpgradeLevelNumber;
                standardUpgradeLevelNumber++;
            
                Debug.Log("upgrade level: " + standardUpgradeLevel[standardUpgradeLevelNumber]);
                Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
            }    
    }

    public void LevelUpPoison()
    {
        if (PlayerStats.upgradeCurrency >= poisonLevelUpCost && poisonPreviousUpgradeLevel < poisonUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - poisonLevelUpCost) >= 0 && poisonUpgradeLevelNumber < 11)
        {
            poisonUpgradeLevel[poisonUpgradeLevelNumber] = true;
            poisonLevelUpCost += poisonLevelUpCost;
            PlayerStats.upgradeCurrency -= poisonLevelUpCost;
            poisonPreviousUpgradeLevel = poisonUpgradeLevelNumber;
            poisonUpgradeLevelNumber++;

            Debug.Log("upgrade level: " + poisonUpgradeLevel[poisonUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpLaser()
    {
        if (PlayerStats.upgradeCurrency >= laserLevelUpCost && laserPreviousUpgradeLevel < laserUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - laserLevelUpCost) >= 0 && laserUpgradeLevelNumber < 11)
        {
            laserUpgradeLevel[laserUpgradeLevelNumber] = true;
            laserLevelUpCost += laserLevelUpCost;
            PlayerStats.upgradeCurrency -= laserLevelUpCost;
            laserPreviousUpgradeLevel = laserUpgradeLevelNumber;
            laserUpgradeLevelNumber++;

            Debug.Log("upgrade level: " + laserUpgradeLevel[laserUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpMinigun()
    {
        if (PlayerStats.upgradeCurrency >= minigunLevelUpCost && minigunPreviousUpgradeLevel < minigunUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - minigunLevelUpCost) >= 0 && minigunUpgradeLevelNumber < 11)
        {
            minigunUpgradeLevel[minigunUpgradeLevelNumber] = true;
            minigunLevelUpCost += minigunLevelUpCost;
            PlayerStats.upgradeCurrency -= minigunLevelUpCost;
            minigunPreviousUpgradeLevel = minigunUpgradeLevelNumber;
            minigunUpgradeLevelNumber++;

            Debug.Log("upgrade level: " + minigunUpgradeLevel[minigunUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }

    public void LevelUpAoe()
    {
        if (PlayerStats.upgradeCurrency >= aoeLevelUpCost && aoePreviousUpgradeLevel < aoeUpgradeLevelNumber
        && (PlayerStats.upgradeCurrency - aoeLevelUpCost) >= 0 && aoeUpgradeLevelNumber < 11)
        {
            aoeUpgradeLevel[aoeUpgradeLevelNumber] = true;
            aoeLevelUpCost += aoeLevelUpCost;
            PlayerStats.upgradeCurrency -= aoeLevelUpCost;
            aoePreviousUpgradeLevel = aoeUpgradeLevelNumber;
            aoeUpgradeLevelNumber++;

            Debug.Log("upgrade level: " + aoeUpgradeLevel[aoeUpgradeLevelNumber]);
            Debug.Log("upgradeCurrency: " + PlayerStats.upgradeCurrency);
        }
    }
}
