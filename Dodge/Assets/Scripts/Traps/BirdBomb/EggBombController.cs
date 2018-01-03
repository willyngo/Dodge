using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBombController : MonoBehaviour {

	public GameObject explosionEffect;

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Ground")
			|| other.gameObject.tag.Equals("Player")) {

			if (other.gameObject.tag.Equals ("Player")) {
				other.gameObject.GetComponent<Player> ().ReceiveDamage ();
			}

			Instantiate (explosionEffect, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}

}
