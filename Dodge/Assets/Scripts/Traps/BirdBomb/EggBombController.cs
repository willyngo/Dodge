using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBombController : MonoBehaviour {

	public Animator anim;

	public Rigidbody2D rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Ground")
			|| other.gameObject.tag.Equals("Player")) {
			// Stops the vertical movement of the bomb.
			rigidBody.isKinematic = true;
			rigidBody.velocity = Vector2.zero;

			// Plays the explosion animation.
			anim.Play ("Explosion");

			// GameObject destroyed after 1 second
			Destroy(gameObject, 1); 
		}
	}

}
