using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BgMusicMainMenu : MonoBehaviour {

	// Intro audio played ONCE when Main Menu is loaded.
	public AudioClip introClip;

	// Loop this audio after the intro audio has finished playing.
	public AudioClip loopClip;

	// Loop this audio when changing to the "Game" scene. Start the loop
	// after loopClip finished playing.
	public AudioClip mainClip;

	private AudioSource audioSource;

	IEnumerator playMainMenuMusic;

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

	void Start () {
		audioSource = GetComponent<AudioSource> ();

		playMainMenuMusic = playBgMusic ();
		StartCoroutine (playMainMenuMusic);
	}
	
	IEnumerator playBgMusic()
	{
		audioSource.clip = introClip;
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length);
		audioSource.clip = loopClip;
		audioSource.Play();
		audioSource.loop = true;
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
		if (scene.name.Equals ("GameShifat")) {

			if(audioSource.clip.name.Equals("bg_1_buildup")){
				StopCoroutine (playMainMenuMusic);
			}

			StartCoroutine (playMainMusic());
		} else {
			
		}
	}

	IEnumerator playMainMusic()
	{
		yield return new WaitForSeconds(audioSource.clip.length - audioSource.time);
		audioSource.clip = mainClip;
		audioSource.Play();
		audioSource.loop = true;
	}
}
