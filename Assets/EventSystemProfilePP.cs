using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class EventSystemProfilePP : MonoBehaviour {

	public GameObject m_BackImage;
	public GameObject m_Button;
	public GameObject m_HelloName;
	public GameObject m_Progress;
	public GameObject m_UserName;
	public GameObject m_FirstName;
	public GameObject m_LastName;
	public GameObject m_Hometown;
	public GameObject m_Age;
	public GameObject m_Gender;
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
	public GameObject m_InputFirstName;
	public GameObject m_InputLastName;
	public GameObject m_InputHometown;
	public GameObject m_ComboGender;
	public GameObject m_ComboAge;


	public GameObject m_LableShowUsername;
	public GameObject m_ToggleShowUsername;

	public GameObject m_LevelTitle;
	public GameObject m_LevelText;
	public GameObject m_LevelBar;

	public GameObject m_BtnBack;

	private MessageBox messageBox;
	private MessageBox verticalMessageBox;


	public GameObject m_ImageUploadingPortrait;
	public GameObject m_ImageUploadingLandscape;
	public GameObject m_TextUploading;
	public GameObject m_ImageTextUploading;
	public GameObject m_TextCommentAdditionalInfo;



	public GameObject m_ImageCheckInternetPortrait;
	public GameObject m_ImageCheckInternetLandscape;
	public GameObject m_TextCheckInternet;
	public GameObject m_BtnBackCheckInternet;
	public GameObject m_ImageBackCheckInternet;
	public GameObject m_BtnCheckInternet;


	public CanvasScaler m_Scaler;
	public GameObject m_BackgroundPortrait;
	public GameObject m_BackgroundLandscape;

	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}


	public void ForceAutoRotate()
	{
		StartCoroutine(ForceAndFixAutoRotate());
	}

	IEnumerator ForceAndFixAutoRotate()
	{
		yield return new WaitForSeconds (0.01f);

		Screen.autorotateToPortraitUpsideDown = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToLandscapeLeft = true;
		Screen.orientation = ScreenOrientation.AutoRotation;
		Screen.autorotateToPortrait = true;
		yield return new WaitForSeconds (0.5f);
	}



	public void ForcePortrait()
	{
		StartCoroutine(ForceAndFixPortrait());
	}

	IEnumerator ForceAndFixPortrait()
	{
		yield return new WaitForSeconds (0.01f);
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;
		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		yield return new WaitForSeconds (0.5f);
	}


	void UpdateBackgroundImage()
	{
		if (Screen.width > Screen.height) {
			m_BackgroundPortrait.SetActive (false);
			m_BackgroundLandscape.SetActive (true);
		} else {
			m_BackgroundPortrait.SetActive (true);
			m_BackgroundLandscape.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());

		#if UNITY_WEBGL
		ForceAutoRotate ();
		#else 
		ForcePortrait ();
		#endif

		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

		UpdateScaler ();

		UpdateBackgroundImage ();

		m_ImageUploadingPortrait.SetActive (false);
		m_ImageUploadingLandscape.SetActive (false);
		m_TextUploading.SetActive (false);
		m_ImageTextUploading.SetActive (false);


		UnityEngine.UI.Dropdown dropdown;
		UnityEngine.UI.Dropdown.OptionData list;


		m_BtnBack.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Back");

			m_UserName.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileUsername");//"Username:";


			m_TextCommentAdditionalInfo.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Please provide us with some information about yourself. This info is only for us to further improve FotoQuest:";


			m_FirstName.GetComponentInChildren<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("ProfileFirstname");// "First Name:";
			m_LastName.GetComponentInChildren<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("ProfileLastname");// "Last Name:";
			m_Hometown.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileHometown");//"Hometown:";
			m_Age.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileAgeGroup");//"Age Group:";
			m_Gender.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileGender");//"Gender:";
			m_Interests.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterests");//"Interests:";


			m_Toggle1.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestScience");//"Science";
			m_Toggle2.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestSports");//"Sports";
			m_Toggle3.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestNature");//"Nature";
			m_Toggle4.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestBiology");//"Biology";
			m_Toggle5.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestGeography");//"Geography";
			m_Toggle6.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestMusic");//"Music";
			m_Toggle7.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestComputers");//"Computers";
			m_Toggle8.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestBooks");//"Books";
			m_Toggle9.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileInterestAgriculture");//"Agriculture";

		m_BtnCheckInternet.GetComponentInChildren<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("BtnCheck");// "First Name:";
		m_TextCheckInternet.GetComponent<UnityEngine.UI.Text> ().text =LocalizationSupport.GetString ("CheckInternet");// "First Name:";


		m_LableShowUsername.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("ProfileShowUsername");

			dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);

			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileFemale"));
			dropdown.options.Add (list);
			list = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString ("ProfileMale"));
			dropdown.options.Add (list);
			dropdown.value = 0;


			UnityEngine.UI.InputField textinput;
			textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";

			textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
			textinput.text = "";



			m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("IsUploading");




		m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
		m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";

		dropdown = m_ComboAge.GetComponent<UnityEngine.UI.Dropdown>();
		dropdown.options.Clear ();
		if (Application.systemLanguage == SystemLanguage.German && false) {
			list = new UnityEngine.UI.Dropdown.OptionData ("(Bitte auswählen)");
			dropdown.options.Add (list);
		} else {
			list = new UnityEngine.UI.Dropdown.OptionData (LocalizationSupport.GetString ("ProfileSelect"));
			dropdown.options.Add (list);
		}

		/*list = new UnityEngine.UI.Dropdown.OptionData("< 10");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("10-14");
		dropdown.options.Add (list);*/
		list = new UnityEngine.UI.Dropdown.OptionData("18-19");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("20-29");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("30-39");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("40-49");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("50-59");
		dropdown.options.Add (list);
		list = new UnityEngine.UI.Dropdown.OptionData("60+");
		dropdown.options.Add (list);
		dropdown.value = 0;



		updateStates ();
		loadBackgroundImage ();



		messageBox = UIUtility.Find<MessageBox> ("MessageBox");


		UnityEngine.UI.Text text;
		string progressname = LocalizationSupport.GetString ("Hello");
		text = m_HelloName.GetComponent<UnityEngine.UI.Text>();
		text.text = progressname;


		text = m_Progress.GetComponent<UnityEngine.UI.Text>();
		int sorting = PlayerPrefs.GetInt ("CurrentlySorting");
		text.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Loading");

		m_LevelTitle.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Loading");
		m_LevelText.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
		m_LevelBar.SetActive(false);

		loadStatistics ();
		loadProgress ();
		loadSettings ();

	}


	void UpdateScaler()
	{
		if (Screen.width > Screen.height) {
			m_Scaler.referenceResolution = new Vector2 (Screen.width * 1.5f, 700);
		} else {
			m_Scaler.referenceResolution = new Vector2 (800, 700);
		}
	}

	void Update () {
		//if (Input.GetKeyDown(KeyCode.Escape)) 
		//	Application.LoadLevel ("DemoMap");
		UpdateScaler();

		UpdateBackgroundImage ();
	}


	int m_CurState = 0;
	public void updateStates() {

		m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString ("BtnSave");
	}

	public void NextClicked () {
		if (Screen.width > Screen.height) {
			m_ImageUploadingPortrait.SetActive (false);
			m_ImageUploadingLandscape.SetActive (true);
		} else {
			m_ImageUploadingPortrait.SetActive (true);
			m_ImageUploadingLandscape.SetActive (false);
		}
		m_TextUploading.SetActive (true);
		m_ImageTextUploading.SetActive (true);
		SaveSettings ();
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

	void loadStatistics() {
		Debug.Log (">> loadStatistics");

		string userd = PlayerPrefs.GetString ("PlayerId");
		string url = "https://geo-wiki.org/Application/api/game/getNrClassificationsDone/" + userd;
			//"https://geo-wiki.org/Application/api/game/getNrUsersBranch";
	/*	string param = "";
		param += "{\"branchid\":\"" + id + "\"";
		param += "}";

		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);*/

		WWW www = new WWW(url);
		StartCoroutine(waitForStatistics(www));
	}

	IEnumerator waitForStatistics(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log (">>> User statistics loaded");
			string data = www.text;


			string[] entries = data.Split(new string[] { "&" }, 0);

			string nrpicturessorted = entries [0];
			m_Progress.GetComponent<UnityEngine.UI.Text>().text = "You have already sorted " + nrpicturessorted + " pictures.\n";
			updateProgressValues (int.Parse (nrpicturessorted));
		} else {
			Debug.Log (">>> User statistics could not be loaded");
		}   

		www.Dispose ();
		Resources.UnloadUnusedAssets();
	}

	void updateProgressValues(int nrpicturessorted)
	{
		float levelbase = 100;
		float levelgrowth = 1.8f;

		int level = 0;
		int lastlevel = 0;
		int nextlevel = (int)levelbase;
		while (nrpicturessorted > levelbase) {
			levelbase *= levelgrowth;

			level++;
			lastlevel = (int)nextlevel;
			nextlevel = (int)levelbase;
		}

		level++;

		if (level == 1) {
			m_LevelTitle.GetComponent<UnityEngine.UI.Text> ().text = "You are on Level " + 1 + ".";
		} else {
			m_LevelTitle.GetComponent<UnityEngine.UI.Text> ().text = "You have reached Level " + level + "!";
		}
		int picturesToNext = nextlevel - nrpicturessorted;
		m_LevelText.GetComponent<UnityEngine.UI.Text> ().text = picturesToNext + " pictures until next level";

		// Adjust bar size
		float proc = ((float)nrpicturessorted - (float)lastlevel) / ((float)nextlevel - (float)lastlevel);
		RectTransform rt = m_LevelBar.GetComponent<RectTransform>();
		Vector2 size = rt.sizeDelta;
		size.x *= proc;
		rt.sizeDelta = size;
		Vector3 position = rt.position;
		position.x -= Screen.width * 0.43f * (1.0f - proc);
		rt.position = position;
		m_LevelBar.SetActive (true);
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

	IEnumerator WaitForProgressData(WWW www)
	{
		yield return www;

		string[] options = { "OK" };
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


			UnityEngine.UI.Text text;
			text = m_HelloName.GetComponent<UnityEngine.UI.Text>();
			text.text = LocalizationSupport.GetString ("Hello") + " " + m_ReadingFirstName + ",";



			UnityEngine.UI.Dropdown dropdown;
			dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
			m_ComboAge.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
			m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";

			if (Application.systemLanguage == SystemLanguage.German) {
				if (m_GenderSelected == 1) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Männlich";
					dropdown.value = 2;
				} else if (m_GenderSelected == 2) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Weiblich";
					dropdown.value = 1;
				}
			} else {
				if (m_GenderSelected == 1) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Male";
					dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
					dropdown.value = 2;
				} else if (m_GenderSelected == 2) {
					m_ComboGender.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Female";
					dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
					dropdown.value = 1;
				}
			}

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
		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);
			checkInternet ();
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
				} else if (obj.n == 11) {
					m_Toggle1.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 12) {
					m_Toggle2.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 13) {
					m_Toggle3.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 14) {
					m_Toggle4.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 15) {
					m_Toggle5.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 16) {
					m_Toggle6.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 17) {
					m_Toggle7.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 18) {
					m_Toggle8.GetComponent<Toggle> ().isOn = true;
				} else if (obj.n == 19) {
					m_Toggle9.GetComponent<Toggle> ().isOn = true;
				} 
			}
			break;
		case JSONObject.Type.BOOL:
			break;
		case JSONObject.Type.NULL:
			break;

		}
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

		string[] options = { "OK" };
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
		string url = "https://geo-wiki.org/Application/api/User/profile";
		string param = "";

		string email = PlayerPrefs.GetString ("PlayerMail");
		string password = PlayerPrefs.GetString ("PlayerPassword");
		string passwordmd5 = ComputeHash (password);
		int randnr = Random.Range(0, 10000000);
		//param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + "\",\"randnr\":" + "\"" + passwordmd5 + "\"" + ",\"scope\":" + "\"total\",\"limit\":\"" + "0" + "\""+ ",\"platform\":{" + "\""+ "app"+ "\":" + "\"14\"" + "}";
		param += "{\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"";

		UnityEngine.UI.InputField textinput;
		textinput = m_InputFirstName.GetComponent<UnityEngine.UI.InputField>();


		param += "," + "\"firstname\":\""   + textinput.text + "\"";


		textinput = m_InputLastName.GetComponent<UnityEngine.UI.InputField>();
		param += "," + "\"lastname\":\""   + textinput.text + "\"";


		textinput = m_InputHometown.GetComponent<UnityEngine.UI.InputField>();
		param += "," + "\"hometown\":\""   + textinput.text + "\"";



		param += "," + "\"attributes\":"   + "[";

		bool bFirst = true;
		UnityEngine.UI.Dropdown dropdown;
		dropdown = m_ComboGender.GetComponent<UnityEngine.UI.Dropdown>();
		if (dropdown.value == 1) {
			param += "2";
			bFirst = false;
		} else if (dropdown.value == 2) {
			param += "1";
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
			param += "11";
			bFirst = false;
		} 

		if (m_Toggle2.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "12";
			bFirst = false;
		} 
		if (m_Toggle3.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "13";
			bFirst = false;
		} 
		if (m_Toggle4.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "14";
			bFirst = false;
		} 
		if (m_Toggle5.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "15";
			bFirst = false;
		} 
		if (m_Toggle6.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "16";
			bFirst = false;
		} 
		if (m_Toggle7.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "17";
			bFirst = false;
		} 
		if (m_Toggle8.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "18";
			bFirst = false;
		} 
		if (m_Toggle9.GetComponent<Toggle> ().isOn) {
			if (!bFirst) {
				param += ",";
			}
			param += "19";
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
		Debug.Log ("Data saved");

		int sorting = PlayerPrefs.GetInt ("CurrentlySorting");
		if(sorting == 1) 
			Application.LoadLevel ("Sorting");
		else
			Application.LoadLevel ("Piles");
	} 

	public void OnBackClicked()
	{
		int sorting = PlayerPrefs.GetInt ("CurrentlySorting");
		if(sorting == 1) 
			Application.LoadLevel ("Sorting");
		else
			Application.LoadLevel ("Piles");
	}


	void loadBackgroundImage()
	{
		int sorting = PlayerPrefs.GetInt ("CurrentlySorting");
		if (sorting == 0) {
			return;
		}


		int pileimg = PlayerPrefs.GetInt ("CurPileImage");
		if (pileimg == 0) {
			return;
		}
		/*
		string picid = "curpic";
		string name = Application.persistentDataPath+"/"+picid+".png";
		if (File.Exists (name)) {
			byte[] bytes = File.ReadAllBytes (name);
			if (bytes != null) {
				Texture2D texture = new Texture2D (1, 1);
				texture.LoadImage (bytes);

				Sprite sprite = Sprite.Create(texture, new Rect(0, 50, texture.width,512+50), new Vector2(0, 0));


				UnityEngine.UI.Image image = m_BackImage.GetComponent<UnityEngine.UI.Image> ();
				image.sprite = sprite;
				m_BackImage.GetComponent<UnityEngine.UI.Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);

				image = m_ImageUploading.GetComponent<UnityEngine.UI.Image> ();
				image.sprite = sprite;
				m_ImageUploading.GetComponent<UnityEngine.UI.Image> ().color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
			}
		} else {
			Debug.Log ("Could not load image " + name);
		}*/
	}


	public void checkInternet()
	{
		if (Screen.width > Screen.height) {
			m_ImageCheckInternetPortrait.SetActive (false);
			m_ImageCheckInternetLandscape.SetActive (true);
		} else {
			m_ImageCheckInternetPortrait.SetActive (true);
			m_ImageCheckInternetLandscape.SetActive (false);
		}

		m_TextCheckInternet.SetActive (true);
		m_BtnBackCheckInternet.SetActive (true);
		m_ImageBackCheckInternet.SetActive (true);
		m_BtnCheckInternet.SetActive (true);
	}


	public void hideCheckInternet()
	{
		m_ImageCheckInternetPortrait.SetActive (false);
		m_ImageCheckInternetLandscape.SetActive (false);
		m_TextCheckInternet.SetActive (false);
		m_BtnBackCheckInternet.SetActive (false);
		m_ImageBackCheckInternet.SetActive (false);
		m_BtnCheckInternet.SetActive (false);
	}

	public void OnReconnect()
	{
		loadProgress ();
	}
} 




