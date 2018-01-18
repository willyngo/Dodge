using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {

	private Animator anim;
	private BoxCollider2D box;

	private Vector3 endScale;

	private float growSpeed = 2.3f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		box = GetComponent<BoxCollider2D> ();
		gameObject.transform.localScale = Vector3.zero;
		endScale = new Vector3 (1.5f, 1.5f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.transform.localScale != endScale) {
			gameObject.transform.localScale = Vector3.MoveTowards (gameObject.transform.localScale, endScale, growSpeed * Time.deltaTime);
		}
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
