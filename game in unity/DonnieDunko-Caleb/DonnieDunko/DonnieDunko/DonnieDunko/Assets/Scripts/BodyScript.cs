using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BodyScript : MonoBehaviour {

	public enum BODY_COLOR 
	{
		DOOFUS = 1,
		DONNIE,
		WHITE,
		BLACK,
		WHITE_SUIT,
		BLACK_SUIT
	};

	Animator BodyAni;
	int Selected = 0;

	GameObject Current_Body;

	List <BODY_COLOR> Bodies;
	BODY_COLOR gBodyCol;

	// Use this for initialization
	void Start () {

		BodyAni = GetComponent<Animator> ();
		Bodies = new List<BODY_COLOR> ();
		gBodyCol = new BODY_COLOR ();
	}
	
	// Update is called once per frame
	void Update () {

		if(GameObject.Find("doofus_1") || GameObject.Find("doofus_2") || GameObject.Find("doofus_3")) 
		{
			Selected = (int)BODY_COLOR.DOOFUS;
		}
		else if(GameObject.Find("donnie_1") || GameObject.Find("donnie_2") || GameObject.Find("donnie_3"))
		{
			Selected = (int)BODY_COLOR.DONNIE;
		}
		else if(GameObject.Find("light_woman_suit_1") || GameObject.Find("light_woman_suit_2") || GameObject.Find("light_woman_suit_3"))
		{
			Selected = (int)BODY_COLOR.WHITE_SUIT;
		}
		else if(GameObject.Find("dark_woman_suit_1") || GameObject.Find("dark_woman_suit_2") || GameObject.Find("dark_woman_suit_3"))
		{
			Selected = (int)BODY_COLOR.BLACK_SUIT;
		}
		else if(GameObject.Find("light_man_suit_1") || GameObject.Find("light_man_suit_2") || GameObject.Find("light_man_suit_3"))
		{
		   Selected = (int)BODY_COLOR.WHITE_SUIT;
		}
		else if(GameObject.Find("dark_man_suit_1") || GameObject.Find("dark_man_suit_2") || GameObject.Find("dark_man_suit_3"))
		{
			Selected = (int)BODY_COLOR.BLACK_SUIT;
		}
		else if(GameObject.Find("light_woman_1") || GameObject.Find("light_woman_2") || GameObject.Find("light_woman_3"))
		{
			Selected = (int)BODY_COLOR.WHITE;
		}
		else if(GameObject.Find("dark_woman_1") || GameObject.Find("dark_woman_2") || GameObject.Find("dark_woman_3"))
		{
			Selected = (int)BODY_COLOR.BLACK;
		}
		else if(GameObject.Find("light_man_1") || GameObject.Find("light_man_2") || GameObject.Find("light_man_3"))
		{
			Selected = (int)BODY_COLOR.WHITE;
		}
		//Commented code may or may not be needed
		/*switch (gBodyCol) {

		case BODY_COLOR.DOOFUS:
			{
				Selected = 1;
				break;
			}
		case BODY_COLOR.DONNIE:
		{
			Selected = 2;
			break;
		}
		case BODY_COLOR.WHITE:
		{
			Selected = 3;
			break;
		}
		case BODY_COLOR.BLACK:
		{
			Selected = 4;
			break;
		}
		case BODY_COLOR.WHITE_SUIT:
		{
			Selected = 5;
			break;
		}
		case BODY_COLOR.BLACK_SUIT:
		{
			Selected = 6;
			break;
		}*/
	}

 }
