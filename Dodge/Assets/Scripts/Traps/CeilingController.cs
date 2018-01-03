using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals ("Player") 
			&& !other.gameObject.GetComponent<Player>().isAirborne) {
			Debug.Log ("SQUASHED");
		}
	}
}
