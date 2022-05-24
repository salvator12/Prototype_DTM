using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    [Header("Optional")]
    public GameObject turret;
    
    public Vector3 positionOffset;
    public Vector3 TowerOffset;

    BuildManager buildManager;
    private Renderer rend;
    private Color startColor;
    NodeUI nodeUI;

    [HideInInspector]
    public bool isUpgraded = false;

    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetListTurretPosition()
    {
        return transform.position + positionOffset;
    }
    public void buildTower(TurretBlueprint _turret)
    {
        if (PlayerStats.Money < _turret.cost)
        {
            Debug.Log("not enough money!");
            return;
        }
        PlayerStats.Money -= _turret.cost;
        turret = (GameObject)Instantiate(_turret.prefab, transform.position + TowerOffset, Quaternion.identity);
        turretBlueprint = _turret;
        return;
    }
    private void OnMouseDown()
    {
        /*if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }*/
        if (turret != null)
        {
            buildManager.SelectUpgradeNode(this);
            /*Debug.Log("Nice");
            rend.material.color = Color.red;*/
            return;
        }
        buildManager.SelectNode(this);
    }
    private void OnMouseEnter()
    {
        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }*/
        if(turret != null)
        {
            rend.material.color = Color.red;
            return;
        }
        rend.material.color = hoverColor;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Build a new one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetListTurretPosition(), Quaternion.identity);
        turret = _turret;
        /*GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);*/

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount(this);

        /*GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetListTurretPosition(), Quaternion.identity);*/
        /*Destroy(effect, 5f);*/

        Destroy(turret);
        turretBlueprint = null;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;   
    }

}
