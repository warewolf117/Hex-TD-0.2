using UnityEngine;

public class BuildManager : MonoBehaviour
{
    

    public static BuildManager instance; //stores a reference to itself to limit instances to 1

    private void Awake()
    {
        if (instance!= null)
        {
           
            return;
        }
        
        instance = this;
    }



    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject buildEffect;

    private TurretBlueprintShop turretToBuild;

    private Node selectedNode;
    private TurretUI selectedTurret;

    public NodeUI nodeUI;
    

    //This function is called a property cus it only allows to get a return value
    public bool CanBuild
    {
        get
        {
            return turretToBuild != null;
        }
    }

    public bool HasMoney
    {
        get
        {
            return PlayerStats.money >= turretToBuild.cost;
        }
    }


    //the following lines till line 71 is so that nodes and turrets cant be selected at the same time  
    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

       // nodeUI.SetTarget(node);
    }
    public void SelectTurret(TurretUI turret)
    {
        if (selectedTurret == turret)
        {
            DeselectNode();
            return;
        }
        selectedTurret = turret;
        turretToBuild = null;

        // nodeUI.SetTarget(node);
    }
    //Deactivates UI when u click the selected node
    public void DeselectNode()
    {
        selectedNode = null;
    }
    public void DeselectTurret()
    {
        selectedTurret = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprintShop turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprintShop GetTurretToBuild()
    {
        return turretToBuild;
    }
}
