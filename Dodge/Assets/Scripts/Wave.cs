using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave {

	public string name;

	// Reference to enemy prefab
	public Transform enemy; // TODO: Create list of enemies

	// Number of enemies
	public int count;
	public float rate;

}
