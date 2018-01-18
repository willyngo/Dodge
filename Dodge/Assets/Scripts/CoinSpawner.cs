using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {

	public GameObject[] coinPatterns;
	private int coinLength;

	private float nextSpawn = 0;
	public float spawnRate = 6f;
	public float randomDelay = 2f;

	// Interval at which we search for coins
	private float searchCountdown = 1f;

	// Use this for initialization
	void Start () {
		coinLength = coinPatterns.Length;
	}

	// Update is called once per frame
	void Update () {
		if(!CoinIsOnScreen() && Time.time > nextSpawn) {
			GameObject obj = coinPatterns [Random.Range (0, coinLength)];
			Vector3 pos = obj.transform.position;
			pos.x = Random.Range (-7, 6);
			Instantiate (obj, pos, obj.transform.rotation);
			nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
		}
	}

	bool CoinIsOnScreen() {
		searchCountdown -= Time.deltaTime;

		if (searchCountdown <= 0f) {
			searchCountdown = 1f;

			if (GameObject.FindGameObjectWithTag("Coin") == null) {
				return false;
			}
		}

		return true;
	}
}
