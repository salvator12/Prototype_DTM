using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public Text MoneyArcher;
    public Text MoneyMortar;
    Shop listMoney;
    // Update is called once per frame
    private void Start()
    {
        listMoney = GetComponent<Shop>();
    }
    void Update()
    {
        MoneyArcher.text = "<b>Fire Turret</b>\n" + listMoney.archerTurret.cost.ToString();
        MoneyMortar.text = "<b>Ice Turret</b>\n" + listMoney.mortarTurret.cost.ToString();
    }
}
