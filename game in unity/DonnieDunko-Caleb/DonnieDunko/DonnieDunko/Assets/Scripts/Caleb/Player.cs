using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private static Player _instance = new Player();
	public static Player Instance { get { return _instance; } }

	public GameObject ball;

	public int balls;
	public int dunks;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) && balls > 0) {

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Instantiate(ball, new Vector3(mousePos.x, mousePos.y, -3), Quaternion.identity);

			balls -= 1;

			SoundManager.Instance.PlaySound("throw", true, -0.35f, 0.35f);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			UIManager.Instance.EnableSelectMenu();
		}
	
	}



	void Awake() { _instance = this; }
}
