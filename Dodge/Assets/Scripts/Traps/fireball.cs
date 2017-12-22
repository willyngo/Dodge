using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
	public Vector2 velocity;
	public BoxCollider2D box;

	// Use this for initialization
	void Start () {
		box = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		velocity.x = -1f;
		transform.Translate (velocity * Time.deltaTime);
	}
}
