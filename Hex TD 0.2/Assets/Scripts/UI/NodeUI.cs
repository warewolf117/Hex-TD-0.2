using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public GameObject disableUIButton;

    public Text upgradeCost;
    public Text fireRate;
    public Text damage;
    public Text range;
    public Text sellAmmount;

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserTurret;

    private Node target;
    public Button upgradeButton;


   

    public void SetTarget(Node _target)
    {


        target = _target;

        fireRate.text = target.turretBlueprint.GetUpgradedFireRate().ToString();
        damage.text = target.turretBlueprint.GetUpgradedDamage().ToString();
        range.text = target.turretBlueprint.GetUpgradedRange().ToString();

        sellAmmount.text = "$" + target.turretBlueprint.GetUpgradedSellAmount();




        //transform.position = target.GetBuildPosition(); //this uses the node location with the offset
        // we made before

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;

            fireRate.text = target.turretBlueprint.GetFireRate().ToString();
            damage.text = target.turretBlueprint.GetDamage().ToString();
            range.text = target.turretBlueprint.GetRange().ToString();

            sellAmmount.text = "$" + target.turretBlueprint.GetSellAmount();
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }



        ui.SetActive(true);
        
        
            disableUIButton.SetActive(true);
        
        

    }

    public void Hide()
    {
        disableUIButton.SetActive(false);
        ui.SetActive(false);      
    }


    public void Upgrade() 
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
        Hide();                               //hides menu when upgrade is done
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


}