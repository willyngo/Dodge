using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	bool contact; //
//	public LayerMask collisionMask;

	public Vector2 velocity;
	public BoxCollider2D box;
	public Animator anim;

	// Use this for initialization
	void Start () {
		contact = false;
		box = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!contact) {
			Move ();
		}
	}


	private void Move(){
		//Moves left for now
		velocity.x = -1f;
		transform.Translate (velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" || other.tag == "Level"){
			contact = true; //so Move() in Update() doesn't run
			box.enabled = false; //take out lingering collider box
			anim.Play ("fireball_contact");
			Destroy (this.gameObject, 1f);
//		Debug.Log ("FIRE HIT");
		}
	}
}
