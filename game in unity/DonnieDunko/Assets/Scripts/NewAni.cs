using UnityEngine;
using System.Collections;

public class NewAni : MonoBehaviour {

	private Animator anim;
	private const int MAX_BODY_FRAMES = 3;
	private const int MAX_SPLASH_FRAMES = 13;
	private int Current_Frame = 1;

	// Use this for initialization
	void Start () {
		anim = transform.root.GetComponent<Animator>();
		anim.StartPlayback();
	}
	
	// Update is called once per frame
	void Update () {
		DoBodyAni();
		DoSplashAni();
	}

	void DoBodyAni() {
		for(int i = 0; i <= MAX_BODY_FRAMES; i++)
		{
			Current_Frame = i;
			if(Current_Frame >= MAX_BODY_FRAMES)
			{
				Current_Frame = 1;
			}
		}
	}

	void DoSplashAni() {
		for(int i = 0; i <= MAX_SPLASH_FRAMES; i++)
		{
			Current_Frame = i;

			SoundManager.Instance.PlaySound("splash");

			if(Current_Frame >= MAX_SPLASH_FRAMES)
			{
				Current_Frame = 1;
				SoundManager.Instance.StopCoroutine("splash");
			}
		}
	}
}
