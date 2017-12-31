using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Player player;

	[SerializeField]
	private GameObject gameOverUI;

	// Use this for initialization
	void Start () 
	{
		player.health = 3;

		//Resets pause menu values
		PauseMenu.GameIsPaused = false;

		//Ensure timescale is set to 1
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player.health == 0) {
			EndGame ();
		}
	}

	private void EndGame()
	{
		//gameover
		Time.timeScale = 0f;
		gameOverUI.SetActive(true);
	}
}
