using UnityEngine;
using System.Collections;
//using Signalphire;
using UI.Pagination;

public class EventSystemIntroduction : MonoBehaviour {

	public GameObject m_Text;
	public GameObject m_Text2;
	public GameObject m_Logo;


	public GameObject m_Page1Text;
	public GameObject m_PrizeText;
	public GameObject m_Page3Text;
	public GameObject m_Page3Title;
	public GameObject m_PageText3;

	public GameObject m_Button;

	public GameObject m_ButtonPoint1;
	public GameObject m_ButtonPoint2;
	public GameObject m_ButtonPoint3;

	public GameObject m_Point1;
	public GameObject m_Point2;
	public GameObject m_Point3;

	public GameObject m_AppleDisclaimer;
	public GameObject m_ImageDisclaimer;
	public GameObject m_ImageNoDisclaimer;

	public GameObject m_BackgroundImage;

	public UI.Pagination.PagedRect_ScrollRect m_ScrollRect;
	public GameObject m_Page;


	IEnumerator changeFramerate() {
		yield return new WaitForSeconds(1);
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(changeFramerate());


		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;


		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

		m_CurState = 0;
		updateStates ();

		bool bApple = false;
		if (!bApple) {
			m_AppleDisclaimer.SetActive (false);
			m_ImageDisclaimer.SetActive (false);
			m_ImageNoDisclaimer.SetActive (true);
		} else {
			m_AppleDisclaimer.SetActive (true);
			m_ImageDisclaimer.SetActive (true);
			m_ImageNoDisclaimer.SetActive (false);
		}

		UnityEngine.UI.Text text;
		if (Application.systemLanguage == SystemLanguage.German || true){

			text = m_Page1Text.GetComponent<UnityEngine.UI.Text>();
		//	text.text = "Versuche Zielpunkte zu erreichen und hilf so beim Umweltschutz in Österreich!";
			text.text = LocalizationSupport.GetString("IntroText");//"Join the green side!\nHelp #FAOUN in the monitoring process of the world’s forests.";

			text = m_Text.GetComponent<UnityEngine.UI.Text>();
			//	text.text = "Versuche Zielpunkte zu erreichen und hilf so beim Umweltschutz in Österreich!";
			text.text = LocalizationSupport.GetString("IntroText");//"Join the green side!\nHelp #FAOUN in the monitoring process of the world’s forests.";


			text = m_PrizeText.GetComponent<UnityEngine.UI.Text>();
			text.text = "Du erhälst für jeden besuchten Punkt 1 Euro!";

			/*text = m_Page2Text.GetComponent<UnityEngine.UI.Text>();
			text.text = "Jeden Tag werden in Österreich 150000 m² Land in Geschäfts-, Verkehrs-, Freizeit- und Wohnflächen umgewandelt. Dabei müssen fruchtbare Böden, Artenvielfalt und natürliche CO2-Speicher Asphalt und Beton weichen. Dies führt unter anderem dazu, dass das Risiko für Überschwemmungen steigt, landwirtschaftliche Flächen unproduktiv werden, Hitzewellen in Städten steigen und zur Erderwärmung beitragen.\n\n" +
			"Mit deiner Hilfe kann FotoQuest Go die Folgen der Veränderung unserer Landschaft aufzeichnen und dabei helfen, Österreichs Natur für zukünftige Generationen zu erhalten.\n\n" +
			"Wir haben 9000 Punkte auf ganz Österreich verteilt. Schaue auf die Karte, finde einen Punkt in deiner Nähe und folge dann den Anweisungen um eine Quest durchzufüren. Dabei musst du Bilder von der Landschaft machen und ein paar kurze Fragen beantworten.";
*/
			/*RectTransform rectTransform2 = m_Page2Text.GetComponent<RectTransform> ();
			float scalex = rectTransform2.sizeDelta.x;
			float heightentry = 1000.0f;
			rectTransform2.sizeDelta = new Vector2 (scalex, heightentry);


			float posx = rectTransform2.position.x;
			float posy = rectTransform2.position.y;
			float posz = rectTransform2.position.z;
			rectTransform2.position = new Vector3 (posx, -287.0f, posz);*/


		//	text = m_Page2Title.GetComponent<UnityEngine.UI.Text>();
	//		text.text = "Warum?";

			text = m_Page3Title.GetComponent<UnityEngine.UI.Text>();
			text.text = "Warum?";

			text = m_Page3Text.GetComponent<UnityEngine.UI.Text>();
			//text.text = "Alle gesammelten Daten werden für alle frei verfügbar sein und einen wichtigen Beitrag zum Naturschutz leisten!";
		//	text.text = "Für jeden besuchten Punkt verdienst du 1€!\n\nDas Geld wird nach dem Ende der Kampagne (28. Dezember 2017) auf dein PayPal Konto überwiesen.";
		//	text.text = "Once you complete your quest, scientists at IIASA will check the quality of your results within 24 hours. If your contribution passes the quality check you will earn 1 EUR.\n\nAt the end of the campaign (December 2017), your total earnings will be transferred to your PayPal account.";
			text.text = LocalizationSupport.GetString("IntroText2");//"FRA Quest is a crowdsourcing tool developed to gather landscape information. The app will guide you to a series of selected locations, collect cardinal pictures and get information about the land cover characteristics. The data collected will be stored in your phone and will be uploaded to a public database once you are connected again.";

			text = m_AppleDisclaimer.GetComponent<UnityEngine.UI.Text>();
			text.text = "(Hinweis: Apple ist nicht Sponsor von FotoQuest Go)";

			text = m_PageText3.GetComponent<UnityEngine.UI.Text>();
			text.text = LocalizationSupport.GetString("IntroText3");

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text =  LocalizationSupport.GetString("Next");//"WEITER";
		} else {

			text = m_Page1Text.GetComponent<UnityEngine.UI.Text>();
//			text.text = "Try to reach locations to help landscape conservation in Austria!";
			text.text = LocalizationSupport.GetString("IntroText");//"Join the green side!\nHelp #FAOUN in the monitoring process of the world’s forests.";


			text = m_PrizeText.GetComponent<UnityEngine.UI.Text>();
			//text.text = "And earn for every visited location 1€!";
			text.text = "You can earn 1 EUR for each point you visit!";

			//text = m_Page2Text.GetComponent<UnityEngine.UI.Text>();
		//	text.text = "In order to track land changes and to better evaluate the effects these changes have, the scientists at IIASA would like to run a careful examination and need your help!";
		/*	text.text = "Every day around 100.000 m² land are soil sealed in Austria. In order to track these land changes and to better evaluate the effects these changes have more data is urgently needed.\n\n" +
				"Therefore the scientists at IIASA would like to run a careful examination and need your help to visit around 8000 points in Austria which are located on a regular 2 km grid!\n\n" +
				"All data collected (after having gone through an anonymization process by removing all personal information like username or e-mail) will be made completely free and thus can serve as a very valuable source for science!";
*/
		/*	text.text = "Every day around 150,000 m² of soil are being turned into roads, businesses, homes and recreational areas in Austria, which leads to soil degradation and an increasing risk of flooding, water scarcity, unproductive agricultural land and heat waves in cities, contributing to global warming.\n\n" +
				"With your help, FotoQuest Go can track the effect of these changes in our landscape and help to conserve Austria’s nature for future generations.\n\n" +
				"We have placed around 9,000 points at a range of locations across Austria. Using the map, find a point near you and then follow the instructions to complete each quest. A quest requires you to take photographs of the landscape and answer a few short questions.";

			//, the scientists at IIASA would like to run a careful examination and need your help! In order to track land changes and to better evaluate the effects these changes have, the scientists at IIASA would like to run a careful examination and need your help!";


			text = m_Page2Title.GetComponent<UnityEngine.UI.Text>();
			text.text = "Why help?";

			*/
			text = m_Page3Title.GetComponent<UnityEngine.UI.Text>();
			text.text = "Why help?";


			text = m_Page3Text.GetComponent<UnityEngine.UI.Text>();
			//text.text = "All data collected will be made completely free and will be very valuable to improve nature protection!";
			//text.text = "You will earn 1€ for every visited location!\n\nThe money will be transferred to your PayPal account after the campaign has finished (December 2017) and has successfully gone through a quality control.\n\nAny attempt to cheat or hack will result in a ban and no money will be transferred.";
			//text.text = "You will earn 1€ for every visited location!\n\nThe money will be transferred to your PayPal account after the campaign has finished (December 2017).";
			//text.text = "Once you complete your quest, scientists at IIASA will check the quality of your results within 24 hours. If your contribution passes the quality check, the point you visited will be removed from the map, and you will earn 1 EUR. At the end of the campaign (December 2017), your total earnings will be transferred to your PayPal account. PLEASE MAKE SURE TO PROVIDE THE CORRECT PAYPAL ADDRESS.";
			//text.text = "Once you complete your quest, scientists at IIASA will check the quality of your results within 24 hours. If your contribution passes the quality check you will earn 1 EUR.\n\nAt the end of the campaign (December 2017), your total earnings will be transferred to your PayPal account.";
			text.text = LocalizationSupport.GetString("IntroText2");//"FRA Quest is a crowdsourcing tool developed to gather landscape information. The app will guide you to a series of selected locations, collect cardinal pictures and get information about the land cover characteristics. The data collected will be stored in your phone and will be uploaded to a public database once you are connected again.";
			//

			//Any attempt to cheat or hack will result in a ban and no money will be transferred.

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Next");//"NEXT";
		}


#if UNITY_ANDROID
		/*	NativeEssentials.Instance.Initialize();
			PermissionsHelper.StatusResponse sr;
			PermissionsHelper.StatusResponse sr2;
			PermissionsHelper.StatusResponse sr3;// = PermissionsHelper.StatusResponse.;//NativeEssentials.Instance.GetAndroidPermissionStatus(PermissionsHelper.Permissions.CAMERA);
			sr =NativeEssentials.Instance.GetAndroidPermissionStatus(PermissionsHelper.Permissions.ACCESS_FINE_LOCATION);
			sr2 =NativeEssentials.Instance.GetAndroidPermissionStatus(PermissionsHelper.Permissions.ACCESS_COARSE_LOCATION);
			sr3 =NativeEssentials.Instance.GetAndroidPermissionStatus(PermissionsHelper.Permissions.CAMERA);
			if (sr == PermissionsHelper.StatusResponse.PERMISSION_RESPONSE_GRANTED && sr2 == PermissionsHelper.StatusResponse.PERMISSION_RESPONSE_GRANTED) {

			} else {
				if (sr == PermissionsHelper.StatusResponse.PERMISSION_RESPONSE_GRANTED && sr2 == PermissionsHelper.StatusResponse.PERMISSION_RESPONSE_GRANTED) {
				} else {
					NativeEssentials.Instance.RequestAndroidPermissions(new string[] {PermissionsHelper.Permissions.ACCESS_FINE_LOCATION, PermissionsHelper.Permissions.ACCESS_COARSE_LOCATION, PermissionsHelper.Permissions.CAMERA
					});
				}
			}*/
#endif


	/*	Input.compass.enabled = true;
		Input.compensateSensors = true;

		Input.location.Start();*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			int instructionshown = PlayerPrefs.GetInt ("IntroductionShown");
			if (instructionshown != 0) {
				Application.LoadLevel ("DemoMap");
			}
		}


		//========================
		// Move background image
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		//float procpage = rect.ScrollRect.GetOffset () / rect.ScrollRect.GetPageSize ();//rect.ScrollRect.GetTotalSize ();
		float procpage = rect.ScrollRect.GetOffset () / rect.ScrollRect.GetTotalSize ();
		Debug.Log("proc: " + procpage + " Offset: " + rect.ScrollRect.GetOffset () + " total: " + rect.ScrollRect.GetTotalSize ());
		if (procpage < 0.0f)
			procpage = 0.0f;
		RectTransform rt;
		rt = m_BackgroundImage.GetComponent<RectTransform> ();
		rt.position = new Vector3 (Screen.width * -procpage * 1.0f/*2.0f*/, Screen.height*0.5f, 0);
		//rt.position = new Vector3 (0.0f, Screen.height*0.5f, 0);
		//rt.sizeDelta = new Vector2 (Screen.width * 1.0f, Screen.width * menuheight);


