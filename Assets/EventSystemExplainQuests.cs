using UnityEngine;
using System.Collections;

public class EventSystemExplainQuests : MonoBehaviour {

	public GameObject m_Text;


	public GameObject m_Button;


	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());

		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();
		
		m_CurState = 0;
		updateStates ();
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToLandscapeLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");


		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	int m_CurState = 0;
	public void updateStates() {

		UnityEngine.UI.Text text;
		text = m_Text.GetComponent<UnityEngine.UI.Text>();
		if (Application.systemLanguage == SystemLanguage.German){
			text.text = LocalizationSupport.GetString("ExplainMakingPhoto");//"Halte die Kamera im Landschaftsmodus in die angezeigte Richtung um Fotos für die Quest zu schießen!";

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Next");//"WEITER";
		} else {
			text.text = LocalizationSupport.GetString("ExplainMakingPhoto");//"Hold your device in landscape mode and move it into the displayed direction to make a picture.";

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Next");//"NEXT";
		} 


	/*	if (m_CurState == 0) {
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
	/*	m_CurState++;
		if (m_CurState > 2) {
			m_CurState = 2;
			Application.LoadLevel ("DemoMap");
		}
		updateStates ();*/
		//Application.LoadLevel ("DemoMap");

		PlayerPrefs.SetInt ("CameraStartLastStep", 0);
		PlayerPrefs.Save ();

		Application.LoadLevel ("TestCamera");
	}
	/*public void Point1Clicked () {
		m_CurState = 0;
		updateStates ();
	}
	public void Point2Clicked () {
		m_CurState = 1;
		updateStates ();
	}
	public void Point3Clicked () {
		m_CurState = 2;
		updateStates ();
	}*/
}
