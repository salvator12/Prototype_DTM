using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public TurretBlueprint archerTurret;
    public TurretBlueprint mortarTurret;
    public Text buyArcher;
    public Text buyMortar;


    Color startColorText = Color.white;
    BuildManager buildManager;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArcherTurret()
    {
        Debug.Log("Archer Turret Selected");
        buildManager.SelectTurretToBuild(archerTurret);
    }

    public void SelectedMortarTurret()
    {
        Debug.Log("Mortar Turret Selected");
        buildManager.SelectTurretToBuild(mortarTurret);
    }
    private void Update()
    {
        if (PlayerStats.Money < archerTurret.cost)
        {
            buyArcher.color = Color.red;
        }
        else if (PlayerStats.Money > archerTurret.cost)
        {
            buyArcher.color = Color.white;
        }

        if (PlayerStats.Money < mortarTurret.cost)
        {
            buyMortar.color = Color.red;
        }
        else if (PlayerStats.Money > mortarTurret.cost)
        {
            buyMortar.color = Color.white;
        }
    }
}
