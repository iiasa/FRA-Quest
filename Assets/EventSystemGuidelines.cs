using UnityEngine;
using System.Collections;

public class EventSystemGuidelines : MonoBehaviour {

	public GameObject m_TextTitle;/*
	public GameObject m_TextGuide;
	public GameObject m_TextGuide2;*/
	public GameObject m_TextGuideAT;
	public GameObject m_TextGuideEN;
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

		updateStates ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel ("DemoMap");
	}

	public void updateStates() {
		
			UnityEngine.UI.Text text;
		text = m_TextTitle.GetComponent<UnityEngine.UI.Text>();


		//UnityEngine.UI.Text text2;
		//text2 = m_TextGuide.GetComponent<UnityEngine.UI.Text>();
	//	UnityEngine.UI.Text text3;
//		text3 = m_TextGuide2.GetComponent<UnityEngine.UI.Text>();


		if (Application.systemLanguage == SystemLanguage.German ) {
			text.text = LocalizationSupport.GetString("GuideTitle");//"Richtlinien";

			m_TextGuideAT.SetActive (true);
			m_TextGuideEN.SetActive (false);
		//	text2.text = "- Verwende existierende Straßen und Pfade\n\n- Betrete kein privates Grundstück, Naturschutzgebiete, Sperrgebiete etc.\n\n- Betrete keine Felder in denen gerade Pflanzen wachsen\n\n- Betrete kein privates Grundstück wenn es eingezäunt ist oder wenn sichtbar ist dass es sich um ein industrielles oder sonst nicht öffentlich zugängliches Gelände handelt.\n\n- Betrete kein möglicherweise gefährliches Gebiet (Wasser, eingezäunte Wiese, Jagdgebiete, militärische Gebiete, steile Hänge, Gräben, Straßen etc.)";

			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Ok");//"OK";
			} else {

			m_TextGuideAT.SetActive (false);
			m_TextGuideEN.SetActive (true);
			text.text = LocalizationSupport.GetString("GuideTitle");//"Guildelines for getting to point";
			m_Button.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Ok");//"OK";

		//	text2.text = "- Use existing roads and pathways\n\n- Always respect private property, forbidden access or natural protection areas, etc.\n\n- Do not enter fields with crops growing in them\n\n- Do not enter private grounds if fenced or have signs of industrial or other non-publically available business or commercial uses, nature reserve areas, etc.\n\n- Do not cross/enter potentially dangerous areas (water, fenced pastures, hunting grounds, military areas, steep slopes, rock outcrops, ditches, highways, etc.)";
			}

	}

	public void NextClicked () {
		Application.LoadLevel ("DemoMap");
	}
}
