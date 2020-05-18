using UnityEngine.EventSystems;
using UnityEngine;


public class Node : MonoBehaviour
{
    private AudioSource dropAudio;

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector] //Allows to put default turrets in any node
    public GameObject turret;

    [HideInInspector]
    public TurretBlueprintShop turretBlueprintShop;


    [HideInInspector]
    public Turret turretStats;

    //public TurretBlueprintStats turretBlueprintStats;

    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    public int nodeSector;

    int range;
    float fireRate;

    BuildManager buildManager;

    public GameObject child;
    public GameObject child2;

    private float radius = 1.0f;
    private new Color originalColor;
    private new Color originalColorE;

    // NodeUI nodeUI;

    void Start()
    {
        dropAudio = GetComponent<AudioSource>();
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
            SendStatsToUI(turret);
            buildManager.SelectNode(this); //this prevents from building where theres a turret
            this.tag = "ActiveNode";



            // Turret.healthStatic.ToString();


            // this.range = turretStats.range;
            // this.fireRate = turretStats.fireRate;
            return;
        }

}
public void RemoveRange()
    {
        child.transform.localScale = (new Vector3(0, 0, 0));
        child2.transform.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", originalColorE);
        child2.transform.GetComponent<MeshRenderer>().material.color = originalColor;
    }

    void BuildTurret(TurretBlueprintShop blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            Debug.Log("Insufficient funds");
            return; //add not enough money feature display
        }

        PlayerStats.money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.pref, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        Sturret.NodeSectionTargetingShit(nodeSector); //sends nodeSector value to the void function in the turret script
         

       /* Turret turretRange = turret.transform.GetComponent<Turret>();
        range = turretRange.range;

        Turret turretFireRate = turret.transform.GetComponent<Turret>();
        fireRate = turretFireRate.fireRate;

        NodeUI stats = turret.transform.GetComponent<NodeUI>();
        stats.TurretStats(range, fireRate);*/



        turretBlueprintShop = blueprint;

        // GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        // Destroy(effect, 2f);
        //print display saying turret built, and money left
    }

    void SendStatsToUI(GameObject turretS)
    {
        Turret currentTurret = turretS.GetComponent<Turret>();
        child = turretS.transform.GetChild(0).gameObject;
        child2 = turretS.transform.GetChild(1).gameObject;
        originalColorE = child2.transform.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");
        child2.transform.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(1f, 1f, 1f));
        originalColor = child2.transform.GetComponent<MeshRenderer>().material.color;
        child2.transform.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
        radius = currentTurret.range;
        child.transform.localScale = (new Vector3(radius * 2, radius * 2, radius * 2));
        NodeUI.fireRateValue = currentTurret.fireRate;
        NodeUI.rangeValue = currentTurret.range;

        if (!currentTurret.useLaser)
        {
            NodeUI.damageValue = currentTurret.bulletDamage;
        }
        else
        {
            NodeUI.damageValue = currentTurret.LaserDamage;
        }

    }

    public void UpgradeTurret(GameObject nodeUI)
    {
        if (PlayerStats.money < turretBlueprintShop.upgradeCost)
        {
            Debug.Log("Insufficient funds");
            return;
        }

        PlayerStats.money -= turretBlueprintShop.upgradeCost;

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprintShop.upgradedPref, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        Sturret.NodeSectionTargetingShit(nodeSector);
        SendStatsToUI(turret);
        nodeUI.GetComponent<NodeUI>().Stats();
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

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprintShop.GetSellAmount();
        //put sell effect here
        Destroy(turret);
        turretBlueprintShop = null;

    }

    public void SellUpgradedTurret()
    {
        PlayerStats.money += turretBlueprintShop.GetUpgradedSellAmount();
        //put sell effect here
        Destroy(turret);
        isUpgraded = false;
        turretBlueprintShop = null;

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0) && UnitGhost.dragGhost == true)
        {
            if (!buildManager.CanBuild)
                return;
            dropAudio.PlayOneShot(dropAudio.clip);
            BuildTurret(buildManager.GetTurretToBuild());
        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (!UnitGhost.dragGhost)
            return;

        if (buildManager.HasMoney && turret == null)
        {
            rend.material.color = hoverColor;
            dropAudio.pitch = 1f;
            dropAudio.volume = 0.6f;
        }
        else
        {
            if (turret == null)
            {
                rend.material.color = notEnoughMoneyColor;
                dropAudio.pitch = 0.5f;
                dropAudio.volume = 0.9f;
            }

        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
