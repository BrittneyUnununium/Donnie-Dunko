using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float 	ballLife;
	private float	elapsedTime;
	public float 	force;

	float minDist = 0.01f;
	float maxDist = 1.0f;

	float minDistScale = 1.0f;
	float maxDistScale = 0.1f;

	void UpdateTime() {
		elapsedTime += Time.deltaTime;
	}

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);
	
	}

	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= ballLife) {
			//GameObject.Find("Player").SendMessage("OnBallDestroyed");
			Destroy(this.gameObject);
		}
	
	}
}
