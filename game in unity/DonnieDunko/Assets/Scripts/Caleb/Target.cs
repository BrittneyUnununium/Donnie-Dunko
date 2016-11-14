using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	// Use this for initialization

	Animator Splash;
	AnimationState state;
	//GameObject SeatPrefab;
	//GameObject player;
	int Finished = Animator.StringToHash("Finished");
	int Splashing = Animator.StringToHash("target_hit");

	void Start () {

		Splash = this.GetComponent<Animator>();
		
	}



	// Update is called once per frame
	void Update () {

		AnimatorStateInfo info = Splash.GetCurrentAnimatorStateInfo(0);

		/*if(info.shortNameHash == Finished)
		{
			Splash.SetBool("Splashing",false);
		}*/
		/*else if(info.shortNameHash == Splashing)
		{
			Splash.SetBool("Splashing",false);
		}*/
	}



	void OnCollisionEnter(Collision col) {


		if (col.gameObject.CompareTag ("ball")) {

			// SEND MESSAGE HERE
			Debug.Log("TARGET HIT: trigger animation and poin increase here");
			this.GetComponent<Animation>().Play("target_hit");
			//this.GetComponent<Player>().dunks++;

			//GameObject.Find("seat_normal").GetComponent<Animation>().enabled = true;

			
			if(GameObject.Find("light_man_suit_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("light_man_suit_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("dark_man_suit_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("dark_man_suit_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("light_woman_suit_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("light_woman_suit_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("light_man_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("light_man_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("dark_man_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("dark_man_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("light_woman_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("light_woman_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("dark_woman_suit_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("dark_woman_suit_1").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("Donnie Dunko"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("Donnie Dunko").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}
			else if(GameObject.Find("Doofus"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = true;
				GameObject.Find("Doofus").GetComponent<Animator>().enabled = true;
				GameObject.Find("splash_1").GetComponent<Animator>().enabled = true;
			}

			//Splash.enabled = true;			

			 
			 SoundManager.Instance.PlaySound("splash");

			//UIManager.Instance.EnableSelectMenu();

			// ignores collision with ball after being hit once 
			// (to prevent multiple hits from the same ball) 
			Physics.IgnoreCollision(this.GetComponent<Collider>(), col.collider);
			
		}
		
		/*else if(Splash.GetBool("Not_Splashing"))
		{
			Splash.enabled = false;
		}*/
	
	}

}
