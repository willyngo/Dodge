using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	private GameObject heart1;
	private GameObject heart2;
	private GameObject heart3;

	[SerializeField]
	private Sprite filled;
	[SerializeField]
	private Sprite empty;

	// Use this for initialization
	void Start () {

		heart1 = GameObject.Find ("heart1");
		heart2 = GameObject.Find ("heart2");
		heart3 = GameObject.Find ("heart3");
	}

	public void UpdateHealthUI(int health)
	{
		if (health == 2) {
			heart3.GetComponent<Image> ().sprite = empty;
		} else if (health == 1) {
			heart2.GetComponent<Image> ().sprite = empty;
		} else if (health == 0) {
			heart1.GetComponent<Image> ().sprite = empty;
		}
	}
}
