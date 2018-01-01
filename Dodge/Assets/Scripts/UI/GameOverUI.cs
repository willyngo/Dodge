using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

	public void ShowScore(float score)
	{
		//Get UI elements
		GameObject scoreObj = GameObject.Find ("ScoreText");
		Text scoreTxt = scoreObj.GetComponent<UnityEngine.UI.Text>();

		//Convert time
		//Convert time to millisecond
		int milliseconds = (int) ((score % 1) * 100);
		int millisecond_1 = milliseconds % 10;
		int millisecond_10 = milliseconds / 10;

		//Convert time to seconds
		int seconds = (int)score % 60;
		int second_1 = seconds % 10;
		int second_10 = (seconds % 60 == 0) ? 0 : seconds / 10;

		//Convert time to minutes
		int minutes = (int) score / 60;
		int minute_1 = minutes % 10;
		int minute_10 = (minutes % 60 == 0) ? 0 : minutes / 10;

		//Display text
		scoreTxt.text = "You survived for: " + minute_10 + minute_1 + ":" + second_10 + second_1 + ":" + 
			millisecond_10 + millisecond_1;
	}
}
