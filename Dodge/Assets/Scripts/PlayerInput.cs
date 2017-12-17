using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour {
	private Player player;
	private Vector2 input;

	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();	
	}
	
	// Update is called once per frame
	void Update () {
		//Move
		player.directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

	}
}
