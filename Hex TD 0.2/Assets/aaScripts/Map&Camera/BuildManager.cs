﻿using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    

    public static BuildManager instance; //stores a reference to itself to limit instances to 1
    public GameObject dragAndDropTooltip;
    public GameObject upgradeTooltip;
    public GameObject waveStarterTooltip;
    public GameObject selectTurretTooltip;
    public GameObject skipTutorialButton;


    private GameObject innerHex1;
    private GameObject innerHex2;
    private GameObject innerHex3;
    private GameObject innerHex4;
    public static bool outerHexTutorial = false;
    private bool waveStarterTutorialDone = false;
    public static bool skipTutorial = false;

    public static bool tutorialGhost = false;

    bool tutorialCounter = false;

    static readonly int materialEmissionColor = Shader.PropertyToID("_EmissionColor");
    static readonly int materialMetallicColor = Shader.PropertyToID("_Metallic");

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

    public NodeUI nodeUI;

    public GameObject Ghost;
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

        if(selectedNode != node)
        {
            DeselectNode();
        }

        selectedNode = node;

        turretToBuild = null;
        nodeUI.SetTarget(node);



    }

    //Deactivates UI when u click the selected node
    public void DeselectNode()
    {
        if (selectedNode != null)
        {
             nodeUI.upgradeTooltip.SetActive(false);
             WaveSpawnerTopRight_Main.tutorialOn = false;
             selectedNode.RemoveRange();
             selectedNode = null;
             nodeUI.Hide();
             upgradeTooltip.SetActive(false);
        }
    }
    public void SelectTurretToBuild(TurretBlueprintShop turret)
    {
        if (tutorialGhost)
            return;

        if (GhostActive)
        {
            Destroy(Ghost);
        }

        turretToBuild = turret;
        Ghost = Instantiate(turretToBuild.pref.GetComponent<Turret>().turretGhost, new Vector3(-0.02f,0.85f,0f), Quaternion.identity) as GameObject;

        if (tutorialCounter == false)
        {
            tutorialCounter = true;
        } 

        Ghost.AddComponent<UnitGhost>();
        Ghost.AddComponent<TurretRange>();
        GhostActive = true;
        DeselectNode();
    }


    public  void SkipTutorial()
    {
        skipTutorial = true;
        WaveSpawnerTopRight_Main.tutorialOn = false;
        upgradeTooltip.SetActive(false);
        dragAndDropTooltip.SetActive(false);
        waveStarterTooltip.SetActive(false);
        selectTurretTooltip.SetActive(false);
        tutorialGhost = false;
        Node.hexTutorialDone = true;
        nodeUI.tutorialCounter = true;
        skipTutorialButton.SetActive(false);
    }

    private void Update()
    {
        if (waveStarterTutorialDone || skipTutorial)
            return;

        if (!WaveSpawnerTopRight_Main.tutorialOn)
        {
            waveStarterTooltip.SetActive(true);

            if (WaveSpawnerTopRight_Main.startFirstWave > 0)
            {
                waveStarterTooltip.SetActive(false);
                waveStarterTutorialDone = true;
            }
        }

        if (Node.hexTutorialDone)
            return;

        if (outerHexTutorial)
        {
            innerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex3.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
            innerHex4.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(0.1698113f, 0.1698113f, 0.1698113f));
        }

        if (tutorialCounter && !Node.tutorialNodes && !outerHexTutorial)
        {
            dragAndDropTooltip.SetActive(true);
            innerHex1 = GameObject.Find("Hex Tile TopRight1");
            innerHex2 = GameObject.Find("Hex Tile TopRight2");
            innerHex3 = GameObject.Find("Hex Tile TopRight3");
            innerHex4 = GameObject.Find("Hex Tile TopRight4");

            GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

            foreach (GameObject hex in hexes)
            {
                hex.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 1);
                hex.transform.localScale = new Vector3(0, 0, 0);
            }

            innerHex1.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex2.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex3.transform.localScale = new Vector3(1, 1, 0.5f);
            innerHex4.transform.localScale = new Vector3(1, 1, 0.5f);

            innerHex1.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex2.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex3.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);
            innerHex4.GetComponent<MeshRenderer>().material.SetFloat(materialMetallicColor, 0.3f);

            innerHex1.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex2.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex3.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));
            innerHex4.GetComponent<MeshRenderer>().material.SetColor(materialEmissionColor, new Color(1, 1, 1));

        }

    }
    public TurretBlueprintShop GetTurretToBuild()
    {
        return turretToBuild;
    }
}
