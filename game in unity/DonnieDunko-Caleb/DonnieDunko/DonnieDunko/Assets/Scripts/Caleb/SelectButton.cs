using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {
	
	public int index;

	public void OnClick() {
		GameObject signText = GameObject.Find("SignText");
		signText.GetComponent<Text>().text = this.GetComponentInChildren<Text>().text;
		UIManager.Instance.UpdateSelectedPerson (PeopleList.Instance.people [index]);
		//UIManager.Instance.selectedPerson = PeopleList.Instance.people [index];
	}
}
