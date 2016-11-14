using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationCode : MonoBehaviour {

	//You can use this script to drag and drop onto the game objects you wanna animate

	//Animation types
	private enum ANI_TYPE {
		NORMAL,
		BODY,
		SPLASH
	};

	private const int MAX_ANI_FRAMES = 16; //16 frames of animations, 3 for the body and 13 for the splash ani
	private const int MAX_BODY_FRAMES = 3; //only 3 frames for the body
	private const int MAX_SPLASH_FRAMES = 13; //13 frames for the splash
	//const denotes it is a constant value (I.E. value does not change)
	public GameObject SplashPrefab; //Game object of the splash prefab
	//Prefab is like a copy of the game object, but can be accessed through code


	public int Current_Frame; //Current frame of animation, default value 1
	public Sprite[] sprites; //Array of sprites to hold sprite images
	public float framesPerSecond; //the amount of frames per second processed
	public Sprite[] BodySprites; //Texture ani slots for body frames
	public Sprite[] SplashSprites; //Texture ani slots for splash frames, note [] denotes it is an array

	private SpriteRenderer spriteRend; //Renderer for sprites
	private Renderer rend; //General graphics renderer
	private ANI_TYPE gAni;

	// Use this for initialization
	void Start () {

		Current_Frame = 1;

		rend = new Renderer(); //make new instance of render
		spriteRend = rend as SpriteRenderer; //set spriterender to normal render, but make sure it is declared as spriteRender
		gAni = new ANI_TYPE(); //make new instance of ani-type enum
		BodySprites = new Sprite[3]; //Make new instance of array, set it to hold 3 slots
		SplashSprites = new Sprite[13]; //Make new instance of array, set it to hold 13 slots
		//Note array indices start 0, The number inside the [] is how big the array is or how many items it can hold
	}
	
	// Update is called once per frame
	void Update () {

		switch(gAni)
		{
			case ANI_TYPE.BODY:
			{
				foreach(Sprite BodyFrame in BodySprites)
				{
				   spriteRend.sprite = BodySprites[Current_Frame];
				}
				if (Current_Frame >= MAX_BODY_FRAMES)
				{
					Current_Frame = MAX_BODY_FRAMES;
				}
				break;
			}
			case ANI_TYPE.SPLASH:
			{
				foreach(Sprite SplashFrame in SplashSprites)
				{
					spriteRend.sprite = SplashSprites[Current_Frame];
					SplashPrefab.SetActive(true); //make the game object enabled
				}
				if(Current_Frame >= MAX_SPLASH_FRAMES)
				{
					Current_Frame = MAX_SPLASH_FRAMES;
				}
				break;
			}
		}

		//Above code checks to see what type of animation it is, then a foreach loop is called,which goes
		//through the array and checks how many there then, next we set the sprite render to render it by the
		//frames through the current frame. We then add a check to make sure it dosen't go over the max limit
		
		Current_Frame = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		//Set the current frame to the time since the level loaded and multiply it by the framesperSecond
		Current_Frame = Current_Frame % SplashSprites.Length; //Set the current frame to the current frame by the length
		//of sprites(length being how many frames there are)
		spriteRend.sprite = SplashSprites[Current_Frame]; //Set renderer to draw sprites by the current frame

		if (Current_Frame >= MAX_ANI_FRAMES) //Check to make sure frames dosen't go over max limit
		{
			Current_Frame = MAX_ANI_FRAMES; //Set current frames to max limit
		}
		//Code above checks type of animation and then check to see if it goes over limit, if it does, it then sets
		//the current frame to the max value of the current type of animation it is trying to animte.
	}
}
