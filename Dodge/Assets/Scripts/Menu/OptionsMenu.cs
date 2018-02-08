using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	// Holds all available resolutions supported by your computer.
	Resolution[] resolutions;

	public Dropdown resolutionDropdown;

	void Start()
	{
		resolutions = Screen.resolutions;

		// Clear the preset options.
		resolutionDropdown.ClearOptions ();

		List<string> options = new List<string> ();

		// Populate resolutions dropdown.
		int currentResolutionIndex = 0;
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + " x " + resolutions [i].height;
			options.Add (option);

			if (resolutions [i].width == Screen.currentResolution.width &&
				resolutions[i].height == Screen.currentResolution.height) {
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions [resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetVolume(float volume)
	{
		//audioMixer.SetFloat ("volume", volume);
		AudioListener.volume = volume;
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel (qualityIndex);
	}

	public void SetFullscreen(bool isFullscreen) 
	{
		Screen.fullScreen = isFullscreen;
	}
}
