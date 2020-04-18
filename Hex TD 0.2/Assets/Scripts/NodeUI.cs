using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    public Text upgradeCost;
    private Node target;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition(); //this uses the node location with the offset
        // we made before

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }
            
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade() //
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //hides menu when upgrade is done
        //need to use this function so that node is deselected too instead of just hiding the
        //ui which is what the Hide() function does
    }

}
