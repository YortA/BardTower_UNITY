using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCol : MonoBehaviour
{
	public GameObject hitPrefab;

	private Transform explosive;

	private void Start()
	{
		explosive = transform;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Walkable")
		{

			// We want to change how our hit particles are seen by the camera.
			ContactPoint contact = collision.contacts[0];
			Quaternion rotation = Quaternion.FromToRotation(Vector3.back, contact.normal);
			Vector3 position = contact.point;

			if(hitPrefab != null)
			{
				GameObject hitVFX = Instantiate(hitPrefab, position, rotation);		// Instantiate our hitvfx particle
				ParticleSystem psHit = hitVFX.GetComponent<ParticleSystem>();		// Find our particle system
				if (psHit != null)
				{
					Destroy(hitVFX, psHit.main.duration);
				}
				else
				{
					var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();		// Destroy our leftover particle system.
					Destroy(hitVFX, psChild.main.duration);
				}
			}

			Destroy(gameObject);

			Collider[] Colls = Physics.OverlapSphere(explosive.position, 8.0f);			// Change second argument for "radius"
			foreach (Collider col in Colls)
			{
				if (col.CompareTag("Enemy"))
				{
					EnemyStats enemyHealth = col.GetComponent<EnemyStats>();
					//float distance = Vector3.Distance(col.transform.position, explosive.position);		// We can use this if we want to change the damage distance
					float damage = 50.0f;
					enemyHealth.ApplyDamage(damage);
				}
			}



			//Damage(collision.transform);
		}
	}
}
