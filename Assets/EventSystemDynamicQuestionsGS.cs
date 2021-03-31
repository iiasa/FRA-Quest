using System;
using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class EventSystemDynamicQuestionsGS : MonoBehaviour {
	public GameObject m_Button;

	private MessageBox messageBox;
	private MessageBox verticalMessageBox;


	public GameObject m_ImageUploading;
	public GameObject m_TextUploading;


	public GameObject m_TextQuestionNr;
	public GameObject m_TextQuestion;
	public GameObject m_BtnStar1;
	public GameObject m_BtnStar2;
	public GameObject m_BtnStar3;
	public GameObject m_BtnStar4;
	public GameObject m_BtnStar5;
	public GameObject m_BtnStar1A;
	public GameObject m_BtnStar2A;
	public GameObject m_BtnStar3A;
	public GameObject m_BtnStar4A;
	public GameObject m_BtnStar5A;
	public GameObject m_BtnSound1;
	public GameObject m_BtnSound2;
	public GameObject m_BtnSound3;
	public GameObject m_BtnSound4;
	public GameObject m_BtnSound5;
	public GameObject m_BtnSound1A;
	public GameObject m_BtnSound2A;
	public GameObject m_BtnSound3A;
	public GameObject m_BtnSound4A;
	public GameObject m_BtnSound5A;
	public GameObject m_InputComment;

	public GameObject m_TextQuestionStehen;
	public GameObject m_TextQuestionSitzen;
	public GameObject m_TextQuestionLiegen;
	public GameObject m_TextQuestionSpielen;
	public GameObject m_TextQuestionGehen;
	public GameObject m_TextQuestionSport;
	public GameObject m_TextQuestionSonstiges;


	public GameObject m_ToggleStehen;
	public GameObject m_ToggleSitzen;
	public GameObject m_ToggleLiegen;
	public GameObject m_ToggleSpielen;
	public GameObject m_ToggleGehen;
	public GameObject m_ToggleSport;
	public GameObject m_ToggleSonstiges;

	public GameObject m_ToggleStehen1;
	public GameObject m_ToggleStehen2;
	public GameObject m_ToggleStehen3;
	public GameObject m_ToggleStehen4;
	public GameObject m_ToggleStehen5;
	public GameObject m_ToggleStehen6;
	public GameObject m_ToggleSitzen1;
	public GameObject m_ToggleSitzen2;
	public GameObject m_ToggleSitzen3;
	public GameObject m_ToggleSitzen4;
	public GameObject m_ToggleSitzen5;
	public GameObject m_ToggleSitzen6;
	public GameObject m_ToggleSitzen7;
	public GameObject m_ToggleSitzen8;
	public GameObject m_ToggleLiegen1;
	public GameObject m_ToggleLiegen2;
	public GameObject m_ToggleLiegen3;
	public GameObject m_ToggleLiegen4;
	public GameObject m_ToggleLiegen5;
	public GameObject m_ToggleSpielen1;
	public GameObject m_ToggleSpielen2;
	public GameObject m_ToggleSpielen3;
	public GameObject m_ToggleSpielen4;
	public GameObject m_ToggleSpielen5;
	public GameObject m_ToggleSpielen6;
	public GameObject m_ToggleSpielen7;
	public GameObject m_ToggleSpielen8;
	public GameObject m_ToggleSpielen9;
	public GameObject m_ToggleGehen1;
	public GameObject m_ToggleGehen2;
	public GameObject m_ToggleGehen3;
	public GameObject m_ToggleSport1;
	public GameObject m_ToggleSport2;
	public GameObject m_ToggleSport3;
	public GameObject m_ToggleSport4;
	public GameObject m_ToggleSport5;
	public GameObject m_ToggleSport6;
	public GameObject m_ToggleSonstiges1;
	public GameObject m_ToggleSonstiges2;
	public GameObject m_ToggleSonstiges3;
	public GameObject m_ToggleSonstiges4;
	public GameObject m_ToggleSonstiges5;
	public GameObject m_ToggleSonstiges6;
	public GameObject m_ToggleSonstiges7;
	public GameObject m_ToggleSonstiges8;
	public GameObject m_ToggleSonstiges9;

	public GameObject m_TextCheckboxes;
	public GameObject m_Checkbox1;
	public GameObject m_Checkbox2;
	public GameObject m_Checkbox3;
	public GameObject m_Checkbox4;
	public GameObject m_Checkbox5;
	public GameObject m_Checkbox6;
	public GameObject m_Checkbox7;
	public GameObject m_Radio1;
	public GameObject m_Radio2;
	public GameObject m_Radio3;
	public GameObject m_Radio4;
	public GameObject m_Radio5;
	public GameObject m_Radio6;
	public GameObject m_Radio7;
	public GameObject m_TextCheckboxOther;
	public GameObject m_InputCheckboxOther;
	public GameObject m_TextOtherMedium;
	public GameObject m_InputOtherMedium;
	public GameObject m_TextOtherTop;
	public GameObject m_InputOtherTop;
	public GameObject m_InputNumber;
	public GameObject m_InputNumberPlaceholder;
	public GameObject m_ButtonBack;


	public GameObject m_Text1_1;
	public GameObject m_Text1_2;
	public GameObject m_Text1_3;
	public GameObject m_Text1_4;
	public GameObject m_Text1_5;
	public GameObject m_Text1_6;
	public GameObject m_Text1_7;
	public GameObject m_Slider1;
	public GameObject m_Slider2;
	public GameObject m_Slider3;
	public GameObject m_Slider4;
	public GameObject m_Slider_1_5;
	public GameObject m_Slider_1_6;


	public GameObject m_Text2;
	public GameObject m_Slider5;
	public GameObject m_ImageButterfly;


	public GameObject m_Text3;
	public GameObject m_Slider3_1;

	public GameObject m_Text3_1;
	public GameObject m_Text3_2;
	public GameObject m_Text3_3;
	public GameObject m_Text3_4;
	public GameObject m_Text3_5;
	public GameObject m_Text3_6;
	public GameObject m_Text3_7;
	public GameObject m_Text3_8;
	public GameObject m_Slider6;
	public GameObject m_Slider7;
	public GameObject m_Slider8;
	public GameObject m_Slider9;
	public GameObject m_Slider3_6;
	public GameObject m_Slider3_7;
	public GameObject m_Slider3_8;


	public GameObject m_Text4_1;
	public GameObject m_Text4_2;
	public GameObject m_Text4_3;
	public GameObject m_Text4_4;
	public GameObject m_Slider10;
	public GameObject m_Slider11;
	public GameObject m_Slider12;
	public GameObject m_Image4_1;
	public GameObject m_Image4_2;
	public GameObject m_Image4_3;


	public GameObject m_SliderLow5;
	public GameObject m_SliderHigh5;
	public GameObject m_SliderLow10;
	public GameObject m_SliderHigh10;
	public GameObject m_SliderLow11;
	public GameObject m_SliderHigh11;
	public GameObject m_SliderLow12;
	public GameObject m_SliderHigh12;

	public GameObject m_SliderNotAtAll_1;
	public GameObject m_SliderNotAtAll_2;
	public GameObject m_SliderNotAtAll_3;
	public GameObject m_SliderNotAtAll_4;
	public GameObject m_SliderNotAtAll_5;
	public GameObject m_SliderNotAtAll_6;
	public GameObject m_SliderNotSoMuch_1;
	public GameObject m_SliderNotSoMuch_2;
	public GameObject m_SliderNotSoMuch_3;
	public GameObject m_SliderNotSoMuch_4;
	public GameObject m_SliderNotSoMuch_5;
	public GameObject m_SliderNotSoMuch_6;
	public GameObject m_SliderSomewhat_1;
	public GameObject m_SliderSomewhat_2;
	public GameObject m_SliderSomewhat_3;
	public GameObject m_SliderSomewhat_4;
	public GameObject m_SliderSomewhat_5;
	public GameObject m_SliderSomewhat_6;
	public GameObject m_SliderVery_1;
	public GameObject m_SliderVery_2;
	public GameObject m_SliderVery_3;
	public GameObject m_SliderVery_4;
	public GameObject m_SliderVery_5;
	public GameObject m_SliderVery_6;
	public GameObject m_SliderExtremely_1;
	public GameObject m_SliderExtremely_2;
	public GameObject m_SliderExtremely_3;
	public GameObject m_SliderExtremely_4;
	public GameObject m_SliderExtremely_5;
	public GameObject m_SliderExtremely_6;


	public GameObject m_Slider_1_1;
	public GameObject m_Slider_2_1;
	public GameObject m_Slider_3_1;
	public GameObject m_Slider_4_1;
	public GameObject m_Slider_5_1;
	public GameObject m_Slider_1_2;
	public GameObject m_Slider_2_2;
	public GameObject m_Slider_3_2;
	public GameObject m_Slider_4_2;
	public GameObject m_Slider_5_2;
	public GameObject m_Slider_1_3;
	public GameObject m_Slider_2_3;
	public GameObject m_Slider_3_3;
	public GameObject m_Slider_4_3;
	public GameObject m_Slider_5_3;
	public GameObject m_Slider_1_4;
	public GameObject m_Slider_2_4;
	public GameObject m_Slider_3_4;
	public GameObject m_Slider_4_4;
	public GameObject m_Slider_5_4;
	public GameObject m_Slider_1_5_1;
	public GameObject m_Slider_2_5;
	public GameObject m_Slider_3_5;
	public GameObject m_Slider_4_5;
	public GameObject m_Slider_5_5;
	public GameObject m_Slider_1_6_1;
	public GameObject m_Slider_2_6;
	public GameObject m_Slider_3_6;
	public GameObject m_Slider_4_6;
	public GameObject m_Slider_5_6;
	public GameObject m_Slider_1_7;
	public GameObject m_Slider_2_7;
	public GameObject m_Slider_3_7;
	public GameObject m_Slider_4_7;
	public GameObject m_Slider_5_7;


	public class SurveyAnswer
	{
		public int m_Id;
		public int m_Type;
		public int m_Answer;
		public bool m_bCheck1;
		public bool m_bCheck2;
		public bool m_bCheck3;
		public bool m_bCheck4;
		public bool m_bCheck5;
		public bool m_bCheck6;
		public bool m_bCheck7;
		public string m_Text;
		public int m_NrAnswersPossible;

		public SurveyAnswer()
		{
			reset();
		}

		public void reset()
		{
			m_Id = 0;
			m_Type = 0;
			m_Answer = 0;
			m_bCheck1 = false;
			m_bCheck2 = false;
			m_bCheck3 = false;
			m_bCheck4 = false;
			m_bCheck5 = false;
			m_bCheck6 = false;
			m_bCheck7 = false;
			m_Text = "";
			m_NrAnswersPossible = 0;
		}
	}

	public SurveyAnswer[] m_Answers;

	int m_Stars1;
	int m_Stars2;
	int m_Stars3;
	int m_Stars4;
	int m_Stars5;
	int m_Stars6;
	int m_Stars7;
	int m_Stars8;

	int m_CurStars;
	string m_StrText;

	public GameObject m_FinishedText;
	public GameObject m_BtnFinished;


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

		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

		ForceLandscapeLeft ();

		m_ImageUploading.SetActive (false);
		m_TextUploading.SetActive (false);
		m_InputComment.SetActive (false);
		m_CurStars = -1;
		m_CurQuestion = 0;// 0;//0;//3;//0;
		m_NrQuestions = 38;

		m_FinishedText.SetActive (false);
		m_BtnFinished.SetActive (false);

		m_Answers = new SurveyAnswer[40];
		for (int i = 0; i < 40; i++) {
			m_Answers[i] = new SurveyAnswer();
		}

		UnityEngine.UI.Dropdown dropdown;
		UnityEngine.UI.Dropdown.OptionData list;

		if (Application.systemLanguage == SystemLanguage.German || true) {
			m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("IsUploading");//"Wird hochgeladen...";
			m_FinishedText.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
			m_BtnFinished.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("CloseQuestions");//"Schließen";





			m_Text1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_1");
			m_Text1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_2");
			m_Text1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_3");
			m_Text1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_4");
			m_Text1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_5");
			m_Text1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_6");
			m_Text1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_1_7");


			m_Text2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_2");


			m_Text3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3");

			m_Text3_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_1");
			m_Text3_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_2");
			m_Text3_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_3");
			m_Text3_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_4");
			m_Text3_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_5");
			m_Text3_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_6");
			m_Text3_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_7");
			m_Text3_8.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_3_8");


			m_Text4_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_4_1");
			m_Text4_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_4_2");
			m_Text4_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_4_3");
			m_Text4_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Question_4_4");


			//m_SliderLow5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Low");
			//m_SliderHigh5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("High");
			m_SliderLow10.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Low");
			m_SliderHigh10.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("High");
			m_SliderLow11.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Low");
			m_SliderHigh11.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("High");
			m_SliderLow12.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Low");
			m_SliderHigh12.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("High");

		//	m_SliderNotAtAll_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
		//	m_SliderNotAtAll_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
		//	m_SliderNotAtAll_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			//m_SliderNotAtAll_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_SliderNotAtAll_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_SliderNotAtAll_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
		//	m_SliderNotSoMuch_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		//	m_SliderNotSoMuch_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		//	m_SliderNotSoMuch_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		//	m_SliderNotSoMuch_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_SliderNotSoMuch_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_SliderNotSoMuch_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		//	m_SliderSomewhat_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
		//	m_SliderSomewhat_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
		//	m_SliderSomewhat_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			//m_SliderSomewhat_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_SliderSomewhat_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_SliderSomewhat_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
		//	m_SliderVery_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
		//	m_SliderVery_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
		//	m_SliderVery_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
		//	m_SliderVery_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_SliderVery_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_SliderVery_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			//m_SliderExtremely_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			/*m_SliderExtremely_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_SliderExtremely_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_SliderExtremely_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");*/
			m_SliderExtremely_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_SliderExtremely_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");

			m_Slider_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_4.GetComponentInChildren<UnityEngine.UI.Text> ().text =  LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_5_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_6_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
			m_Slider_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
			m_Slider_2_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
			m_Slider_3_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
			m_Slider_4_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
			m_Slider_5_7.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
		} else {
			m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("IsUploading");//"Uploading...";
			m_FinishedText.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
			m_BtnFinished.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("CloseQuestions");//"Close";



		}

		m_bIgnoreRatioButtons = false;


		string startquestionstime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("CurQuestStartQuestionsTime", startquestionstime);
		PlayerPrefs.Save ();

		loadQuestions ();
		//m_NrQuestions = m_Questions.questions.Length;
		m_NrQuestions = 9;//8;
		updateStates ();

		messageBox = UIUtility.Find<MessageBox> ("MessageBox");
	}

	[Serializable]
	public class SurveyQuestionAnswer
	{
		public string text;
		public int jumpto;
	}
	[Serializable]
	public class SurveyQuestion
	{
		public int id;
		public int type;
		public string text;
		public string textvalue;
		public SurveyQuestionAnswer[] answers;
		public int other;
		public int jumptoprev;
		public int jumptonext;
	}
	[Serializable]
	public class SurveyQuestions
	{
		public string name;
		public int id;
		public SurveyQuestion[] questions;
	}

	SurveyQuestions m_Questions;

	public static SurveyQuestions createQuestionsFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<SurveyQuestions>(jsonString);
	}
	public string m_StrQuestions;
	void loadQuestions()
	{
		string path = "Assets/data/questions.txt";

		/*StreamReader reader = new StreamReader(path); 
		string data = reader.ReadToEnd ();
		Debug.Log(data);
		reader.Close();*/
		string data = m_StrQuestions;

		SurveyQuestions questions = createQuestionsFromJSON (data);
		m_Questions = questions;
		Debug.Log ("Questions name: " + questions.name);
		Debug.Log ("Questions id: " + questions.id);
		if (questions.questions != null) {
			Debug.Log ("Nr questions: " + questions.questions.Length);
			for (int i = 0; i < questions.questions.Length; i++) {
				SurveyQuestion question = questions.questions [i];
				Debug.Log ("# question id: " + question.id + " type: " + question.type + " text: " + question.text + " textvalue: " + question.textvalue + " other: " + question.other);
				if (question.answers != null) {
					for (int curquestion = 0; curquestion < question.answers.Length; curquestion++) {
						Debug.Log ("> question answer text: " + question.answers[curquestion].text + " jumpnext: " + question.answers[curquestion].jumpto);

					}
				}
			}
		}



	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			OnBackClicked ();
		}
	}

	void askScale(string title) 
	{
		m_CurQuestionType = 1;
		m_TextQuestion.SetActive (true);
		m_BtnStar1.SetActive (true);
		m_BtnStar2.SetActive (true);
		m_BtnStar3.SetActive (true);
		m_BtnStar4.SetActive (true);
		m_BtnStar5.SetActive (true);
		m_TextQuestion.GetComponentInChildren<UnityEngine.UI.Text> ().text = title;
		m_Button.SetActive (false);
	}

	void askSound(string title) 
	{
		m_CurQuestionType = 2;
		m_TextQuestion.SetActive (true);
		m_BtnSound1.SetActive (true);
		m_BtnSound2.SetActive (true);
		m_BtnSound3.SetActive (true);
		m_BtnSound4.SetActive (true);
		m_BtnSound5.SetActive (true);
		m_TextQuestion.GetComponentInChildren<UnityEngine.UI.Text> ().text = title;
		m_Button.SetActive (false);
	}

	int m_NrAnswersPossible;
	void askCheckBoxes(string title, string option1, string option2, string option3, string option4, string option5, string option6, string option7, int nrquestions, int other)
	{
		Debug.Log ("askCheckBoxes");
		m_NrAnswersPossible = nrquestions;
		if(nrquestions > 0)
			m_Checkbox1.SetActive (true);
		if(nrquestions > 1)
			m_Checkbox2.SetActive (true);
		if(nrquestions > 2)
			m_Checkbox3.SetActive (true);
		if(nrquestions > 3)
			m_Checkbox4.SetActive (true);
		if(nrquestions > 4)
			m_Checkbox5.SetActive (true);
		if(nrquestions > 5)
			m_Checkbox6.SetActive (true);
		if(nrquestions > 6)
			m_Checkbox7.SetActive (true);
		m_TextCheckboxes.GetComponentInChildren<UnityEngine.UI.Text>().text = title;
		m_TextCheckboxes.SetActive (true);

		m_Checkbox1.GetComponentInChildren<UnityEngine.UI.Text>().text = option1;
		m_Checkbox2.GetComponentInChildren<UnityEngine.UI.Text>().text = option2;
		m_Checkbox3.GetComponentInChildren<UnityEngine.UI.Text>().text = option3;
		m_Checkbox4.GetComponentInChildren<UnityEngine.UI.Text>().text = option4;
		m_Checkbox5.GetComponentInChildren<UnityEngine.UI.Text>().text = option5;
		m_Checkbox6.GetComponentInChildren<UnityEngine.UI.Text>().text = option6;
		m_Checkbox7.GetComponentInChildren<UnityEngine.UI.Text>().text = option7;
		m_Button.SetActive (true);
		m_CheckBoxesOther = other;
		m_CurQuestionType = 3;
	}

	void askOneChoice(string title, string option1, string option2, string option3, string option4, string option5, string option6, string option7, int nrquestions, int other)
	{
		m_NrAnswersPossible = nrquestions;
		if(nrquestions > 0)
			m_Radio1.SetActive (true);
		if(nrquestions > 1)
			m_Radio2.SetActive (true);
		if(nrquestions > 2)
			m_Radio3.SetActive (true);
		if(nrquestions > 3)
			m_Radio4.SetActive (true);
		if(nrquestions > 4)
			m_Radio5.SetActive (true);
		if(nrquestions > 5)
			m_Radio6.SetActive (true);
		if(nrquestions > 6)
			m_Radio7.SetActive (true);
		m_TextCheckboxes.GetComponentInChildren<UnityEngine.UI.Text>().text = title;
		m_TextCheckboxes.SetActive (true);

		m_Radio1.GetComponentInChildren<UnityEngine.UI.Text>().text = option1;
		m_Radio2.GetComponentInChildren<UnityEngine.UI.Text>().text = option2;
		m_Radio3.GetComponentInChildren<UnityEngine.UI.Text>().text = option3;
		m_Radio4.GetComponentInChildren<UnityEngine.UI.Text>().text = option4;
		m_Radio5.GetComponentInChildren<UnityEngine.UI.Text>().text = option5;
		m_Radio6.GetComponentInChildren<UnityEngine.UI.Text>().text = option6;
		m_Radio7.GetComponentInChildren<UnityEngine.UI.Text>().text = option7;
		m_Button.SetActive (false);
		m_CheckBoxesOther = other;
		m_CurQuestionType = 4;
	}

	void askForNumber(string title, string placeholder)
	{
		m_TextCheckboxes.GetComponentInChildren<UnityEngine.UI.Text>().text = title;
		m_TextCheckboxes.SetActive (true);

		m_InputNumber.SetActive (true);

		m_InputNumberPlaceholder.GetComponentInChildren<UnityEngine.UI.Text>().text = placeholder;
		m_Button.SetActive (false);
		m_CurQuestionType = 5;
	}

	void askQuestion(string title)
	{
		m_TextCheckboxes.GetComponentInChildren<UnityEngine.UI.Text>().text = title;
		m_TextCheckboxes.SetActive (true);

		m_TextOtherTop.SetActive (true);
		m_InputOtherTop.SetActive (true);

		//m_InputNumberPlaceholder.GetComponentInChildren<UnityEngine.UI.Text>().text = placeholder;
		m_Button.SetActive (true);
		m_CurQuestionType = 6;
	}

	int m_CurQuestion = 0;
	int m_CurQuestionType;
	int m_CurQuestionId;
	int m_CurQuestionAnswer;
	int m_CurQuestionJumpToNext = 0;

	int m_NrQuestions = 4;
	public void updateStates() {
		m_CurStars = -1;
		m_StrText = "";
		m_TextQuestion.SetActive (false);
		m_BtnStar1.SetActive (false);
		m_BtnStar2.SetActive (false);
		m_BtnStar3.SetActive (false);
		m_BtnStar4.SetActive (false);
		m_BtnStar5.SetActive (false);
		m_BtnSound1.SetActive (false);
		m_BtnSound2.SetActive (false);
		m_BtnSound3.SetActive (false);
		m_BtnSound4.SetActive (false);
		m_BtnSound5.SetActive (false);
		m_BtnStar1A.SetActive (false);
		m_BtnStar2A.SetActive (false);
		m_BtnStar3A.SetActive (false);
		m_BtnStar4A.SetActive (false);
		m_BtnStar5A.SetActive (false);
		m_BtnSound1A.SetActive (false);
		m_BtnSound2A.SetActive (false);
		m_BtnSound3A.SetActive (false);
		m_BtnSound4A.SetActive (false);
		m_BtnSound5A.SetActive (false);
		m_InputComment.SetActive (false);
		m_Button.SetActive (false);
		m_TextCheckboxes.SetActive (false);
		m_Checkbox1.SetActive (false);
		m_Checkbox2.SetActive (false);
		m_Checkbox3.SetActive (false);
		m_Checkbox4.SetActive (false);
		m_Checkbox5.SetActive (false);
		m_Checkbox6.SetActive (false);
		m_Checkbox7.SetActive (false);
		m_TextCheckboxOther.SetActive (false);
		m_InputCheckboxOther.SetActive (false);

		m_TextQuestionStehen.SetActive (false);
		m_TextQuestionSitzen.SetActive (false);
		m_TextQuestionLiegen.SetActive (false);
		m_TextQuestionSpielen.SetActive (false);
		m_TextQuestionGehen.SetActive (false);
		m_TextQuestionSport.SetActive (false);
		m_TextQuestionSonstiges.SetActive (false);

		m_TextOtherMedium.SetActive (false);
		m_InputOtherMedium.SetActive (false);
		m_TextOtherTop.SetActive (false);
		m_InputOtherTop.SetActive (false);
		m_InputNumber.SetActive (false);
		m_Checkbox1.GetComponent<Toggle>().isOn = false;
		m_Checkbox2.GetComponent<Toggle>().isOn = false;
		m_Checkbox3.GetComponent<Toggle>().isOn = false;
		m_Checkbox4.GetComponent<Toggle>().isOn = false;
		m_Checkbox5.GetComponent<Toggle>().isOn = false;
		m_Checkbox6.GetComponent<Toggle>().isOn = false;
		m_Checkbox7.GetComponent<Toggle>().isOn = false;

		m_bInitRadioValues = true;
		m_Radio1.SetActive (false);
		m_Radio2.SetActive (false);
		m_Radio3.SetActive (false);
		m_Radio4.SetActive (false);
		m_Radio5.SetActive (false);
		m_Radio6.SetActive (false);
		m_Radio7.SetActive (false);
		m_Radio1.GetComponent<Toggle> ().isOn = false;
//		m_Radio1.GetComponent<Toggle>().isOn = false;
		m_Radio2.GetComponent<Toggle>().isOn = false;
		m_Radio3.GetComponent<Toggle>().isOn = false;
		m_Radio4.GetComponent<Toggle>().isOn = false;
		m_Radio5.GetComponent<Toggle>().isOn = false;
		m_Radio6.GetComponent<Toggle>().isOn = false;
		m_Radio7.GetComponent<Toggle>().isOn = false;
		m_bInitRadioValues = false;

		UnityEngine.UI.InputField inputfield = m_InputOtherTop.GetComponent<UnityEngine.UI.InputField> ();
		inputfield.text = "";
		inputfield = m_InputOtherMedium.GetComponent<UnityEngine.UI.InputField> ();
		inputfield.text = "";
		inputfield = m_InputNumber.GetComponent<UnityEngine.UI.InputField> ();
		inputfield.text = "";
		inputfield = m_InputCheckboxOther.GetComponent<UnityEngine.UI.InputField> ();
		inputfield.text = "";

		m_Button.SetActive (true);


		m_Text1_1.SetActive (false);
		m_Text1_2.SetActive (false);
		m_Text1_3.SetActive (false);
		m_Text1_4.SetActive (false);
		m_Text1_5.SetActive (false);
		m_Text1_6.SetActive (false);
		m_Text1_7.SetActive (false);
		m_Text2.SetActive (false);
		m_Slider1.SetActive (false);
		m_Slider2.SetActive (false);
		m_Slider3.SetActive (false);
		m_Slider4.SetActive (false);
		m_Slider_1_5.SetActive (false);
		m_Slider_1_6.SetActive (false);
		m_Slider7.SetActive (false);
		m_ImageButterfly.SetActive (false);


		m_Text3.SetActive (false);
		m_Slider3_1.SetActive (false);

		m_Text3_1.SetActive (false);
		m_Text3_2.SetActive (false);
		m_Text3_3.SetActive (false);
		m_Text3_4.SetActive (false);
		m_Text3_5.SetActive (false);
		m_Slider6.SetActive (false);
		m_Slider7.SetActive (false);
		m_Slider8.SetActive (false);
		m_Slider9.SetActive (false);
		m_Slider5.SetActive (false);
		m_Slider3_6.SetActive (false);
		m_Slider3_7.SetActive (false);
		m_Slider3_8.SetActive (false);
		m_Text3_6.SetActive (false);
		m_Text3_7.SetActive (false);
		m_Text3_8.SetActive (false);

		m_Text4_1.SetActive (false);
		m_Text4_2.SetActive (false);
		m_Text4_3.SetActive (false);
		m_Text4_4.SetActive (false);
		m_Slider10.SetActive (false);
		m_Slider11.SetActive (false);
		m_Slider12.SetActive (false);
		m_Image4_1.SetActive (false);
		m_Image4_2.SetActive (false);
		m_Image4_3.SetActive (false);


		if (m_CurQuestion == 0) {
			//m_Text1_1.SetActive (true);
			m_Text1_2.SetActive (true);
			m_Text1_3.SetActive (true);
			m_Text1_4.SetActive (true);
			m_Text1_5.SetActive (true);
		//	m_Text1_6.SetActive (true);
	//		m_Text1_7.SetActive (true);
			m_Slider1.SetActive (true);
			m_Slider2.SetActive (true);
			m_Slider3.SetActive (true);
			m_Slider4.SetActive (true);
		//	m_Slider_1_5.SetActive (true);
	//		m_Slider_1_6.SetActive (true);
		} else if (m_CurQuestion == 1) {
			//m_Text3_1.SetActive (true);
			m_Text3_2.SetActive (true);
			m_Text3_3.SetActive (true);
			m_Text3_4.SetActive (true);
			m_Text3_5.SetActive (true);
			m_Slider6.SetActive (true);
			m_Slider7.SetActive (true);
			m_Slider8.SetActive (true);
			m_Slider9.SetActive (true);
			m_Slider3_6.SetActive (true);
		/*	m_Slider3_7.SetActive (true);
			m_Slider3_8.SetActive (true);*/
			m_Text3_6.SetActive (true);
		/*	m_Text3_7.SetActive (true);
			m_Text3_8.SetActive (true);*/
		}else if (m_CurQuestion == 2) {
			m_Text2.SetActive (true);
			//	m_Slider5.SetActive (true);
			//m_ImageButterfly.SetActive (true);
		}  else if (m_CurQuestion == 3) {
			m_TextQuestionStehen.SetActive (true);
		}  else if (m_CurQuestion == 4) {
			m_TextQuestionSitzen.SetActive (true);
		}  else if (m_CurQuestion == 5) {
			m_TextQuestionLiegen.SetActive (true);
		}  else if (m_CurQuestion == 6) {
			m_TextQuestionSpielen.SetActive (true);
		}  else if (m_CurQuestion == 7) {
			m_TextQuestionGehen.SetActive (true);
		}  else if (m_CurQuestion == 8) {
			m_TextQuestionSport.SetActive (true);
		}  else if (m_CurQuestion == 9) {
			m_TextQuestionSonstiges.SetActive (true);
		} 

		/*else if (m_CurQuestion == 2) {
			m_Text3.SetActive (true);
			m_Slider3_1.SetActive (true);
			//m_ImageButterfly.SetActive (true);
		} else if (m_CurQuestion == 3) {
			m_Text3_1.SetActive (true);
			m_Text3_2.SetActive (true);
			m_Text3_3.SetActive (true);
			m_Text3_4.SetActive (true);
			m_Text3_5.SetActive (true);
			m_Slider6.SetActive (true);
			m_Slider7.SetActive (true);
			m_Slider8.SetActive (true);
			m_Slider9.SetActive (true);
			m_Slider3_6.SetActive (true);
			m_Slider3_7.SetActive (true);
			m_Slider3_8.SetActive (true);
			m_Text3_6.SetActive (true);
			m_Text3_7.SetActive (true);
			m_Text3_8.SetActive (true);
		}*//* else if (m_CurQuestion == 3) {
			m_Text4_1.SetActive (true);
			m_Text4_2.SetActive (true);
			m_Text4_3.SetActive (true);
			m_Text4_4.SetActive (true);
			m_Slider10.SetActive (true);
			m_Slider11.SetActive (true);
			m_Slider12.SetActive (true);
			m_Image4_1.SetActive (true);
			m_Image4_2.SetActive (true);
			m_Image4_3.SetActive (true);
		} *//*else if (m_CurQuestion == 4) {
			askOneChoice(LocalizationSupport.GetString("Question_5"), LocalizationSupport.GetString("Yes"), LocalizationSupport.GetString("No"), "Schlecht", "Kein Schatten", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 5) {
			askOneChoice(LocalizationSupport.GetString("Question_6"), LocalizationSupport.GetString("Question_6_1"),
				LocalizationSupport.GetString("Question_6_2"), 
				LocalizationSupport.GetString("Question_6_3"),
				LocalizationSupport.GetString("Question_6_4"), 
				LocalizationSupport.GetString("Question_6_5"), "", "",5, -1);

			//askOneChoice("How often do you come here?", "Every day", "Several times a week", "Once a week", "1-3 times a month", "Less than once a month", "", "",5, -1);
		}*/ /*else if (m_CurQuestion == 6) {
			askOneChoice("Do you usually come here:", "Alone", "In company", "Once a week", "1-3 times a month", "Less than once a month", "", "",2, -1);
		} *//*else if (m_CurQuestion == 6) {

			askCheckBoxes(LocalizationSupport.GetString("Question_7"), LocalizationSupport.GetString("Question_7_1"),
				LocalizationSupport.GetString("Question_7_2"), 
				LocalizationSupport.GetString("Question_7_3"),
				LocalizationSupport.GetString("Question_7_4"), 
				LocalizationSupport.GetString("Question_7_5"), "", "",5, -1);
			//askCheckBoxes("With whom do you come here:", "Family", "Friends", "Relatives", "Work colleagues", "Other", "", "",5, 5);
		}else if (m_CurQuestion == 7) {

			askCheckBoxes(LocalizationSupport.GetString("Question_8"), LocalizationSupport.GetString("Question_8_1"),
				LocalizationSupport.GetString("Question_8_2"), 
				LocalizationSupport.GetString("Question_8_3"),
				LocalizationSupport.GetString("Question_8_4"), 
				LocalizationSupport.GetString("Question_8_5"), "", "",5, -1);
			//askCheckBoxes("What types of activities do you engage in here?", "Passing through", "Walking", "Socializing", "Relaxing", "Other", "", "",5, 5);
		}
*/
		m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Next");
		/*

		//if (Application.systemLanguage == SystemLanguage.German ) {
		int questionnr = m_CurQuestion + 1;

		if (Application.systemLanguage == SystemLanguage.German) {
			m_TextQuestionNr.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString ("Question") + " " + questionnr + "/" + m_NrQuestions;
			m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Next");//"WEITER";
		} else {
			m_TextQuestionNr.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString ("Question") + " " + questionnr + "/" + m_NrQuestions;
			m_Button.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString ("Next");//"NEXT";
		}

		m_CurQuestionId = m_Questions.questions [m_CurQuestion].id;
		m_CurQuestionJumpToNext = m_Questions.questions [m_CurQuestion].jumptonext;
		if (m_Questions.questions [m_CurQuestion].type == 1) {
			askScale (m_Questions.questions [m_CurQuestion].text);
		} else if (m_Questions.questions [m_CurQuestion].type == 2) {
			askSound (m_Questions.questions [m_CurQuestion].text);
		} else if (m_Questions.questions [m_CurQuestion].type == 3 || m_Questions.questions [m_CurQuestion].type == 4) {
			int nranswers = m_Questions.questions [m_CurQuestion].answers.Length;
			string answer1 = "";
			string answer2 = "";
			string answer3 = "";
			string answer4 = "";
			string answer5 = "";
			string answer6 = "";
			string answer7 = "";
			if (nranswers > 0)
				answer1 = m_Questions.questions [m_CurQuestion].answers [0].text;
			if (nranswers > 1)
				answer2 = m_Questions.questions [m_CurQuestion].answers [1].text;
			if (nranswers > 2)
				answer3 = m_Questions.questions [m_CurQuestion].answers [2].text;
			if (nranswers > 3)
				answer4 = m_Questions.questions [m_CurQuestion].answers [3].text;
			if (nranswers > 4)
				answer5 = m_Questions.questions [m_CurQuestion].answers [4].text;
			if (nranswers > 5)
				answer6 = m_Questions.questions [m_CurQuestion].answers [5].text;
			if (nranswers > 6)
				answer7 = m_Questions.questions [m_CurQuestion].answers [6].text;
			int other = -1;
			if (m_Questions.questions [m_CurQuestion].other > 0) {
				other = m_Questions.questions [m_CurQuestion].other;
			}

			if(m_Questions.questions [m_CurQuestion].type == 3)
				askCheckBoxes(m_Questions.questions [m_CurQuestion].text, answer1, answer2, answer3, answer4, answer5, answer6, answer7, nranswers, other);
			else if(m_Questions.questions [m_CurQuestion].type == 4)
				askOneChoice(m_Questions.questions [m_CurQuestion].text, answer1, answer2, answer3, answer4, answer5, answer6, answer7, nranswers, other);
			
		} else if (m_Questions.questions [m_CurQuestion].type == 5) {
			askQuestion (m_Questions.questions [m_CurQuestion].text);
		} else if (m_Questions.questions [m_CurQuestion].type == 6) {
			askForNumber (m_Questions.questions [m_CurQuestion].text, m_Questions.questions [m_CurQuestion].textvalue);
		}*/
		/*if (m_CurQuestion == 0) {
			askScale ("Fü̈hlst du dich wohl in dem Raum?");
		} else if (m_CurQuestion == 1) {
			askScale ("Wie sicher fü̈hlst du dich in diesem Freiraum?");
		} else if (m_CurQuestion == 2) {
			askSound ("Empfindest du den Freiraum als laut?");
		} else if (m_CurQuestion == 3) {
			askCheckBoxes("Welche Geräusche sind zu hören?", "Verkehr", "Vögel", "Kinder", "Sonstige", "Weiter", "Weiter", "", 4, 4);
		} else if (m_CurQuestion == 4) {
			askCheckBoxes("Wie riecht der Raum?", "Nach Abgase", "Nach Essen", "Nach Blumen", "Nach Müll","Sonstige", "Weiter", "",5,5);
		} else if (m_CurQuestion == 5) {
			askOneChoice("Wie viele Menschen halten sich in dem Raum auf?", "0", "1-5", "5-10", "> 10","Sonstige", "Weiter", "",4, -1);
		} else if (m_CurQuestion == 6) {
			askOneChoice("Zur welche Benutzergruppen gehörst du?", "Kinder", "Eltern", "Ältere Leute", "Jugendliche", "Sonstige", "", "",5, 5);
		} else if (m_CurQuestion == 7) {
			askCheckBoxes("Was machst du?", "Sitzen", "Stehen", "Spielen, sich unterhalten", "Lesen", "Sonstige", "", "",5, 5);
		} else if (m_CurQuestion == 8) {
			askCheckBoxes("Für welche Nutzergruppen eignet sich der Freiraum?", "Erwachsene", "Schulkinder", "Jugendliche", "Eltern mit Kleinkindern", "Sonstige", "", "",5, 5);
		} else if (m_CurQuestion == 9) {
			askOneChoice("Ist der Freiraum barrierefrei?", "Ja, weitgehend", "Nein", "Jugendliche", "Eltern mit Kleinkindern", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 10) {
			askCheckBoxes("Gibt es öffentliche oder ähnliche Nutzungen an den Raum angrenzend?", "Kaffees", "Gasthaus", "Ämter", "Schulen", "Sonstiges", "", "",5, 5);
		} else if (m_CurQuestion == 11) {
			askOneChoice("Gibt es eine öffentliche Verkehrsanbindung die sichtbar ist?", "Ja", "Nein", "Jugendliche", "Eltern mit Kleinkindern", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 12) {
			askOneChoice("Läuft ein Radweg an dem Freiraum vorbei bzw. durch den Raum?", "Ja", "Nein", "Jugendliche", "Eltern mit Kleinkindern", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 13) {
			askOneChoice("In welchem Pflegezustand ist der Raum? (Beläge; Möblierung; Graffiti; Abfälle)", "Gut", "Mittelmässig", "Schlecht", "Eltern mit Kleinkindern", "Sonstige", "", "",3, -1);
		} else if (m_CurQuestion == 14) {
			askOneChoice("Wie schattig ist der Raum?", "Schattig", "Halb-schatten", "Teilweise schattig", "Kein Schatten", "Sonstige", "", "",4, -1);
		} else if (m_CurQuestion == 15) {
			askCheckBoxes("Wenn Schatten vorhanden ist, wodurch entsteht dieser Schatten?", "Baum", "Plane", "Pergolen", "Gebäudeschatten", "Sonstiges", "", "",5, 5);
		} else if (m_CurQuestion == 16) {
			askOneChoice("Wie ist deine Wärmeempfindung?", "Zu heiß", "Angenehm", "Zu kalt", "Kein Schatten", "Sonstige", "", "",3, -1);
		} else if (m_CurQuestion == 17) {
			askOneChoice("Ist der Freiraum windig?", "Windstill", "Leichte Luftbewegung", "Unangenehmer Luftzug", "Kein Schatten", "Sonstige", "", "",3, -1);
		} else if (m_CurQuestion == 18) {
			askOneChoice("Ist die Oberfläche teilweise wasserdurchlässig?", "Ja", "Nein", "Jugendliche", "Eltern mit Kleinkindern", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 19) {
			askOneChoice("Gibt es Vegetation im Raum?", "Ja", "Nein", "Schlecht", "Kein Schatten", "Sonstige", "", "",2, -1);
		} else if (m_CurQuestion == 20) {
			askOneChoice("Wie ist der Pflegezustand der Vegetation?", "Gut", "Ausreichend", "Schlecht", "Kein Schatten", "Sonstige", "", "",3, -1);
		}  else if (m_CurQuestion == 21) {
			askCheckBoxes("Welche Vegetation gibt es in dem Raum?", "Bäume", "Sträucher", "Stauden", "Rasen", "Sonstige", "", "",5, 5);
		} else if (m_CurQuestion == 22) {
			askOneChoice("Ist auch spontane Vegetation zu sehen - wie z.B. in Pflasterritzen oder Baumscheiben?", "Ja", "Nein", "Schlecht", "Kein Schatten", "Sonstige", "", "",2, -1);
		}else if (m_CurQuestion == 23) {
			askOneChoice("Sind Vögel zu sehen/hören (außer Tauben!)", "Nein", "Eine Art", "Mehrere Arten", "Kein Schatten", "Sonstige", "", "",3, -1);
		}else if (m_CurQuestion == 24) {
			askOneChoice("Sind Insekten zu sehen/hören?", "Ja", "Nein", "Mehrere Arten", "Kein Schatten", "Sonstige", "", "",2, -1);
		}else if (m_CurQuestion == 25) {
			askCheckBoxes("Welche Insekten sind zu sehen/hören?", "Bienen", "Schmetterlinge", "Käfer", "Sonstige", "Sonstige", "", "",4, 4);
		}else if (m_CurQuestion == 26) {
			askOneChoice("Wie würdest du den Raum charakterisieren?", "Straßenraum", "Stadtplatz", "Wohnsiedlung", "Grünfläche", "Sonstige", "", "",5, 5);
		}else if (m_CurQuestion == 27) {
			askQuestion("Was bestimmt den Charakter des Freiraumes?");
		}else if (m_CurQuestion == 28) {
			askCheckBoxes("Wie ist der Raum definiert (Raumkanten)?", "Bauten", "Vegetation", "Topographie", "Sonstiges", "Sonstige", "", "",4, 4);
		}  else if (m_CurQuestion == 29) {
			askOneChoice("Wie leicht ist es zu sehen wo das 'Grüne Netz' von hier aus weiter geht?", "Sehr leicht", "Unsicher", "Gar nicht", "Kein Schatten", "Sonstige", "", "",3, -1);
		} else if (m_CurQuestion == 30) {
			askOneChoice("Gibt es eine Anbindung an das öffentliche Verkehrsnetz (Haltestelle sichtbar)?", "Ja", "Nein", "Gar nicht", "Kein Schatten", "Sonstige", "", "",2, -1);
		}else if (m_CurQuestion == 31) {
			askCheckBoxes("Welche Oberflächenmaterialien sind dominant?", "Asphalt", "Platten", "Pflaster", "Kies", "Rasen", "Wasser", "",6, -1);
		} else if (m_CurQuestion == 32) {
			askOneChoice("Gibt es Bäume an dem Standort?", "Ja", "Nein", "Gar nicht", "Kein Schatten", "Sonstige", "", "",2, -1);
		}else if (m_CurQuestion == 33) {
			askForNumber ("Wie groß sind sie? (Kronendurchmesser eines 'typischen' Baum abschreiten)", "In Metern");
		} else if (m_CurQuestion == 34) {
			askCheckBoxes("Wie sind die Bäume angeordnet?", "Gruppen", "Raster", "Allee", "Einzeln", "Rasen", "Wasser", "",4, -1);
		} else if (m_CurQuestion == 35) {
			askOneChoice("Gibt es Wasser am Standort?", "Kein Wasser", "Brunnen", "Becken", "Fließgewässer", "Teich", "", "",5, -1);
		} else if (m_CurQuestion == 36) {
			askCheckBoxes("Welche Möblierung gibt es in dem Freiraum?", "Keine", "Bänke", "Papierkörbe", "Tische", "Sonstiges", "Wasser", "",5, 5);
		} else if (m_CurQuestion == 37) {
			askOneChoice("Ist der Raum beleuchtet damit er auch am Abend benutzt werden kann? ", "Gut beleuchtet", "Schlecht beleuchtet", "Nicht beleuchtet", "Kein Schatten", "Sonstige", "", "",3, -1);
		}*/
			
		if (Application.systemLanguage == SystemLanguage.German ) {
			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Back");//"Zurück";
		} else {
			m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Back");//"Back";
		} 



	}

	public void PrevClicked() {
		m_CurQuestion--;
		if (m_CurQuestion < 0) {
			m_CurQuestion = 0;
		}
		updateStates ();
	}



	public void OnStar1Clicked() {
		m_BtnStar1A.SetActive (true);
		m_BtnStar2A.SetActive (false);
		m_BtnStar3A.SetActive (false);
		m_BtnStar4A.SetActive (false);
		m_BtnStar5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 1;
	}
	public void OnStar2Clicked() {
		m_BtnStar1A.SetActive (true);
		m_BtnStar2A.SetActive (true);
		m_BtnStar3A.SetActive (false);
		m_BtnStar4A.SetActive (false);
		m_BtnStar5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 2;
	}
	public void OnStar3Clicked() {
		m_BtnStar1A.SetActive (true);
		m_BtnStar2A.SetActive (true);
		m_BtnStar3A.SetActive (true);
		m_BtnStar4A.SetActive (false);
		m_BtnStar5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 3;
	}
	public void OnStar4Clicked() {
		m_BtnStar1A.SetActive (true);
		m_BtnStar2A.SetActive (true);
		m_BtnStar3A.SetActive (true);
		m_BtnStar4A.SetActive (true);
		m_BtnStar5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 4;
	}
	public void OnStar5Clicked() {
		m_BtnStar1A.SetActive (true);
		m_BtnStar2A.SetActive (true);
		m_BtnStar3A.SetActive (true);
		m_BtnStar4A.SetActive (true);
		m_BtnStar5A.SetActive (true);
		m_Button.SetActive (true);
		m_CurStars = 5;
	}



	public void OnSound1Clicked() {
		m_BtnSound1A.SetActive (true);
		m_BtnSound2A.SetActive (false);
		m_BtnSound3A.SetActive (false);
		m_BtnSound4A.SetActive (false);
		m_BtnSound5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 1;
	}
	public void OnSound2Clicked() {
		m_BtnSound1A.SetActive (true);
		m_BtnSound2A.SetActive (true);
		m_BtnSound3A.SetActive (false);
		m_BtnSound4A.SetActive (false);
		m_BtnSound5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 2;
	}
	public void OnSound3Clicked() {
		m_BtnSound1A.SetActive (true);
		m_BtnSound2A.SetActive (true);
		m_BtnSound3A.SetActive (true);
		m_BtnSound4A.SetActive (false);
		m_BtnSound5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 3;
	}
	public void OnSound4Clicked() {
		m_BtnSound1A.SetActive (true);
		m_BtnSound2A.SetActive (true);
		m_BtnSound3A.SetActive (true);
		m_BtnSound4A.SetActive (true);
		m_BtnSound5A.SetActive (false);
		m_Button.SetActive (true);
		m_CurStars = 4;
	}
	public void OnSound5Clicked() {
		m_BtnSound1A.SetActive (true);
		m_BtnSound2A.SetActive (true);
		m_BtnSound3A.SetActive (true);
		m_BtnSound4A.SetActive (true);
		m_BtnSound5A.SetActive (true);
		m_Button.SetActive (true);
		m_CurStars = 5;
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

	void SaveSurvey()
	{
		int m_NrQuestsDone = 0;
		if (PlayerPrefs.HasKey ("NrQuestsDone")) {
			m_NrQuestsDone = PlayerPrefs.GetInt ("NrQuestsDone");
		} else {
			m_NrQuestsDone = 0;
		}




		PlayerPrefs.SetInt ("Quest_" + m_NrQuestsDone + "_NrLandUses", 0);// m_CurNrLandUses);





		PlayerPrefs.SetInt ("Quest_" + m_NrQuestsDone + "_LandCoverId", 0);//m_CurLandCoverId);
		//PlayerPrefs.SetInt ("Quest_" + m_NrQuestsDone + "_LandUseId", m_CurLandUseId);
		PlayerPrefs.SetInt ("Quest_" + m_NrQuestsDone + "_LandUseId", 0);

		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Heading", Input.compass.trueHeading);
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_AccX", Input.acceleration.x);
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_AccY", Input.acceleration.y);
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_AccZ", Input.acceleration.z);

		// Save timings
		string strtime = PlayerPrefs.GetString("CurQuestSelectedTime");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "SelectedTime", strtime);

		strtime = PlayerPrefs.GetString("CurQuestStartQuestTime");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "StartQuestTime", strtime);

		strtime = PlayerPrefs.GetString("CurQuestStartCameraTime");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "StartCameraTime", strtime);

		strtime = PlayerPrefs.GetString("CurQuestEndCameraTime");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "EndCameraTime", strtime);

		strtime = PlayerPrefs.GetString("CurQuestStartQuestionsTime");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "StartQuestionsTime", strtime);

		string endquestionstime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "EndQuestionsTime", endquestionstime);

		// Save player positions
		float fvalue = PlayerPrefs.GetFloat("CurQuestStartPositionX");
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "StartPositionX", fvalue);
		fvalue = PlayerPrefs.GetFloat("CurQuestStartPositionY");
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "StartPositionY", fvalue);
		fvalue = PlayerPrefs.GetFloat("CurQuestEndPositionX");
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "EndPositionX", fvalue);
		fvalue = PlayerPrefs.GetFloat("CurQuestEndPositionY");
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "EndPositionY", fvalue);

		fvalue = PlayerPrefs.GetFloat("CurDistanceWalked");
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "DistanceWalked", fvalue);

		int nrpositions = PlayerPrefs.GetInt("CurQuestNrPositions");
		PlayerPrefs.SetInt ("Quest_" + m_NrQuestsDone + "_" + "NrPositions", nrpositions);
		for (int pos = 0; pos < nrpositions; pos++) {
			float posx = PlayerPrefs.GetFloat ("CurQuestPositionX_" + pos);
			float posy = PlayerPrefs.GetFloat ("CurQuestPositionY_" + pos);

			PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "PositionX_" + pos, posx);
			PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "PositionY_" + pos, posy);
		}






		float tilted = Input.acceleration.z;
		if (tilted > 1.0f) {
			tilted = 1.0f;
		} else if (tilted < -1.0f) {
			tilted = -1.0f;
		}
		tilted *= 90.0f;
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Tilt", tilted);

		float lat = Input.location.lastData.latitude;
		float lng = Input.location.lastData.longitude;

		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Lat", lat);
		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Lng", lng);

		PlayerPrefs.SetFloat ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Accuracy", Input.compass.headingAccuracy);

		PlayerPrefs.SetInt ("CurQuestions_QuestionId", m_CurQuestion);


		string theTime = System.DateTime.Now.ToString ("yyyy-MM-dd HH:mm:sszz");
		string theTime2 = theTime;//theTime.Replace ("+", "%2B");
		Debug.Log ("CurrentTimestamp: " + theTime2);
		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_" + "LandCover" + "_Timestamp", theTime2);

		/*
		PlayerPrefs.Save ();
		Application.LoadLevel ("QuestFinished");
		return;

		m_FinishedText.SetActive (true);
		m_BtnFinished.SetActive (true);
		m_TextUploading.SetActive (false);*/

		string text = "{";
		text += "questions:location,";// + m_Questions.name + ",";
		text += "id:" + m_Questions.id + ",";



		string curquestid = PlayerPrefs.GetString ("CurQuestId");
		text += "questid:" + curquestid + ",";
		float strlat = PlayerPrefs.GetFloat ("CurQuestLat");
		float strlng = PlayerPrefs.GetFloat ("CurQuestLng");
		text += "lat:" + lat + ",";
		text += "lng:" + lng + ",";

	Debug.Log ("SaveSurvey0");

		// Save sliders
		text += "{";
		text += "questionid:" + 0 + ",";
		text += "value1:" + m_Slider1.GetComponent<Slider> ().value + ",";
		text += "value2:" + m_Slider2.GetComponent<Slider> ().value + ",";
		text += "value3:" + m_Slider3.GetComponent<Slider> ().value + ",";
		text += "value4:" + m_Slider4.GetComponent<Slider> ().value;
		/*text += "value5:" + m_Slider_1_5.GetComponent<Slider> ().value + ",";
		text += "value6:" + m_Slider_1_6.GetComponent<Slider> ().value + ",";*/
		text += "},";


	text += "{";
	text += "questionid:" + 9 + ",";
	text += "nrtrees:" + m_Slider6.GetComponent<Slider> ().value + ",";
	text += "nrbees:" + m_Slider7.GetComponent<Slider> ().value + ",";
	text += "nrbirds:" + m_Slider8.GetComponent<Slider> ().value + ",";
	text += "nrbutterflys:" + m_Slider9.GetComponent<Slider> ().value + ",";
	text += "nranimals:" + m_Slider3_6.GetComponent<Slider> ().value;
	/*text += "value5:" + m_Slider_1_5.GetComponent<Slider> ().value + ",";
		text += "value6:" + m_Slider_1_6.GetComponent<Slider> ().value + ",";*/
	text += "},";




	Debug.Log ("SaveSurvey01");
		text += "{";
			text += "questionid:" + 1 + ",";
	text += "stehen:" + m_ToggleStehen.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen:" + m_ToggleSitzen.GetComponent<Toggle> ().isOn + ",";
	text += "liegen:" + m_ToggleLiegen.GetComponent<Toggle> ().isOn + ",";
	text += "spielen:" + m_ToggleSpielen.GetComponent<Toggle> ().isOn + ",";
	text += "gehen:" + m_ToggleGehen.GetComponent<Toggle> ().isOn + ",";
	text += "sport:" + m_ToggleSport.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges:" + m_ToggleSonstiges.GetComponent<Toggle> ().isOn;
	text += "},";

		Debug.Log ("SaveSurvey1");

	text += "{";
	text += "questionid:" + 2 + ",";
	text += "stehen1:" + m_ToggleStehen1.GetComponent<Toggle> ().isOn + ",";
	text += "stehen2:" + m_ToggleStehen2.GetComponent<Toggle> ().isOn + ",";
	text += "stehen3:" + m_ToggleStehen3.GetComponent<Toggle> ().isOn + ",";
	text += "stehen4:" + m_ToggleStehen4.GetComponent<Toggle> ().isOn + ",";
	text += "stehen5:" + m_ToggleStehen5.GetComponent<Toggle> ().isOn + ",";
	text += "stehen6:" + m_ToggleStehen6.GetComponent<Toggle> ().isOn;
	text += "},";

	Debug.Log ("SaveSurvey2");
	text += "{";
	text += "questionid:" + 3 + ",";
	text += "sitzen1:" + m_ToggleSitzen1.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen2:" + m_ToggleSitzen2.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen3:" + m_ToggleSitzen3.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen4:" + m_ToggleSitzen4.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen5:" + m_ToggleSitzen5.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen6:" + m_ToggleSitzen6.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen7:" + m_ToggleSitzen7.GetComponent<Toggle> ().isOn + ",";
	text += "sitzen8:" + m_ToggleSitzen8.GetComponent<Toggle> ().isOn;
	text += "},";

	Debug.Log ("SaveSurvey3");
	text += "{";
	text += "questionid:" + 4 + ",";
	text += "liegen1:" + m_ToggleLiegen1.GetComponent<Toggle> ().isOn + ",";
	text += "liegen2:" + m_ToggleLiegen2.GetComponent<Toggle> ().isOn + ",";
	text += "liegen3:" + m_ToggleLiegen3.GetComponent<Toggle> ().isOn + ",";
	text += "liegen4:" + m_ToggleLiegen4.GetComponent<Toggle> ().isOn + ",";
	text += "liegen5:" + m_ToggleLiegen5.GetComponent<Toggle> ().isOn;
	text += "},";
	Debug.Log ("SaveSurvey4");

	text += "{";
	text += "questionid:" + 5 + ",";
	text += "spielen1:" + m_ToggleSpielen1.GetComponent<Toggle> ().isOn + ",";
	text += "spielen2:" + m_ToggleSpielen2.GetComponent<Toggle> ().isOn + ",";
	text += "spielen3:" + m_ToggleSpielen3.GetComponent<Toggle> ().isOn + ",";
	text += "spielen4:" + m_ToggleSpielen4.GetComponent<Toggle> ().isOn + ",";
	text += "spielen5:" + m_ToggleSpielen5.GetComponent<Toggle> ().isOn + ",";
	text += "spielen6:" + m_ToggleSpielen6.GetComponent<Toggle> ().isOn + ",";
	text += "spielen7:" + m_ToggleSpielen7.GetComponent<Toggle> ().isOn + ",";
	text += "spielen8:" + m_ToggleSpielen8.GetComponent<Toggle> ().isOn + ",";
	text += "spielen9:" + m_ToggleSpielen9.GetComponent<Toggle> ().isOn;
	text += "},";
	Debug.Log ("SaveSurvey5");

	text += "{";
	text += "questionid:" + 6 + ",";
	text += "gehen1:" + m_ToggleGehen1.GetComponent<Toggle> ().isOn + ",";
	text += "gehen2:" + m_ToggleGehen2.GetComponent<Toggle> ().isOn + ",";
	text += "gehen3:" + m_ToggleGehen3.GetComponent<Toggle> ().isOn;
	text += "},";

	Debug.Log ("SaveSurvey6");
	text += "{";
	text += "questionid:" + 7 + ",";
	text += "sport1:" + m_ToggleSport1.GetComponent<Toggle> ().isOn + ",";
	text += "sport2:" + m_ToggleSport2.GetComponent<Toggle> ().isOn + ",";
	text += "sport3:" + m_ToggleSport3.GetComponent<Toggle> ().isOn + ",";
	text += "sport4:" + m_ToggleSport4.GetComponent<Toggle> ().isOn + ",";
	text += "sport5:" + m_ToggleSport5.GetComponent<Toggle> ().isOn + ",";
	text += "sport6:" + m_ToggleSport6.GetComponent<Toggle> ().isOn;
	text += "},";
	Debug.Log ("SaveSurvey7");

	text += "{";
	text += "questionid:" + 8 + ",";
	text += "sonstiges1:" + m_ToggleSonstiges1.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges2:" + m_ToggleSonstiges2.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges3:" + m_ToggleSonstiges3.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges4:" + m_ToggleSonstiges4.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges5:" + m_ToggleSonstiges5.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges6:" + m_ToggleSonstiges6.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges7:" + m_ToggleSonstiges7.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges8:" + m_ToggleSonstiges8.GetComponent<Toggle> ().isOn + ",";
	text += "sonstiges9:" + m_ToggleSonstiges9.GetComponent<Toggle> ().isOn;
	text += "}";


	Debug.Log ("SaveSurvey8");
		text += "}";

	/*
		for (int i = 4; i < m_NrQuestions; i++) {
			text += "{";
			int questionid = i + 1;
			//text += "questionid:" + questionid + ",";
			text += "questionid:" + m_Answers[i].m_Id + ",";
			int questiontype = m_Answers [i].m_Type;
			text += "type:" + m_Answers [i].m_Type + ",";
			if (questiontype == 1 || questiontype == 2) {
				text += "answer:" + m_Answers [i].m_Answer + "";
			} else if (questiontype == 3 || questiontype == 4) {
				if(m_Answers[i].m_NrAnswersPossible >= 1)
					text += "check1:" + m_Answers [i].m_bCheck1 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 2)
					text += "check2:" + m_Answers [i].m_bCheck2 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 3)
					text += "check3:" + m_Answers [i].m_bCheck3 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 4)
					text += "check4:" + m_Answers [i].m_bCheck4 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 5)
					text += "check5:" + m_Answers [i].m_bCheck5 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 6)
					text += "check6:" + m_Answers [i].m_bCheck6 + ",";
				if(m_Answers[i].m_NrAnswersPossible >= 7)
					text += "check7:" + m_Answers [i].m_bCheck7 + ",";
				text += "text:\"" + m_Answers [i].m_Text + "\"";
			} else if (questiontype == 5 || questiontype == 6) {
				text += "text:\"" + m_Answers [i].m_Text + "\""; 
			}

			text += "}";
			if (i != (m_NrQuestions-1))
				text += ",";
		}
		text += "}";*/
		Debug.Log ("SaveSurvey: " + text);

		PlayerPrefs.SetString ("Quest_" + m_NrQuestsDone + "_Questions", text);


	PlayerPrefs.Save ();
	Application.LoadLevel ("TestCamera");
