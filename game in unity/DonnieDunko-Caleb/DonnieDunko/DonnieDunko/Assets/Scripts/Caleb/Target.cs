using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.CompareTag ("ball")) {

			// SEND MESSAGE HERE
			Debug.Log("TARGET HIT: trigger animation and poin increase here");
			this.GetComponent<Animation>().Play("target_hit");

			// ignores collision with ball after being hit once 
			// (to prevent multiple hits from the same ball) 
			Physics.IgnoreCollision(this.GetComponent<Collider>(), col.collider);
		}
	}
}
