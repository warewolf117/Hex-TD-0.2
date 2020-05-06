using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes the variables in this script visible in inspector
//needed so that data can be input from inspector in the shop script
public class TurretBlueprint  //removed monobehavior because this script doesnt need
                              //to be attached to an object
{
    public GameObject pref;
    public int cost;
    public int range;
    public int damage;
    public float fireRate;

    public GameObject upgradedPref;
    public int upgradeCost;
    public int upgradedRange;
    public int upgradedDamage;
    public float upgradedFireRate;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    public int GetUpgradedSellAmount()
    {
        return upgradeCost / 2;
    }

    public int GetRange()
    {
        return range;
    }
    public int GetDamage()
    {
        return damage;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    public int GetUpgradedRange()
    {
        return upgradedRange;
    }
    public int GetUpgradedDamage()
    {
        return upgradedDamage;
    }
    public float GetUpgradedFireRate()
    {
        return upgradedFireRate;
    }
}