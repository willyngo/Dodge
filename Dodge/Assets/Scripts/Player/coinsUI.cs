using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsUI : MonoBehaviour
{

	public Player player;

	private int amountOfCoins;

	private GameObject unit;
	private GameObject tenfold;
	private GameObject hundredfold;

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
	void Start ()
	{
		unit = GameObject.Find ("count_one");
		tenfold = GameObject.Find ("count_ten");
		hundredfold = GameObject.Find ("count_hundred");
	}
	
	// Update is called once per frame
	void Update ()
	{
		amountOfCoins = player.coins;
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

		setAmount (unit, ones);
		setAmount (tenfold, tens);
		setAmount (hundredfold, hundreds);
	}

	void setAmount (GameObject go, int amount)
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
