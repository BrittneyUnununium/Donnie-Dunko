using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private static Player _instance = new Player();
	public static Player Instance { get { return _instance; } }

	public GameObject ball;

	PeopleList people;
	CharityList charity;

	public int balls;
	public int dunks;

	bool thrown;
	bool donated;

	public int doofus_dunks;
	public int donnie_dunks;
	public int lance_armstrong_dunks;
	public int michelle_bachmann_dunks;
	public int doug_baldwin_dunks;
	public int glen_beck_dunks;
	public int michael_bennet_dunks;
	public int joe_biden_dunks;
	public int justin_bieber_dunks;
	public int michael_bloomberg_dunks;
	public int john_boehner_dunks;
	public int pat_buchanan_dunks;
	public int george_bush_dunks;
	public int kam_chancellor_dunks;
	public int dick_cheney_dunks;
	public int chris_christie_dunks;
	public int hillary_clinton_dunks;
	public int stephen_colbert_dunks;
	public int bill_cosby_dunks;
	public int ann_coulter_dunks;
	public int simon_cowell_dunks;
	public int ted_cruz_dunks;
	public int miley_cyrus_dunks;
	public int scott_disick_dunks;
	public int robert_downeyjr_dunks;
	public int dr_phil_dunks;
	public int newt_gingrich_dunks;
	public int kate_gosselin_dunks;
	public int nancy_grace_dunks;
	public int sean_hannity_dunks;
	public int paris_hilton_dunks;
	public int honey_boo_boo_dunks;
	public int kim_jung_un_dunks;
	public int jwoww_dunks;
	public int khloe_kardashian_dunks;
	public int kim_kardashian_dunks;
	public int kourtney_kardashian_dunks;
	public int john_kerry_dunks;
	public int charles_koch_dunks;
	public int david_kock_dunks;
	public int ashton_kutcher_dunks;
	public int nene_leakes_dunks;
	public int rush_limbaugh_dunks;
	public int lindsay_lohan_dunks;
	public int marshawn_lynch_dunks;
	public int rachel_maddow_dunks;
	public int bill_maher_dunks;
	public int john_mccain_dunks;
	public int mitch_mcconnel_dunks;
	public int mike_mcginn_dunks;
	public int rob_mckenna_dunks;
	public int piers_morgan_dunks;
	public int patty_murray_dunks;
	public int barack_obama_dunks;
	public int russell_okung_dunks;
	public int bill_oreilly_dunks;
	public int sarah_palin_dunks;
	public int bob_parsons_dunks;
	public int rand_paul_dunks;
	public int pauly_d_dunks;
	public int rick_perry_dunks;
	public int harry_reid_dunks;
	public int rihanna_dunks;
	public int mitt_romney_dunks;
	public int karl_rove_dunks;
	public int paul_ryan_dunks;
	public int jerry_sandusky_dunks;
	public int arnold_schwarzenegger_dunks;
	public int charlie_sheen_dunks;
	public int richard_sherman_dunks;
	public int jessica_simpsons_dunks;
	public int situation_dunks;
	public int snooki_dunks;
	public int brittney_spears_dunks;
	public int jerry_springer_dunks;
	public int steve_o_dunks;
	public int jon_stewart_dunks;
	public int earl_thomas_dunks;
	public int donald_trump_dunks;
	public int max_unger_dunks;
	public int anthony_weiner_dunks;
	public int kayne_west_dunks;
	public int russell_wilson_dunks;
	public int tiger_woods_dunks;
	public int rene_zellweger_dunks;

	// Use this for initialization
	void Start () {
		donated = false;

		balls = 3; //set to 3 for testing purposes, set to 0 when not testing
		if(donated == true)
		{
		 	balls = 3;
		}

		thrown = true;

		people = new PeopleList();
		charity = new CharityList();
	}
	
	// Update is called once per frame
	void Update () {

		donated = true;

		if(Input.GetMouseButtonDown(0) && balls > 0) {

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Instantiate(ball, new Vector3(mousePos.x, mousePos.y, -3), Quaternion.identity);
			//balls -= 1;
			thrown = false;

			SoundManager.Instance.PlaySound("throw", true, -0.35f, 0.35f);

			//CheckDunks();

			if(thrown == false)
			{
				//UIManager.Instance.EnableSelectMenu();
			}
			else
			{
				thrown = true;
			}

		}

		if(balls == 0)
		{
			donated = false;
			UIManager.Instance.EnableSelectMenu();
		}
		else if(balls == 0 && donated == false)
		{
			UIManager.Instance.EnableCharityMenu();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {

			UIManager.Instance.EnableSelectMenu();
		}
	
	}

	void CheckDunks()
	{
		if(people.name == "armstrong lance")
		{
			lance_armstrong_dunks++;
		}
		else if(people.name == "bachmann michelle")
		{
			michelle_bachmann_dunks++;
		}
		else if(people.name == "baldwin doug")
		{
			doug_baldwin_dunks++;
		}
		else if(people.name == "beck glenn")
		{
			glen_beck_dunks++;
		}
		else if(people.name == "bennett michael")
		{
			michael_bennet_dunks++;
		}
		else if(people.name == "biden joe")
		{
			joe_biden_dunks++;
		}
		else if(people.name == "bieber justin")
		{
			justin_bieber_dunks++;
		}
		else if(people.name == "bloomberg michael")
		{
			michael_bloomberg_dunks++;
		}
		else if(people.name == "boehner john")
		{
			john_boehner_dunks++;
		}
		else if(people.name == "buchanan pat")
		{
			pat_buchanan_dunks++;
		}
		else if(people.name == "bush george")
		{
			george_bush_dunks++;
		}
		else if(people.name == "chancellor kam")
		{
			kam_chancellor_dunks++;
		}
		else if(people.name == "cheney dick")
		{
			dick_cheney_dunks++;
		}
		else if(people.name == "christie chris")
		{
			chris_christie_dunks++;
		}
		else if(people.name == "clinton hillary")
		{
			hillary_clinton_dunks++;
		}
		else if(people.name == "colbert stephen")
		{
			stephen_colbert_dunks++;
		}
		else if(people.name == "cosby bill")
		{
			bill_cosby_dunks++;
		}
		else if(people.name == "coulter ann")
		{
			ann_coulter_dunks++;
		}
		else if(people.name == "cowell simon")
		{
			simon_cowell_dunks++;
		}
		else if(people.name == "cruz ted")
		{
			ted_cruz_dunks++;
		}
		else if(people.name == "cyrus miley")
		{
			miley_cyrus_dunks++;
		}
		else if(people.name == "disick scott")
		{
			scott_disick_dunks++;
		}
		else if(people.name == "downyjr robert")
		{
			robert_downeyjr_dunks++;
		}
		else if(people.name == "dr phil")
		{
			dr_phil_dunks++;
		}
		else if(people.name == "gingrich newt")
		{
			newt_gingrich_dunks++;
		}
		else if(people.name == "gosselin kate")
		{
			kate_gosselin_dunks++;
		}
		else if(people.name == "grace nancy")
		{
			nancy_grace_dunks++;
		}
		else if(people.name == "hannity sean")
		{
			sean_hannity_dunks++;
		}
		else if(people.name == "hilton paris")
		{
			paris_hilton_dunks++;
		}
		else if(people.name == "honey boo boo")
		{
			honey_boo_boo_dunks++;
		}
		else if(people.name == "jong-un kim")
		{
			kim_jung_un_dunks++;
		}
		else if(people.name == "jwoww")
		{
			jwoww_dunks++;
		}
		else if(people.name == "kardashian khloe")
		{
			khloe_kardashian_dunks++;
		}
		else if(people.name == "kardashian kim")
		{
			kim_kardashian_dunks++;
		}
		else if(people.name == "kardashian kourtney")
		{
			kourtney_kardashian_dunks++;
		}
		else if(people.name == "kerry john")
		{
			john_kerry_dunks++;
		}
		else if(people.name == "koch charles")
		{
			charles_koch_dunks++;
		}
		else if(people.name == "kock david")
		{
			david_kock_dunks++;
		}
		else if(people.name == "kutcher ashton")
		{
			ashton_kutcher_dunks++;
		}
		else if(people.name == "leakes nene")
		{
			nene_leakes_dunks++;
		}
		else if(people.name == "lambaugh rush")
		{
			rush_limbaugh_dunks++;
		}
		else if(people.name == "lohan lindsay")
		{
			lindsay_lohan_dunks++;
		}
		else if(people.name == "lynch marshawn")
		{
			marshawn_lynch_dunks++;
		}
		else if(people.name == "maddow rachel")
		{
			rachel_maddow_dunks++;
		}
		else if(people.name == "maher bill")
		{
			bill_maher_dunks++;
		}
		else if(people.name == "mccain john")
		{
			john_mccain_dunks++;
		}
		else if(people.name == "mcconnell mitch")
		{
			mitch_mcconnel_dunks++;
		}
		else if(people.name == "mcginn mike")
		{
			mike_mcginn_dunks++;
		}
		else if(people.name == "mckenna rob")
		{
		  rob_mckenna_dunks++;
		}
		else if(people.name == "morgan piers")
		{
			piers_morgan_dunks++;
		}
		else if(people.name == "murray patty")
		{
			patty_murray_dunks++;
		}
		else if(people.name == "obama barack")
		{
			barack_obama_dunks++;
		}
		else if(people.name == "okung russell")
		{
			russell_okung_dunks++;
		}
		else if(people.name == "oreilly bill")
		{
			bill_oreilly_dunks++;
		}
		else if(people.name == "palin sarah")
		{
			sarah_palin_dunks++;
		}
		else if(people.name == "parsons bob")
		{
			bob_parsons_dunks++;
		}
		else if(people.name == "paul rand")
		{
			rand_paul_dunks++;
		}
		else if(people.name == "pauly d")
		{
			pauly_d_dunks++;
		}
		else if(people.name == "perry rick")
		{
			rick_perry_dunks++;
		}
		else if(people.name == "reid harry")
		{
			harry_reid_dunks++;
		}
		else if(people.name == "rihanna")
		{
			rihanna_dunks++;
		}
		else if(people.name == "romney mitt")
		{
			mitt_romney_dunks++;
		}
		else if(people.name == "rove karl")
		{
		  karl_rove_dunks++;
		}
		else if(people.name == "ryan paul")
		{
			paul_ryan_dunks++;
		}
		else if(people.name == "sandusky jerry")
		{
			jerry_sandusky_dunks++;
		}
		else if(people.name == "schwarzenegger arnold")
		{
			arnold_schwarzenegger_dunks++;
		}
		else if(people.name == "sheen charlie")
		{
			charlie_sheen_dunks++;
		}
		else if(people.name == "sherman richard")
		{
			richard_sherman_dunks++;
		}
		else if(people.name == "simpson jessica")
		{
			jessica_simpsons_dunks++;
		}
		else if(people.name == "situation")
		{
		  situation_dunks++;
		}
		else if(people.name == "snooki")
		{
			snooki_dunks++;
		}
		else if(people.name == "spears brittney")
		{
		  brittney_spears_dunks++;
		}
		else if(people.name == "springer jerry")
		{
			jerry_springer_dunks++;
		}
		else if(people.name == "stevo o")
		{
			steve_o_dunks++;
		}
		else if(people.name == "stewart jon")
		{
			jon_stewart_dunks++;
		}
		else if(people.name == "thomas earl")
		{
			earl_thomas_dunks++;
		}
		else if(people.name == "trump donald")
		{
			donald_trump_dunks++;
		}
		else if(people.name == "unger max")
		{
			max_unger_dunks++;
		}
		else if(people.name == "weiner anthony")
		{
			anthony_weiner_dunks++;
		}
		else if(people.name == "west kayne")
		{
			kayne_west_dunks++;
		}
		else if(people.name == "wilson russell")
		{
			russell_wilson_dunks++;
		}
		else if(people.name == "woods tiger")
		{
			tiger_woods_dunks++;
		}
		else if(people.name == "zellweger rene")
		{
			rene_zellweger_dunks++;
		}
	}

	void Awake() { _instance = this; }
}
