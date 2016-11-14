using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharitySelect : MonoBehaviour {

	public int index;
	
	public void OnClick() {
		GameObject signText = GameObject.Find("SignText");
		signText.GetComponent<Text>().text = this.GetComponentInChildren<Text>().text;
		UIManager.Instance.UpdateSelectedCharity (CharityList.Instance.Chairty [index]);
 }
}