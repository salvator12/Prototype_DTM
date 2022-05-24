using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellAmount(Node target)
	{
		if(target.isUpgraded)
        {
			return upgradeCost / 2;
		}
		return cost / 2;
	}
}
