﻿using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

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



    
    public GameObject buildEffect;

    private TurretBlueprintShop turretToBuild;

    private Node selectedNode;
    private TurretUI selectedTurret;

    public NodeUI nodeUI;

    public GameObject Ghost;
    public Material GhostMat;
    public static bool GhostActive = false;


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
        if (GhostActive)
        {
            Destroy(Ghost);
        }
        turretToBuild = turret;
        Ghost = Instantiate(turretToBuild.pref.GetComponent<Turret>().turretGhost, new Vector3(-0.02f,0.85f,0f), Quaternion.identity) as GameObject;
        Ghost.AddComponent<UnitGhost>();
        GhostActive = true;
        DeselectNode();
    }

    public TurretBlueprintShop GetTurretToBuild()
    {
        return turretToBuild;
    }
}
