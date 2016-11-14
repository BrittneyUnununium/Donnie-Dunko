using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	

	// PUT ON ANY OBJECT/SPRITE YOU WANT ALWAYS FACING THE CAMERA

	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform.position, Vector3.up);




	}
}
