using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	/// <summary>
	/// Opens the next scene in the build queue (should be the game).
	/// </summary>
	public void PlayGame()
    {
        SceneManager.LoadScene("GameWilly");
    }

	/// <summary>
	/// Quits/Closes the application.
	/// </summary>
	public void QuitGame()
	{
		Debug.Log ("QUIT");
		Application.Quit ();
	}
}
