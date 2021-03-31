using UnityEngine;
using System.Collections;

public class EventSystemNotInReach : MonoBehaviour {

	public GameObject m_TextTitle;
	public GameObject m_TextReason;
	public GameObject m_Combobox;
	public GameObject m_Button;
	public GameObject m_ButtonBack;
	public GameObject m_Input;


	public GameObject m_CommentBack;
	public GameObject m_CommentText;


	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}

	public void ForceLandscapeLeft()
	{
		StartCoroutine(ForceAndFixLandscape());
	}

	IEnumerator ForceAndFixLandscape()
	{
		yield return new WaitForSeconds (0.01f);
		/*for (int i = 0; i < 3; i++) {
			if (i == 0) {
				Screen.orientation = ScreenOrientation.Portrait;
			}  else if (i == 1) {
				Screen.orientation = ScreenOrientation.LandscapeLeft;
			}  else {*/
		//	Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;
		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		//	}
		yield return new WaitForSeconds (0.5f);
		//}
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());
		ForceLandscapeLeft ();

		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

		updateStates ();
		m_TextReason.SetActive (false);
		m_Input.SetActive (false);
		m_Button.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");


	}

	int m_CurState = 0;
	public void updateStates() {

		UnityEngine.UI.Text text;
		text = m_TextTitle.GetComponent<UnityEngine.UI.Text>();
		if (Application.systemLanguage == SystemLanguage.German ){
			text.text =  LocalizationSupport.GetString("NotInReachTitle");//"Warum ist der Punkt nicht erreichbar?";

			text = m_TextReason.GetComponent<UnityEngine.UI.Text>();
			text.text =  LocalizationSupport.GetString("NotInReachReason");//"Grund:";

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text =  LocalizationSupport.GetString("Next");//"WEITER";
			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text> ().text =  LocalizationSupport.GetString("Back");//"Zurück";

			m_Combobox.GetComponentInChildren<UnityEngine.UI.Text>().text = "< " + LocalizationSupport.GetString("NotInReachSelectReason") + " >";//"< Grund auswählen >";

			UnityEngine.UI.Dropdown.OptionData list = new UnityEngine.UI.Dropdown.OptionData( "< " + LocalizationSupport.GetString("NotInReachSelectReason") + " >");
			UnityEngine.UI.Dropdown.OptionData list2 = new UnityEngine.UI.Dropdown.OptionData( LocalizationSupport.GetString("NotInReachSelectReasonPrivate"));
			UnityEngine.UI.Dropdown.OptionData list3 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonGPS"));
			UnityEngine.UI.Dropdown.OptionData list4 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonInWater"));
			UnityEngine.UI.Dropdown.OptionData list5 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonObstacle"));
			UnityEngine.UI.Dropdown.OptionData list6 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonOther"));
							
			//UnityEngine.UI.Dropdown.OptionData list7 = new UnityEngine.UI.Dropdown.OptionData("");


			UnityEngine.UI.Dropdown dropdown;
			dropdown = m_Combobox.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			dropdown.options.Add (list);
			dropdown.options.Add (list2);
			dropdown.options.Add (list3);
			dropdown.options.Add (list4);
			dropdown.options.Add (list5);
			dropdown.options.Add (list6);
		//	dropdown.options.Add (list7);

			m_CommentText.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("NotInReachExplanation");//"Wähle 'Punkt nicht erreichbar' nur aus, wenn man den Punkt wirklich nicht erreichen kann.";

		} else {
			text.text = LocalizationSupport.GetString("NotInReachTitle");//"Why is the point not reachable?";

			text = m_TextReason.GetComponent<UnityEngine.UI.Text>();
			text.text =  LocalizationSupport.GetString("NotInReachReason");//"Reason:";

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text =  LocalizationSupport.GetString("Next");//"NEXT";

			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text> ().text =  LocalizationSupport.GetString("Back");//"Back";
			m_Combobox.GetComponentInChildren<UnityEngine.UI.Text>().text =  "< " + LocalizationSupport.GetString("NotInReachSelectReason") + " >";//"< Select Reason >";

			UnityEngine.UI.Dropdown.OptionData list = new UnityEngine.UI.Dropdown.OptionData( "< " + LocalizationSupport.GetString("NotInReachSelectReason") + " >");
			UnityEngine.UI.Dropdown.OptionData list2 = new UnityEngine.UI.Dropdown.OptionData( LocalizationSupport.GetString("NotInReachSelectReasonPrivate"));
			UnityEngine.UI.Dropdown.OptionData list3 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonGPS"));
			UnityEngine.UI.Dropdown.OptionData list4 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonInWater"));
			UnityEngine.UI.Dropdown.OptionData list5 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonObstacle"));
			UnityEngine.UI.Dropdown.OptionData list6 = new UnityEngine.UI.Dropdown.OptionData(LocalizationSupport.GetString("NotInReachSelectReasonOther"));
		//	UnityEngine.UI.Dropdown.OptionData list7 = new UnityEngine.UI.Dropdown.OptionData("");


			UnityEngine.UI.Dropdown dropdown;
			dropdown = m_Combobox.GetComponent<UnityEngine.UI.Dropdown>();
			dropdown.options.Clear ();
			dropdown.options.Add (list);
			dropdown.options.Add (list2);
			dropdown.options.Add (list3);
			dropdown.options.Add (list4);
			dropdown.options.Add (list5);
			dropdown.options.Add (list6);
			//dropdown.options.Add (list7);


			m_CommentText.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("NotInReachExplanation");//"Only select 'Point not reachable' if the point is really not reachable.";
		}


		UnityEngine.UI.Dropdown dropdown2;
		dropdown2 = m_Combobox.GetComponent<UnityEngine.UI.Dropdown>();
		dropdown2.value = -1;


		/*if (m_CurState == 0) {
			m_Point1.SetActive (true);
			m_Point2.SetActive (false);
			m_Point3.SetActive (false);

			m_Logo.SetActive (true);

			m_ButtonPoint1.SetActive (false);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (true);


			m_Text.SetActive (true);
			m_Text2.SetActive (false);


			UnityEngine.UI.Text text;
			text = m_Text.GetComponent<UnityEngine.UI.Text>();
			if (Application.systemLanguage == SystemLanguage.German){
				text.text = "Unterstütze die Wissenschaft beim Landschaftsschutz mit deinem Smartphone!";

				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Weiter";
			} else {
				text.text = "Support Science with your smpartphone and help to improve the landscape converstaion!";

				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Next";
			}  
		} else if (m_CurState == 1) {
			m_Point1.SetActive (false);
			m_Point2.SetActive (true);
			m_Point3.SetActive (false);

			m_Logo.SetActive (false);



			m_Text.SetActive (false);
			m_Text2.SetActive (true);
			UnityEngine.UI.Text text;
			text = m_Text2.GetComponent<UnityEngine.UI.Text>();
			if (Application.systemLanguage == SystemLanguage.German) {
				text.text = "Um die Veränderungen von Landflächen und deren Auswirkungen auf die Umwelt besser nachverfolgen und verstehen zu können, möchten die Forscher des IIASA eine sorgfältige Bestandsaufnahme durchführen und benötigen dabei deine Hilfe!";


				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Weiter";
			} else {
				text.text = "In order to track land changes and to better evaluate the effects these changes have, the scientists of the IIASA would like to run a careful examination and need your help!";
			

				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Next";
			}  

			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (false);
			m_ButtonPoint3.SetActive (true);
		} else if (m_CurState == 2) {
			m_Point1.SetActive (false);
			m_Point2.SetActive (false);
			m_Point3.SetActive (true);

			m_Logo.SetActive (false);

			m_Text.SetActive (false);
			m_Text2.SetActive (true);

			UnityEngine.UI.Text text;
			text = m_Text2.GetComponent<UnityEngine.UI.Text>();
			if (Application.systemLanguage == SystemLanguage.German)  {
				text.text = "Mit der FotoQuest Go App kannst du mit deinem Smartphone zum Wissenschaftler werden, wertvolle Daten sammeln, einen Beitrag zum Naturschutz leisten und gleichzeitig wie bei einer Schatzsuche mit deinen gesammelten Punkten Preise gewinnen!";


				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Start!";
			} else {
				text.text = "With the FotoQuest Go App you can use your smartphone and become a hobby scientist and help us to collect valuable data to improve nature protection and also win great prizes!";
		

				m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = "Start!";
			} 

			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (false);
		}*/
	}

	public void NextClicked () {
		/*m_CurState++;
		if (m_CurState > 2) {
			m_CurState = 2;
			Application.LoadLevel ("DemoMap");
		}
		updateStates ();*/

		int m_NrQuestsDone = 0;
		if (PlayerPrefs.HasKey ("NrQuestsDone")) {
			m_NrQuestsDone = PlayerPrefs.GetInt ("NrQuestsDone");
		} else {
			m_NrQuestsDone = 0;
		}

		string skipreason = "";

		if(m_CurSelection == 1) {
			skipreason = "privateproperty";
		} else if(m_CurSelection == 2) {
			skipreason = "badgps";
		} else if(m_CurSelection == 3) {
			skipreason = "inwater";
		} else if(m_CurSelection == 4) {
			skipreason = "obstacle";
		}else if(m_CurSelection == 5) {
			skipreason = "otherreason";
		}


		PlayerPrefs.SetString("Quest_" + m_NrQuestsDone + "_NotInReachReason", skipreason);
		if (m_CurSelection == 5) {
			

			UnityEngine.UI.InputField textinput;
			textinput = m_Input.GetComponent<UnityEngine.UI.InputField>();
			string otherreason = textinput.text;

			Debug.Log("Set other reason: " + otherreason);
			PlayerPrefs.SetString("Quest_" + m_NrQuestsDone + "_NotInReachReason", otherreason);
			//PlayerPrefs.SetString("Quest_" + m_NrQuestsDone + "_NotInReachOtherReason", otherreason);
		}

		PlayerPrefs.SetInt ("CameraStartLastStep", 0);

		PlayerPrefs.Save ();


		Application.targetFrameRate = 30;
		Application.LoadLevel ("DynamicQuestionsFRA");
		//Application.LoadLevel ("TestCamera");
	}

	public void BackClicked() {
		Application.LoadLevel ("DemoMap");
	}

	int m_CurSelection;
	public void OnSelectedRange( int value) {


		UnityEngine.UI.Dropdown dropdown;
		dropdown = m_Combobox.GetComponent<UnityEngine.UI.Dropdown>();

		Debug.Log ("OnSelected: " + value + "," + dropdown.value);

		m_CurSelection = dropdown.value;

		if (m_CurSelection == 5) {
			m_TextReason.SetActive (true);
			m_Input.SetActive (true);

			m_CommentText.SetActive (false);
			m_CommentBack.SetActive (false);
		} else {
			m_TextReason.SetActive (false);
			m_Input.SetActive (false);

			m_CommentText.SetActive (true);
			m_CommentBack.SetActive (true);
		}

		if (m_CurSelection != 0) {
			m_Button.SetActive (true);
		} else {
			m_Button.SetActive (false);
		}
	}
}
