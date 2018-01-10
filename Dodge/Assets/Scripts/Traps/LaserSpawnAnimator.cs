using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnAnimator : MonoBehaviour {

	public float movementSpeed = 2f;
	private float timer = 0.0f;
	public float destroyTimer = 8f;

	private bool reachedDestination = false;

	private Transform laserGun;
	private Vector3 startPosition;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () {
		laserGun = transform.Find ("LaserGun");
		startPosition = laserGun.position;
		endPosition = transform.Find("LaserFinalPosition").position;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		// Move the laser gun forward a bit when it spawns.
		if (laserGun.transform.position != endPosition && !reachedDestination) {
			laserGun.transform.position = Vector3.MoveTowards (laserGun.transform.position, endPosition, movementSpeed * Time.deltaTime);
		} else if (reachedDestination && timer > destroyTimer) {
			laserGun.transform.position = Vector3.MoveTowards (laserGun.transform.position, startPosition, movementSpeed * Time.deltaTime);
			Destroy (gameObject, 3f);
		} else {
			reachedDestination = true;
		}
	}
}
