using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float startSpeed = 1f;

	[HideInInspector]
	public float speed;

	public float startHealth;
	private float health;

	public int worth;
	public int damageBase;

	[Header("Unity Stuff")]
	public Image healthBar;

	/*private bool isDead = false;*/

	void Start()
	{
		speed = startSpeed;
		health = startHealth;
		
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
		{
			Die();
		}
	}
    public void AttackBase()
    {
		PlayerStats player = GameObject.Find("Game Manager").GetComponent<PlayerStats>();
		player.TakeDamage(damageBase);
		Destroy(this.gameObject);
    }

	public void Slow(float pct, Enemy targetEnemy)
	{
		targetEnemy.speed = startSpeed * (1f - pct);
	}
	void Die()
	{
        /*isDead = true;*/

        PlayerStats.Money += worth;

        /*GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);*/

        /*WaveSpawner.EnemiesAlive--;*/

        Destroy(gameObject);
	}
    private void Update()
    {
        if(SpawnEnemy.isPreparation)
        {
			Destroy(this.gameObject);
        }
		if(Bullet3.isSlow)
        {
			Slow(Bullet3.slowAmount, Bullet3.targetEnemy);
        }
    }
}
