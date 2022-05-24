using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealhPlayerUI : MonoBehaviour
{
    public Image HealthPlayerBar;
    public static int healthPlayer;
    public int startHealthPlayer = 1000;

    private void Start()
    {
        healthPlayer = startHealthPlayer;
    }
    public void enemyAttack(int damage)
    {
        healthPlayer -= damage;
        HealthPlayerBar.fillAmount = healthPlayer / startHealthPlayer;
    }
}
