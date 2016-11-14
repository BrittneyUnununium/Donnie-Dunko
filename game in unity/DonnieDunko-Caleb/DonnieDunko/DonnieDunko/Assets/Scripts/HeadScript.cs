using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HeadScript : MonoBehaviour {

	private List <string> Head_Name;
	private int TOTAL_HEADS = 82; //Amount of heads
	private int Selected = 0; //currently selected head


	enum HEADS {
		LANCE_ARMSTRONG,
		MICHELLE_BACHMANN,
		DOUG_BALDWIN,
		GLENN_BECK,
		MICHAEL_BENNET,
		JOE_BIDEN,
		JUSTIN_BIEBER,
		MICHEAL_BLOOMBERG,
		JOHN_BOEHNER,
		PAT_BUCHANAN,
		GEORGE_BUSH,
		KAM_CHANCELLOR,
		DICK_CHENEY,
		CHRIS_CHRISTIE,
		HILLARY_CLINTON,
		STEPHEN_COLBERT,
		BILL_COSBY,
		ANN_COULTER,
		SIMON_COWELL,
		TED_CRUZ,
		MILEY_CYRUS,
		SCOTT_DISICK,
		ROBERT_DOWNY_JR,
		DR_PHIL,
		NEWT_GIGNGRICH,
		KATE_GOSSELIN,
		NANCY_GRACE,
		SEAN_HANNITY,
		PARIS_HILTON,
		HONEY_BOO_BOO,
		KIM_JONG_UN,
		JWOWW,
		KHLOE_KARDASHIAN,
		KIM_HARDASHIAN,
		KOURTNEY_KARDASHIAN,
		JOHN_KERRY,
		CHARLES_KOCH,
		DAVID_KOCH,
		ASHTON_KUTCHER,
		NENE_LEAKES,
		RUSH_LIMBAUGH,
		LINDSAY_LOHAN,
		MARSHAWN_LYNCH,
		RACHEL_MADDOW,
		BILL_MAHER,
		JOHN_MCCAIN,
		MITCH_MCCONNEL,
		MIKE_MCGINN,
		ROB_MCKENNA,
		PIERS_MORGAN,
		PATTY_MURRAY,
		BARACK_OBAMA,
		RUSSEL_OKUNG,
		BILL_OREILLY,
		SARAH_PALIN,
		BOB_PARSONS,
		RAND_PAUL,
		D_PAULY,
		RICK_PERRY,
		HARRY_REID,
		RIHANNA,
		MITT_ROMNEY,
		KARL_ROVE,
		PAUL_RYAN,
		JERRY_SANDUSKY,
		ARNOLD_SCHWARZENEGGER,
		CHARLIE_SHEEN,
		RICHARD_SHERMAN,
		JESSICA_SIMPSON,
		SITUATION,
		SNOOKIE,
		BRITTNEY_SPEARS,
		JERRY_SPRINGER,
		STEVE_O,
		JON_STEWART,
		EARL_THOMAS,
		DONALD_TRUMP,
		MAX_UNGER,
		ANTHONY_WEINER,
		KANYE_WEST,
		RUSSEL_WILSON,
		TIGER_WOODS,
		RENE_ZELLWEGER
	};

	HEADS gHead;

	// Use this for initialization
	void Start () {

		gHead = new HEADS ();

		Head_Name = new List<string> ();

		//Add head names to list
		Head_Name.Add ("Lance_Armstrong");
		Head_Name.Add ("Michelle_Bachmann");
		Head_Name.Add ("Doug Baldwin");
		Head_Name.Add ("Glenn Beck");
		Head_Name.Add ("Michael Bennet");
		Head_Name.Add ("Joe Biden");
		Head_Name.Add ("Justin Bieber");
		Head_Name.Add ("Michael Bloomberg");
		Head_Name.Add ("John Boehner");
		Head_Name.Add ("Pat Buchanan");
		Head_Name.Add ("George Bush");
		Head_Name.Add ("Kam Chancellor");
		Head_Name.Add ("Dick Cheney");
		Head_Name.Add ("Chris Christie");
		Head_Name.Add ("Hillary Clinton");
		Head_Name.Add ("Stephen Colbert");
		Head_Name.Add ("Bill Cosby");
		Head_Name.Add ("Ann Coulter");
		Head_Name.Add ("Simon Cowell");
		Head_Name.Add ("Ted Cruz");
		Head_Name.Add ("Miley Cyrus");
		Head_Name.Add ("Scott Disick");
		Head_Name.Add ("Robert Downy Jr.");
		Head_Name.Add ("Dr. Phil");
		Head_Name.Add ("Newt Gingrich");
		Head_Name.Add ("Kate Gosselin");
		Head_Name.Add ("Nancy Grace");
		Head_Name.Add ("Sean Hannity");
		Head_Name.Add ("Paris Hilton");
		Head_Name.Add ("Honey Boo Boo");
		Head_Name.Add ("Kim Jong-un");
		Head_Name.Add ("Jwoww");
		Head_Name.Add ("Khloe Kardashian");
		Head_Name.Add ("Kim Kardashian");
		Head_Name.Add ("Kourtney Kardashian");
		Head_Name.Add ("John Kerry");
		Head_Name.Add ("Charles Koch");
		Head_Name.Add ("David Koch");
		Head_Name.Add ("Ashton Kutcher");
		Head_Name.Add ("Nene Leakes");
		Head_Name.Add ("Rush Limbaugh");
		Head_Name.Add ("Lindsay Lohan");
		Head_Name.Add ("Marshawn Lynch");
		Head_Name.Add ("Rachel Maddow");
		Head_Name.Add ("Bill Maher");
		Head_Name.Add ("John McCain");
		Head_Name.Add ("Mitch McConnell");
		Head_Name.Add ("Mike McGinn");
		Head_Name.Add ("Rob McKenna");
		Head_Name.Add ("Piers Morgan");
		Head_Name.Add ("Patty Murray");
		Head_Name.Add ("Barack Obama");
		Head_Name.Add ("Russell Okung");
		Head_Name.Add ("Bill Oreilly");
		Head_Name.Add ("Sarah Palin");
		Head_Name.Add ("Bob Parsons");
		Head_Name.Add ("Rand Paul");
		Head_Name.Add ("Pauly D");
		Head_Name.Add ("Rick Perry");
		Head_Name.Add ("Harry Reid");
		Head_Name.Add ("Rihanna");
		Head_Name.Add ("Mitt Romney");
		Head_Name.Add ("Karl Rove");
		Head_Name.Add ("Paul Ryan");
		Head_Name.Add ("Jerry Sandusky");
		Head_Name.Add ("Arnold Schwarzenegger");
		Head_Name.Add ("Charley Sheen");
		Head_Name.Add ("Richard Sherman");
		Head_Name.Add ("Jessica Simpsons");
		Head_Name.Add ("Situation");
		Head_Name.Add ("Snookie");
		Head_Name.Add ("Brittney Spears");
		Head_Name.Add ("Jerry Springer");
		Head_Name.Add ("Steve-O");
		Head_Name.Add ("Jon Stewart");
		Head_Name.Add ("Earl Thomas");
		Head_Name.Add ("Donald Trump");
		Head_Name.Add ("Max Unger");
		Head_Name.Add ("Anthony Weiner");
		Head_Name.Add ("Kanye West");
		Head_Name.Add ("Russell Wilson");
		Head_Name.Add ("Tiger Woods");
		Head_Name.Add ("Rene Zellweger");
	}
	
	// Update is called once per frame
	void Update () {

		//Sort and check for selected head names
		Head_Name.Sort ();

		if (Head_Name.Contains ("Lance_Armstrong")) 
		{
			Selected = (int)HEADS.LANCE_ARMSTRONG;
		} 
		else if (Head_Name.Contains ("Michelle_Bachmann"))
		{
			Selected = (int)HEADS.MICHELLE_BACHMANN;
		} else if (Head_Name.Contains ("Doug Baldwin")) {
			Selected = (int)HEADS.DOUG_BALDWIN;
		} else if (Head_Name.Contains ("Glenn Beck")) {
			Selected = (int)HEADS.GLENN_BECK;
		} else if (Head_Name.Contains ("Michael Bennet")) {
			Selected = (int)HEADS.MICHAEL_BENNET;
		} else if (Head_Name.Contains ("Joe Biden")) {
			Selected = (int)HEADS.JOE_BIDEN;
		} else if (Head_Name.Contains ("Justin Bieber")) {
			Selected = (int)HEADS.JUSTIN_BIEBER;
		} else if (Head_Name.Contains ("Michael Bloomberg")) {
			Selected = (int)HEADS.MICHEAL_BLOOMBERG;
		} else if (Head_Name.Contains ("John Boehner")) {
			Selected = (int)HEADS.JOHN_BOEHNER;
		} else if (Head_Name.Contains ("Pat Buchanan")) {
			Selected = (int)HEADS.PAT_BUCHANAN;
		} else if (Head_Name.Contains ("George Bush")) {
			Selected = (int)HEADS.GEORGE_BUSH;
		} else if (Head_Name.Contains ("Kam Chancellor")) {
			Selected = (int)HEADS.KAM_CHANCELLOR;
		}
		else if(Head_Name.Contains("Dick Cheney")) 
		{
			Selected = (int)HEADS.DICK_CHENEY;
		}
		else if(Head_Name.Contains("Chris Christie"))
		{
			Selected = (int)HEADS.CHRIS_CHRISTIE;
		}
		else if(Head_Name.Contains("Hillary Cliton"))
		{
			Selected = (int)HEADS.HILLARY_CLINTON;
		}
		else if(Head_Name.Contains("Stephen Colbert"))
		{
			Selected = (int)HEADS.STEPHEN_COLBERT;
		}
		else if(Head_Name.Contains("Bill Cosby"))
		{
			Selected = (int)HEADS.BILL_COSBY;
		}
		else if(Head_Name.Contains("Ann Coulter"))
		{
			Selected = (int)HEADS.ANN_COULTER;
		}
		else if(Head_Name.Contains("Simon Cowell"))
		{
			Selected = (int)HEADS.SIMON_COWELL;
		}
		else if(Head_Name.Contains("Ted Cruz"))
		{
			Selected = (int)HEADS.TED_CRUZ;
		}
		else if(Head_Name.Contains("Miley Cyrus"))
		{
			Selected = (int)HEADS.MILEY_CYRUS;
		}
		else if(Head_Name.Contains("Scott Disick"))
		{
			Selected = (int)HEADS.SCOTT_DISICK;
		}
		else if(Head_Name.Contains("Robert Downy Jr."))
		{
			Selected = (int)HEADS.ROBERT_DOWNY_JR;
		}
		else if(Head_Name.Contains("Dr. Phil"))
		{
			Selected = (int)HEADS.DR_PHIL;
		}
		else if(Head_Name.Contains("Newt Gingrich"))
		{
			Selected = (int)HEADS.NEWT_GIGNGRICH;
		}
		else if(Head_Name.Contains("Kate Gosselin"))
		{
			Selected = (int)HEADS.KATE_GOSSELIN;
		}
		else if(Head_Name.Contains("Nancy Grace"))
		{
			Selected = (int)HEADS.NANCY_GRACE;
		}
		else if(Head_Name.Contains("Sean Hannity"))
		{
			Selected = (int)HEADS.SEAN_HANNITY;
		}
		else if(Head_Name.Contains("Paris Hilton"))
		{
			Selected = (int)HEADS.PARIS_HILTON;
		}
		else if(Head_Name.Contains("Honey Boo Boo"))
		{
			Selected = (int)HEADS.HONEY_BOO_BOO;
		}
		else if(Head_Name.Contains("Kim Jong-Un"))
		{
			Selected = (int)HEADS.KIM_JONG_UN;
		}
		else if(Head_Name.Contains("Jwoww"))
		{
			Selected = (int)HEADS.JWOWW;
		}
		else if(Head_Name.Contains("Khloe Kardashian"))
		{
			Selected = (int)HEADS.KHLOE_KARDASHIAN;
		}
		else if(Head_Name.Contains("Kim Kardashian"))
		{
			Selected = (int)HEADS.KIM_HARDASHIAN;
		}
		else if(Head_Name.Contains("Kourtney Kardashian"))
		{
			Selected = (int)HEADS.KOURTNEY_KARDASHIAN;
		}
		else if(Head_Name.Contains("John Kerry"))
		{
			Selected = (int)HEADS.JOHN_KERRY;
		}
		else if(Head_Name.Contains("Charles Koch"))
		{
			Selected = (int)HEADS.CHARLES_KOCH;
		}
		else if(Head_Name.Contains("David Koch"))
		{
			Selected = (int)HEADS.DAVID_KOCH;
		}
		else if(Head_Name.Contains("Ashton Kutcher"))
		{
			Selected = (int)HEADS.ASHTON_KUTCHER;
		}
		else if(Head_Name.Contains("Nene Leakes"))
		{
			Selected = (int)HEADS.NENE_LEAKES;
		}
		else if(Head_Name.Contains("Rush Limbaugh"))
		{
			Selected = (int)HEADS.RUSH_LIMBAUGH;
		}
		else if(Head_Name.Contains("Lindsay Lohan"))
		{
			Selected = (int)HEADS.LINDSAY_LOHAN;
		}
		else if(Head_Name.Contains("Marshawn Lync"))
		{
			Selected = (int)HEADS.MARSHAWN_LYNCH;
		}
		else if(Head_Name.Contains("Rachel Maddow"))
		{
			Selected = (int)HEADS.RACHEL_MADDOW;
		}
		else if(Head_Name.Contains("Bill Maher"))
		{
			Selected = (int)HEADS.BILL_MAHER;
		}
		else if(Head_Name.Contains("John McCain"))
		{
			Selected = (int)HEADS.JOHN_MCCAIN;
		}
		else if(Head_Name.Contains("Mitch McConnel"))
		{
			Selected = (int)HEADS.MITCH_MCCONNEL;
		}
		else if(Head_Name.Contains("Mike McGinn"))
		{
			Selected = (int)HEADS.MIKE_MCGINN;
		}
		else if(Head_Name.Contains("Rob McKenna"))
		{
			Selected = (int)HEADS.ROB_MCKENNA;
		}
		else if(Head_Name.Contains("Piers Morgan"))
		{
			Selected = (int)HEADS.PIERS_MORGAN;
		}
		else if(Head_Name.Contains("Patty Murray"))
		{
			Selected = (int)HEADS.PATTY_MURRAY;
		}
		else if(Head_Name.Contains("Barack Obama"))
		{
			Selected = (int)HEADS.BARACK_OBAMA;
		}
		else if(Head_Name.Contains("Russel Okung"))
		{
			Selected = (int)HEADS.RUSSEL_OKUNG;
		}
		else if(Head_Name.Contains("Bill O'Reilly"))
		{
			Selected = (int)HEADS.BILL_OREILLY;
		}
		else if(Head_Name.Contains("Sarah Palin"))
		{
			Selected = (int)HEADS.SARAH_PALIN;
		}
		else if(Head_Name.Contains("Bob Parsons"))
		{
			Selected = (int)HEADS.BOB_PARSONS;
		}
		else if(Head_Name.Contains("Rand Paul"))
		{
			Selected = (int)HEADS.RAND_PAUL;
		}
		else if(Head_Name.Contains("Pauly D"))
		{
			Selected = (int)HEADS.D_PAULY;
		}
		else if(Head_Name.Contains("Rick Perry"))
		{
			Selected = (int)HEADS.RICK_PERRY;
		}
		else if(Head_Name.Contains("Harry Reid"))
		{
			Selected = (int)HEADS.HARRY_REID;
		}
		else if(Head_Name.Contains("Rihanna"))
		{
			Selected = (int)HEADS.RIHANNA;
		}
		else if(Head_Name.Contains("Mitt Romney"))
		{
			Selected = (int)HEADS.MITT_ROMNEY;
		}
		else if(Head_Name.Contains("Karl Rove"))
		{
			Selected = (int)HEADS.KARL_ROVE;
		}
		else if(Head_Name.Contains("Ryan Paul"))
		{
			Selected = (int)HEADS.PAUL_RYAN;
		}
		else if(Head_Name.Contains("Jerry Sandusky"))
		{
			Selected = (int)HEADS.JERRY_SANDUSKY;
		}
		else if(Head_Name.Contains("Arnold Schwarzenegger"))
		{
			Selected = (int)HEADS.ARNOLD_SCHWARZENEGGER;
		}
		else if(Head_Name.Contains("Charley Sheen"))
		{
			Selected = (int)HEADS.CHARLIE_SHEEN;
		}
		else if(Head_Name.Contains("Richard Sherman"))
		{
			Selected = (int)HEADS.RICHARD_SHERMAN;
		}
		else if(Head_Name.Contains("Jessica Simpson"))
		{
			Selected = (int)HEADS.JESSICA_SIMPSON;
		}
		else if(Head_Name.Contains("Situation"))
		{
			Selected = (int)HEADS.SITUATION;
		}
		else if(Head_Name.Contains("Snookie"))
		{
			Selected = (int)HEADS.SNOOKIE;
		}
		else if(Head_Name.Contains("Brittney Spears"))
		{
			Selected = (int)HEADS.BRITTNEY_SPEARS;
		}
		else if(Head_Name.Contains("Jerry Springer"))
		{
			Selected = (int)HEADS.JERRY_SPRINGER;
		}
		else if(Head_Name.Contains("Steve-O"))
		{
			Selected = (int)HEADS.STEVE_O;
		}
		else if(Head_Name.Contains("Jon Stewart"))
		{
			Selected = (int)HEADS.JON_STEWART;
		}
		else if(Head_Name.Contains("Earl Thomas"))
		{
			Selected = (int)HEADS.EARL_THOMAS;
		}
		else if(Head_Name.Contains("Donald Trump"))
		{
			Selected = (int)HEADS.DONALD_TRUMP;
		}
		else if(Head_Name.Contains("Max Unger"))
		{
			Selected = (int)HEADS.MAX_UNGER;
		}
		else if(Head_Name.Contains("Anthony Weiner"))
		{
			Selected = (int)HEADS.ANTHONY_WEINER;
		}
		else if(Head_Name.Contains("Kanye West"))
		{
			Selected = (int)HEADS.KANYE_WEST;
		}
		else if(Head_Name.Contains("Russell Wilson"))
		{
			Selected = (int)HEADS.RUSSEL_WILSON;
		}
		else if(Head_Name.Contains("Tiger Woods"))
		{
			Selected = (int)HEADS.TIGER_WOODS;
		}
		else if(Head_Name.Contains("Rene Zellweger"))
		{
			Selected = (int)HEADS.RENE_ZELLWEGER;
		}
  }
}
