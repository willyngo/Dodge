using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RaycastController : MonoBehaviour {

	public LayerMask collisionMask; //Layer in which to detect a collision

	public const float widthBuffer = 0.015f; //Buffer distance
	private const float dstBetweenRays = 0.25f; //Should have 4 rays for each side

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

	public void checkCollisions(ref Vector2 moveAmount){
		
		if (moveAmount.y != 0) {
			checkVerticalCollisions (ref moveAmount);
		}
	}

	private void checkHorizontalCollision(ref Vector2 moveAmount)
	{

	}

	private void checkVerticalCollisions(ref Vector2 moveAmount)
	{
		float directionY = Mathf.Sign (moveAmount.y);
		float rayLength = Mathf.Abs (moveAmount.y) + widthBuffer;

		//firing raycast
		for (int i = 0; i < rayCount_v; i++) {
			Vector2 rayOrigin = (directionY == -1) ? botLeft : topLeft;
			rayOrigin += Vector2.right * (raySpacing_v * i + moveAmount.x);
			RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay (rayOrigin, Vector2.up * directionY, Color.red);

			//If collision found, update moveAmount.y by reducing the change in velocity
			if (hit) {
				moveAmount.y = (hit.distance - widthBuffer) * directionY;
				rayLength = hit.distance;
			}

			//Set collision bool
			collision.below = (directionY == -1);
			collision.above = (directionY == 1);
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
		public int faceDir;
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
