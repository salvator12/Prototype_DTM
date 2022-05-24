using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public Image HealthPlayerBar;
    public float startHealthPlayer = 1000;
    private float healthPlayer;
    private void Start()
    {
        Money = startMoney;
        healthPlayer = startHealthPlayer;
    }

    private void Update()
    {
        if(healthPlayer <= 0)
        {
            /*Debug.Log("Game Over!!");*/
        }
    }
    public void TakeDamage(float damage)
    {
        healthPlayer -= damage;
        HealthPlayerBar.fillAmount = healthPlayer / startHealthPlayer;
    }

}
