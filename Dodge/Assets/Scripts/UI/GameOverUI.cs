using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

	public void PlayAgain()
	{
		Scene currentLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentLevel.buildIndex);
	}

	public void LoadMenu() 
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}
}
