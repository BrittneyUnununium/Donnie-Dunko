using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	private static UIManager _instance = new UIManager();
	public static UIManager Instance { get { return _instance; } }

	public GameObject player;
	public GameObject selectPanel;
	public GameObject CharityPanel;

	public GameObject selectedPerson;
	public GameObject selectedCharity;
	public Transform spawnPoint;

	public GameObject ballAmtText;
	public GameObject Dunks;


	public void EnableSelectMenu() {
		player.GetComponent<Player> ().enabled = false;
		selectPanel.SetActive (true);

	}
	public void DisableSelectMenu() {
		player.GetComponent<Player> ().enabled = true;
		selectPanel.SetActive (false);
	}

	public void EnableCharityMenu()
	{
		player.GetComponent<Player>().enabled = false;
		CharityPanel.SetActive(true);
	}

	public void DisableCharityMenu()
	{
		player.GetComponent<Player>().enabled = true;
		CharityPanel.SetActive(false);
	}

	public void StartGame() {
		// other code may be needed here later //

		//Instantiate (selectedPerson, spawnPoint.position, spawnPoint.rotation);
		if (selectedPerson != null) {

			//Player.Instance.balls = 3; // TEMP
			//Player.Instance.dunks = 0;
			DisableSelectMenu ();
		}

	}

	public void UpdateSelectedPerson(GameObject newPerson) {
		Destroy (selectedPerson);
		selectedPerson = Instantiate (newPerson, spawnPoint.position, spawnPoint.rotation) as GameObject;
	}

	public void UpdateSelectedCharity(GameObject newCharity) {
		Destroy(selectedCharity);
		selectedCharity = Instantiate(newCharity, spawnPoint.position, spawnPoint.rotation) as GameObject;
	}



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		ballAmtText.GetComponent<Text> ().text = Player.Instance.balls.ToString ();
		Dunks.GetComponent<Text>().text = Player.Instance.dunks.ToString();
	}


	void Awake() { _instance = this; }
}
