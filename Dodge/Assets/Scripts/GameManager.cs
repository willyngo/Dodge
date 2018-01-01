using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Player player;

	[SerializeField]
	private GameObject gameOverScreen;

	public CoinsUI coinScript;
	public HealthUI healthScript;
	public GameOverUI gameOverScript;

	// Use this for initialization
	void Start () 
	{
		//Ensure player starts with 3 hp
		player.health = 3;

		//Resets pause menu values
		PauseMenu.GameIsPaused = false;

		//Ensure timescale is set to 1
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Updates
		coinScript.UpdateCoinUI (player.coins);
		healthScript.UpdateHealthUI (player.health);

		//If player health reaches 0, game is over;
		if (player.health == 0) {
			EndGame ();
		}
	}

	private void EndGame()
	{
		//gameover
		Time.timeScale = 0f;
		gameOverScreen.SetActive(true);

		//Display score, currentTime format X.00
		float currentTime = Mathf.Round(100f * Time.timeSinceLevelLoad) / 100f;
		gameOverScript.ShowScore (currentTime);
	}
}
