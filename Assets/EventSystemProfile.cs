using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections.Generic;
using UnityEngine.UI;

public class EventSystemProfile : MonoBehaviour {



	public GameObject m_Button;
	public GameObject m_ProgressName;


	public GameObject m_UserName;
	public GameObject m_FirstName;


    public GameObject m_BtnBack;


	public GameObject m_LastName;
	public GameObject m_Hometown;
	public GameObject m_Age;
	public GameObject m_Gender;
	public GameObject m_Education;
	public GameObject m_Nature;
	public GameObject m_Amsterdam;
	public GameObject m_Household;
	public GameObject m_HouseholdOther;
	public GameObject m_HouseholdOtherInput;
	public GameObject m_HouseType;
	public GameObject m_HouseTypeOther;
	public GameObject m_HouseTypeOtherInput;
	public GameObject m_SliderNotAtAll;
	public GameObject m_SliderNotSoMuch;
	public GameObject m_SliderSomewhat;
	public GameObject m_SliderVery;
	public GameObject m_SliderExtremely;
	public GameObject m_Interests;
	public GameObject m_Toggle1;
	public GameObject m_Toggle2;
	public GameObject m_Toggle3;
	public GameObject m_Toggle4;
	public GameObject m_Toggle5;
	public GameObject m_Toggle6;
	public GameObject m_Toggle7;
	public GameObject m_Toggle8;
	public GameObject m_Toggle9;
	public GameObject m_Toggle10;
	public GameObject m_Toggle11;
	public GameObject m_Toggle12;
	public GameObject m_Zip;
	public GameObject m_ZipInput;

	public GameObject m_InputFirstName;
	public GameObject m_InputLastName;
	public GameObject m_InputHometown;

	public GameObject m_ComboGender;
	public GameObject m_ComboAge;
	public GameObject m_ComboEducation;
	public GameObject m_ComboNature;
	public GameObject m_ComboAmsterdam;
	public GameObject m_ComboHousehold;
	public GameObject m_ComboHouseType;


	private MessageBox messageBox;
	private MessageBox verticalMessageBox;


	public GameObject m_ImageUploading;
	public GameObject m_TextUploading;
	public GameObject m_ImageTextUploading;



	public GameObject m_TextCommentAdditionalInfo;


    public GameObject m_LableShowUsername;
    public GameObject m_ToggleShowUsername;


