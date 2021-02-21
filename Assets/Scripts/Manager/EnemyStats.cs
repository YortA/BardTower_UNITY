using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
	public float StartHealth = 100;
	public int ManaReturn = 1;

	private float Health;

	//public GameObject deathAnimation;			// Add death animation later


	public static EnemyStats _enemy { get; private set; }

	[Header("Enemy Drop-ins")]
	public Image healthBar;

	private void Awake()
	{
		if (_enemy == null)
		{
			_enemy = this;
		}
	}

	private void Start()
	{
		Health = StartHealth;
	}


	public void ApplyDamage(float amount)
	{
		Health -= amount;

		healthBar.fillAmount = Health / StartHealth;


		if (Health <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Destroy(gameObject);
		// banana
		//PlayerStats.Mana += ManaReturn;
	}



}
