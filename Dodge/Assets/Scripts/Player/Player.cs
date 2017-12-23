using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RaycastController))]
public class Player : MonoBehaviour {

	/* STATS */
	public int health;

	/* MOVEMENT */
	public float gravity; //Amount of velocity y to fall
	public float jumpHeight; //Height of jump
	public float speed; //Horizontal movement speed

	public int facing = 1; //1 means facing right, -1 means left
	public bool isAirborne;
	public bool isDoubleJumping;

	public Vector2 velocity;
	public Vector2 directionalInput;

	public RaycastController rc;
	public SpriteRenderer render;
	public Animator animator;

	// Use this for initialization
	void Start () {
		rc = GetComponent<RaycastController> ();
		render = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();

		health = 3;

		//Kinematic formula, solve for acceleration going down
		gravity = -(2 * 2.5f) / Mathf.Pow(0.32f, 2);
		speed = 5f;
		jumpHeight = 12.5f;
	}
	
	// Update is called once per frame
	void Update () {
		GetPlayerInput ();
		velocity.x = directionalInput.x * speed;
		velocity.y += gravity * Time.deltaTime; //Gravity makes game obj fall at all times
		//Move game object'
		Move (velocity * Time.deltaTime);

		//Checks current state of game obj and makes adjustment to velocity if necessary
		checkState ();
	}

	/// <summary>
	/// Maybe game master file should keep track of player's health.
	/// </summary>
	private void ReceiveDamage(){
		health--;
		if (health <= 0) {
			//Call EndGame() method from gamemaster file.
		}
	}

	//Called in update()
	public void Move(Vector2 moveAmount)
	{
		//Updates raycast position as game object moves.
		rc.UpdateRayOrigins ();
		rc.collision.Reset ();

		//direction player is facing; right = 1, left = -1
		setFacingDirection();

		//Check collisions - if found, moveAmount velocity will be reduced appropriately
		rc.checkCollisions (ref moveAmount);

		//Actually changing the velocity of game object
		transform.Translate (moveAmount);
	}

	/// <summary>
	/// This method checks the state of the game object after moving and makes any approriate changes 
	/// should it encounter states such as being airborne, grounded or interacting with incoming obstacle.
	/// </summary>
	private void checkState()
	{
		//If grounded, reset airborne and double jump state
		if (rc.collision.below) {
			velocity.y = 0f;
			isAirborne = false;
			isDoubleJumping = false;
		} else if (!rc.collision.below) { //when airborne
			isAirborne = true;
		}
		animator.SetBool ("airborne", isAirborne); //Set sprite to airborne animation

		if (rc.collision.above) { //If hit ceiling, set velocity.y to 0 to prevent accumulating
			velocity.y = 0f;
			Debug.Log ("Hit ceiling");
		}
	}

	/// <summary>
	/// Sets the facing direction of game object
	/// </summary>
	private void setFacingDirection()
	{
		//Keeps game object facing direction when not moving
		if (velocity.x != 0) {
			rc.collision.collDirection = (int)Mathf.Sign (velocity.x);
		}

		//Flips sprite
		bool dir = render.flipX ? (directionalInput.x > 0) : (directionalInput.x < 0);
		if (dir) {
			render.flipX = !render.flipX;
		}
	}

	/**
	 * USER INPUT
	 * 
	 */
	private void GetPlayerInput()
	{
		this.directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		animator.SetFloat ("velocityX", Mathf.Abs (directionalInput.x));

		//Jump
		if (Input.GetKeyDown ("j")) {
			OnJumpDown ();
		}
	}

	private void OnJumpDown()
	{
		if (rc.collision.below) {
			isAirborne = true;
			velocity.y = jumpHeight;
		}

		//Double jump
		if (!isDoubleJumping && !rc.collision.below) {
			velocity.y = jumpHeight * .8f;
			isDoubleJumping = true;
		}
	}
}
