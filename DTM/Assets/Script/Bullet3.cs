using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
	private Transform target;
	public static Enemy targetEnemy;
	public float speed;

	public int damage;

	public float explosionRadius = 0f;
    public GameObject impactEffect;
	public static float slowAmount = 0.5f;
	public static bool isSlow = false;
	public void Seek(Transform _target, Enemy _targetEnemy)
	{
		target = _target;
		targetEnemy = _targetEnemy;
	}

	// Update is called once per frame
	void Update()
	{

		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;
		if (dir.magnitude <= distanceThisFrame)
		{
			isSlow = false;
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);
	}

	void HitTarget()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);
		if (explosionRadius > 0f)
		{
			Explode();
		}
		else
		{
            Damage(target);
		}
		/*GetComponent<MeshRenderer>().enabled = false;*/
		Destroy(gameObject);
	}

	void Explode()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
	}

	void Damage(Transform enemy)
	{
		Enemy e = enemy.GetComponent<Enemy>();
		if (e != null)
		{
			e.TakeDamage(damage);
			isSlow = true;
		}
	}


	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);
	}
}
