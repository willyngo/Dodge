using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState {
		SPAWNING, 
		WAITING, 
		COUNTING 
	};

	public Wave[] waves;

	// Index to wave spawning
	private int nextWave = 0;

	public List<Transform> spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;

	[Range(0.0f, 1.0f)]
	public float statMultiplier = 0.05f;

	// Interval at which we search for enemies
	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;

	void Start() {
		waveCountdown = timeBetweenWaves;
	}

	void Update() {
		if (state == SpawnState.WAITING) {
			// Check if enemies still on screen
			if (!EnemyIsAlive ()) {
				// Begin a new round
				WaveCompleted();

				return;
			} else {
				// Don't run rest of the code if there are still enemies on screen.
				return;
			}
		}

		if (waveCountdown <= 0) {
			if (state != SpawnState.SPAWNING) {
				// Start spawning wave
				if (waves != null && waves.Length > 0) {
					StartCoroutine (SpawnWave (waves [nextWave]));
				}
			}
		} else {
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted() {
		Debug.Log("Wave completed");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) {
			// TODO: Add stat multiplier
			timeBetweenWaves = timeBetweenWaves * statMultiplier;
			for (int i = 0; i < waves.Length; i++) {
				waves [i].rate = (waves [i].rate * statMultiplier) + waves [i].rate;
			}

			nextWave = 0;
			Debug.Log ("ALL WAVES COMPLETE! Looping...");
		} else {
			nextWave++;
		}
	}

	bool EnemyIsAlive() {
		searchCountdown -= Time.deltaTime;

		if (searchCountdown <= 0f) {
			searchCountdown = 1f;

			if (GameObject.FindGameObjectWithTag("Trap") == null) {
				return false;
			}
		}

		return true;
	}

	IEnumerator SpawnWave (Wave _wave){
		Debug.Log ("Spawning Wave: " + _wave.name);

		state = SpawnState.SPAWNING;

		int enemyCount = _wave.enemies.Length;

		// Spawn
		for (int i = 0; i < _wave.count; i++) {
			SpawnEnemy (_wave.enemies[Random.Range(0, enemyCount)]);

			// Wait few seconds before spawning next wave.
			yield return new WaitForSeconds (1/_wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy){
		// Spawn Enemy
		Debug.Log("Spawning Enemy: " + _enemy.name);

		if (spawnPoints.Count == 0) {
			Debug.LogError ("No spawn points found");
		}

		// Spawn the traps at a position accordingly.
		if (_enemy.name.StartsWith ("SpikeRow")) {
			// Spawn SpikeRow gameobject to its original position (prefab's position)
			Instantiate (_enemy, _enemy.transform.position, _enemy.transform.rotation);
		} else if (_enemy.name == "Laser") {
			// Get all the laser spawners.
			List<Transform> laserSpawnPoints = spawnPoints.FindAll (s => s.name.StartsWith ("LaserSpawner"));

			// Select a random spawn point
			Transform _sp = laserSpawnPoints [Random.Range (0, laserSpawnPoints.Count)];

			Instantiate (_enemy, _sp.position, _sp.rotation);
		} else {
			// Get all the default spawners.
			List<Transform> defaultSpawnPoints = spawnPoints.FindAll (s => s.name.StartsWith ("DefaultSpawner"));

			// Select a random spawn point
			Transform _sp = defaultSpawnPoints [Random.Range (0, defaultSpawnPoints.Count)];

			Instantiate(_enemy, _sp.position, _sp.rotation);
		}
	}
}
