using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovementController : MonoBehaviour {

	public float speed = 10;

	public string direction = "right";

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(direction.Equals("left", System.StringComparison.InvariantCultureIgnoreCase)){
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if(direction.Equals("right", System.StringComparison.InvariantCultureIgnoreCase)){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		else if(direction.Equals("up", System.StringComparison.InvariantCultureIgnoreCase)){
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		else if(direction.Equals("down", System.StringComparison.InvariantCultureIgnoreCase)){
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
	}
}
