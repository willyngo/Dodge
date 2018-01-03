using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {

	private Animator anim;
	private BoxCollider2D box;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Debug.Log ("Picked up Coin");
			anim.Play ("coin_pickup");
			box.enabled = false; //prevents lingering boxcollider from registering with player after pickup
			Destroy (gameObject, 0.4f);
		}
	}
}
