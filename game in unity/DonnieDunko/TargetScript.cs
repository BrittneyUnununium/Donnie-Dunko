using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	private bool was_hit; //was target hit
	private int frames; //total frames
	private int current_frame; //current frame
	private TargetScript target;

	// Use this for initialization
	void Start () {
		was_hit = false;
		frames = 2;
		current_frame = 1;
	}
	
	// Update is called once per frame
	void Update () {

		Animate ();
	}

	void Animate()
	{
		if (was_hit == true) 
		{
			current_frame++;
			if(current_frame >= frames)
			{
				current_frame = 1;
			}
		}
	}
}
