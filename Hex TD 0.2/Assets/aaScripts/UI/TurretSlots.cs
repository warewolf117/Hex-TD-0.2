using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlots : MonoBehaviour
{
    private bool slotPlaced = false;

    /*public GameObject[] turretsSlot1;
    public GameObject[] turretsSlot2;
    public GameObject[] turretsSlot3;
    public GameObject[] turretsSlot4;
    public GameObject[] turretsSlot5;*/

    static bool standartTurretPlaced = false;
    static bool poisonTurretPlaced = false;
    static bool laserTurretPlaced = false;
    static bool minigunTurretPlaced = false;
    static bool aoeTurretPlaced = false;



    public void UpdateSlots()
    {
        
        //slot 1
        if (standartTurretPlaced == false && slotPlaced == false && LoadoutMenu.standartTurretSelected == true)
        {
            //turretsSlot1[0].SetActive(true);
            standartTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 5: Standart turret selected");
        }
        else if (poisonTurretPlaced == false && slotPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            //turretsSlot1[1].SetActive(true);
            poisonTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 5: Poison turret selected");
        }
        else if (laserTurretPlaced == false && slotPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            //turretsSlot1[2].SetActive(true);
            laserTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 5: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && slotPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            //turretsSlot1[3].SetActive(true);
            minigunTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 5: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && slotPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            //turretsSlot1[4].SetActive(true);
            aoeTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 5: AOE turret selected");
        }
        slotPlaced = false;
        //slot 2
        if (standartTurretPlaced == false && slotPlaced == false && LoadoutMenu.standartTurretSelected == true)
        {
            //turretsSlot2[0].SetActive(true);
            standartTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 4: Standart turret selected");
        }
        else if (poisonTurretPlaced == false && slotPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
           // turretsSlot2[1].SetActive(true);
            poisonTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 4: Poison turret selected");
        }
        else if (laserTurretPlaced == false && slotPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            //turretsSlot2[2].SetActive(true);
            laserTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 4: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && slotPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            //turretsSlot2[3].SetActive(true);
            minigunTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 4: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && slotPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            //turretsSlot2[4].SetActive(true);
            aoeTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 4: AOE turret selected");
        }
        slotPlaced = false;
        //slot3
        if (standartTurretPlaced == false && slotPlaced == false && LoadoutMenu.standartTurretSelected == true)
        {
            //turretsSlot3[0].SetActive(true);
            standartTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 3: Standart turret selected");
        }
        else if (poisonTurretPlaced == false && slotPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            //turretsSlot3[1].SetActive(true);
            poisonTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 3: Poison turret selected");
        }
        else if (laserTurretPlaced == false && slotPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            //turretsSlot3[2].SetActive(true);
            laserTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 3: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && slotPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            //turretsSlot3[3].SetActive(true);
            minigunTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 3: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && slotPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            //turretsSlot3[4].SetActive(true);
            aoeTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 3: AOE turret selected");
        }
        slotPlaced = false;
        //slot4
        if (standartTurretPlaced == false && slotPlaced == false && LoadoutMenu.standartTurretSelected == true)
        {
            //turretsSlot4[0].SetActive(true);
            standartTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 2: Standart turret selected");
        }
        else if (poisonTurretPlaced == false && slotPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            //turretsSlot4[1].SetActive(true);
            poisonTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 2: Poison turret selected");
        }
        else if (laserTurretPlaced == false && slotPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            //turretsSlot4[2].SetActive(true);
            laserTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 2: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && slotPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            //turretsSlot4[3].SetActive(true);
            minigunTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 2: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && slotPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            //turretsSlot4[4].SetActive(true);
            aoeTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 2: AOE turret selected");
        }
        slotPlaced = false;
        //slot5
        if (standartTurretPlaced == false && slotPlaced == false && LoadoutMenu.standartTurretSelected == true)
        {
            //turretsSlot5[0].SetActive(true);
            standartTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 1: Standart turret selected");
        }
        else if (poisonTurretPlaced == false && slotPlaced == false && LoadoutMenu.poisonTurretSelected == true)
        {
            //turretsSlot5[1].SetActive(true);
            poisonTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 1: Poison turret selected");
        }
        else if (laserTurretPlaced == false && slotPlaced == false && LoadoutMenu.laserTurretSelected == true)
        {
            //turretsSlot5[2].SetActive(true);
            laserTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 1: Laser turret selected");
        }
        else if (minigunTurretPlaced == false && slotPlaced == false && LoadoutMenu.minigunTurretSelected == true)
        {
            //turretsSlot5[3].SetActive(true);
            minigunTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 1: Minigun turret selected");
        }
        else if (aoeTurretPlaced == false && slotPlaced == false && LoadoutMenu.aoeTurretSelected == true)
        {
            //turretsSlot5[4].SetActive(true);
            aoeTurretPlaced = true;
            slotPlaced = true;
            Debug.Log("Slot 1: AOE turret selected");
        }
        slotPlaced = false;
    }
}
    

