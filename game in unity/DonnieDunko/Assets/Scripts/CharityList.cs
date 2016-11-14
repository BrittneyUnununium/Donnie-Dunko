using UnityEngine;
using System.Collections;

public class CharityList : MonoBehaviour {

	private static CharityList _instance = new CharityList();

	public static CharityList Instance {
		get {return _instance;}}

	public GameObject[] Chairty;

	void Awake() {_instance = this;}
	
}
