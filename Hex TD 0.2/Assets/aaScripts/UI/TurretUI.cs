using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurretUI : MonoBehaviour
{
    //public Vector3 positionOffset;

    public GameObject turret;
    public UnityEvent OnClick = new UnityEvent();

    [HideInInspector]
    public TurretBlueprintShop turretBlueprintShop;

    [HideInInspector]
    public bool isUpgraded = false;

    BuildManager buildManager;


    void Start()
    {
        turret = this.gameObject;
        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {


        if (turret == enabled)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
                {
                    OnClick.Invoke();
                    
                }
            }
        }
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.money < turretBlueprintShop.upgradeCost)
        {
            Debug.Log("Insufficient funds");
            return;
        }

        PlayerStats.money -= turretBlueprintShop.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprintShop.upgradedPref, transform.position, Quaternion.identity);
       // turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        //Sturret.NodeSectionTargetingShit(nodeSector);

        /*Turret turretRange = turret.transform.GetComponent<Turret>();
        range = turretRange.range;

        Turret turretFireRate = turret.transform.GetComponent<Turret>();
        fireRate = turretFireRate.fireRate;

        NodeUI stats = turret.transform.GetComponent<NodeUI>();
        stats.TurretStats(range, fireRate);*/

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 2f);
        //display turret upgraded

        isUpgraded = true;
    }
}

