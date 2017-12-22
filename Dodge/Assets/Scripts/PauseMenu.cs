using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

	/// <summary>
	/// Resume the game.
	/// </summary>
	public void Resume() {
		pauseMenuUI.SetActive (false);

		// Restores normal game speed.
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	/// <summary>
	/// Freezes the game.
	/// </summary>
	void Pause() {
		// Enable the pause menu canvas.
		pauseMenuUI.SetActive (true);

		// Freeze the game.
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu() {
		// Restores normal game speed.
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