//	Application.LoadLevel ("QuestFinished");
		return;


		string url = "https://geo-wiki.org/application/api/game/saveGreenSpaceAnswers";
		string param = "";

		string textescaped =  WWW.EscapeURL(text);
		string email = PlayerPrefs.GetString ("PlayerMail");
		//text = "asdf";
		param += "{\"mail\":" + "\"" + email + "\"";//,\"md5password\":" + "\"" + passwordmd5 + "\"";
		param += "," + "\"answers\":\"" + textescaped + "\"";
		/*
		param += "," + "\"stars1\":\""   + m_Stars1 + "\"";
		param += "," + "\"stars2\":\""   + m_Stars2 + "\"";
		param += "," + "\"stars3\":\""   + m_Stars3 + "\"";
		param += "," + "\"stars4\":\""   + m_Stars4 + "\"";
		param += "," + "\"stars5\":\""   + m_Stars5 + "\"";
		param += "," + "\"stars6\":\""   + m_Stars6 + "\"";
		param += "," + "\"stars7\":\""   + m_Stars7 + "\"";
		param += "," + "\"stars8\":\""   + m_Stars8 + "\"";

		UnityEngine.UI.InputField textinput;
		textinput = m_InputComment.GetComponent<UnityEngine.UI.InputField>();


		param += "," + "\"comment\":\""   + textinput.text + "\"";*/


		param += "}";



		Debug.Log ("saveAnswers: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForProgressDataSave(www));
	}

	int m_CheckBoxesOther = -1;
	public void onCheckbox1(bool bChecked) 
	{
		if (m_CheckBoxesOther == 1) {
			showTextBoxOther (bChecked);
		}

	}
	public void onCheckbox2(bool bChecked) 
	{
		if (m_CheckBoxesOther == 2) {
			showTextBoxOther (bChecked);
		}
	}
	public void onCheckbox3(bool bChecked) 
	{
		if (m_CheckBoxesOther == 3) {
			showTextBoxOther (bChecked);
		}
	}
	public void onCheckbox4(bool bChecked) 
	{
		if (m_CheckBoxesOther == 4) {
			showTextBoxOther (bChecked);
		}
	}
	public void onCheckbox5(bool bChecked) 
	{
		if (m_CheckBoxesOther == 5) {
			showTextBoxOther (bChecked);
		}
	}
	public void onCheckbox6(bool bChecked) 
	{
		if (m_CheckBoxesOther == 6) {
			showTextBoxOther (bChecked);
		}
	}
	public void onCheckbox7(bool bChecked) 
	{
		if (m_CheckBoxesOther == 7) {
			showTextBoxOther (bChecked);
		}
	}

	void showTextBoxOther(bool bShow)
	{
		if (m_NrAnswersPossible >= 5) {
			if (bShow) {
				m_InputCheckboxOther.SetActive (true);
				m_TextCheckboxOther.SetActive (true);
			} else {
				m_InputCheckboxOther.SetActive (false);
				m_TextCheckboxOther.SetActive (false);
			}
		} else {
			if (bShow) {
				m_InputOtherMedium.SetActive (true);
				m_TextOtherMedium.SetActive (true);
			} else {
				m_InputOtherMedium.SetActive (false);
				m_TextOtherMedium.SetActive (false);
			}
		}
	}

	bool m_bInitRadioValues = false;
	bool m_bIgnoreRatioButtons = false;
	public void onRadio1(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		//Debug.Log ("onRadio1");
		if (bChecked) {
			if (m_CheckBoxesOther == 1) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}
		//Debug.Log ("onRadio1_2");
		if (bChecked) {
		//	Debug.Log ("onRadio1_2 on=false");
			m_bInitRadioValues = true;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
			//Debug.Log ("onRadio1_3 on=false");
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio1.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}

		m_Button.SetActive (true);
	}
	public void onRadio2(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		if (bChecked) {
			if (m_CheckBoxesOther == 2) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			//m_Radio2.GetComponent<Toggle> ().isOn = true;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio2.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}
	public void onRadio3(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		if (bChecked) {
			if (m_CheckBoxesOther == 3) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			//m_Radio3.GetComponent<Toggle> ().isOn = true;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio3.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}
	public void onRadio4(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		if (bChecked) {
			if (m_CheckBoxesOther == 4) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			//m_Radio4.GetComponent<Toggle> ().isOn = true;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio4.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}
	public void onRadio5(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		if (bChecked) {
			if (m_CheckBoxesOther == 5) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			//m_Radio5.GetComponent<Toggle> ().isOn = true;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio5.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}
	public void onRadio6(bool bChecked) 
	{
	//	Debug.Log ("onRadio6: " + bChecked);
		if (m_bIgnoreRatioButtons) {
			return;
		}

	//	Debug.Log ("onRadio6_2: " + bChecked);
		if (bChecked) {
			if (m_CheckBoxesOther == 6) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			//m_Radio6.GetComponent<Toggle> ().isOn = true;
			m_Radio7.GetComponent<Toggle> ().isOn = false;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
		//	Debug.Log ("onRadio6_3: " + bChecked);
			m_bIgnoreRatioButtons = true;
			m_Radio6.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}
	public void onRadio7(bool bChecked) 
	{
		if (m_bIgnoreRatioButtons) {
			return;
		}
		if (bChecked) {
			if (m_CheckBoxesOther == 7) {
				showTextBoxOther (bChecked);
			} else {
				showTextBoxOther (false);
			}
		}

		if (bChecked) {
			m_bInitRadioValues = true;
			m_Radio1.GetComponent<Toggle> ().isOn = false;
			m_Radio2.GetComponent<Toggle> ().isOn = false;
			m_Radio3.GetComponent<Toggle> ().isOn = false;
			m_Radio4.GetComponent<Toggle> ().isOn = false;
			m_Radio5.GetComponent<Toggle> ().isOn = false;
			m_Radio6.GetComponent<Toggle> ().isOn = false;
		//	m_Radio7.GetComponent<Toggle> ().isOn = true;
			m_bInitRadioValues = false;
		} else if(!m_bInitRadioValues) {
			m_bIgnoreRatioButtons = true;
			m_Radio7.GetComponent<Toggle> ().isOn = true;
			m_bIgnoreRatioButtons = false;
		}
		m_Button.SetActive (true);
	}

	public void onNumberEntered(string value)
	{
	//	Debug.Log ("OnNumberEntered: " + value);
		m_StrText = value;
		if (value.Length > 0) {
			m_Button.SetActive (true);
		} else {
			m_Button.SetActive (false);
		}
	}

	public void onTextEntered(string value)
	{
		m_StrText = value;
		//Debug.Log ("onTextEntered: " + value);
		if (value.Length > 0) {
			m_Button.SetActive (true);
		} else {
			m_Button.SetActive (false);
		}
	}

	IEnumerator WaitForProgressDataSave(WWW www)
	{
		yield return www;
		Debug.Log ("Data saved");
		string data = www.text;
		Debug.Log ("data: " + data);
		m_FinishedText.SetActive (true);
		m_BtnFinished.SetActive (true);
		m_TextUploading.SetActive (false);
	} 

	public void FinishedClicked () {
		//PlayerPrefs.SetInt ("SurveyDone", 1);

//		Application.LoadLevel ("DemoMap");
	}

	public void TextChanged(string text)
	{
		Debug.Log ("TextChanged: " + text);
		m_StrText = text;
	}

	public void NextClicked () {
		int jumpto = -1;

	#if ASDFASDFASDFASASFSDF
		m_Answers [m_CurQuestion].reset ();
		m_Answers [m_CurQuestion].m_Id = m_CurQuestion;//m_CurQuestionId;
		m_Answers [m_CurQuestion].m_Type = m_CurQuestionType;
		if (m_CurQuestionType == 1 || m_CurQuestionType == 2) {
			m_Answers [m_CurQuestion].m_Answer = m_CurStars;
			Debug.Log (@"CurQuestion nrstars: " + m_CurStars);
		} else if (m_CurQuestionType == 3) {
			m_Answers [m_CurQuestion].m_NrAnswersPossible = m_NrAnswersPossible;
			if (m_Checkbox1.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 1");
				m_Answers [m_CurQuestion].m_bCheck1 = true;
			}
			if (m_Checkbox2.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 2");
				m_Answers [m_CurQuestion].m_bCheck2 = true;
			}
			if (m_Checkbox3.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 3");
				m_Answers [m_CurQuestion].m_bCheck3 = true;
			}
			if (m_Checkbox4.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 4");
				m_Answers [m_CurQuestion].m_bCheck4 = true;
			}
			if (m_Checkbox5.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 5");
				m_Answers [m_CurQuestion].m_bCheck5 = true;
			}
			if (m_Checkbox6.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 6");
				m_Answers [m_CurQuestion].m_bCheck6 = true;
			}
			if (m_Checkbox7.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Check 7");
				m_Answers [m_CurQuestion].m_bCheck7 = true;
			}
			m_Answers [m_CurQuestion].m_Text = m_StrText;
			Debug.Log ("Text: " + m_StrText);
		} else if (m_CurQuestionType == 4) {
			m_Answers [m_CurQuestion].m_NrAnswersPossible = m_NrAnswersPossible;
			if (m_Radio1.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 1");
				m_Answers [m_CurQuestion].m_bCheck1 = true;
			/*
				if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 0) {
					if (m_Questions.questions [m_CurQuestion].answers [0].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [0].jumpto;
					}
				}*/
			}
			if (m_Radio2.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 2");
				m_Answers [m_CurQuestion].m_bCheck2 = true;

				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 1) {
					if (m_Questions.questions [m_CurQuestion].answers [1].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [1].jumpto;
					}
				}*/
			}
			if (m_Radio3.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 3");
				m_Answers [m_CurQuestion].m_bCheck3 = true;

				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 2) {
					if (m_Questions.questions [m_CurQuestion].answers [2].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [2].jumpto;
					}
				}*/
			}
			if (m_Radio4.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 4");
				m_Answers [m_CurQuestion].m_bCheck4 = true;
				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 3) {
					if (m_Questions.questions [m_CurQuestion].answers [3].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [3].jumpto;
					}
				}*/
			}
			if (m_Radio5.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 5");
				m_Answers [m_CurQuestion].m_bCheck5 = true;
				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 4) {
					if (m_Questions.questions [m_CurQuestion].answers [4].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [4].jumpto;
					}
				}*/
			}
			if (m_Radio6.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 6");
				m_Answers [m_CurQuestion].m_bCheck6 = true;
				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 5) {
					if (m_Questions.questions [m_CurQuestion].answers [5].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [5].jumpto;
					}
				}*/
			}
			if (m_Radio7.GetComponent<Toggle> ().isOn) {
				Debug.Log ("Radio 7");
				m_Answers [m_CurQuestion].m_bCheck7 = true;
				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 6) {
					if (m_Questions.questions [m_CurQuestion].answers [6].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [6].jumpto;
					}
				}*/
			}
			m_Answers [m_CurQuestion].m_Text = m_StrText;
			Debug.Log ("Text: " + m_StrText);
		} else if (m_CurQuestionType == 5) {
			Debug.Log ("Number asked: " + m_StrText);
			m_Answers [m_CurQuestion].m_Text = m_StrText;
		} else if (m_CurQuestionType == 6) {
			Debug.Log ("Text asked: " + m_StrText);
			m_Answers [m_CurQuestion].m_Text = m_StrText;
		}

		if (m_CurQuestion == 0) {
			m_Stars1 = m_CurStars;
		} else if (m_CurQuestion == 1) {
			m_Stars2 = m_CurStars;
		}  else if (m_CurQuestion == 2) {
			m_Stars3 = m_CurStars;
		}  else if (m_CurQuestion == 3) {
			m_Stars4 = m_CurStars;
		}  else if (m_CurQuestion == 4) {
			m_Stars5 = m_CurStars;
		}  else if (m_CurQuestion == 5) {
			m_Stars6 = m_CurStars;
		}  else if (m_CurQuestion == 6) {
			m_Stars7 = m_CurStars;
		}  else if (m_CurQuestion == 7) {
			m_Stars8 = m_CurStars;
		} 

		if (m_CurQuestionJumpToNext != 0) {
			jumpto = m_CurQuestionJumpToNext;
		}

		if (jumpto != -1) {
			Debug.Log ("JUMP TO: " + jumpto);
			int newquestion = getQuestionNr (jumpto);
			Debug.Log ("newquestion: " + newquestion);
			if (newquestion != 0) {
				m_CurQuestion = newquestion;
				m_CurQuestion--;
			}
		}
	#endif
		// Jump over questions if neccessary
/*		if (m_CurQuestion == 19) {
			if (m_Radio1.GetComponent<Toggle> ().isOn) {
				m_CurQuestion++;
			} else {
				m_CurQuestion = 23;
			}
		} else if (m_CurQuestion == 24) {
			if (m_Radio1.GetComponent<Toggle> ().isOn) {
				m_CurQuestion++;
			} else {
				m_CurQuestion = 26;
			}
		} else if (m_CurQuestion == 32) {
			if (m_Radio1.GetComponent<Toggle> ().isOn) {
				m_CurQuestion++;
			} else {
				m_CurQuestion = 35;
			}
		} else {
			m_CurQuestion++;
		}*/
		m_CurQuestion++;

		if (m_CurQuestion >= 3) {
			bool bActive = false;
			while (!bActive && m_CurQuestion < m_NrQuestions) {
				if (m_CurQuestion == 3) {
					if (m_ToggleStehen.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 4) {
					if (m_ToggleSitzen.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 5) {
					if (m_ToggleLiegen.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 6) {
					if (m_ToggleSpielen.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 7) {
					if (m_ToggleGehen.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 8) {
					if (m_ToggleSport.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				} else if (m_CurQuestion == 9) {
					if (m_ToggleSonstiges.GetComponent<Toggle> ().isOn) {
						bActive = true;
					}
				}

				if (!bActive) {
					m_CurQuestion++;
				}
			}
		}

		Debug.Log ("Curquestion: " + m_CurQuestion);


		if (m_CurQuestion < m_NrQuestions) {
			updateStates ();
		} else {
			m_ImageUploading.SetActive (true);
			//m_TextUploading.SetActive (true);
		//m_Button.SetActive(false);
			SaveSurvey ();
		}
	}

	int getQuestionNr(int questionid) {
		if (m_Questions.questions == null) {
			return 0;
		}
		for (int i = 0; i < m_Questions.questions.Length; i++) {
			//Debug.Log ("getQuestionNr: " + i + " id: " + m_Questions.questions [i].id);
			if (m_Questions.questions [i].id == questionid) {
				return i;
			}
		}
		return 0;
	}

public void OnBackClicked()
{
		/*if (m_CurQuestion == 23) {
			m_CurQuestion = 19;
		} else if (m_CurQuestion == 26) {
			m_CurQuestion = 24;
		} else if (m_CurQuestion == 35) {
			m_CurQuestion = 32;
		} else {
			m_CurQuestion--;
		}*/
		m_CurQuestion--;

		bool bActive = false;
		while (!bActive && m_CurQuestion >= 3) {
			if (m_CurQuestion == 3) {
			if (m_ToggleStehen.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 4) {
			if (m_ToggleSitzen.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 5) {
			if (m_ToggleLiegen.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 6) {
			if (m_ToggleSpielen.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 7) {
			if (m_ToggleGehen.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 8) {
			if (m_ToggleSport.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			} else if (m_CurQuestion == 9) {
			if (m_ToggleSonstiges.GetComponent<Toggle> ().isOn) {
					bActive = true;
				}
			}

			if (!bActive) {
				m_CurQuestion--;
			}
		}


		if (m_CurQuestion >= 0) {
			/*if (m_Questions.questions [m_CurQuestion].jumptoprev != 0) {
				m_CurQuestion = getQuestionNr (m_Questions.questions [m_CurQuestion].jumptoprev);
			}*/
		} else {
			m_CurQuestion = 0;
			/*PlayerPrefs.SetInt ("CameraStartLastStep", 1);
			PlayerPrefs.Save ();
			Application.LoadLevel ("TestCamera");*/
			Application.LoadLevel ("DemoMap");
		}
	if (m_CurQuestion >= 0) {
		updateStates ();
	} 
}

} 




