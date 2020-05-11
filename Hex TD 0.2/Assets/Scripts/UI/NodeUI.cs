using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public GameObject disableUIButton;
    private bool checkUI = false;

    public Text upgradeCost;
    public Text fireRate;
    public Text damage;
    public Text range;
    public Text sellAmmount;

    /*int turretRange;
    float turretFireRate;*/

    public TurretBlueprintStats standartTurret;
    public TurretBlueprintStats missileLauncher;
    public TurretBlueprintStats laserTurret;

    private Node target;
    public Button upgradeButton;


   /* public void TurretStats(int _range, float _fireRate)
    {
        turretRange = _range;
        turretFireRate = _fireRate;
    }*/

    public void SetTarget(Node _target)
    {


        target = _target;

        /*fireRate.text = turretFireRate.ToString();
        range.text = turretRange.ToString();*/
        fireRate.text = target.turretBlueprintStats.GetUpgradedFireRate().ToString();
        damage.text = target.turretBlueprintStats.GetUpgradedDamage().ToString();
        range.text = target.turretBlueprintStats.GetUpgradedRange().ToString();

        sellAmmount.text = "$" + target.turretBlueprintShop.GetUpgradedSellAmount();


        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprintShop.upgradeCost;
            upgradeButton.interactable = true;

            /*fireRate.text = turretFireRate.ToString();
            range.text = turretRange.ToString();*/
            fireRate.text = target.turretBlueprintStats.GetFireRate().ToString();
            damage.text = target.turretBlueprintStats.GetDamage().ToString();
            range.text = target.turretBlueprintStats.GetRange().ToString();

            sellAmmount.text = "$" + target.turretBlueprintShop.GetSellAmount();
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }



        ui.SetActive(true);
        checkUI = true;
        
        
            
        
        

    }

    public void Hide()
    {
        ui.SetActive(false);
              
    }

    public void DeactivateButton()
    {
        if (checkUI)
        {
            disableUIButton.SetActive(false);
            checkUI = false;
        }
            
    }


    public void Upgrade() 
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //hides menu when upgrade is done
                                              //need to use this function so that node is deselected too instead of just hiding the
                                              //ui which is what the Hide() function does

    }

    public void Sell()
    {
        if (target.isUpgraded)
        {
            target.SellUpgradedTurret();
            BuildManager.instance.DeselectNode();
        }
        else
        {
            target.SellTurret();
            BuildManager.instance.DeselectNode(); //deselects node after selling turret
        }
        
        
    }
    public void Update()
    {
        if (ui.activeSelf)
        {
            disableUIButton.SetActive(true);
        }
        
    }

}