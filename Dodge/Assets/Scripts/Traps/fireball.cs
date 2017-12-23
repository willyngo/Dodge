using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {

	bool contact; //
	public LayerMask playerMask;

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

		SendRaycast ();
	}

	private void Move(){
		velocity.x = -1f;
		transform.Translate (velocity * Time.deltaTime);
	}

	private void SendRaycast(){
		Bounds bounds = box.bounds;
		Vector2 left = new Vector2 (bounds.min.x, bounds.max.y - bounds.extents.y);

		RaycastHit2D leftHit = Physics2D.Raycast (left, Vector2.left, 0f, playerMask);

		Debug.DrawRay (left, Vector2.left, Color.red);

		if (leftHit) {
//			Debug.Log ("HIT PLAYER");
			contact = true;
			OnContact ();
		}
	}

	private void OnContact(){	
		anim.SetTrigger ("contact");
		Destroy (this.gameObject, 1f);
	}


}
