using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharityListMenu : MonoBehaviour
{

	public GameObject button;
	public GameObject startingPoint;
	public GameObject SignText;

	CharityList charity;

	void PopulateMenu() {
		float ySpace = 30;
		int numberOfButtons = CharityList.Instance.Chairty.Length;
		
		for (int i=0; i<numberOfButtons; i++) {
			GameObject newButton = Instantiate(button, new Vector3(this.transform.position.x, startingPoint.transform.position.y - (ySpace * i), 0), Quaternion.identity) as GameObject;
			newButton.transform.parent = this.transform;
			newButton.GetComponentInChildren<Text>().text = CharityList.Instance.Chairty[i].name;
			newButton.GetComponent<SelectButton>().index = i;
		}
	}

	// Use this for initialization
	void Start ()
	{
		PopulateMenu();
		charity = new CharityList();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(charity.name == "Seattle_7_Writers")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DUDYPYNYDYLSS");
		}
		else if(charity.name == "826_Seattle")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=2STWZSLC9QXAA");
		}
		else if(charity.name == "Union_Gospel_Mission")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XSJRQASTMJXGA");
		}
		else if(charity.name == "Hope Link")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=XPVMD449SM6Z6");
		}
		else if(charity.name == "Russel Wilson's Pass the Peace")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=366YLJYKXCJ8C");
		}
		else if(charity.name == "Richard Sherman Family Foundation")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QCG32MHPMMDSJ");
		}
		else if(charity.name == "Pete Carrol's A Better Seattle")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GKS5KMWV3VCVA");
		}
		else if(charity.name == "Russel OKung's UP Foundation")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FT5GM8A2UEHJY");
		}
		else if(charity.name == "Guardian Angel Foundation")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=WD23Z9M79N5MY");
		}
		else if(charity.name == "Marshawn Lynch's Family First Foundation")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=53MVYY8KPRBQC");
		}
		else if(charity.name == "El Centro de la Rasa")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=NA62JUBPC546N");
		}
		else if(charity.name == "Rainier Chamber of Commerce")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=AWX9SK9C6D8RL");
		}
		else if(charity.name == "Seattle Foundation")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GT5BV9N928VZ2");
		}
		else if(charity.name == "Washington Ceasefire")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=U88CEGNMUNL9E");
		}
		else if(charity.name == "Fare Start")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FWYL2695GZB2A");
		}
		else if(charity.name == "Youthcare")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=YV8C34QAWDDJ6");
		}
		else if(charity.name == "Red Badge Project")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=PZXWUEQGLSZ6N");
		}
		else if(charity.name == "Atlantic Street Center")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=5GWU6KC8G9S3Y");
		}
		else if(charity.name == "Northwest Immigrant Rights Program")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=D2SRQ7TBW2U6S");
		}
		else if(charity.name == "Big Brothers & Big Sisters of Puget Sound")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DCTJDHYTCAKYW");
		}
		else if(charity.name == "Futurewise")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=5R7CQ57U2S8RN");
		}
		else if(charity.name == "Washington State Democrats")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DZXYPJBTMG24G");
		}
		else if(charity.name == "Friends of Youth")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=N9R8ATCP78F6Y");
		}
		else if(charity.name == "YMCA Seattle")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=89S25ZXHKKFDU");
		}
		else if(charity.name == "University Churches Emergency Fund")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GRAV7P7JPTGE6");
		}
		else if(charity.name == "Northwest Film Fund")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GKVY2WCBCMTDS");
		}
		else if(charity.name == "Grand Illusion Cinema")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=D52RMVJ22JV9J");
		}
		else if(charity.name == "Ark Lodge Cinema")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DLFG6PTC5F88A");
		}
		else if(charity.name == "Bike Works")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DMH4LU3K9A5R6");
		}
		else if(charity.name == "Rainier Valley Post")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=CDG5WVH7NTVQY");
		}
		else if(charity.name == "Nature Conservancy")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FFGKUG9TXC9X8");
		}
		else if(charity.name == "Sierra Club")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=PYJL4VUXXUWYG");
		}
		else if(charity.name == "Wounded Warrior Project")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=QD7ZKXQG7F4PL");
		}
		else if(charity.name == "Salvation Army")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=KC9PGUZCZ9QX6");
		}
		else if(charity.name == "Boys and Girls Clubs of America")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=MP8QPQLXVKXCQ");
		}
		else if(charity.name == "Solid Ground International")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Z32YQAGNKVWBE");
		}
		else if(charity.name == "Gun Control")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=WXD886L22HEQN");
		}
		else if(charity.name == "Charity: Water")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HG92V95VQRR7W");
		}
		else if(charity.name == "Habitat for Humanity")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=PWUKEPLSFW5EE");
		}
		else if(charity.name == "Save the Children")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=9EW7WY4UBTZZJ");
		}
		else if(charity.name == "World Wildlife Fund")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JN2LCH9ADJKEJ");
		}
		else if(charity.name == "YMCA")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FPBJ454ZKLYWU");
		}
		else if(charity.name == "YWCA")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=AACA2RN4XSL5J");
		}
		else if(charity.name == "Human Rights Watch")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LXT5QRLY6XTKC");
		}
		else if(charity.name == "Mothers Against Drunk Driving")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=YXKRBDTJTMFS4");
		}
		else if(charity.name == "NAACP")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=B3UM9QL7H5YWS");
		}
		else if(charity.name == "The American Red Cross")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7Q44XP77AYZLQ");
		}
		else if(charity.name == "The Hunger Project")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DJX2JEAAFLWSY");
		}
		else if(charity.name == "ACLU")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=WQTA5P5X9TKEG");
		}
		else if(charity.name == "Moms Rising")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UBVFEYGE4MWAW");
		}
		else if(charity.name == "Food Lifeline")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=Z5ZNERF5LY3KW");
		}
		else if(charity.name == "ASPCA")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3WM484Q9ATFJC");
		}
		else if(charity.name == "The Donnie Fund")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=H64P6PL7ZMKJQ");
		}
		else if(charity.name == "Autism Society of America")
		{
			Application.OpenURL("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=FEXMY5UR2EYPQ");
		}
	}
}

