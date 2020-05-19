using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Linq.Expressions;

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
    private Color originalColor;
    private Color originalColorE;

    public Text dragAndDropText;
    public static bool tutorialNodes;
    public static bool hexTutorialDone = false;

    private float innerHexTutorialTimer;
    private float outerHexTutorialTimer;
    private bool outerHexTutorial;
    private bool timerRunning;

    private GameObject outerHex1;
    private GameObject outerHex2;
    private Color originalColorHex;


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

        if (!hexTutorialDone)
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

    private void Update()
    {
        if (hexTutorialDone)

            return;

        if (tutorialNodes)
        {
            innerHexTutorialTimer -= Time.deltaTime;
            outerHexTutorialTimer -= Time.deltaTime;

            if (innerHexTutorialTimer <= 0 && !outerHexTutorial)
            {
                innerHexTutorialTimer = 6f;
                dragAndDropText.text = "TURRETS PLACED HERE WILL ONLY ATTACK THIS LANE";
                GameObject.Find("TutorialPointer").transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                BuildManager.tutorialGhost = true;
            }

            if (innerHexTutorialTimer > 0)
            {
                outerHexTutorial = true;
            }

            if (outerHexTutorialTimer <= 0 && timerRunning == true)
            {
                GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

                foreach (GameObject hex in hexes)
                {
                    hex.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 0.3f);
                    hex.transform.localScale = new Vector3(1, 1, 0.5f);
                }

                outerHex1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.1933962f, 0.1933962f, 0.1933962f));
                outerHex2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(0.1933962f, 0.1933962f, 0.1933962f));

                outerHex1.GetComponent<MeshRenderer>().material.color = new Color(0, 0.517309f, 0.5660378f, 1);
                outerHex2.GetComponent<MeshRenderer>().material.color = new Color(0, 0.517309f, 0.5660378f, 1);

                GameObject.Find("TutorialPointer").SetActive(false);
                GameObject.Find("TutorialPointer2").SetActive(false);


                dragAndDropText.text = "CLICK A TURRET TO VIEW ITS STATS";

                BuildManager.tutorialGhost = false;
                hexTutorialDone = true;
                return;

            }

            if (outerHexTutorial && innerHexTutorialTimer <= 0 && outerHexTutorialTimer <= 0 && timerRunning == false)
            {

                BuildManager.outerHexTutorial = true;
                dragAndDropText.text = "TURRETS PLACED HERE WILL ATTACK BOTH LANES";
                GameObject.Find("TutorialPointer2").transform.localScale = new Vector3(0.5f, 0.3f, 0.3f);
                GameObject.Find("TutorialPointer").transform.localScale = new Vector3(0.5f, 0.3f, 0.3f);
                GameObject.Find("TutorialPointer").transform.localPosition = new Vector3(0.1157f, 0.3979f, 0f);

                outerHex1 = GameObject.Find("Hex Tile TopVertex1");
                outerHex2 = GameObject.Find("Hex Tile TopVertex2");

                GameObject[] hexes = GameObject.FindGameObjectsWithTag("Node");

                foreach (GameObject hex in hexes)
                {
                    hex.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 1);
                    hex.transform.localScale = new Vector3(0, 0, 0);
                }

                outerHex1.transform.localScale = new Vector3(1, 1, 0.5f);
                outerHex2.transform.localScale = new Vector3(1, 1, 0.5f);

                outerHex1.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 0.3f);
                outerHex2.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", 0.3f);

                originalColorHex = outerHex1.GetComponent<MeshRenderer>().material.GetColor("_EmissionColor");

                outerHex1.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(1, 1, 1));
                outerHex2.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Color(1, 1, 1));

                outerHex1.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
                outerHex2.GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);

                outerHexTutorialTimer = 6f;
                timerRunning = true;
            }
        }

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

        tutorialNodes = true;
    
        turret = _turret;
        Turret Sturret = turret.transform.GetComponent<Turret>();
        Sturret.NodeSectionTargetingShit(nodeSector); //sends nodeSector value to the void function in the turret script

        turretBlueprintShop = blueprint;

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
        if (Input.GetMouseButtonUp(0) && UnitGhost.dragGhost == true && rend.CompareTag("Node"))
        {
            if (!buildManager.CanBuild)
                return;

            dropAudio.PlayOneShot(dropAudio.clip);
            BuildTurret(buildManager.GetTurretToBuild());

            if (buildManager.HasMoney)
            this.tag = "ActiveNode";

        }
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (this.CompareTag("ActiveNode"))
        {
            UnitGhost.RedGhost();
            return;
        }

        if (!buildManager.CanBuild)
            return;

        if (!UnitGhost.dragGhost)
            return;

        if (buildManager.HasMoney && turret == null)
        {
            UnitGhost.NormalGhost();
            rend.material.color = hoverColor;
            dropAudio.pitch = 1f;
            dropAudio.volume = 0.6f;
        }
        else
        {
            if (turret == null)
            {
                UnitGhost.RedGhost();
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
