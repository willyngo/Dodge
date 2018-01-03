using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public static Sprite one;
	public static Sprite two;
	public static Sprite three;
	public static Sprite four;
	public static Sprite five;
	public static Sprite six;
	public static Sprite seven;
	public static Sprite eight;
	public static Sprite nine;
	public static Sprite zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void SetNumberSprite(GameObject numberSprite, int value)
	{
		switch (value) {
		case 0:
			numberSprite.GetComponent<Image> ().sprite = zero;
			break;
		case 1:
			numberSprite.GetComponent<Image> ().sprite = one;
			break;
		case 2:
			numberSprite.GetComponent<Image> ().sprite = two;
			break;
		case 3:
			numberSprite.GetComponent<Image> ().sprite = three;
			break;
		case 4:
			numberSprite.GetComponent<Image> ().sprite = four;
			break;
		case 5:
			numberSprite.GetComponent<Image> ().sprite = five;
			break;
		case 6:
			numberSprite.GetComponent<Image> ().sprite = six;
			break;
		case 7:
			numberSprite.GetComponent<Image> ().sprite = seven;
			break;
		case 8:
			numberSprite.GetComponent<Image> ().sprite = eight;
			break;
		case 9:
			numberSprite.GetComponent<Image> ().sprite = nine;
			break;
		}
	}
}
