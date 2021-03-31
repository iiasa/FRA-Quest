using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;

public class EventSystemNotifications : MonoBehaviour {
	

	public GameObject m_Loading;

	public GameObject m_Button;


	public GameObject m_Content;


	public GameObject m_Text;


	private MessageBox messageBox;
	private MessageBox verticalMessageBox;

	ArrayList m_AddedTexts;


	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());

		messageBox = UIUtility.Find<MessageBox> ("MessageBox");

		updateStates ();
		//LoadChat ();
		loadNotifications ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");

		float newheight = m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.rect.size.y;
		Vector3 pos = m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.localPosition;
		pos.y = -newheight;
		m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.localPosition = pos;

		Debug.Log ("Text size3  x: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.x + " y: " +
			m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.y);
	}


	int m_CurState = 0;
	public void updateStates() {
		
		if (Application.systemLanguage == SystemLanguage.German) {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Schließen";
			m_Loading.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Wird geladen...";

		} else {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Close";
			m_Loading.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Loading...";
		}


		m_Text.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
	}

	public void NextClicked () {
		Application.LoadLevel ("DemoMap");
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

	void loadNotifications() {
		if (PlayerPrefs.HasKey ("PlayerPassword") == false || PlayerPrefs.HasKey ("PlayerMail") == false ) {
			Debug.Log ("Did not login yet");

			if (Application.systemLanguage == SystemLanguage.German) {
				m_MessageRead = "\nDu hast noch keine Benachrichtigungen erhalten.";
			} else {
				m_MessageRead = "\nYou have not received any notifications yet.";
			}

			m_Text.GetComponentInChildren<UnityEngine.UI.Text>().text = m_MessageRead;//data;

			TextGenerator textGen = new TextGenerator();
			TextGenerationSettings generationSettings = m_Text.GetComponentInChildren<UnityEngine.UI.Text>().GetGenerationSettings( m_Text.GetComponentInChildren<UnityEngine.UI.Text>().rectTransform.rect.size); 
			float width = textGen.GetPreferredWidth(m_MessageRead, generationSettings);
			float height = textGen.GetPreferredHeight(m_MessageRead, generationSettings);



			RectTransform rectTransform2 = m_Content.GetComponent<RectTransform> ();
			//rectTransform2.sizeDelta.
			//rt.sizeDelta = new Vector2 (100, 100);
			float scalex = rectTransform2.sizeDelta.x;
			float scaley = rectTransform2.sizeDelta.y;
			float heightentry = 240.0f;//250.0f;//200.0f;
			//rectTransform2.sizeDelta = new Vector2 (scalex, heightentry * nrentries + 100.0f);
			//rectTransform2.sizeDelta = new Vector2 (scalex, 2000.0f);
			rectTransform2.sizeDelta = new Vector2 (scalex, height);

			m_Loading.SetActive (false);
			return;
		}

		string url = "https://geo-wiki.org/Application/api/Campaign/FotoQuestGetMessages";
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

		StartCoroutine(WaitForNotificationData(www));
	}

	int m_ReadingWhich;
	int m_NrNotifications;
	string m_MessageRead;
	//string m_MessageReadOnlyText;
	IEnumerator WaitForNotificationData(WWW www)
	{
		yield return www;

		string[] options = { "Ok" };



		// check for errors
		if (www.error == null)
		{
			string data = www.text;
			Debug.Log ("Notification data: " + data);

			m_ReadingWhich = 0;
			m_NrNotifications = 0;
			m_MessageRead = "";
	//		m_MessageReadOnlyText = "";
			JSONObject j = new JSONObject(www.text);
			accessNotificationData(j);

			Debug.Log ("Data read. Nr notifiactions: " + m_NrNotifications);

			if (m_NrNotifications == 0) {

				if (Application.systemLanguage == SystemLanguage.German) {
					m_MessageRead = "Du hast noch keine Benachrichtigungen erhalten.";
				} else {
					m_MessageRead = "You have not received any notifications yet.";
				}

		//		m_MessageReadOnlyText = m_MessageRead;
			} else {
				PlayerPrefs.SetInt ("NrNotificationsRead", m_NrNotifications);
				PlayerPrefs.Save ();
			}

			m_MessageRead = m_MessageRead + "\n\n\n\n";

			//m_MessageReadOnlyText = m_MessageReadOnlyText.Replace ("\n", "");

			m_Loading.SetActive (false);
			m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().text = m_MessageRead;//m_MessageRead;//m_MessageRead;//OnlyText;//m_MessageRead;//data;

			/*Vector2 extend = new Vector2 ();
			extend.x = Screen.width * 0.9f;//0.8f;
			extend.y = 10000;*/
			/*Debug.Log ("Notifications width: " + Screen.width);

			Debug.Log ("text width: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.rect.size.x +
			" height: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.rect.size.y);


			TextGenerator textGen = new TextGenerator();
			//TextGenerationSettings generationSettings = m_Text.GetComponentInChildren<UnityEngine.UI.Text>().GetGenerationSettings( extend); 
			TextGenerationSettings generationSettings = m_Text.GetComponentInChildren<UnityEngine.UI.Text>().GetGenerationSettings(  m_Text.GetComponentInChildren<UnityEngine.UI.Text>().rectTransform.rect.size); 
			//TextGenerationSettings generationSettings = m_Text.GetComponentInChildren<UnityEngine.UI.Text>().GetGenerationSettings( m_Content.GetComponentInChildren<RectTransform>().rect.size); 
			//float width = textGen.GetPreferredWidth(m_MessageReadOnlyText, generationSettings);
			float height = textGen.GetPreferredHeight(m_MessageReadOnlyText, generationSettings);

			RectTransform rectTransform2 = m_Content.GetComponent<RectTransform> ();//m_Content.GetComponent<RectTransform> ();
			//rectTransform2.sizeDelta.
			//rt.sizeDelta = new Vector2 (100, 100);
			float scalex = rectTransform2.sizeDelta.x;
			float scaley = rectTransform2.sizeDelta.y;

		//	Canvas.ForceUpdateCanvases ();
			*/
			/*UnityEngine.UI.Text text = m_Text.GetComponentInChildren<UnityEngine.UI.Text> ();
			TextGenerationSettings settings = text.GetGenerationSettings(text.rectTransform.rect.size);
			float height2 = text.cachedTextGeneratorForLayout.GetPreferredHeight(m_MessageReadOnlyText,settings);
			Debug.Log("height2: " + height2);

			height += 410;*/
			/*

			Debug.Log ("scalex: " + scalex + " y: " + scaley + " height: " + height);
			//float heightentry = 240.0f;//250.0f;//200.0f;
			//rectTransform2.sizeDelta = new Vector2 (scalex, heightentry * nrentries + 100.0f);
			//rectTransform2.sizeDelta = new Vector2 (scalex, 2000.0f);
			rectTransform2.sizeDelta = new Vector2 (scalex, height);//scalex, height);*/

			Canvas.ForceUpdateCanvases ();
			float newheight = m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.rect.size.y;
			Debug.Log ("Text size x: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.x + " y: " +
			m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.y);
			//	Debug.Log("Text size 2 x: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text>().rectTransform.rect.size.x + " y: " +
		//			m_Text.GetComponentInChildren<UnityEngine.UI.Text>().rectTransform.rect.size.y);

		/*	Vector3 pos = m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.localPosition;
			pos.y = -newheight;
			m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.localPosition = pos;
			Canvas.ForceUpdateCanvases ();
*/

			RectTransform rectTransform2 = m_Content.GetComponent<RectTransform> ();//m_Content.GetComponent<RectTransform> ();
			float scalex = rectTransform2.sizeDelta.x;
			float scaley = rectTransform2.sizeDelta.y;
			rectTransform2.sizeDelta = new Vector2 (scalex, newheight);


			Debug.Log ("Text size2  x: " + m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.x + " y: " +
				m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().rectTransform.sizeDelta.y);

		} else {
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.text);
		}   
	} 

	void accessNotificationData(JSONObject obj){
		byte[] bytes;// = System.Text.Encoding.UTF8.GetBytes(obj.str);
		string strtext;// = System.Text.Encoding.UTF8(bytes);


		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				//Debug.Log("key: " + key);
				if (key == "id") {
					//m_CurrentNotification++;
					m_ReadingWhich = 2;
				} else if (key == "numberMessages") {
					m_ReadingWhich = 1;
				}else if (key == "title") {
					m_ReadingWhich = 6;
				}else if (key == "content") {
					m_ReadingWhich = 4;
				}else if (key == "time_created") {
					m_ReadingWhich = 5;
				} else {
					m_ReadingWhich = 0;
				}
				accessNotificationData(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			//	Debug.Log ("Array");
			foreach(JSONObject j in obj.list){
				accessNotificationData(j);
			}
			break;
		case JSONObject.Type.STRING:
		//	bytes = System.Text.Encoding.UTF8.GetBytes (obj.str);
	//		strtext = System.Text.Encoding.UTF8.GetString (bytes);
			strtext = obj.str;
			//Debug.Log ("word: " + strtext);
			strtext = strtext.Replace ("\\n", "\n");
			strtext = strtext.Replace ("\\/", "/");
			strtext = strtext.Replace ("\\r", "");
			strtext = strtext.Replace ("\\u00df", "ß");
			strtext = strtext.Replace ("\\u00dc", "Ü");
			strtext = strtext.Replace ("\\u00fc", "ü");
			strtext = strtext.Replace ("\\u00c4", "Ä");
			strtext = strtext.Replace ("\\u00e4", "ä");
			strtext = strtext.Replace ("\\u00d6", "Ö");
			strtext = strtext.Replace ("\\u00f6", "ö");

			if (m_ReadingWhich == 6) {
				m_MessageRead += "<size=37>" + strtext + "</size>\n";
			//	m_MessageReadOnlyText += strtext + "\n";
			} else if (m_ReadingWhich == 5) {
				string[] strArr = strtext.Split(new string[] { "." }, System.StringSplitOptions.None);
				if(strArr.Length > 0) 
					strtext = strArr[0];

				m_MessageRead += "<color=#2194FBFF><size=22>" + strtext + "</size></color>\n";
			} else if (m_ReadingWhich == 4) {
				m_MessageRead += strtext + "\n\n";
			//	m_MessageReadOnlyText += strtext + "\n\n\n";
			}
			m_ReadingWhich = -1;
			/*if (m_ReadingWhich == 1) {
				m_Pins [m_CurrentPin].m_Id = obj.str;
			} else if (m_ReadingWhich == 2) {
				m_Pins [m_CurrentPin].m_Lat = double.Parse(obj.str);
			} else if (m_ReadingWhich == 3) {
				m_Pins [m_CurrentPin].m_Lng = double.Parse(obj.str);
			} else if (m_ReadingWhich == 5) {
				m_Pins [m_CurrentPin].m_Color = obj.str;
			} else if (m_ReadingWhich == 6) {
				//		Debug.Log ("Read conquered by: " + obj.str);
				m_Pins [m_CurrentPin].m_Conquerer = obj.str;
			}*/
			break;
		case JSONObject.Type.NUMBER:
			if (m_ReadingWhich == 1) {
				Debug.Log ("Read nr notifications: " + obj.n);
				m_NrNotifications = (int)obj.n;
			}
			m_ReadingWhich = -1;
			break;
		case JSONObject.Type.BOOL:
			//		Debug.Log("bool: " + obj.b);
			break;
		case JSONObject.Type.NULL:
			//	Debug.Log("NULL");
			break;

		}
	}

	void LoadChat() {
		string url = "https://geo-wiki.org/Application/api/game/readChat";
		string param = "";

		param += "{\"pileid\":\"" + "1001" + "\"" + "}";
	


	Debug.Log ("login param: " + param);


	WWWForm form = new WWWForm();
	form.AddField ("parameter", param);

	//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
	WWW www = new WWW(url, form);

	StartCoroutine(WaitForData(www));
	}

