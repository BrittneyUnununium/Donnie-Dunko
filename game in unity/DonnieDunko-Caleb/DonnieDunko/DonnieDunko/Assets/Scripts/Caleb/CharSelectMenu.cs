using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSelectMenu : MonoBehaviour {

	public GameObject button;
	public GameObject startingPoint;
	public GameObject SignText;

	public void UpdateSignText() {

	}

	void PopulateMenu() {
		float ySpace = 30;
		int numberOfButtons = PeopleList.Instance.people.Length;
		
		for (int i=0; i<numberOfButtons; i++) {
			GameObject newButton = Instantiate(button, new Vector3(this.transform.position.x, startingPoint.transform.position.y - (ySpace * i), 0), Quaternion.identity) as GameObject;
			newButton.transform.parent = this.transform;
			newButton.GetComponentInChildren<Text>().text = PeopleList.Instance.people[i].name;
			newButton.GetComponent<SelectButton>().index = i;
		}
	}


	// Use this for initialization
	void Start () {

		PopulateMenu ();

		//RectTransform rect = this.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
