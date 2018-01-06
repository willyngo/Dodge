using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	bool contact; //
	private int direction = 1;
	private int speed;

	public Vector2 velocity;
	private BoxCollider2D box;
	private Animator anim;

	// Use this for initialization
	void Start () {
		speed = Random.Range (3, 6);

		contact = false;
		box = GetComponent<BoxCollider2D> ();
		anim = GetComponent<Animator> ();

		//Decide direction to go
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null && player.transform.position.x < transform.position.x) {
			direction = -1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!contact) {
			Move ();
		}
	}


	private void Move(){
		//Moves left for now
		velocity.x = speed * (direction / Mathf.Abs(direction));
		transform.Translate (velocity * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player" || other.tag == "Level"){
			if (other.tag == "Player") {
				other.gameObject.GetComponent<Player> ().ReceiveDamage ();
			}
			contact = true; //so Move() in Update() doesn't run
			box.enabled = false; //take out lingering collider box
			anim.Play ("fireball_contact");
			Destroy (this.gameObject, 1f);
//		Debug.Log ("FIRE HIT");
		}
	}
}
