using UnityEngine;
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

    public TurretBlueprintShop standartTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;

    private Node target;
    public Button upgradeButton;


    public void SetTarget(Node _target)
    {
        target = _target;
        

        
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
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //hides menu when upgrade is done
                                              //need to use this function so that node is deselected too instead of just hiding the
                                              //ui which is what the Hide() function does
       // Hide();
       // DeactivateButton();
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
        // DeactivateButton();
        Hide();
    }
    public void Update()
    {
        /*if (ui.activeSelf)
        {
            disableUIButton.SetActive(true);
        }*/

        if (ui == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
               
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.tag != "ActiveNode" && Hit.collider.tag != "UIButtons")
                    {
                    Hide();
                    }

                
            }
        }

    }
    

    }