using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float 	ballLife;
	private float	elapsedTime;
	public float 	force;
	public float 	rollForce;

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
			Destroy(this.gameObject);
		}

		if (hit) {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.right * rollForce);
		}


	
	}


	void OnCollisionEnter(Collision col) {
		// SEND MESSAGE HERE
		Debug.Log("TEST");
		hit = true;
		if (col.collider.CompareTag ("wall")) {

			SoundManager.Instance.PlaySound ("ball_drop");

		} else if (col.collider.CompareTag ("floor")) {

			SoundManager.Instance.PlaySound ("ball_rolling");

		} else if (col.collider.CompareTag ("BigTarget")) {

			SoundManager.Instance.PlaySound ("target_hit");
		} else {
			SoundManager.Instance.PlaySound ("ball_drop");
		}
	}
}
