using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

	private Transform target;
	private EnemyAI targetEnemy;

	[Header("General")]

	[SerializeField] private float range = 15f;

	[Header("Unity Setup Fields")]

	private string enemyTag = "Enemy";

	public GameObject bulletPrefab;

	[SerializeField] private Transform partToRotate;
	[SerializeField] private float turnSpeed = 10f;

	[SerializeField] private Transform firePoint;
	[SerializeField] private float shootDelay = 2f;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
		InvokeRepeating("Shoot", 0f, shootDelay);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<EnemyAI>();
		}
		else
		{
			target = null;
		}

	}

	void Shoot()
	{
		if(target) {
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			Bullet bullet = bulletGO.GetComponent<Bullet>();

			if(bullet != null)
				bullet.Seek(target);
		}
	}

	void Update()
	{
		if(target != null) LockOnTarget();
	}

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}