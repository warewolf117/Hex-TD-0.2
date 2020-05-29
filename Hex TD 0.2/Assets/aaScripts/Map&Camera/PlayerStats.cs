using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money; //static is so that money doesnt need a reference object
    public int startMoney = 400;
    public static int Rounds;

    void Start ()
    {
        money = startMoney;
        Rounds = 0;
    }

    public void SaveMoney()
    {
        SaveSystem.SavePlayerStats(this);
    }

    public void LoadMoney()
    {
        SaveData data = SaveSystem.LoadData();

        money = data.money;
    }
}
