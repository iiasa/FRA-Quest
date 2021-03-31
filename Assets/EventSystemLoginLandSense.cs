using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.Networking;

public class EventSystemLoginLandSense : MonoBehaviour {


	public GameObject m_ButtonBack;
	public GameObject m_TextTitle;
	public GameObject m_TextEMail;
	public GameObject m_TextPassword;
	public GameObject m_TextForgot;

	public GameObject m_ButtonLogin;
	public GameObject m_TextResult;


	public GameObject m_InputLogin;
	public GameObject m_InputPassword;
	public GameObject m_InputFieldLogin;
	public GameObject m_InputFieldPassword;

	private Rect windowRect = new Rect (20, 20, 120, 50);


	private MessageBox messageBox;
	private MessageBox verticalMessageBox;

	private int m_Show = 0;

	public GameObject m_TermsBack;
	public GameObject m_TermsTitle;
	public GameObject m_TermsTextBack;
	public GameObject m_TermsScrollbarAT;
	public GameObject m_TermsImageAT;
	public GameObject m_TermsScrollbarEN;
	public GameObject m_TermsImageEN;
	public GameObject m_TermsBtnAccept;
	public GameObject m_TermsBtnDecline;


	public GameObject m_LoadingBack;
	public GameObject m_LoadingText;


	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Portrait;

		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;


		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;


		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

		updateStates ();


		m_LoadingText.SetActive (false);
		m_LoadingBack.SetActive (false);
			messageBox = UIUtility.Find<MessageBox> ("MessageBox");
		//	verticalMessageBox = UIUtility.Find<MessageBox> ("VerticalMessageBox");

		/*
			messageBox.Show(title,message,icon,null,options);
		*/


		if (messageBox == null) {
			Debug.Log ("No message box set");
		} else {
			Debug.Log ("Message set");
		}

		hideTerms ();

