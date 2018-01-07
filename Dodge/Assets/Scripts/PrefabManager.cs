using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class will be responsible for changing values for prefabs.
/// Good for when the prefab hasn't spawned yet and you want it to behave in a 
/// special way later.
/// TODO: Create methods according to the prefabs that has public values.
/// </summary>
public class PrefabManager : MonoBehaviour {

	public GameObject[] prefabs;

	/// <summary>
	/// Changes the spike row speed to a given float value.
	/// </summary>
	/// <param name="speed">Speed.</param>
	public void ChangeSpikeRowSpeed(float speed) {
		for (int i = 0; i < prefabs.Length; i++) {
			if(prefabs[i].name.StartsWith("SpikeRow")) {
				prefabs [i].GetComponent<LinearMovementController> ().speed = speed;
			}
		}
	}

	public void IncreaseSpikeRowSpeed(float multiplier) {
		float initSpeed = 0f;
		for (int i = 0; i < prefabs.Length; i++) {
			if(prefabs[i].name.StartsWith("SpikeRow")) {
				initSpeed = prefabs [i].GetComponent<LinearMovementController> ().speed;
				prefabs [i].GetComponent<LinearMovementController> ().speed = initSpeed + initSpeed * multiplier;;
			}
		}
	}
}
