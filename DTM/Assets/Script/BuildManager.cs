using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    private Node selectedUpgradeNode;

    public static BuildManager instance;
    public GameObject ArcherPrefab;
    public GameObject MortarPrefab;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("No");
            return;
        }
        instance = this;
    }
    public NodeUI nodeUI;
    public UpgradeUI upgradeUI;
    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        nodeUI.SetTarget(selectedNode);
        
    }

    public void SelectUpgradeNode(Node node)
    {
        if (selectedUpgradeNode == node)
        {
            DeselectUpgradeNode();
            return;
        }

        selectedUpgradeNode = node;
        upgradeUI.SetTarget(selectedUpgradeNode);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void DeselectUpgradeNode()
    {
        selectedUpgradeNode = null;
        upgradeUI.Hide();
    }
    public bool CanBuild { get { return turretToBuild != null; } }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode.buildTower(turretToBuild);
        nodeUI.Hide();
    }
    
}