    public GameObject m_ImageCheckInternet;
    public GameObject m_TextCheckInternet;
    public GameObject m_BtnBackCheckInternet;



	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());


		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();
		
		Screen.orientation = ScreenOrientation.Portrait;

		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		//	Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeLeft = false;

		m_ImageUploading.SetActive (false);
		m_TextUploading.SetActive (false);
		m_ImageTextUploading.SetActive (false);

        hideCheckInternet();

		m_HouseholdOther.SetActive (false);
		m_HouseholdOtherInput.SetActive (false);
		m_HouseTypeOther.SetActive (false);
		m_HouseTypeOtherInput.SetActive (false);


		UnityEngine.UI.InputField textinput;
		textinput = m_HouseholdOtherInput.GetComponent<UnityEngine.UI.InputField>();
		textinput.text = PlayerPrefs.GetString("ProfileHouseholdOther");

		textinput = m_HouseTypeOtherInput.GetComponent<UnityEngine.UI.InputField>();
		textinput.text = PlayerPrefs.GetString("ProfileHouseTypeOther");

		textinput = m_ZipInput.GetComponent<UnityEngine.UI.InputField>();
		textinput.text = PlayerPrefs.GetString("ProfileZip");




		UnityEngine.UI.Dropdown dropdown;
		UnityEngine.UI.Dropdown.OptionData list;

		if (Application.systemLanguage == SystemLanguage.German && false) {
			m_UserName.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Benutzername:";


			m_TextCommentAdditionalInfo.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Die folgenden Informationen werden nur von uns verwendet um FotoQuest Go weiter zu verbessern:";

			m_FirstName.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Vorname:";
			m_LastName.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Nachname:";
			m_Hometown.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Heimatstadt:";
			m_Age.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Alter:";
			m_Gender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Geschlecht:";
			m_Interests.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Interessen:";

			m_Toggle1.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Wissenschaft";
			m_Toggle2.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Sport";
			m_Toggle3.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Natur";
			m_Toggle4.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Biologie";
			m_Toggle5.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Geographie";
			m_Toggle6.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Musik";
			m_Toggle7.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Computer";
			m_Toggle8.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Bücher";
			m_Toggle9.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Landwirtschaft";



			dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();

			list = new UnityEngine.UI.Dropdown.OptionData("(Bitte auswählen)");
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData("Weiblich");
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData("Männlich");
			dropdown.options.Add (list);
			dropdown.value = 0;



			textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";



			m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Wird hochgeladen...";


		} else {
			m_UserName.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileUsername");//"Username:";


            m_BtnBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");

            m_BtnBackCheckInternet.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("BtnCheck");// "First Name:";
            m_TextCheckInternet.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("CheckInternet");// "First Name:";

			m_TextCommentAdditionalInfo.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Please provide us with some information about yourself. This info is only for us to further improve FotoQuest:";
            m_LableShowUsername.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("ProfileShowUsername");


			m_FirstName.GetComponentInChildren<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("ProfileFirstname");// "First Name:";
			m_LastName.GetComponentInChildren<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("ProfileLastname");// "Last Name:";
			m_Hometown.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInstitution");//"Hometown:";
			m_Age.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileAgeGroup");//"Age Group:";
			m_Gender.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileGender");//"Gender:";
			m_Education.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileEducation");//"Gender:";
			m_Nature.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileNature");//"Gender:";
		/*	m_Amsterdam.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileAmsterdam");//"Gender:";
			m_Interests.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileOwnership");//"Interests:";
			m_Household.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileHousehold");//"Gender:";
			m_HouseType.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileHouseType");//"Gender:";
*/
			m_SliderNotAtAll.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_SliderNotSoMuch.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_SliderSomewhat.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_SliderVery.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_SliderExtremely.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");

            /*
			m_Toggle1.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileOwnership1");//"Science";
			m_Toggle2.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileOwnership2");//"Sports";
			m_Toggle3.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileOwnership3");//"Nature";
			m_Toggle4.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileOwnership4");//"Biology";
			m_Toggle5.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestMusic");//"Geography";
			m_Toggle6.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestMusic");//"Music";
			m_Toggle7.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestComputers");//"Computers";
			m_Toggle8.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestBooks");//"Books";
			m_Toggle9.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestAgriculture");//"Agriculture";
*/

			dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileFemale"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileMale"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileOther"));
			dropdown.options.Add (list);
			dropdown.value = 0;
			dropdown.RefreshShownValue ();


			dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("EducationPrimary"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("EducationHigh"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("EducationVocational"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("EducationUni"));
			dropdown.options.Add (list);
			dropdown.value = 0;
			dropdown.RefreshShownValue ();


			dropdown = m_ComboAmsterdam.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("Yes"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("No"));
			dropdown.options.Add (list);
			dropdown.value = 0;
			dropdown.RefreshShownValue ();
            /*
			dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold1"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold2"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold3"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold4"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold5"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold6"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHousehold7"));
			dropdown.options.Add (list);
			dropdown.value = 0;
			dropdown.RefreshShownValue ();

			dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHouseType1"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHouseType2"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHouseType3"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHouseType4"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileHouseType5"));
			dropdown.options.Add (list);
			dropdown.value = 0;
			dropdown.RefreshShownValue ();
*/

			textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";



			m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("IsUploading");
		}


	//	m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
//		m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";

		dropdown = m_ComboAge.GetComponent<UnityEngine.UI.Dropdown>();
		dropdown.options.Clear ();
		list = new UnityEngine.UI.Dropdown.OptionData (LocalizationSupport.GetString ("ProfileSelect"));
		dropdown.options.Add (list);


		/*list = new UnityEngine.UI.Dropdown.OptionData("< 10");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("10-14");
		dropdown.options.Add (list);*/
		list = new UnityEngine.UI.Dropdown.OptionData("< 20");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("20-29");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("30-39");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("40-49");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("50-59");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("60-69");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("70-79");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("> 80");
		dropdown.options.Add (list);
		dropdown.value = 0;
		dropdown.RefreshShownValue ();


		updateStates ();



		messageBox = UIUtility.Find<MessageBox> ("MessageBox");

		updateProgressValuesLoading ();

		UnityEngine.UI.Text textprogress;
		string progressname = "";
		if (Application.systemLanguage == SystemLanguage.German) {
			progressname = "Gast";
		} else {
			progressname = "Guest";
		}
		if (PlayerPrefs.HasKey ("PlayerName")) {
			progressname = PlayerPrefs.GetString ("PlayerName");
		} 
		textprogress = m_ProgressName.GetComponent<UnityEngine.UI.Text>();
		textprogress.text = progressname;

        loadProgress();
        loadAnonym();
	//	loadSettings ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");


		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		//	Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeLeft = false;
	}


	int m_CurState = 0;
	public void updateStates() {

		if (Application.systemLanguage == SystemLanguage.German && false ) {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "SPEICHERN";


		} else {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString ("Save");
		}


	}

	public void NextClicked () {
		if (m_bProfileLoaded) {
			m_ImageUploading.SetActive (true);
			m_TextUploading.SetActive (true);
			m_ImageTextUploading.SetActive (true);

			SaveSettings ();
		} else {
			Application.LoadLevel ("DemoMap");
		}
//		Application.LoadLevel ("DemoMap");
		//	Debug.Log ("OnSelected: " );
	}



	public static string ComputeHash(string s){
		// Form hash
		System.Security.Cryptography.MD5 h = System.Security.Cryptography.MD5.Create();
		byte[] data = h.ComputeHash(System.Text.Encoding.Default.GetBytes(s));
		// Create string representation
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		for (int i = 0; i < data.Length; ++i) {
			sb.Append(data[i].ToString("x2"));
		}
		return sb.ToString();
	}

	void loadProgress()
	{
		if (PlayerPrefs.HasKey ("PlayerPassword") == false || PlayerPrefs.HasKey ("PlayerMail") == false) {
			Debug.Log ("Did not login yet");
			return;
		}

		string url = "https://geo-wiki.org/Application/api/User/profile";
		string param = "";

		string email = PlayerPrefs.GetString ("PlayerMail");
		string password = PlayerPrefs.GetString ("PlayerPassword");
		string passwordmd5 = ComputeHash (password);
		int randnr = Random.Range(0, 10000000);
		//param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + "\",\"randnr\":" + "\"" + passwordmd5 + "\"" + ",\"scope\":" + "\"total\",\"limit\":\"" + "0" + "\""+ ",\"platform\":{" + "\""+ "app"+ "\":" + "\"14\"" + "}";
		param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\""  + "}";



		Debug.Log ("loadProgress: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForProgressData(www));
	}


	int m_ReadingProgressWhich = 0;
	string m_ReadingProgessValue = "";
	int m_NrScoresMade = 0;

	string m_ReadingFirstName;
	string m_ReadingLastName;
	string m_ReadingHometown;
	string m_ReadingPaypal;
	int m_GenderSelected;
	int m_AgeSelected;
	int m_EducationSelected;
	int m_NatureSelected;
	int m_AmsterdamSelected;
	int m_HouseholdSelected;
	int m_HouseTypeSelected;
	bool m_bProfileLoaded = false;

	IEnumerator WaitForProgressData(WWW www)
	{
		yield return www;

		string[] options = { "Ok" };
		if (www.error == null)
		{
			string data = www.text;
			//string[] parts = data.Split (":", 2);

			m_ReadingFirstName = "";
			 m_ReadingLastName = "";
			 m_ReadingHometown = "";
			m_ReadingPaypal = "";
			m_GenderSelected = -1;
			m_AgeSelected = -1;
			m_EducationSelected = -1;
			m_NatureSelected = -1;
			m_AmsterdamSelected = -1;
			m_HouseholdSelected = -1;
			m_HouseTypeSelected = -1;

			Debug.Log ("loadProgress result: " + data);

			JSONObject j = new JSONObject(www.text);
			m_ReadingProgressWhich = 0;
			m_ReadingProgessValue = "0";
			accessProgressData(j);

			Debug.Log ("Result first name: " + m_ReadingFirstName);
			Debug.Log ("Result last name: " + m_ReadingLastName);
			Debug.Log ("Result hometown: " + m_ReadingHometown);

			UnityEngine.UI.InputField textinput;
			textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingFirstName;

			textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingLastName;

			textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingHometown;



			UnityEngine.UI.Dropdown dropdown;
			dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
		//	m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
	//		m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";

			/*if (Application.systemLanguage == SystemLanguage.German) {
				if (m_GenderSelected == 1) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Männlich";
					dropdown.value = 2;
				} else if (m_GenderSelected == 2) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Weiblich";
					dropdown.value = 1;
				}
			} else {*/
				if (m_GenderSelected == 1) {
					dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
					dropdown.value = 2;
					dropdown.RefreshShownValue ();
			} else if (m_GenderSelected == 2) {
				dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 1;
				dropdown.RefreshShownValue ();
			} else if (m_GenderSelected == 3) {
				dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 3;
				dropdown.RefreshShownValue ();
			}

			if (m_EducationSelected == 1) {
				dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 1;
				dropdown.RefreshShownValue ();
			} else if (m_EducationSelected == 2) {
				dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 2;
				dropdown.RefreshShownValue ();
			} else if (m_EducationSelected == 3) {
				dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 3;
				dropdown.RefreshShownValue ();
			} else if (m_EducationSelected == 4) {
				dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 3;
				dropdown.RefreshShownValue ();
			}

			if (m_NatureSelected != -1) {
				m_ComboNature.GetComponent<Slider> ().value = m_NatureSelected-1;
			}
			if (m_AmsterdamSelected == 1) {
				dropdown = m_ComboAmsterdam.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 1;
				dropdown.RefreshShownValue ();
			} else if (m_AmsterdamSelected == 2) {
				dropdown = m_ComboAmsterdam.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 2;
				dropdown.RefreshShownValue ();
			}

			if (m_HouseholdSelected == 1) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 1;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 2) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 2;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 3) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 3;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 4) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 4;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 5) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 5;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 6) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 6;
				dropdown.RefreshShownValue ();
			} else if (m_HouseholdSelected == 7) {
				dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 7;
				dropdown.RefreshShownValue ();
			}

			if (m_HouseTypeSelected == 1) {
				dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 1;
				dropdown.RefreshShownValue ();
			} else if (m_HouseTypeSelected == 2) {
				dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 2;
				dropdown.RefreshShownValue ();
			} else if (m_HouseTypeSelected == 3) {
				dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 3;
				dropdown.RefreshShownValue ();
			} else if (m_HouseTypeSelected == 4) {
				dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 4;
				dropdown.RefreshShownValue ();
			} else if (m_HouseTypeSelected == 5) {
				dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
				dropdown.value = 5;
				dropdown.RefreshShownValue ();
			}
		//	}

			dropdown = m_ComboAge.GetComponent<UnityEngine.UI.Dropdown>();
			if (m_AgeSelected == 1) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "< 10";
				dropdown.value = 1;
			} else if (m_AgeSelected == 2) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "10-14";
				dropdown.value = 2;
			} else if (m_AgeSelected == 3) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "15-19";
				dropdown.value = 3;
			} else if (m_AgeSelected == 4) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "20-29";
				dropdown.value = 4;
			} else if (m_AgeSelected == 5) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "30-39";
				dropdown.value = 5;
			} else if (m_AgeSelected == 6) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "40-49";
				dropdown.value = 6;
			} else if (m_AgeSelected == 7) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "50-59";
				dropdown.value = 7;
			} else if (m_AgeSelected == 8) {
				m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "60+";
				dropdown.value = 8;
			}

			m_bProfileLoaded = true;
		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);

            checkInternet();
		}   
	} 


	void accessProgressData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				if (key == "firstname") {
					m_ReadingProgressWhich = 7;
				} else if (key == "lastname") {
					m_ReadingProgressWhich = 8;
				} else if (key == "hometown") {
					m_ReadingProgressWhich = 9;
				}else if (key == "paypal") {
					m_ReadingProgressWhich = 11;
				} else if (key == "attributes") {
					m_ReadingProgressWhich = 10;
				}
				accessProgressData(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			/*foreach(JSONObject j in obj.list){
				accessProgressData(j);
			}*/

			foreach(JSONObject j in obj.list){
				accessProgressData(j);
				//Debug.Log("Array number: " + j.n);
			}
			break;
		case JSONObject.Type.STRING:
			if (m_ReadingProgressWhich == 6) {
				m_ReadingProgessValue = obj.str;
			}
			if (m_ReadingProgressWhich == 7) {
				m_ReadingFirstName = obj.str;
			}
			if (m_ReadingProgressWhich == 8) {
				m_ReadingLastName = obj.str;
			}
			if (m_ReadingProgressWhich == 9) {
				m_ReadingHometown = obj.str;
			}
			if (m_ReadingProgressWhich == 11) {
				m_ReadingPaypal = obj.str;
			}
			if (m_ReadingProgressWhich == 10) {
				Debug.Log ("Strnumber: " + obj.str);
			}
		//	Debug.Log ("Str: " + obj.str);
			m_ReadingProgressWhich = -1;

			break;
		case JSONObject.Type.NUMBER:
			//m_ReadingProgressWhich = -1;
			if (m_ReadingProgressWhich == 10) {
				Debug.Log ("Number: " + obj.n);

				if (obj.n == 1) {
					m_GenderSelected = 1;
				} else if (obj.n == 2) {
					m_GenderSelected = 2;
				} else if (obj.n == 3) {
					m_AgeSelected = 1;
				} else if (obj.n == 4) {
					m_AgeSelected = 2;
				} else if (obj.n == 5) {
					m_AgeSelected = 3;
				} else if (obj.n == 6) {
					m_AgeSelected = 4;
				} else if (obj.n == 7) {
					m_AgeSelected = 5;
				} else if (obj.n == 8) {
					m_AgeSelected = 6;
				} else if (obj.n == 9) {
					m_AgeSelected = 7;
				} else if (obj.n == 10) {
					m_AgeSelected = 8;
				} else if (obj.n == 111) {
					m_Toggle1.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 112) {
					m_Toggle2.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 113) {
					m_Toggle3.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 114) {
					m_Toggle4.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 115) {
					m_Toggle5.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 116) {
					m_Toggle6.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 117) {
					m_Toggle7.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 118) {
					m_Toggle8.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 119) {
					m_Toggle9.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 120) {
					m_GenderSelected = 3;
				} else if (obj.n == 21) {
					m_EducationSelected = 1;
				} else if (obj.n == 22) {
					m_EducationSelected = 2;
				} else if (obj.n == 23) {
					m_EducationSelected = 3;
				} else if (obj.n == 24) {
					m_EducationSelected = 4;
				} else if (obj.n == 25) {
					m_NatureSelected = 1;
				} else if (obj.n == 26) {
					m_NatureSelected = 2;
				} else if (obj.n == 27) {
					m_NatureSelected = 3;
				} else if (obj.n == 28) {
					m_NatureSelected = 4;
				} else if (obj.n == 29) {
					m_NatureSelected = 5;
				} else if (obj.n == 30) {
					m_AmsterdamSelected = 1;
				} else if (obj.n == 31) {
					m_AmsterdamSelected = 2;
				} else if (obj.n == 32) {
					m_HouseholdSelected = 1;
				} else if (obj.n == 33) {
					m_HouseholdSelected = 2;
				} else if (obj.n == 34) {
					m_HouseholdSelected = 3;
				} else if (obj.n == 35) {
					m_HouseholdSelected = 4;
				} else if (obj.n == 36) {
					m_HouseholdSelected = 5;
				} else if (obj.n == 37) {
					m_HouseholdSelected = 6;
				} else if (obj.n == 38) {
					m_HouseholdSelected = 7;
				} else if (obj.n == 39) {
					m_HouseTypeSelected = 1;
				} else if (obj.n == 40) {
					m_HouseTypeSelected = 2;
				} else if (obj.n == 41) {
					m_HouseTypeSelected = 3;
				} else if (obj.n == 42) {
					m_HouseTypeSelected = 4;
				} else if (obj.n == 43) {
					m_HouseTypeSelected = 5;
				} 
			}
			break;
		case JSONObject.Type.BOOL:
			break;
		case JSONObject.Type.NULL:
			break;

		}
	}

	void updateProgressValuesLoading() {
		/*UnityEngine.UI.Text textprogress;
		if (Application.systemLanguage == SystemLanguage.German) {
			textprogress = m_ProgressLevel.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Wird geladen";

			textprogress = m_ProgressLevelName.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Wird geladen";

			textprogress = m_ProgressScorePoints.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Punkte werden geladen";

			textprogress = m_ProgressScorePointsNextLevel.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Wird geladen";
		} else {
			textprogress = m_ProgressLevel.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Loading";

			textprogress = m_ProgressLevelName.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Loading";

			textprogress = m_ProgressScorePoints.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Loading score points";

			textprogress = m_ProgressScorePointsNextLevel.GetComponent<UnityEngine.UI.Text> ();
			textprogress.text = "Loading";
		}*/
	}


	void loadSettings()
	{
		string url = "https://geo-wiki.org/Application/api/Campaign/FotoQuestSettings";
		string param = "";

		string email = PlayerPrefs.GetString ("PlayerMail");
		string password = PlayerPrefs.GetString ("PlayerPassword");
		string passwordmd5 = ComputeHash (password);
		int randnr = Random.Range(0, 10000000);
		//param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + "\",\"randnr\":" + "\"" + passwordmd5 + "\"" + ",\"scope\":" + "\"total\",\"limit\":\"" + "0" + "\""+ ",\"platform\":{" + "\""+ "app"+ "\":" + "\"14\"" + "}";
		param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\""  + "}";



		Debug.Log ("loadSettings: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);
		//WWW www = new WWW(url, form);
		WWW www = new WWW(url);

		StartCoroutine(WaitForProgressDataSettings(www));
	}



	IEnumerator WaitForProgressDataSettings(WWW www)
	{
		yield return www;

		string[] options = { "Ok" };
		if (www.error == null)
		{
			string data = www.text;

			Debug.Log ("loadSettings result: " + data);
			/*
			JSONObject j = new JSONObject(www.data);
			m_ReadingProgressWhich = 0;
			m_ReadingProgessValue = "0";
			accessProgressData(j);

			Debug.Log ("Result first name: " + m_ReadingFirstName);
			Debug.Log ("Result last name: " + m_ReadingLastName);
			Debug.Log ("Result hometown: " + m_ReadingHometown);

			UnityEngine.UI.InputField textinput;
			textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingFirstName;

			textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingLastName;

			textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = m_ReadingHometown;*/

		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);
		}   
	} 




	void SaveSettings()
	{
		UnityEngine.UI.Dropdown dropdown;

		UnityEngine.UI.InputField textinput;
		textinput = m_HouseholdOtherInput.GetComponent<UnityEngine.UI.InputField>();
		PlayerPrefs.SetString ("ProfileHouseholdOther", textinput.text);

		textinput = m_HouseTypeOtherInput.GetComponent<UnityEngine.UI.InputField>();
		PlayerPrefs.SetString ("ProfileHouseTypeOther", textinput.text);

		textinput = m_ZipInput.GetComponent<UnityEngine.UI.InputField>();
		PlayerPrefs.SetString ("ProfileZip", textinput.text);
		PlayerPrefs.Save ();


		string url = "https://geo-wiki.org/Application/api/User/profile";
		string param = "";

		string email = PlayerPrefs.GetString ("PlayerMail");
		string password = PlayerPrefs.GetString ("PlayerPassword");
		string passwordmd5 = ComputeHash (password);
		int randnr = Random.Range(0, 10000000);
		//param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + "\",\"randnr\":" + "\"" + passwordmd5 + "\"" + ",\"scope\":" + "\"total\",\"limit\":\"" + "0" + "\""+ ",\"platform\":{" + "\""+ "app"+ "\":" + "\"14\"" + "}";
		param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"";


		textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();


		param += "," + "\"firstname\":\""   + textinput.text + "\"";


		textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
		param += "," + "\"lastname\":\""   + textinput.text + "\"";


		textinput = m_ZipInput.GetComponent<UnityEngine.UI.InputField>();
		param += "," + "\"hometown\":\""   + textinput.text + "\"";



		param += "," + "\"attributes\":"   + "[";

		bool bFirst = true;
		dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			param += "2";
			bFirst = false;
		} else if (dropdown.value == 2) {
			param += "1";
			bFirst = false;
		} else if (dropdown.value == 3) {
			param += "20";
			bFirst = false;
		}

		dropdown = m_ComboEducation.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "21";
			bFirst = false;
		} else if (dropdown.value == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "22";
			bFirst = false;
		} else if (dropdown.value == 3) {
			if (!bFirst) {
				param += ",";
			}
			param += "23";
			bFirst = false;
		} else if (dropdown.value == 4) {
			if (!bFirst) {
				param += ",";
			}
			param += "24";
			bFirst = false;
		}

		dropdown = m_ComboAge.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "3";
			bFirst = false;
		} else if (dropdown.value == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "4";
			bFirst = false;
		} else if (dropdown.value == 3) {
			if (!bFirst) {
				param += ",";
			}
			param += "5";
			bFirst = false;
		} else if (dropdown.value == 4) {
			if (!bFirst) {
				param += ",";
			}
			param += "6";
			bFirst = false;
		} else if (dropdown.value == 5) {
			if (!bFirst) {
				param += ",";
			}
			param += "7";
			bFirst = false;
		} else if (dropdown.value == 6) {
			if (!bFirst) {
				param += ",";
			}
			param += "8";
			bFirst = false;
		} else if (dropdown.value == 7) {
			if (!bFirst) {
				param += ",";
			}
			param += "9";
			bFirst = false;
		} else if (dropdown.value == 8) {
			if (!bFirst) {
				param += ",";
			}
			param += "10";
			bFirst = false;
		}


		if (m_Toggle1.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "111";
			bFirst = false;
		} 

		if (m_Toggle2.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "112";
			bFirst = false;
		} 
		if (m_Toggle3.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "113";
			bFirst = false;
		} 
		if (m_Toggle4.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "114";
			bFirst = false;
		} 
		if (m_Toggle5.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "115";
			bFirst = false;
		} 
		if (m_Toggle6.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "116";
			bFirst = false;
		} 
		if (m_Toggle7.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "117";
			bFirst = false;
		} 
		if (m_Toggle8.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "118";
			bFirst = false;
		} 
		if (m_Toggle9.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "119";
			bFirst = false;
		}

		int nature = (int)m_ComboNature.GetComponent<Slider> ().value;
		Debug.Log ("Nature value: " + nature);
		if (nature == 0) {
			if (!bFirst) {
				param += ",";
			}
			param += "25";
			bFirst = false;
		} else if (nature == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "26";
			bFirst = false;
		} else if (nature == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "27";
			bFirst = false;
		} else if (nature == 3) {
			if (!bFirst) {
				param += ",";
			}
			param += "28";
			bFirst = false;
		} else if (nature == 4) {
			if (!bFirst) {
				param += ",";
			}
			param += "29";
			bFirst = false;
		}

		dropdown = m_ComboAmsterdam.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "30";
			bFirst = false;
		} else if (dropdown.value == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "31";
			bFirst = false;
		}

		dropdown = m_ComboHousehold.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "32";
			bFirst = false;
		} else if (dropdown.value == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "33";
			bFirst = false;
		}  else if (dropdown.value == 3) {
			if (!bFirst) {
				param += ",";
			}
			param += "34";
			bFirst = false;
		}  else if (dropdown.value == 4) {
			if (!bFirst) {
				param += ",";
			}
			param += "35";
			bFirst = false;
		}  else if (dropdown.value == 5) {
			if (!bFirst) {
				param += ",";
			}
			param += "36";
			bFirst = false;
		}  else if (dropdown.value == 6) {
			if (!bFirst) {
				param += ",";
			}
			param += "37";
			bFirst = false;
		}  else if (dropdown.value == 7) {
			if (!bFirst) {
				param += ",";
			}
			param += "38";
			bFirst = false;
		} 

		dropdown = m_ComboHouseType.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			if (!bFirst) {
				param += ",";
			}
			param += "39";
			bFirst = false;
		} else if (dropdown.value == 2) {
			if (!bFirst) {
				param += ",";
			}
			param += "40";
			bFirst = false;
		} else if (dropdown.value == 3) {
			if (!bFirst) {
				param += ",";
			}
			param += "41";
			bFirst = false;
		} else if (dropdown.value == 4) {
			if (!bFirst) {
				param += ",";
			}
			param += "42";
			bFirst = false;
		} else if (dropdown.value == 5) {
			if (!bFirst) {
				param += ",";
			}
			param += "43";
			bFirst = false;
		}

		param += "]";


		param += "}";



		Debug.Log (">>> saveProfile: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);
		WWW www = new WWW(url, form);
		//WWW www = new WWW(url);

		StartCoroutine(WaitForProgressDataSave(www));
	}



	IEnumerator WaitForProgressDataSave(WWW www)
    {
        yield return www;
        Debug.Log("Data saved");
        saveAnonym();
	} 


	public void OnSelectedHousehold( int value) {
		Debug.Log ("OnSelectedHousehold: " + value);
		if (value == 7) {
			m_HouseholdOther.SetActive (true);
			m_HouseholdOtherInput.SetActive (true);
		} else {
			m_HouseholdOther.SetActive (false);
			m_HouseholdOtherInput.SetActive (false);
		}
	}

	public void OnSelectedHouseType( int value) {
		Debug.Log ("OnSelectedHouseType: " + value);
		if (value == 5) {
			m_HouseTypeOther.SetActive (true);
			m_HouseTypeOtherInput.SetActive (true);
		} else {
			m_HouseTypeOther.SetActive (false);
			m_HouseTypeOtherInput.SetActive (false);
		}
	}


    public void OnBackClicked()
    {
        Application.LoadLevel("DemoMap");
    }




    void loadAnonym()
    {
        if (PlayerPrefs.HasKey ("PlayerPassword") == false || PlayerPrefs.HasKey ("PlayerMail") == false) {
            Debug.Log ("Did not login yet");
            return;
        }

        string url = "https://geo-wiki.org/Application/api/User/getMarkerAnonymization";
        string param = "";

        string email = PlayerPrefs.GetString ("PlayerMail");
        string password = PlayerPrefs.GetString ("PlayerPassword");
        Debug.Log ("password: " + password);
        string passwordmd5 = ComputeHash (password);
        int randnr = Random.Range(0, 10000000);
        //param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + "\",\"randnr\":" + "\"" + passwordmd5 + "\"" + ",\"scope\":" + "\"total\",\"limit\":\"" + "0" + "\""+ ",\"platform\":{" + "\""+ "app"+ "\":" + "\"14\"" + "}";
        param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\""  + ",\"groupid\":" + 23  + "}";



        Debug.Log ("loadAnonym: " + param);


        WWWForm form = new WWWForm();
        form.AddField ("parameter", param);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForAnonymData(www));
    }

    IEnumerator WaitForAnonymData(WWW www)
    {
        yield return www;
        string[] options = { "Ok" };
        if (www.error == null)
        {
            string data = www.text;

            Debug.Log ("loadAnonym result: " + data);

            if (data == "true") {
                m_ToggleShowUsername.GetComponent<Toggle> ().isOn = false;
            } else {
                m_ToggleShowUsername.GetComponent<Toggle> ().isOn = true;
            }

        } else {
            Debug.Log("WWW Error Anonym: "+ www.error);
            Debug.Log("WWW Error 2 Anonym: "+ www.text);
        }   
    } 


    void saveAnonym()
    {
        if (PlayerPrefs.HasKey ("PlayerPassword") == false || PlayerPrefs.HasKey ("PlayerMail") == false) {
            Debug.Log ("Did not login yet");
            Application.LoadLevel ("DemoMap");
            return;
        }

        string url = "https://geo-wiki.org/Application/api/User/setMarkerAnonymization";
        string param = "";

        string email = PlayerPrefs.GetString ("PlayerMail");
        string password = PlayerPrefs.GetString ("PlayerPassword");
        string passwordmd5 = ComputeHash (password);
        int randnr = Random.Range(0, 10000000);

        if (m_ToggleShowUsername.GetComponent<Toggle> ().isOn) {
            param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + ",\"groupid\":" + 23 + ",\"anonymize\":false" + "}";
        } else {
            param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + ",\"groupid\":" + 23 + ",\"anonymize\":true"+ "}";
        }


        Debug.Log ("saveAnonym: " + param);


        WWWForm form = new WWWForm();
        form.AddField ("parameter", param);
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForAnonymDataSaved(www));
    }

    IEnumerator WaitForAnonymDataSaved(WWW www)
    {
        PlayerPrefs.SetInt("ProfileSaved", 1);
        PlayerPrefs.Save();

        yield return www;
        Debug.Log ("Saved Anonymization");
        Application.LoadLevel ("DemoMap"); 
    } 


    public void checkInternet()
    {
        m_ImageCheckInternet.SetActive(true);
        m_TextCheckInternet.SetActive(true);
        m_BtnBackCheckInternet.SetActive(true);
    }


    public void hideCheckInternet()
    {
        m_ImageCheckInternet.SetActive(false);
        m_TextCheckInternet.SetActive(false);
        m_BtnBackCheckInternet.SetActive(false);
    }

    public void OnReconnect()
    {
        loadProgress();
        loadAnonym();
    }
} 




