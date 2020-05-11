using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprintShop standartTurret;
    public TurretBlueprintShop missileLauncher;
    public TurretBlueprintShop laserTurret;

    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret ()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileLauncher ()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
