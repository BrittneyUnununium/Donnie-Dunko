using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float 	ballLife;
	private float	elapsedTime;
	public float 	force;
	public float 	rollForce;
	 bool 	thrown;
	GameObject player;

	bool hit;

	float minimumDistance = 1.0f;
	float maximumDistance = 10.0f;
	
	float minimumDistanceScale = 1.5f;
	float maximumDistanceScale = 0.7f;

	void UpdateTime() {
		elapsedTime += Time.deltaTime;
	}

	// Use this for initialization
	void Start () {
		hit = false;
		thrown = true;
		this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);
	
	}

	// Update is called once per frame
	void Update () {

		float distance = (transform.position - Camera.main.transform.position).magnitude;
		float norm = (distance - minimumDistance) / (maximumDistance - minimumDistance);
		norm = Mathf.Clamp01 (norm);

		var minScale = Vector3.one * maximumDistanceScale;
		var maxScale = Vector3.one * minimumDistanceScale;

		transform.localScale = Vector3.Lerp(maxScale, minScale, norm);

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= ballLife) {
			//GameObject.Find("Player").SendMessage("OnBallDestroyed");
			thrown = false;
			Destroy(this.gameObject);

			
			if(GameObject.Find("light_man_suit_1"))
			{
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
				GameObject.Find("light_man_suit_1").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("light_man_1"))
			{
				GameObject.Find("light_man_1").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("dark_man_suit_1"))
			{	
				GameObject.Find("dark_man_suit_1").GetComponent<Animator>().enabled = false;	
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;	
			}
			else if(GameObject.Find("dark_man_1"))
			{
				GameObject.Find("dark_man_1").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("light_woman_suit_1"))
			{
				GameObject.Find("light_woman_suit_1").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("light_woman_1"))
			{
				GameObject.Find("light_woman_1").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("Donnie Dunko"))
			{
				GameObject.Find("Donnie Dunko").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("dark_woman_suit_1"))
			{
				GameObject.Find("dark_woman_suit_1").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
			else if(GameObject.Find("Doofus"))
			{
				GameObject.Find("Doofus").GetComponent<Animator>().enabled = false;
				GameObject.Find("seat_normal").GetComponent<Animator>().enabled = false;
			}
	
			GameObject.Find("splash_1").GetComponent<Animator>().enabled = false;

			UIManager.Instance.EnableSelectMenu();
		}

		if (hit) {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * rollForce);
		}


	
	}


	void OnCollisionEnter(Collision col) {
		// SEND MESSAGE HERE
		Debug.Log("TEST");
		hit = true;
		thrown = false;
		if (col.collider.CompareTag ("wall")) {

			SoundManager.Instance.PlaySound ("ball_drop");

		} else if (col.collider.CompareTag ("floor")) {

			SoundManager.Instance.PlaySound ("ball_rolling");

		} else if (col.collider.CompareTag ("BigTarget")) {

			GameObject.Find("Player").GetComponent<Player>().balls -= 1;
			GameObject.Find("Player").GetComponent<Player>().dunks += 1;
			SoundManager.Instance.PlaySound ("target_hit");

		}
		else {
			SoundManager.Instance.PlaySound ("ball_drop");
		}
	}
}
