using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgMusicController : MonoBehaviour {

	public AudioSource intro;
	public AudioSource mainMenuLoop;
	public AudioSource gameLoop;

	void Awake() {
		// Check if there was already a background music. If so, destroy it
		// to remove duplicate background music.
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("Music");
		if (objs.Length > 1)
			Destroy (this.gameObject);

		// Keep the music playing after pressing "PLAY" and changing to 
		// the Game scene.
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		intro.PlayScheduled (AudioSettings.dspTime + 0.25f);
		mainMenuLoop.PlayScheduled (AudioSettings.dspTime + 0.22f + intro.clip.length);
	}

	void OnEnable() {
		// Tell our 'OnLevelFinishedLoading' function to start listening
		// for a scene change as soon as this script is enabled.
		SceneManager.sceneLoaded += OnSceneChange;
	}

	void OnDisable() {
		//Tell our 'OnLevelFinishedLoading' function to stop listening 
		// for a scene change as soon as this script is disabled. 
		// Remember to always have an unsubscription for every delegate you subscribe to!
		SceneManager.sceneLoaded -= OnSceneChange;
	}

	/// <summary>
	/// Custom function. Raises the scene change event.
	/// </summary>
	/// <param name="scene">Scene.</param>
	/// <param name="mode">Mode.</param>
	void OnSceneChange(Scene scene, LoadSceneMode mode) {
		if (scene.name.Equals ("GameWilly")) {
			double switchWithIntroTime = AudioSettings.dspTime + (intro.clip.length - intro.time) - 0.03f;
			double switchWithMainMenuLoopTime = AudioSettings.dspTime + (mainMenuLoop.clip.length - mainMenuLoop.time) - 0.03f;
			if (intro.isPlaying) {
				gameLoop.PlayScheduled (switchWithIntroTime);
				mainMenuLoop.Stop ();
			} else {
				mainMenuLoop.SetScheduledEndTime (switchWithMainMenuLoopTime);
				gameLoop.PlayScheduled (switchWithMainMenuLoopTime);
			}
		} else {
			gameLoop.Stop ();
			intro.PlayScheduled (AudioSettings.dspTime + 0.25f);
			mainMenuLoop.PlayScheduled (AudioSettings.dspTime + 0.22f + intro.clip.length);
		}
	}
}