		m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF" +
			"ASDFASDF asdf ASDF ASDF SDAFASDF";

	}


	void OnGUI () {
//		windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
	}



	void WindowFunction (int windowID) {
		// Draw any Controls inside the window here
	}

	bool m_bShown = false;
	bool m_bLoggedInAndroid = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel ("StartScreen");
		}

		//--------------------------
		// Android

		string strurl = AndroidDeepLink.GetURL();
		if (m_bLoggedInAndroid == false) {
			if (strurl.CompareTo ("null") != 0) {
				m_bLoggedInAndroid = true;
				OnOpenWithUrl (strurl);
			} else {
				m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = strurl;
			}
		}

		//--------------------------
		/*
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");*/
		
		/*m_Show++;
		if (m_Show >= 3 && !m_bShown) {
			if (Application.systemLanguage == SystemLanguage.German) {
				string[] options = { "Ok" };
				messageBox.Show ("", "Verwende deinen Geo-Wiki Account (www.geo-wiki.org) um dich einzuloggen.", options);
			} else {
				string[] options = { "Ok" };
				messageBox.Show ("", "Use your excisting Geo-Wiki Account (www.geo-wiki.org) to login.", options);
			}
			m_bShown = true;
		}*/
	}

	public void updateStates() {
		if (Application.systemLanguage == SystemLanguage.German && false) {
			m_TextTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Login";

			m_ButtonLogin.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginLogin");//"EINLOGGEN";
			m_TextForgot.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginForgotPassword");//"Passwort vergessen?";
			m_TextEMail.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoginMail");//"E-Mail:";
			m_TextPassword.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoginPassword");//"Passwort:";

			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Zurück";

			m_LoadingText.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Loading");//"Laden...";
		} else {
			m_TextTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Login LS";
		
			m_ButtonLogin.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginLogin");//"LOGIN";
			m_TextForgot.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginForgotPassword");//"Forgot password?";
			m_TextEMail.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoginMail");//"E-Mail:";
			m_TextPassword.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoginPassword");//"Password:";
			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Back";
			m_LoadingText.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Loading");//"Loading...";
		}

		if (Application.systemLanguage == SystemLanguage.German ) {
			m_TermsTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("MenuTerms");//"Teilnahmebedingungen";


			m_TermsBtnAccept.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Accept");//"Annehmen";
			m_TermsBtnDecline.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Decline");//"Ablehnen";
		} else {
			m_TermsTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("MenuTerms");//"Terms and Conditions";

			m_TermsBtnAccept.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Accept");//"Accept";
			m_TermsBtnDecline.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Decline");//"Decline";
		}
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


	public static string ComputeHashSHA256(string s){
		// Form hash
		System.Security.Cryptography.SHA256 h = System.Security.Cryptography.SHA256.Create();
		byte[] data = h.ComputeHash(System.Text.Encoding.Default.GetBytes(s));
		// Create string representation
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		for (int i = 0; i < data.Length; ++i) {
			sb.Append(data[i].ToString("x2"));
		}
		return sb.ToString();
	}

	public void LoginClicked () {
		Debug.Log ("LoginClicked");


		// Create code verifier
		byte[] array = new byte[32];
		System.Random random = new System.Random();
		random.NextBytes (array);
		string verifier = Convert.ToBase64String (array);
		string verifierEscaped =  WWW.EscapeURL(verifier);
		Debug.Log ("Code verifier: " + verifierEscaped);

		PlayerPrefs.SetString ("CodeVerifier", verifier);
		PlayerPrefs.Save ();







	//	StartCoroutine(ReadingToken("asdf"));
//		return;



		string challenge = ComputeHashSHA256 (verifierEscaped);
		string challengeEscaped =  WWW.EscapeURL(challenge);
		Debug.Log ("Challenge: " + challengeEscaped);

		string client = "V2eQJA8ZkWUCIP_Xmzhg0kFyBQ3kNZaH";//"V2eQJA8ZkWUCIP_Xmzhg0kFyBQ3kNZaH";
		string clientEscaped =  WWW.EscapeURL(client);

		//string urlauthorize = "https://as.landsense.eu/oauth/authorize?scope=appointments%20contacts&audience=appointments:api&response_type=code";
		string urlauthorize = "https://as.landsense.eu/oauth/authorize?";
		urlauthorize = "audience=API_AUDIENCE&";
		urlauthorize += "response_type=code&";
		urlauthorize += "client_id=" + WWW.EscapeURL("019fde2d-edef-052b-2ddd-440e9e898ff7@as.landsens.eu");//xamarin&";
		urlauthorize += "&client_secret=" +  WWW.EscapeURL("adc4db06695693cb05b1a56fe910e7d92aa52fd3066827b7b99434fb1db90944");//xamarin&";
		urlauthorize += "&scope=" + WWW.EscapeURL("openid profile email");
		urlauthorize += "&code_challenge=" + challengeEscaped + "&code_challenge_method=S256";


		byte[] arraystate = new byte[32];
		random.NextBytes (arraystate);
		string state = Convert.ToBase64String (arraystate);
		string stateEscaped =  WWW.EscapeURL(state);
		urlauthorize += "&state="+stateEscaped;


		urlauthorize += "&redirect_uri="+ WWW.EscapeURL("eu.landsense://GreenSpaceNL");

		urlauthorize = "https://as.landsense.eu/oauth/authorize?" + urlauthorize;//WWW.EscapeURL(urlauthorize);

/*

			"scope=appointments%20contacts&audience=appointments:api&response_type=code";
		urlauthorize += "&client_id=" + clientEscaped;
		urlauthorize += "&code_challenge=" + challengeEscaped + "&code_challenge_method=S256";
		//urlauthorize += "&redirect_uri=GreenSpaceNL://";
		urlauthorize += "&redirect_uri=GreenSpaceNL://myclientapp.com/callback";*/


		string urlauthorizeEscaped = urlauthorize;
		Debug.Log ("Open url: " + urlauthorizeEscaped);
		Application.OpenURL(urlauthorizeEscaped);


		//string[] optionstest = { "Ok" };
	//	messageBox.Show ("", "This is a test asdf tasdf asf sfd This is a test this is a test this is a testThis is a test asdf tasdf asf sfd This is a test this is a test this is a testThis is a test asdf tasdf asf sfd This is a test this is a test this is a testThis is a test asdf tasdf asf sfd This is a test this is a test this is a test", optionstest);
		return;
		Debug.Log("LoginClicked");

		//string user = m_InputLogin.GetComponent<UnityEngine.UI.Text> ().text;
	//	string password = m_InputPassword.GetComponent<UnityEngine.UI.InputField> ().text;
		UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField> ();
		string user = inputfield.text;
		Debug.Log ("user2: " + user);


		UnityEngine.UI.InputField textinput;
		textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
		string password = textinput.text;

		string value = user + "," + password;
		string[] options = { "OK" };
		//messageBox.Show ("", value, options);

		if (user.Length <= 0) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoMail"), options);
			} else {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoMail"), options);
			}
			return;
		}

		if (password.Length <= 0) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoPassword"), options);
			} else {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoPassword"), options);
			}
			return;
		}

