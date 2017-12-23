using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y <= -4.04 && gameObject.transform.position.y >= -4.30
			&& player.transform.position.x >= -4.7 && player.transform.position.y <= -3.079) {
			Debug.Log ("SQUASHED");
		}
	}
}
