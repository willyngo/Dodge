using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthUI))]
[RequireComponent(typeof(GameOverUI))]
public class GameManager : MonoBehaviour {

	public Player player;

	public GameObject gameOverScreen;
	public GameObject coinScript;
	public GameObject healthScript;
	public GameObject gameOverScript;

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
//		coinScript.gameObject.GetComponent<CoinsUI>().UpdateCoinUI (player.coins);
		healthScript.gameObject.GetComponent<HealthUI>().UpdateHealthUI (player.health);

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
		gameOverScript.gameObject.GetComponent<GameOverUI>().ShowScore (currentTime);
	}
}
