using UnityEngine;
using System.Collections;

public class CannonTower : MonoBehaviour {
	public float m_shootInterval = 0.5f;
	public float m_range = 4f;
	public GameObject m_projectilePrefab;
	public Transform m_shootPoint;
	private float m_lastShotTime = -0.5f;


	bool ShootPermition()
    {
		if (m_lastShotTime <= 0)
			return true;
		else
			return false;
    }
	void EnemySearch()
    {
		Transform nearestMonster = null;
		float nearestMonsterDistance = Mathf.Infinity;
		foreach (var monster in GameObject.FindObjectsOfType<Monster>())
        {
			float current_distance = Vector3.Distance(transform.position,monster.transform.position);
			if(current_distance<nearestMonsterDistance && current_distance <=m_range)
            {
				nearestMonster = monster.transform;
				nearestMonsterDistance = current_distance;
				
			}

		}
		if (nearestMonster != null)
		{
			Aim(nearestMonster, nearestMonsterDistance);
		}
	}
	void Aim(Transform monster,float nearestMonsterDistance)
    {
		Vector3 shootpos;
		if (monster.position.x <= 0)
		{
			float x = monster.position.x - 0.8f;
			shootpos = new Vector3(x, 4f,9f);
		}
        else
        {
			float x = monster.position.x + 1f;
			shootpos = new Vector3(x, 4f, 9f);
		}
        transform.LookAt(shootpos);
        m_shootPoint.LookAt(shootpos);
        if (ShootPermition())
		{
			Shoot(m_shootPoint);
		}
	}
	void Shoot(Transform m_shootpoint)
	{ 
		m_lastShotTime = m_shootInterval;
		Instantiate(m_projectilePrefab, transform.position, m_shootPoint.rotation);
	}
	void Update() {
		if (m_lastShotTime > 0)
			m_lastShotTime -= Time.deltaTime;
		EnemySearch();
	}
}
