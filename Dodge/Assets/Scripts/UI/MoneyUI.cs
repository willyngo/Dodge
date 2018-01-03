using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

	//UI elements
	private GameObject oneUI;
	private GameObject tenUI;
	private GameObject hundredUI;

	//Sprites images - Is this how it's supposed to be done???
	[SerializeField]
	private Sprite one;
	[SerializeField]
	private Sprite two;
	[SerializeField]
	private Sprite three;
	[SerializeField]
	private Sprite four;
	[SerializeField]
	private Sprite five;
	[SerializeField]
	private Sprite six;
	[SerializeField]
	private Sprite seven;
	[SerializeField]
	private Sprite eight;
	[SerializeField]
	private Sprite nine;
	[SerializeField]
	private Sprite zero;


	// Use this for initialization
	void Start ()
	{
		oneUI = GameObject.Find ("count_one");
		tenUI = GameObject.Find ("count_ten");
		hundredUI = GameObject.Find ("count_hundred");
	}

	/// <summary>
	/// Called in the GameManager's update(). This method seperates the 
	/// amount of coins in digits and updates each coins UI elements.
	/// </summary>
	/// <param name="amountOfCoins">Amount of coins.</param>
	public void UpdateCoinUI(int amountOfCoins)
	{
		int ones = 0;
		int tens = 0;
		int hundreds = 0;

		ones = amountOfCoins % 10;

		if (amountOfCoins > 9) {
			tens = (amountOfCoins % 100) / 10;

			if (amountOfCoins > 99) {
				hundreds = amountOfCoins / 100;
			}
		}

		SetAmount (oneUI, ones);
		SetAmount (tenUI, tens);
		SetAmount (hundredUI, hundreds);
	}

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