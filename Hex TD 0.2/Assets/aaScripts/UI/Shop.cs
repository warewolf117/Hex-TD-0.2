﻿using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprintShop standartTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;

    public GameObject selectTurretTooltip;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        buildManager.SelectTurretToBuild(standartTurret);
        selectTurretTooltip.SetActive(false);
    }

    public void SelectMissileLauncher ()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        selectTurretTooltip.SetActive(false);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
        selectTurretTooltip.SetActive(false);
    }
}