using UnityEngine;
using System.Collections;

public class PeopleList : MonoBehaviour {

	private static PeopleList _instance = new PeopleList();
	public static PeopleList Instance { get { return _instance; } }

	public GameObject[] people;

	void Awake() { _instance = this; }
}
