using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float m_interval = 3;
	public GameObject m_moveTarget;
	public Monster Monster;
	public float m_start_time;


	void Start()
    {
		StartCoroutine(Spawn());
		//InvokeRepeating("AddCreep", m_start_time, m_interval);

	}
	IEnumerator Spawn()
	{
		while (true)
		{
			Monster.m_moveTarget = m_moveTarget;
			Instantiate(Monster, transform.position, Quaternion.identity);
			yield return new WaitForSeconds(m_interval);
		}
	}
		private void AddCreep()
    {
		Instantiate(Monster, transform.position, Quaternion.identity);
	}
	
}


