using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFollowPlayer : MonoBehaviour {

	private SpriteRenderer render;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		// Check if the player is on the left side of the bird
		if (player != null && player.transform.position.x < transform.position.x) {
			// Make the bird go left
			render = GetComponent<SpriteRenderer> ();
			MakeBirdGoLeft ();
		}
	}

	void MakeBirdGoLeft() {
		GetComponent<LinearMovementController>().direction = "left";
		render.flipX = !render.flipX;
	}
}
