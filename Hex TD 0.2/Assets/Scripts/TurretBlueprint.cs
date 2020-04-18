using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes the variables in this script visible in inspector
//needed so that data can be input from inspector
public class TurretBlueprint  //removed monobehavior because this script doesnt need
    //to be attached to an object
{
    public GameObject pref;
    public int cost;

    public GameObject upgradedPref;
    public int upgradeCost;
}
