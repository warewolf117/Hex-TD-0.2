﻿using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
   // public GameObject disableUIButton;
   // private bool checkUI = false;

    public Text upgradeCost;
    public Text fireRate;
    public Text damage;
    public Text range;
    public Text sellAmmount;

    public static float fireRateValue;
    public static int damageValue;
    public static int rangeValue;

    public TurretBlueprintShop standartTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;

    private Node target;
    public Button upgradeButton;

    public GameObject dragAndDropTooltip;
    public GameObject upgradeTooltip;

    bool tutorialCounter = false;

    public void Stats()
    {
        fireRate.text = fireRateValue.ToString();

        damage.text = damageValue.ToString();

        range.text = rangeValue.ToString();

    }


    public void SetTarget(Node _target)
    {
        target = _target;

        Stats();

        //fireRate.text = target.turretStats.fireRate.ToString();

        sellAmmount.text = "$" + target.turretBlueprintShop.GetUpgradedSellAmount();

        //transform.position = target.GetBuildPosition(); //this uses the node location with the offset
        // we made before

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprintShop.upgradeCost;
            upgradeButton.interactable = true;
            
            
            sellAmmount.text = "$" + target.turretBlueprintShop.GetSellAmount();
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }
        ui.SetActive(true);
        //Destroy(dragAndDropTooltip);
        dragAndDropTooltip.SetActive(false);
        if (tutorialCounter == false)
        {
            upgradeTooltip.SetActive(true);
        }
        
        //checkUI = true;
    }

    public void Hide()
    {
        ui.SetActive(false);

    }

   /* public void DeactivateButton()
    {
        if (checkUI)
        {
            disableUIButton.SetActive(false);
            checkUI = false;
        }
    }*/

    public void Upgrade()
    {
        target.UpgradeTurret(this.gameObject);
        upgradeTooltip.SetActive(false);
        tutorialCounter = true;
    }

    public void Sell()
    {
        if (target.isUpgraded)
        {
            target.SellUpgradedTurret();
            target.tag = "Node";
            BuildManager.instance.DeselectNode();
        }
        else
        {
            target.SellTurret();
            target.tag = "Node";
            BuildManager.instance.DeselectNode(); //deselects node after selling turret
        }
        Hide();
        upgradeTooltip.SetActive(false);
        tutorialCounter = true;
    }
    public void Update()
    {
        if (ui == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
               
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.tag != "ActiveNode" && Hit.collider.tag != "UIButtons")
                    {
                         BuildManager.instance.DeselectNode();
                         
                    }

                
            }
        }

    }
    

    }