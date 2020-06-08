using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprintShop standartTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;
    public TurretBlueprintShop minigunTurret;

    public static bool turretBought = false;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        buildManager.SelectTurretToBuild(standartTurret);
        turretBought = true;
    }

    public void SelectMissileLauncher ()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
        turretBought = true;
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
        turretBought = true;
    }

    public void SelectMinigunTurret()
    {
        buildManager.SelectTurretToBuild(minigunTurret);
        turretBought = true;
    }
}
