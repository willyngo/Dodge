using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoinPattern : MonoBehaviour {

	// Interval at which we search for coins
	private float searchCountdown = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		searchCountdown -= Time.deltaTime;

		if (searchCountdown <= 0f) {
			searchCountdown = 1f;
			if(transform.childCount <= 0){
				Destroy (gameObject);
			}
		}
	}
}
