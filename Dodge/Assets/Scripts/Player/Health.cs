using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public Player player;
	private GameObject heart1;
	private GameObject heart2;
	private GameObject heart3;

	public Sprite filled;
	public Sprite empty;

	// Use this for initialization
	void Start () {

		heart1 = GameObject.Find ("heart1");
		heart2 = GameObject.Find ("heart2");
		heart3 = GameObject.Find ("heart3");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.health == 2) {
			heart3.GetComponent<Image> ().sprite = empty;
		} else if (player.health == 1) {
			heart2.GetComponent<Image> ().sprite = empty;
		} else if (player.health == 0) {
			heart1.GetComponent<Image> ().sprite = empty;
		}
	}
}
