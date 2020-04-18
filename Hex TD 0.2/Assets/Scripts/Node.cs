using UnityEngine.EventSystems;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] //Allows to put default turrets in any node
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this); //this prevents from building where theres a turret
            Debug.Log("Cant build there");
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Insufficient funds");
            return; //add not enough money feature display
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.pref, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 2f);
        //print display saying turret built, and money left
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Insufficient funds");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPref, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 2f);
        //display turret upgraded

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();
        //put sell effect here
        Destroy(turret);
        turretBlueprint = null;

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney && turret == null)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            if (turret == null)
            {
                rend.material.color = notEnoughMoneyColor;
            }

        }



    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
