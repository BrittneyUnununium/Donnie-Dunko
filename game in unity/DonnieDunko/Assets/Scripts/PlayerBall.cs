using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBall : MonoBehaviour {

	public float Speed = 1000.0f;
	public GameObject BallPrefab;

	private int Num_Dunks;

	public Transform Trans;

	private int Balls;
	private GameObject SeatFlipped,SeatNotFlipped;
	private int Ball_Life; //how long the ball lasts after being shot


	public GameObject TankPrefab;
	public GameObject FloorPrefab;
	public GameObject YellowBackPrefab;

	void Start () {

		Trans = GameObject.Find("Player").transform;
		Num_Dunks = 0;
		Balls = 4;
		Ball_Life = 5000;
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
		float v = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

		if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1"))
		{
			Rigidbody rbBall;
			BallPrefab.SetActive(true); //make the prefab active/visible
			rbBall = Instantiate(BallPrefab, Trans.position, Trans.rotation) as Rigidbody; //shoot the ball
			rbBall.AddForce(Trans.forward * Speed); //add force to the ball

			SeatFlipped.SetActive(true); //make the seat animation active

			Ball_Life--;

			if(Ball_Life == 0)
			{
				SeatFlipped.SetActive(false);
				SeatNotFlipped.SetActive(true);
			}

			Num_Dunks++;
			Balls--;
		}
	}
}
