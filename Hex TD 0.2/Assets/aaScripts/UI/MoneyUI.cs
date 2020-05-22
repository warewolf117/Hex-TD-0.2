﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    int money;
    int previousMoney = 0;

    // Update is called once per frame
    void Update()
    {
        money = PlayerStats.money;
        if (money != previousMoney)
        {
            moneyText.text = "$" + PlayerStats.money.ToString();
            previousMoney = money;
        }
       
    }
}
