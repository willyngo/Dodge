using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour {

	public LayerMask collisionMask; //Layer in which to detect a collision

	public const float widthBuffer = .015f; //Buffer distance
	private const float dstBetweenRays = .25f; //Should have 4 rays for each side

	public int rayCount_h; //number of horizontal rays
	public int rayCount_v; //number of vertical rays

	public float raySpacing_h;
	public float raySpacing_v;

	public BoxCollider2D box; //box collider of game object

	//Raycast origins
	public Vector2 topLeft;
	public Vector2 topRight;
	public Vector2 botLeft;
	public Vector2 botRight;

	//Collisions information
	public CollisionInformation collision;

	public virtual void Awake(){
		box = GetComponent<BoxCollider2D> ();
	}

	void Start () {
		/*** Set up raycasts ***/
		//Get bounds of boxcollider with a bit of buffer
		Bounds bounds = box.bounds;
		bounds.Expand (widthBuffer * -2);

		float width = bounds.size.x;
		float height = bounds.size.y;

		//Set direction, by default we face right;
		collision.collDirection = 1;

		//Calculate number of rays
		rayCount_h = Mathf.RoundToInt (height / dstBetweenRays);
		rayCount_v = Mathf.RoundToInt (width / dstBetweenRays);

		//Space them out evenly
		raySpacing_h = height / (rayCount_h - 1);
		raySpacing_v = width / (rayCount_v - 1);
	}

	/**
	 * Update point of origin of raycast when boxcollider moves.
	 *
	 */
	public void UpdateRayOrigins()
	{
		//Get bounds of boxcollider with a bit of buffer
		Bounds bounds = box.bounds;
		bounds.Expand (widthBuffer * -2);

		//set raycast origin point
		topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		topRight = new Vector2 (bounds.max.x, bounds.max.y);
		botLeft = new Vector2 (bounds.min.x, bounds.min.y);
		botRight = new Vector2 (bounds.max.x, bounds.min.y);
	}

	/// <summary>
	/// Checks for both horizontal and vertical collisions. 
	/// If collisions are encountered, moveAmount will be adjusted
	/// </summary>
	/// <param name="moveAmount">Move amount.</param>
	public void checkCollisions(ref Vector2 moveAmount){

		checkHorizontalCollision (ref moveAmount);

		if (moveAmount.y != 0) {
			checkVerticalCollisions (ref moveAmount);
		}
	}

	private void checkHorizontalCollision(ref Vector2 moveAmount)
	{
		float directionX = collision.collDirection;
		float rayLength = Mathf.Abs (moveAmount.x) + widthBuffer;
		Vector2 rayDirection = Vector2.right * directionX;

		//Creates raycast
		for (int i = 0; i < rayCount_h; i++) {
			Vector2 rayOrigin = directionX == 1 ? botRight : botLeft;
			rayOrigin += Vector2.up * raySpacing_h * i;
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, rayDirection, rayLength, collisionMask);

			Debug.DrawRay (rayOrigin, rayDirection, Color.red);

			if (hit) {
				if (hit.distance == 0) {
					continue;
				}

				//If hit a wall
				moveAmount.x = (hit.distance - widthBuffer) * directionX;
				rayLength = hit.distance;

				//Set which side has collided
				collision.right = (directionX == 1);
				collision.left = (directionX == -1);
			}
		}
	}

	private void checkVerticalCollisions(ref Vector2 moveAmount)
	{
		float directionY = Mathf.Sign (moveAmount.y);
		float rayLength = Mathf.Abs (moveAmount.y) + widthBuffer;
		Vector2 rayDirection = Vector2.up * directionY;

		//firing raycast
		for (int i = 0; i < rayCount_v; i++) {
			Vector2 rayOrigin = (directionY == -1) ? botLeft : topLeft;
			rayOrigin += Vector2.right * (raySpacing_v * i + moveAmount.x);
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, rayDirection, rayLength, collisionMask);

			Debug.DrawRay (rayOrigin, rayDirection, Color.red);

			//If collision found, update moveAmount.y by reducing the change in velocity
			if (hit) {
				moveAmount.y = (hit.distance - widthBuffer) * directionY;
				rayLength = hit.distance;

				//Set collision bool
				collision.below = (directionY == -1);
				collision.above = (directionY == 1);
			}
		}
	}

	public struct CollisionInformation
	{
		public bool above, below;
		public bool left, right;

		public bool climbingSlope;
		public bool descendingSlope;
		public float slopeAngle, slopeAngleOld;
		public Vector2 moveAmountOld;
		public int collDirection;
		public bool fallingThroughPlatform;
		public bool standingOnPlatform;

		public void Reset()
		{
			above = below = false;
			left = right = false;
			climbingSlope = false;
			descendingSlope = false;

			slopeAngleOld = slopeAngle;
			slopeAngle = 0f;
		}
	}
}
