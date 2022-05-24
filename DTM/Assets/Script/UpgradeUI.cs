using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
	public GameObject uiUpgrade;
	private Node target;
	public Text sellAmount;
	public Text upgradeCost;
	public Button upgradeButton;
	public void SetTarget(Node _target)
	{
		target = _target;

		uiUpgrade.SetActive(true);
		/*transform.position = target.GetListTurretPosition();*/
		
			
		if (!target.isUpgraded)
		{
			upgradeCost.text = target.turretBlueprint.upgradeCost.ToString();
			upgradeButton.interactable = true;
		}
		else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
		}

		sellAmount.text = target.turretBlueprint.GetSellAmount(target).ToString();
	}
	public void Hide()
	{
		uiUpgrade.SetActive(false);
	}
	public void Upgrade()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectUpgradeNode();
	}

	public void Sell()
	{
		target.SellTurret();
		BuildManager.instance.DeselectUpgradeNode();
	}

}