IEnumerator WaitForData(WWW www)
{
	yield return www;

	string[] options = { "Ok" };



	// check for errors
	if (www.error == null)
	{
		string data = www.text;
		//string[] parts = data.Split ("#", 0);
			string[] parts = data.Split(new string[] { "#" }, 0);

			string resultstr = "";
			int nrentries = (parts.Length - 1) / 4;
			for (int i = 0; i < nrentries; i++) {
				int index = i * 4; 

				string username = parts [index + 1];
				if (username.Equals ("")) {
					username = "Guest";
				}

				if (Application.systemLanguage == SystemLanguage.German) {
					username = "12/02/2017";
				} else {
					username = "12/02/2017";
				}

				//string curentry = "<color=#2194FBFF><size=36>" + username + "</size></color>\n" + parts[index+2]  + "\n\n";
				string curentry = "<color=#2194FBFF><size=22>" + username + "</size></color>\n" + parts[index+2]  + "\n\n";

				resultstr += curentry;
			}

			if (Application.systemLanguage == SystemLanguage.German) {
				resultstr = "Du hast noch keine Benachrichtigungen erhalten.";
			} else {
				resultstr = "You have not received any notifications yet.";
			}

			m_Text.GetComponentInChildren<UnityEngine.UI.Text>().text = resultstr;//data;



			TextGenerator textGen = new TextGenerator();
			TextGenerationSettings generationSettings = m_Text.GetComponentInChildren<UnityEngine.UI.Text>().GetGenerationSettings( m_Text.GetComponentInChildren<UnityEngine.UI.Text>().rectTransform.rect.size); 
			float width = textGen.GetPreferredWidth(resultstr, generationSettings);
			float height = textGen.GetPreferredHeight(resultstr, generationSettings);



			RectTransform rectTransform2 = m_Content.GetComponent<RectTransform> ();
			//rectTransform2.sizeDelta.
			//rt.sizeDelta = new Vector2 (100, 100);
			float scalex = rectTransform2.sizeDelta.x;
			float scaley = rectTransform2.sizeDelta.y;
			float heightentry = 240.0f;//250.0f;//200.0f;
			//rectTransform2.sizeDelta = new Vector2 (scalex, heightentry * nrentries + 100.0f);
			//rectTransform2.sizeDelta = new Vector2 (scalex, 2000.0f);
			rectTransform2.sizeDelta = new Vector2 (scalex, height);


		//Debug.Log ("Leaderboard result: " + data);

//			m_Text.GetComponentInChildren<UnityEngine.UI.Text> ().resizeTextForBestFit ()

	} else {
		Debug.Log("WWW Error: "+ www.error);
		Debug.Log("WWW Error 2: "+ www.text);
	}   
} 

}
