using System.Collections;
using UnityEngine;

public class fireProjectile : MonoBehaviour
{
	public GameObject projectilePrefab;
	public GameObject cursor;
	public Transform shootPoint;
	public LayerMask layer;
	public GameObject ImpactFX;
	
	// Let's move these audio clips to a separate script later
	public AudioClip FireSpell;
	private AudioSource fireProjSound;
	//public float explosionRadius = 0f;

	private Camera cam;

	private float radius;
	private float dist;

	public static fireProjectile projectile { get; private set; }

	private void Awake()
	{
		if (projectile == null)
		{
			projectile = this;
		}

		fireProjSound = GetComponent<AudioSource>();
	}

	private void Start()
	{
		cam = Camera.main; // get our "Main Camera" tag
	}

	//private void Update()
	//{
	//	LaunchProjectile();
	//}

	public void StartCo()
	{
		StartCoroutine(TestProjectile());
	}

	public IEnumerator TestProjectile()
	{

		while (true)
		{
			Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(camRay, out hit, Mathf.Infinity, layer))
			{
				cursor.SetActive(true);
				cursor.transform.position = hit.point + Vector3.up * 0.1f;

				Vector3 Vo = CalculateVelocity(hit.point, shootPoint.position, 0.3f);
				
				//transform.rotation = Quaternion.LookRotation(Vo);

				radius = 84f; // this is the range you want the player to move without restriction
				dist = Vector3.Distance(cursor.transform.position, shootPoint.position); // the distance from player current position to the circleCenter

				if (dist > radius)
				{
					Vector3 fromOrigintoObject = cursor.transform.position - shootPoint.position;
					fromOrigintoObject *= radius / dist;
					cursor.transform.position = shootPoint.position + fromOrigintoObject;
					//transform.position = cursor.transform.position;
				}

				if (dist < radius)
				{
					if (Input.GetMouseButtonDown(0))
					{
						GameObject obj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
						//obj.velocity = Vo;
						obj.GetComponent<Rigidbody>().velocity = Vo;
						cursor.SetActive(false);
						fireProjSound.PlayOneShot(FireSpell, 0.5f);
						yield break;
					}
				}

				if (Input.GetMouseButtonDown(1))
				{
					SpellSuccess._success.CallFade('g');
					cursor.SetActive(false);
					yield break;
				}
			}
			else
			{
				cursor.SetActive(false);
			}
			yield return null;
		}
	}

	//private void MouseDetection()
	//{
	//	radius = 64f; // this is the range you want the player to move without restriction
	//	dist = Vector3.Distance(cursor.transform.position, shootPoint.position); // the distance from player current position to the circleCenter

	//	if (dist > radius)
	//	{
	//		Vector3 fromOrigintoObject = cursor.transform.position - shootPoint.position;
	//		fromOrigintoObject *= radius / dist;
	//		cursor.transform.position = shootPoint.position + fromOrigintoObject;
	//		//transform.position = cursor.transform.position;
	//	}
	//}

	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.gameObject.tag == "Walkable")
	//	{
	//		Destroy(gameObject);
	//		Damage(collision.transform);
	//	}
	//}

	//private void Damage(Transform enemy)
	//{
	//	EnemyStats e = enemy.GetComponent<EnemyStats>();
	//	e.ApplyDamage(50);
	//}

	//void AreaDamageEnemies(Vector3 location, float radius, float damage)
	//{
	//	Collider[] objectsInRange = Physics.OverlapSphere(location, radius);
	//	foreach (Collider col in objectsInRange)
	//	{
	//		EnemyStats enemy = col.GetComponent<EnemyStats>();
	//		if (enemy != null)
	//		{
	//			// linear falloff of effect
	//			float proximity = (location - enemy.transform.position).magnitude;
	//			float effect = 1 - (proximity / radius);

	//			//Destroy(enemy);

	//			enemy.ApplyDamage(damage * effect);
	//		}
	//	}
	//}

	//private void Explode()
	//{
	//	Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);

	//	foreach (Collider hitObject in hitObjects)
	//	{
	//		if (hitObject.tag == "Enemy")
	//		{
	//			Damage(hitObject.transform);
	//		}
	//	}
	//}

	private void Damage(Transform enemy)
	{
		Destroy(enemy.gameObject);
	}



	Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
	{
		// Define distance x, y first
		Vector3 distance = target - origin;
		Vector3 distanceXZ = distance;
		distanceXZ.y = 0f;

		// Represents our distance
		float Sy = distance.y;
		float Sxz = distanceXZ.magnitude;

		// Velocity
		float Vxz = Sxz / time; // horizontal
		float Vy = (Sy / time) + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

		Vector3 result = distanceXZ.normalized;
		result *= Vxz;
		result.y = Vy;

		return result;
	}
}
