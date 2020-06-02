using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenUI : MonoBehaviour
{
    public Text oxygenText;
    private int oxygen;
    private int previousOxygen = 0;

    private float timeSinceLastCalled;
    private int oxygenDepleteRate = 5; //time in secs


    void Update()
    {
        oxygenDepleteRate = oxygenDepleteRate/Health.deadWallCounter;
        oxygen = PlayerStats.oxygen;
        Debug.Log(oxygenDepleteRate);

        timeSinceLastCalled += Time.deltaTime;
        if (timeSinceLastCalled > oxygenDepleteRate)
        {
            PlayerStats.oxygen--;
            timeSinceLastCalled = 0;
            if (oxygen != previousOxygen)
            {
                oxygenText.text = PlayerStats.oxygen.ToString();
                previousOxygen = oxygen;
            }
        }
        
        
        

    }
}