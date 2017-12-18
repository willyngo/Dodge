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
		if (other.gameObject.tag.Equals("Ground")) {
			rigidBody.isKinematic = true;
			rigidBody.velocity = Vector2.zero;
			anim.Play ("Explosion");
			Destroy(gameObject, 1); // Destroyed after 1 second
		}
	}

}
