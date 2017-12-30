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

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;

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
				StartCoroutine(SpawnWave(waves[nextWave]));
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

		// Spawn
		for (int i = 0; i < _wave.count; i++) {
			SpawnEnemy (_wave.enemy);

			// Wait few seconds before spawning next wave.
			yield return new WaitForSeconds (1/_wave.rate);
		}

		state = SpawnState.WAITING;

		yield break;
	}

	void SpawnEnemy(Transform _enemy){
		// Spawn Enemy
		Debug.Log("Spawning Enemy: " + _enemy.name);

		if (spawnPoints.Length == 0) {
			Debug.LogError ("No spawn points found");
		}

		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

		Instantiate(_enemy, _sp.position, _sp.rotation);

	}
}
