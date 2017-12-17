using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RaycastController))]
public class Player : MonoBehaviour {

	public float gravity; //Amount of velocity y to fall
	public float jumpHeight; //Height of jump
	public float speed; //Horizontal movement speed
	public int facing = 1; //1 means facing right, -1 means left

	public Vector2 velocity;
	public Vector2 directionalInput;

	public RaycastController rc;

	// Use this for initialization
	void Start () {
		rc = GetComponent<RaycastController> ();

		gravity = -(2 * 2.5f) / Mathf.Pow(0.32f, 2);
		speed = 7f;
		jumpHeight = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		getPlayerInput ();
		velocity.x = directionalInput.x * speed;
		velocity.y += gravity * Time.deltaTime;
		Move (velocity * Time.deltaTime);

		if (rc.collision.below) {
			Debug.Log ("COLLISION BELOW");
			velocity.y = 0f;
		} else {
			Debug.Log ("AIRBORNE");
		}
	}
	public void Move(Vector2 moveAmount)
	{
		rc.UpdateRayOrigins ();
		rc.collision.Reset ();

		//facing
		facing = (int)Mathf.Sign(moveAmount.x);

		//Check collisions - if found, moveAmount velocity will be reduced appropriately
		rc.checkCollisions (ref moveAmount);

		//Actually changing the velocity of game object
		transform.Translate (moveAmount);
	}

	private void getPlayerInput()
	{
		this.directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
	}
}
