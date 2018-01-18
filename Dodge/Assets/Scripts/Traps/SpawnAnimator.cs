using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimator : MonoBehaviour {

	public float movementSpeed = 2f;
	private float timer = 0.0f;
	public float destroyTimer = 8f;

	private bool reachedDestination = false;

	public Transform objectToMove;
	private Vector3 startPosition;
	public Transform endPoint;
	private Vector3 endPosition;

	// Use this for initialization
	void Start () {
		startPosition = objectToMove.position;
		endPosition = endPoint.position;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		// Move the laser gun forward a bit when it spawns.
		if (objectToMove.position != endPosition && !reachedDestination) {
			objectToMove.position = Vector3.MoveTowards (objectToMove.position, endPosition, movementSpeed * Time.deltaTime);
		} else if (reachedDestination && timer > destroyTimer) {
			objectToMove.position = Vector3.MoveTowards (objectToMove.position, startPosition, movementSpeed * Time.deltaTime);
			Destroy (gameObject, 3f);
		} else {
			reachedDestination = true;
		}
	}
}
