using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money; 
    public int startMoney = 400;
    public static int Rounds;

    void Start ()
    {
        money = startMoney;
        Rounds = 0;
    }

}
