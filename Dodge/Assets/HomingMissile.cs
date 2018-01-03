﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour {

	public Transform target;

	public float speed = 5f;
	public float rotateSpeed = 200f;

	public GameObject explosionEffect;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		if (target == null) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
		}

		rigidBody = GetComponent<Rigidbody2D> ();
	}

	// For physics
	void FixedUpdate () {
		// Direction/vector from missile's position to the target's position.
		Vector2 direction = (Vector2) target.position - rigidBody.position;

		direction.Normalize ();

		// Cross product of the two vectors
		float rotateAmount = Vector3.Cross (direction, transform.right).z;

		// Put minus because the cross product gives the rotate in orthogonal vectors
		rigidBody.angularVelocity = -rotateAmount * rotateSpeed;

		rigidBody.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Ground")
			|| other.gameObject.tag.Equals("Player")) {

			Instantiate (explosionEffect, transform.position, transform.rotation);

			Destroy(gameObject); 
		}
	}
}
