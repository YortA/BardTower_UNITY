using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
	public CompositeSpawnZone CompositeSpawnZone;

	public enum SpawnState { Spawning, Waiting, Counting };
	private SpawnState State = SpawnState.Counting; // default state

	[System.Serializable]
	public class Wave
	{
		public string EnemyName;
		public Transform EnemyPrefab;
		public int Count; // Amount of enemies to spawn
		public float SpawnRate;
		// Add more things later
	}

	public Wave[] Waves;
	private int NextWave = 0;

	public float TimePerWave = 5f;
	private float WaveCountdown = 0f; // Displays our timer countdown before next wave

	public TextMeshProUGUI WaveCountdownText;
	public TextMeshProUGUI WaveNumberText;

	private float SearchCountdown = 1f; // Change this value to increse/decrease time to check (1f=1second)

	private void Start()
	{
		//  ########### Fix this later to be used with composite spawns
		// Make sure we've chosen our spawn locations
		//if (SpawnPoints.Length == 0)
		//{
		//	Debug.LogError("Spawn point not referenced.");
		//}

		WaveCountdown = TimePerWave;
	}

	private void Update()
	{
		TestDeleteEnemies();

		if (State == SpawnState.Waiting)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
				return;
			}
			else
			{
				// Enemies are alive, so we return
				return;
			}
		}


		// We use this to make sure that the game is spawning a wave based on time, rather than per frame
		if (WaveCountdown <= 0)
		{
			if (State != SpawnState.Spawning)
			{
				StartCoroutine(SpawnWave(Waves[NextWave]));
				//Countdown = TimePerWave;
			}
		}
		// This is the amount of time since we drew the last frame. Meaning it will reduce countdown by 1 every second.
		else
		{
			WaveCountdown -= Time.deltaTime;
			if (WaveCountdown <= 0)
			{
				// we can assign this a different prefab later if we want to.
				WaveCountdownText.text = "";
				WaveNumberText.text = "Wave " + (NextWave + 1);
			}
			else
			{
				WaveNumberText.text = "";
				WaveCountdownText.text = Mathf.RoundToInt(WaveCountdown).ToString();
			}
		}
	}

	// Check to see if enemies are alive in our scene
	private bool EnemyIsAlive()
	{
		SearchCountdown -= Time.deltaTime;
		if (SearchCountdown <= 0f)
		{
			SearchCountdown = 1f; // reset our timer
			if (GameObject.FindGameObjectWithTag("Enemy") == null)
			{
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave wave)
	{
		Debug.Log("Spawning wave." + wave.EnemyName);
		State = SpawnState.Spawning;

		for (int i = 0; i < wave.Count; ++i)
		{
			SpawnEnemy(wave.EnemyPrefab);
			yield return new WaitForSeconds(1f / wave.SpawnRate); // This controls how often our enemy is spawned. 
		}

		State = SpawnState.Waiting;
		yield break;
	}

	// Spawn Enemies (can use multiple methods for multiple enemies, such as a for loop inside this.
	private void SpawnEnemy(Transform enemy)
	{
		Debug.Log("Spawning Enemy" + enemy.name);
		Instantiate(enemy, CompositeSpawnZone.SpawnPoint(), Quaternion.identity);
	}

	private void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		State = SpawnState.Counting;
		WaveCountdown = TimePerWave;

		// Here we can add game finished, add multipliers, new scene (level), etc.
		if ((NextWave + 1) > Waves.Length - 1)
		{
			NextWave = 0;
			Debug.Log("WAVES FINISHED. Looping");
		}
		else
		{
			++NextWave;
		}
	}

	private void TestDeleteEnemies()
	{
		// Assign enemies to an array and then delete them
		GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			foreach (GameObject enemy in Enemies) 
			{
				GameObject.Destroy(enemy);
				//EnemyStats._enemy.ApplyDamage(25);
			}
		}
	}
}