		//===========================
		// Force app to portrait mode

		Screen.orientation = ScreenOrientation.Portrait;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToLandscapeLeft = false;
	}

	int m_CurState = 0;
	public void updateStates() {
	//	m_Logo.SetActive (false);
		//m_Text.SetActive (false);
		m_Text2.SetActive (false);


		if (m_CurState == 0) {
			m_Point1.SetActive (true);
			m_Point2.SetActive (false);
			m_Point3.SetActive (false);

			m_ButtonPoint1.SetActive (false);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (true);


		} else if (m_CurState == 1) {
			m_Point1.SetActive (false);
			m_Point2.SetActive (true);
			m_Point3.SetActive (false);


			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (false);
			m_ButtonPoint3.SetActive (true);
		} else if (m_CurState == 2) {
			m_Point1.SetActive (false);
			m_Point2.SetActive (false);
			m_Point3.SetActive (true);


			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (false);
		} else {
			m_Point1.SetActive (false);
			m_Point2.SetActive (false);
			m_Point3.SetActive (false);


			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (true);
		} 
	}

	public void NextClicked () {

		/*m_CurState++;
		if (m_CurState > 2) {
			m_CurState = 2;
			PlayerPrefs.SetInt ("IntroductionShown", 1);
			PlayerPrefs.Save ();
			Application.LoadLevel ("DemoMap");
		}
		updateStates ();*/
		m_CurState++;
		if (m_CurState >= 3) {
			m_CurState = 2;
			/*m_CurState = 2;
			*/


			int instructionshown = PlayerPrefs.GetInt("InstructionShown");

			PlayerPrefs.SetInt ("IntroductionShown", 1);
			PlayerPrefs.Save ();

			if (instructionshown == 0) {
				Application.LoadLevel ("Campaigns");
			} else {
				Application.LoadLevel ("DemoMap");
			}
			/**/
		} else {
			UI.Pagination.PagedRect rect;
			rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
			rect.SetCurrentPage (m_CurState+1, false);
		}
		updateButtonText ();
	}

	void updateButtonText()
	{
		if (m_CurState < 2) {
			if (Application.systemLanguage == SystemLanguage.German) {
				m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Next");//"WEITER";
			} else {
				m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Next");//"NEXT";
			}
		} else {
			if (Application.systemLanguage == SystemLanguage.German) {
				m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LetsGo");//"LOS GEHTS!";
			} else {
				m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LetsGo");//"LET'S GO!";
			}
		}
	}
	public void Point1Clicked () {
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		rect.SetCurrentPage (1, false);
		m_CurState = 0;
		updateButtonText ();
	}
	public void Point2Clicked () {
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		rect.SetCurrentPage (2, false);
		m_CurState = 1;
		updateButtonText ();
	}
	public void Point3Clicked () {
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		rect.SetCurrentPage (3, false);
		m_CurState = 2;
		updateButtonText ();
	}
	public void Point4Clicked () {
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		rect.SetCurrentPage (4, false);
		m_CurState = 3;
		updateButtonText ();
	}
	public void Point5Clicked () {
		UI.Pagination.PagedRect rect;
		rect = m_Page.GetComponent<UI.Pagination.PagedRect>();
		rect.SetCurrentPage (5, false);
		m_CurState = 4;
		updateButtonText ();
	}

	public void OnPageChanged (Page newpage, Page lastpage) {
		Debug.Log ("> OnPageChanged: " + newpage.PageNumber);

		if (newpage.PageNumber == 1) {
			m_ButtonPoint1.SetActive (false);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (true);

			m_Point1.SetActive (true);
			m_Point2.SetActive (false);
			m_Point3.SetActive (false);
			m_CurState = 0;
		} else if (newpage.PageNumber == 2) {
			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (false);
			m_ButtonPoint3.SetActive (true);

			m_Point1.SetActive (false);
			m_Point2.SetActive (true);
			m_Point3.SetActive (false);
			m_CurState = 1;
		} else if (newpage.PageNumber == 3) {
			m_ButtonPoint1.SetActive (true);
			m_ButtonPoint2.SetActive (true);
			m_ButtonPoint3.SetActive (false);

			m_Point1.SetActive (false);
			m_Point2.SetActive (false);
			m_Point3.SetActive (true);
			m_CurState = 2;
		} 

		updateButtonText ();
	}
}
