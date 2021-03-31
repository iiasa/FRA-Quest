using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;

public class EventSystemChat : MonoBehaviour {
	


	public GameObject m_Button;
	public GameObject m_ButtonSend;
	public GameObject m_Placeholder;
	public GameObject m_SenderText;


	public GameObject m_Content;


	public GameObject m_Text;


	private MessageBox messageBox;
	private MessageBox verticalMessageBox;

	ArrayList m_AddedTexts;

	// Use this for initialization
	void Start () {

		messageBox = UIUtility.Find<MessageBox> ("MessageBox");

		updateStates ();
		LoadChat ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");
	}


	int m_CurState = 0;
	public void updateStates() {
		
		if (Application.systemLanguage == SystemLanguage.German) {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Schließen";
			m_ButtonSend.GetComponentInChildren<UnityEngine.UI.Text>().text = "Senden";
			m_Placeholder.GetComponentInChildren<UnityEngine.UI.Text>().text = "Text eingeben...";

		} else {
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Close";
			m_ButtonSend.GetComponentInChildren<UnityEngine.UI.Text>().text = "Send";
			m_Placeholder.GetComponentInChildren<UnityEngine.UI.Text>().text = "Enter text...";
		}


		m_Text.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
	}

	public void NextClicked () {
		Application.LoadLevel ("DemoMap");
	//	Debug.Log ("OnSelected: " );
	}

	public void SendClicked() {

		UnityEngine.UI.InputField inputfield = m_SenderText.GetComponent<UnityEngine.UI.InputField> ();
		string texttosend = inputfield.text;

		string[] options = { "Ok" };
		if (texttosend.Equals ("")) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", "Kein Text angegeben.", options);
			} else {
				messageBox.Show ("", "No text entered.", options);
			}
			return;
		}

		inputfield.text = "";

		if(PlayerPrefs.HasKey("PlayerId") == false) {
			if (Application.systemLanguage == SystemLanguage.German) {
				messageBox.Show ("", "Bitte logge dich ein oder registriere dich um eine Chatnachricht zu senden.", options);
			} else {
				messageBox.Show ("", "Please login or register to send a chat message.", options);
			}
			return;
		}
		string playerid = PlayerPrefs.GetString("PlayerId");

		string url = "https://geo-wiki.org/Application/api/game/writeChat";
		string param = "";

		param += "{\"pileid\":\"" + 1001 + "\",\"userid\":\"" + playerid + "\",\"text\":\"" + texttosend + "\"";
		param += "}";





		Debug.Log ("login param: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);

		//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForDataSent(www));



	}


	IEnumerator WaitForDataSent(WWW www)
	{
		yield return www;

		string[] options = { "Ok" };

		// check for errors
		if (www.error == null)
		{
			LoadChat ();

		} else {
			
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
				string curentry = "<color=#2194FBFF><size=36>" + username + "</size></color>\n" + parts[index+2]  + "\n\n";

				resultstr += curentry;
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