//		showTerms();
		acceptedTerms ();


	/*
		if (Application.systemLanguage == SystemLanguage.German) {
			string[] options = { "OK" };
			messageBox.Show ("", "erwende deinen Geo-Wiki (www.geo-wiki.org) Account um dich einzuloggen.", options);
		} else {
			string[] options = { "OK" };
			messageBox.Show ("", "Use your excisting Geo-Wiki Account (www.geo-wiki.org) to login.", options);
		}*/

	}



	IEnumerator WaitForData(WWW www)
	{
		yield return www;

		string[] options = { "OK" };


		// check for errors
		if (www.error == null)
		{
			string data = www.text;
			//string[] parts = data.Split (":", 2);

			string[] parts = data.Split(new string[] { ":" }, 0);
			string[] parts2 = parts[1].Split(new string[] { "," }, 0);
			string part3 = parts2 [0];

			Debug.Log("WWW Ok!: " + www.text);
			Debug.Log("part1: " + parts[0]);
			Debug.Log("part2: " + parts[1]);
			Debug.Log("part3: " + part3);

			part3 = part3.Replace ("\"", "");
			part3 = part3.Replace ("}", "");

			Debug.Log ("parts2 len: " + parts2.Length);
			if (parts.Length > 2) {
				string part4 = parts [2];
				Debug.Log ("Part4: " + part4);


				part4 = part4.Replace ("\"", "");
				part4 = part4.Replace ("}", "");


				Debug.Log ("Part4: " + part4);

				PlayerPrefs.SetString("PlayerName",part4);
			}

			if (part3.Equals ("null")) {

				m_LoadingText.SetActive (false);
				m_LoadingBack.SetActive (false);

				if (Application.systemLanguage == SystemLanguage.German) {
					messageBox.Show ("", LocalizationSupport.GetString("LoginFailed"), options);
				} else {
					messageBox.Show ("", LocalizationSupport.GetString("LoginFailed"), options);
				}
				yield return www;
			} else {

				/*if (Application.systemLanguage == SystemLanguage.German) {
					messageBox.Show ("", "Einloggen erfolgreich.", options);
				} else {
					messageBox.Show ("", "Login successful.", options);
				}*/

				PlayerPrefs.SetString("PlayerId",part3);


				UnityEngine.UI.InputField textinput;
				textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
				string password = textinput.text;

				PlayerPrefs.SetString("PlayerPassword",password);

				UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField> ();
				string mail = inputfield.text;
				//string mail = m_InputLogin.GetComponent<UnityEngine.UI.Text> ().text;
				PlayerPrefs.SetString("PlayerMail",mail);


				PlayerPrefs.SetInt ("LoggedOut", 0);

				PlayerPrefs.Save ();

				Debug.Log ("Saved Mail: " + mail + " password: " + password);

				bool bDontGoToQuestsPage = false;
				if (PlayerPrefs.HasKey ("LoginReturnToQuests")) {
					int returntoquests = PlayerPrefs.GetInt ("LoginReturnToQuests");
					if (returntoquests == 1) {
						Application.LoadLevel ("Quests");
						bDontGoToQuestsPage = true;
						yield return www;
					}
				}

				if (bDontGoToQuestsPage == false) {
					Application.LoadLevel ("DemoMap");
				}
			}


		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);


			m_LoadingText.SetActive (false);
			m_LoadingBack.SetActive (false);

			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", LocalizationSupport.GetString("LoginFailedNoInternet"), options);
			} else {
				messageBox.Show ("", LocalizationSupport.GetString("LoginFailedNoInternet"), options);
			}
		}   
	} 


	public void RegisterClicked () {
	}
	public void OnBackClicked () {
		Application.LoadLevel ("StartScreen");
	}
	public void OnForgotClicked () {
		Application.OpenURL("http://www.geo-wiki.org/Security/lostpassword");
	}


	public void hideTerms()
	{
		m_TermsBack.SetActive (false);
		m_TermsTitle.SetActive (false);
		m_TermsScrollbarAT.SetActive (false);
		m_TermsTextBack.SetActive (false);
		m_TermsImageAT.SetActive (false);
		m_TermsBtnAccept.SetActive (false);
		m_TermsBtnDecline.SetActive (false);
		m_TermsScrollbarEN.SetActive (false);
		m_TermsImageEN.SetActive (false);
	}
	void showTerms()
	{
		m_TermsBack.SetActive (true);
		m_TermsTitle.SetActive (true);

		if (Application.systemLanguage == SystemLanguage.German ) {
			m_TermsScrollbarAT.SetActive (true);
			m_TermsImageAT.SetActive (true);
			m_TermsScrollbarEN.SetActive (false);
			m_TermsImageEN.SetActive (false);
		} else {
			m_TermsScrollbarAT.SetActive (false);
			m_TermsImageAT.SetActive (false);
			m_TermsScrollbarEN.SetActive (true);
			m_TermsImageEN.SetActive (true);
		}

		m_TermsTextBack.SetActive (true);
		m_TermsBtnAccept.SetActive (true);
		m_TermsBtnDecline.SetActive (true);
	}

	public void acceptedTerms()
	{
		UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField> ();
		string user = inputfield.text;
		Debug.Log ("user2: " + user);


		UnityEngine.UI.InputField textinput;
		textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
		string password = textinput.text;

		string value = user + "," + password;
		string[] options = { "OK" };
		//messageBox.Show ("", value, options);

		if (user.Length <= 0) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoMail"), options);
			} else {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoMail"), options);
			}
			return;
		}

		if (password.Length <= 0) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoPassword"), options);
			} else {
				messageBox.Show ("", LocalizationSupport.GetString("LoginNoPassword"), options);
			}
			return;
		}


		m_LoadingText.SetActive (true);
		m_LoadingBack.SetActive (true);
		hideTerms ();

		string passwordmd5 = ComputeHash (password);

		string url = "https://geo-wiki.org/Application/api/User/checkCredentials";
		string param = "";
		param += "{\"username\":\"" + user + "\",\"passwordMD5\":\"" + passwordmd5 + "\"";
		param += "}";



		Debug.Log ("login param: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);

		//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForData(www));
	}

	public void declineTerms()
	{
		hideTerms ();
	}


	IEnumerator ReadingToken(string code) {
		string url = "https://as.landsense.eu/oauth/token";

		//string bodyData = "{\"grant_type\":\"authorization_code\", }";
	/*	string bodyData = "{\"grant_type\":\"authorization_code\",\"client_id\": \"" + "019fde2d-edef-052b-2ddd-440e9e898ff7@as.landsens.eu"
			+ "\",\"code_verifier\": \"" + "asdf" + "\",\"code\": \"" +  "ASDS" + "\",\"redirect_uri\": \"" + 
			"eu.landsense://GreenSpaceNL" + "\", }";*/

		string verifierEscaped = PlayerPrefs.GetString ("CodeVerifier");


		/*string paramjson = "{\"grant_type\":\"authorization_code\"," +
			"\"client_id\": \"" + WWW.EscapeURL("019fde2d-edef-052b-2ddd-440e9e898ff7@as.landsens.eu") + "\"," +
			"\"client_secret\": \"" + WWW.EscapeURL("adc4db06695693cb05b1a56fe910e7d92aa52fd3066827b7b99434fb1db90944") + "\"," + 
			"\"code_verifier\": \"" + verifierEscaped + "\",\"code\": \"" +  WWW.EscapeURL(code) + "\",\"redirect_uri\": \"" + 
			WWW.EscapeURL("eu.landsense://GreenSpaceNL") + "\"}";*/

		string paramjson = "{\"grant_type\":\"authorization_code\"," +
			"\"client_id\": \"" + "019fde2d-edef-052b-2ddd-440e9e898ff7@as.landsens.eu" + "\"," +
			"\"client_secret\": \"" + "adc4db06695693cb05b1a56fe910e7d92aa52fd3066827b7b99434fb1db90944" + "\"," + 
			"\"code_verifier\": \"" + verifierEscaped + "\",\"code\": \"" +  code + "\",\"redirect_uri\": \"" + 
			"eu.landsense://GreenSpaceNL" + "\"}";

		Debug.Log ("param: " + paramjson);



		UnityWebRequest www = UnityWebRequest.Put(url, paramjson);
		www.method = "POST";
		www.SetRequestHeader ("content-type", "application/json");
		yield return www.Send();

		if(www.isNetworkError || www.isHttpError) {
			Debug.Log(www.error);
		}
		else {
			Debug.Log("Form upload complete!");
			Debug.Log (www.downloadHandler.text);
			string[] options = { "OK" };

			string text = www.downloadHandler.text;
			messageBox.Show ("", text, options);


			string[] parts = text.Split(new string[] { "access_token\":\"" }, 0);
			string[] parts2 = parts[1].Split(new string[] { "\","}, 0);
					
			string accesstoken = parts2 [0];
			//m_TextResult.GetComponent<UnityEngine.UI.Text>().text = "access_token: " + accesstoken;


			string[] parts3 = text.Split(new string[] { "id_token\":\"" }, 0);
			if (parts3.Length <= 1) {
				m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "noid";
			} else {
				string[] parts4 = parts3 [1].Split (new string[] { "\"}" }, 0);
				if (parts4.Length <= 0) {
					m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "noid 2";
				} else {
					string idtoken = parts4 [0];
					//m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "accesstoken: " + accesstoken;// + " id_token: " + idtoken;
					/*
					byte[] bytes = System.Convert.FromBase64String (idtoken);
					string userinfo = System.Text.ASCIIEncoding.ASCII.GetString (bytes);
					m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "userinfo: " + userinfo + " TEXT: " + text;
*/
					m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "idtoken: " + idtoken;

					string[] partsid = idtoken.Split(new string[] { "." }, 0);
					if (partsid.Length > 2) {
						string decode = partsid [1];
						int padLength = 4 - decode.Length % 4;
						if (padLength < 4) {
							decode += new string ('=', padLength);
						}
						byte[] bytes = System.Convert.FromBase64String (decode);
						string userInfo = System.Text.ASCIIEncoding.ASCII.GetString (bytes);


						m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "access token: " + accesstoken + "\nuserinfo: " + userInfo;
					} else {
						m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "idtoken: " + idtoken + " not 3 parts";
					}


					/*
					string[] partsid = idtoken.Split('.');
					if (partsid.Length > 1) {
						string decode = partsid [1];

						byte[] bytes = System.Convert.FromBase64String (decode);
						string userinfo = System.Text.ASCIIEncoding.ASCII.GetString (bytes);
						m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "userinfo: " + userinfo + " TEXT: " + text;
					} else {

						string[] partemail = idtoken.Split (new string[] { "email\":" }, 0);
						if (partemail.Length <= 1) {
							m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "no email idlen: " + idtoken.Length;
							m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = idtoken + "TEXT: " + text;


						} else {
							string[] emails = partemail [1].Split (new string[] { "\"}" }, 0);
							if (emails.Length <= 0) {
								m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "no email 2";
							} else {
								string email = emails [0];
								m_TextResult.GetComponent<UnityEngine.UI.Text> ().text = "email: " + email;// + " id_token: " + idtoken;
							}
						}
					}*/
				}
			}

		}
	}



	public void OnOpenWithUrl(string paramurl) 
	{
		string[] optionstest = { "Ok" };
		//messageBox.Show ("", "" + param, optionstest);
		string[] parts = paramurl.Split(new string[] { "code=" }, 0);

		//messageBox.Show ("", "" + parts[1], optionstest);

		string[] parts2 = parts[1].Split(new string[] { "&" }, 0);

		string code = parts2 [0];
		//messageBox.Show ("", "The code: " + code, optionstest);


		StartCoroutine(ReadingToken(code));
		return;

		string url = "https://as.landsense.eu/oauth/token";
	/*	string param = "";
		param += "{\"email\":\"" + mail + "\",\"md5password\":\"" + passwordmd5 + "\",\"username\":\"" + user + "\"";
		param += "}";

		m_UrlParams = param;
		Debug.Log ("login param: " + param);*/


		string verifierEscaped = PlayerPrefs.GetString ("CodeVerifier");


		string paramjson = "{\"grant_type\":\"authorization_code\",\"client_id\": \"" + WWW.EscapeURL("019fde2d-edef-052b-2ddd-440e9e898ff7@as.landsens.eu")
			+ "\",\"code_verifier\": \"" + verifierEscaped + "\",\"code\": \"" +  WWW.EscapeURL(code) + "\",\"redirect_uri\": \"" + 
			WWW.EscapeURL("eu.landsense://GreenSpaceNL") + "\"}";
		paramjson = WWW.EscapeURL (paramjson);

		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("content-type", "application/json");
	//headers.Add("content-type", "application/json");


		WWWForm form = new WWWForm();
		//form.AddField ("application/json", paramjson);
		form.AddField ("parameter", paramjson);


		//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
		WWW www = new WWW(url, form.data, headers);
		StartCoroutine(WaitForToken(www));
	}

	IEnumerator WaitForToken(WWW www)
	{
		yield return www;

		string[] options = { "OK" };

		if (www.error == null) {
			string data = www.text;
			messageBox.Show ("","Token: " + data, options);
		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);
			string m_StrError = www.text;


			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("","Registrierung fehlgeschlagen: " + m_StrError, options);
			} else {
				messageBox.Show ("", "Registration not successful: " + m_StrError, options);
			}
		}   
		yield return www;
	}
}
