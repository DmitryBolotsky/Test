using UnityEngine;
using System.Collections;

public class CannonProjectile : MonoBehaviour {
	public float m_speed = 1f;
	public int m_damage = 30;

	void Update () {
		Shooting();
	}
	void Shooting()
    {
		var translation = transform.forward * m_speed;
		transform.Translate(translation);
		StartCoroutine(Destroyer(this.gameObject));
	}

	void OnTriggerEnter(Collider other) {
		var monster = other.gameObject.GetComponent<Monster> ();
		if (monster == null)
		{
			return;

		}
		Destroy(this.gameObject);
		monster.m_hp -= m_damage;
		if (monster.m_hp <= 0) {
			Destroy (monster.gameObject);
		}
		
	}
	IEnumerator Destroyer(GameObject projectile)
    {
		yield return new WaitForSeconds(5f);
		Destroy(projectile);
	}
}
