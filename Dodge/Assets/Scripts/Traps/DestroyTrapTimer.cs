using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrapTimer : MonoBehaviour {

	public float timer;
	public float timeUntilDestroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= timeUntilDestroy) {
			Destroy (this.gameObject);
		}
	}
}
