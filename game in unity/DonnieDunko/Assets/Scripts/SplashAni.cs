using UnityEngine;
using System.Collections;

public class SplashAni : MonoBehaviour {

	Animator splash;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Animator>().Play("Splash_2");
		SoundManager.Instance.PlaySound("splash");
	}
}
