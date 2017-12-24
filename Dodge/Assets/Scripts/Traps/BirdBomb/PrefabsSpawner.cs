using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsSpawner : MonoBehaviour {

	private float nextSpawn = 0;
	public GameObject[] prefabsToSpawn;
	public float spawnRate = 1;
	public float randomDelay = 1;
	private int index = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn) {
			index = Random.Range (0, prefabsToSpawn.Length);
			Instantiate (prefabsToSpawn[index], transform.position, prefabsToSpawn[index].transform.rotation);
			nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
		}
	}
}
