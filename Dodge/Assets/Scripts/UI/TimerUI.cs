using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

	//UI Image
	private GameObject second_one;
	private GameObject second_ten;
	private GameObject milli_one;
	private GameObject milli_ten;
	private GameObject minute_one;
	private GameObject minute_ten;

	//Seperate values of time
	private int second_1;
	private int second_10;
	private int millisecond_1;
	private int millisecond_10;
	private int minute_1;
	private int minute_10;

	//Sprites
	public Sprite one;
	public Sprite two;
	public Sprite three;
	public Sprite four;
	public Sprite five;
	public Sprite six;
	public Sprite seven;
	public Sprite eight;
	public Sprite nine;
	public Sprite zero;

	// Use this for initialization
	void Start () {
		second_one = GameObject.Find ("second_one");
		second_ten = GameObject.Find ("second_ten");
		milli_one = GameObject.Find ("milli_one");
		milli_ten = GameObject.Find ("milli_ten");
		minute_one = GameObject.Find ("minute_one");
		minute_ten = GameObject.Find ("minute_ten");

		second_1 = 0;
		second_10 = 0;
		millisecond_1 = 0;
		millisecond_10 = 0;
		minute_1 = 0;
		minute_10 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Get time with 2 decimal points
		float currentTime = Mathf.Round(100f * Time.timeSinceLevelLoad) / 100f;
		UpdateTimerUI (currentTime);
	}

	private void UpdateTimerUI(float currentTime)
	{
		//Convert time to millisecond
		int milliseconds = (int) ((currentTime % 1) * 100);
		millisecond_1 = milliseconds % 10;
		millisecond_10 = milliseconds / 10;


		//Convert time to seconds
		int seconds = (int)currentTime % 60;
		second_1 = seconds % 10;
		second_10 = (seconds % 60 == 0) ? 0 : seconds / 10;

		//When time goes above a minute
		if (currentTime > 59) {
			int minutes = (int) currentTime / 60;
			minute_1 = minutes % 10;
			SetAmount (minute_one, minute_1);

			//When time goes above 10 minutes
			if (minutes > 9) {
				minute_10 = (minutes % 60 == 0) ? 0 : minutes / 10;
				SetAmount (minute_ten, minute_10);
			}
		}

		//SetUI elements
		SetAmount (milli_one, millisecond_1);
		SetAmount (milli_ten, millisecond_10);

		//SetUI elements
		SetAmount (second_one, second_1);
		SetAmount (second_ten, second_10);
	}

	/// <summary>
	/// Yeah its repeated code from CoinsUI, I'll refactor the codes to make it more efficient some other time.
	/// </summary>
	/// <param name="go">Go.</param>
	/// <param name="amount">Amount.</param>
	void SetAmount (GameObject go, int amount)
	{
		switch (amount) {
		case 0:
			go.GetComponent<Image> ().sprite = zero;
			break;
		case 1:
			go.GetComponent<Image> ().sprite = one;
			break;
		case 2:
			go.GetComponent<Image> ().sprite = two;
			break;
		case 3:
			go.GetComponent<Image> ().sprite = three;
			break;
		case 4:
			go.GetComponent<Image> ().sprite = four;
			break;
		case 5:
			go.GetComponent<Image> ().sprite = five;
			break;
		case 6:
			go.GetComponent<Image> ().sprite = six;
			break;
		case 7:
			go.GetComponent<Image> ().sprite = seven;
			break;
		case 8:
			go.GetComponent<Image> ().sprite = eight;
			break;
		case 9:
			go.GetComponent<Image> ().sprite = nine;
			break;
		}
	}
}
