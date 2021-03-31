using System;
using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class EventSystemDynamicQuestionsParkCopy : MonoBehaviour {
	public GameObject m_Button;

	private MessageBox messageBox;
	private MessageBox verticalMessageBox;


	public GameObject m_ImageUploading;
	public GameObject m_TextUploading;


	public GameObject m_TextQuestion;
	public GameObject m_InputComment;

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


	public GameObject m_Text_1;
	public GameObject m_Text_1_1;
	public GameObject m_Text_1_2;
	public GameObject m_Slider_1_1;
	public GameObject m_Slider_1_2;
	public GameObject m_SliderNotAtAll_1_1;
	public GameObject m_SliderNotSoMuch_1_1;
	public GameObject m_SliderSomewhat_1_1;
	public GameObject m_SliderVery_1_1;
	public GameObject m_SliderExtremely_1_1;
	public GameObject m_SliderNotAtAll_1_2;
	public GameObject m_SliderNotSoMuch_1_2;
	public GameObject m_SliderSomewhat_1_2;
	public GameObject m_SliderVery_1_2;
	public GameObject m_SliderExtremely_1_2;


	public GameObject m_Text_2;
	public GameObject m_Text_2_1;
	public GameObject m_Text_2_2;
	public GameObject m_Text_2_3;
	public GameObject m_Text_2_4;
	public GameObject m_Text_2_5;
	public GameObject m_Text_2_6;
	public GameObject m_Slider_2_1;
	public GameObject m_Slider_2_2;
	public GameObject m_Slider_2_3;
	public GameObject m_Slider_2_4;
	public GameObject m_Slider_2_5;
	public GameObject m_Slider_2_6;
	public GameObject m_SliderNotAtAll_1_3;
	public GameObject m_SliderNotSoMuch_1_3;
	public GameObject m_SliderSomewhat_1_3;
	public GameObject m_SliderVery_1_3;
	public GameObject m_SliderExtremely_1_3;
	public GameObject m_SliderNotAtAll_1_4;
	public GameObject m_SliderNotSoMuch_1_4;
	public GameObject m_SliderSomewhat_1_4;
	public GameObject m_SliderVery_1_4;
	public GameObject m_SliderExtremely_1_4;
	public GameObject m_SliderNotAtAll_1_5;
	public GameObject m_SliderNotSoMuch_1_5;
	public GameObject m_SliderSomewhat_1_5;
	public GameObject m_SliderVery_1_5;
	public GameObject m_SliderExtremely_1_5;
	public GameObject m_SliderNotAtAll_1_6;
	public GameObject m_SliderNotSoMuch_1_6;
	public GameObject m_SliderSomewhat_1_6;
	public GameObject m_SliderVery_1_6;
	public GameObject m_SliderExtremely_1_6;
	public GameObject m_SliderNotAtAll_1_7;
	public GameObject m_SliderNotSoMuch_1_7;
	public GameObject m_SliderSomewhat_1_7;
	public GameObject m_SliderVery_1_7;
	public GameObject m_SliderExtremely_1_7;
	public GameObject m_SliderNotAtAll_1_8;
	public GameObject m_SliderNotSoMuch_1_8;
	public GameObject m_SliderSomewhat_1_8;
	public GameObject m_SliderVery_1_8;
	public GameObject m_SliderExtremely_1_8;

	public GameObject m_TextOther;

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

		m_TextUploading.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("IsUploading");//"Wird hochgeladen...";
			m_FinishedText.GetComponentInChildren<UnityEngine.UI.Text> ().text = "";
			m_BtnFinished.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("CloseQuestions");//"Schließen";





			m_Text_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_1");
		m_Text_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_1_1");
		m_Text_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_1_2");


		m_Text_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2");
		m_Text_2_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_1");
		m_Text_2_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_2");
		m_Text_2_3.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_3");
		m_Text_2_4.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_4");
		m_Text_2_5.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_5");
		m_Text_2_6.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("QuestionPark_2_6");

		m_SliderNotAtAll_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
		m_SliderNotAtAll_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		m_SliderNotSoMuch_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
		m_SliderSomewhat_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
		m_SliderVery_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_1.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");
		m_SliderExtremely_1_2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Extremely");


		m_SliderNotAtAll_1_3.GetComponentInChildren<UnityEngine.UI.Text> ().text = "1";// LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";// LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_3.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_SliderNotAtAll_1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = "1";//LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";//LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_4.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_SliderNotAtAll_1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = "1";//LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";//LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_5.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_SliderNotAtAll_1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = "1";//LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";//LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_6.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_SliderNotAtAll_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = "1";//LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";//LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_7.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_SliderNotAtAll_1_8.GetComponentInChildren<UnityEngine.UI.Text>().text = "1";//LocalizationSupport.GetString("NotAtAll");
		m_SliderNotSoMuch_1_8.GetComponentInChildren<UnityEngine.UI.Text>().text = "2";//LocalizationSupport.GetString("NotSoMuch");
		m_SliderSomewhat_1_8.GetComponentInChildren<UnityEngine.UI.Text>().text = "3";//LocalizationSupport.GetString("Somewhat");
		m_SliderVery_1_8.GetComponentInChildren<UnityEngine.UI.Text>().text = "4";//LocalizationSupport.GetString("Very");
		m_SliderExtremely_1_8.GetComponentInChildren<UnityEngine.UI.Text>().text = "5";//LocalizationSupport.GetString("Extremely");

		m_TextOther.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("PleaseDescribe");

		m_bIgnoreRatioButtons = false;


		string startquestionstime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("CurQuestStartQuestionsTime", startquestionstime);
		PlayerPrefs.Save ();

		loadQuestions ();
		//m_NrQuestions = m_Questions.questions.Length;
		m_NrQuestions = 7;//8;
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


		m_Text_1.SetActive (false);
		m_Text_1_1.SetActive (false);
		m_Text_1_2.SetActive (false);
		m_Slider_1_1.SetActive (false);
		m_Slider_1_2.SetActive (false);


		m_Text_2.SetActive (false);
		m_Text_2_1.SetActive (false);
		m_Text_2_2.SetActive (false);
		m_Text_2_3.SetActive (false);
		m_Text_2_4.SetActive (false);
		m_Text_2_5.SetActive (false);
		m_Text_2_6.SetActive (false);
		m_Slider_2_1.SetActive (false);
		m_Slider_2_2.SetActive (false);
		m_Slider_2_3.SetActive (false);
		m_Slider_2_4.SetActive (false);
		m_Slider_2_5.SetActive (false);
		m_Slider_2_6.SetActive (false);

		if (m_CurQuestion == 0) {
			m_Text_1.SetActive (true);
			m_Text_1_1.SetActive (true);
			m_Text_1_2.SetActive (true);
			m_Slider_1_1.SetActive (true);
			m_Slider_1_2.SetActive (true);
		} else if (m_CurQuestion == 1) {
			m_Text_2.SetActive (true);
			m_Text_2_1.SetActive (true);
			m_Text_2_2.SetActive (true);
			m_Text_2_3.SetActive (true);
			/*m_Text_2_4.SetActive (true);
			m_Text_2_5.SetActive (true);
			m_Text_2_6.SetActive (true);*/
			m_Slider_2_1.SetActive (true);
			m_Slider_2_2.SetActive (true);
			m_Slider_2_3.SetActive (true);
		/*	m_Slider_2_4.SetActive (true);
			m_Slider_2_5.SetActive (true);
			m_Slider_2_6.SetActive (true);*/
		} else if (m_CurQuestion == 2) {
			m_Text_2.SetActive (true);
			m_Text_2_4.SetActive (true);
			m_Text_2_5.SetActive (true);
			m_Text_2_6.SetActive (true);
			m_Slider_2_4.SetActive (true);
			m_Slider_2_5.SetActive (true);
			m_Slider_2_6.SetActive (true);
		} else if (m_CurQuestion == 3) {
			askOneChoice(LocalizationSupport.GetString("QuestionPark_3"), LocalizationSupport.GetString("QuestionPark_3_1"),
				LocalizationSupport.GetString("QuestionPark_3_2"), 
				LocalizationSupport.GetString("QuestionPark_3_3"),
				LocalizationSupport.GetString("QuestionPark_3_4"), 
				LocalizationSupport.GetString("QuestionPark_3_5"),
				LocalizationSupport.GetString("QuestionPark_3_6"), "",6, -1);
			
		}

		else if (m_CurQuestion == 4) {
		//	askOneChoice(LocalizationSupport.GetString("Question_5"), LocalizationSupport.GetString("Yes"), LocalizationSupport.GetString("No"), "Schlecht", "Kein Schatten", "Sonstige", "", "",2, -1);
			askCheckBoxes(LocalizationSupport.GetString("QuestionPark_4"), LocalizationSupport.GetString("QuestionPark_4_1"),
				LocalizationSupport.GetString("QuestionPark_4_2"), 
				LocalizationSupport.GetString("QuestionPark_4_3"),
				LocalizationSupport.GetString("QuestionPark_4_4"), 
				LocalizationSupport.GetString("QuestionPark_4_5"),
				LocalizationSupport.GetString("QuestionPark_4_6"), LocalizationSupport.GetString("QuestionPark_4_6"),6, 6);
		} else if (m_CurQuestion == 5) {
			askOneChoice(LocalizationSupport.GetString("QuestionPark_5"), LocalizationSupport.GetString("QuestionPark_5_1"),
				LocalizationSupport.GetString("QuestionPark_5_2"), 
				LocalizationSupport.GetString("QuestionPark_3_3"),
				LocalizationSupport.GetString("QuestionPark_3_4"), 
				LocalizationSupport.GetString("QuestionPark_3_5"),
				LocalizationSupport.GetString("QuestionPark_3_6"), "",2, -1);
			
		/*	askOneChoice(LocalizationSupport.GetString("Question_6"), LocalizationSupport.GetString("Question_6_1"),
				LocalizationSupport.GetString("Question_6_2"), 
				LocalizationSupport.GetString("Question_6_3"),
				LocalizationSupport.GetString("Question_6_4"), 
				LocalizationSupport.GetString("Question_6_5"), "", "",5, -1);*/

			//askOneChoice("How often do you come here?", "Every day", "Several times a week", "Once a week", "1-3 times a month", "Less than once a month", "", "",5, -1);
		} /*else if (m_CurQuestion == 6) {
			askOneChoice("Do you usually come here:", "Alone", "In company", "Once a week", "1-3 times a month", "Less than once a month", "", "",2, -1);
		} */else if (m_CurQuestion == 6) {

			askCheckBoxes(LocalizationSupport.GetString("QuestionPark_6"), LocalizationSupport.GetString("QuestionPark_6_1"),
				LocalizationSupport.GetString("QuestionPark_6_2"), 
				LocalizationSupport.GetString("QuestionPark_6_3"),
				LocalizationSupport.GetString("QuestionPark_6_4"), 
				LocalizationSupport.GetString("QuestionPark_6_5"), "", "",5, -1);
			//askCheckBoxes("With whom do you come here:", "Family", "Friends", "Relatives", "Work colleagues", "Other", "", "",5, 5);
		}else if (m_CurQuestion == 7) {

			askCheckBoxes(LocalizationSupport.GetString("Question_8"), LocalizationSupport.GetString("Question_8_1"),
				LocalizationSupport.GetString("Question_8_2"), 
				LocalizationSupport.GetString("Question_8_3"),
				LocalizationSupport.GetString("Question_8_4"), 
				LocalizationSupport.GetString("Question_8_5"), "", "",5, -1);
			//askCheckBoxes("What types of activities do you engage in here?", "Passing through", "Walking", "Socializing", "Relaxing", "Other", "", "",5, 5);
		}

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

		return;

		string text = "{";
		text += "questions:" + m_Questions.name + ",";
		text += "id:" + m_Questions.id + ",";


	/*
		string curquestid = PlayerPrefs.GetString ("CurQuestId");
		text += "questid:" + curquestid + ",";
		float strlat = PlayerPrefs.GetFloat ("CurQuestLat");
		float strlng = PlayerPrefs.GetFloat ("CurQuestLng");
		text += "lat:" + lat + ",";
		text += "lng:" + lng + ",";*/


	// Save sliders
	text += "{";/*
	text += "questionid:" + 0 + ",";
	text += "value1:" + m_Slider1.GetComponent<Slider> ().value + ",";
	text += "value2:" + m_Slider2.GetComponent<Slider> ().value + ",";
	text += "value3:" + m_Slider3.GetComponent<Slider> ().value + ",";
	text += "value4:" + m_Slider4.GetComponent<Slider> ().value;
	text += "},";

	text += "{";
	text += "questionid:" + 1 + ",";
		text += "value1:" + m_Slider5.GetComponent<Slider> ().value;
	text += "},";

	text += "{";
	text += "questionid:" + 2 + ",";
	text += "value1:" + m_Slider6.GetComponent<Slider> ().value + ",";
	text += "value2:" + m_Slider7.GetComponent<Slider> ().value + ",";
	text += "value3:" + m_Slider8.GetComponent<Slider> ().value + ",";
	text += "value1:" + m_Slider9.GetComponent<Slider> ().value + ",";
	text += "},";


	text += "{";
	text += "questionid:" + 3 + ",";
	text += "value2:" + m_Slider10.GetComponent<Slider> ().value + ",";
	text += "value3:" + m_Slider11.GetComponent<Slider> ().value + ",";
	text += "value4:" + m_Slider12.GetComponent<Slider> ().value;
	text += "},";


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
		}*/
		text += "}";
		Debug.Log ("SaveSurvey: " + text);

		PlayerPrefs.SetString ("Quest_Park_Questions", text);


		PlayerPrefs.Save ();
		Application.LoadLevel ("QuestFinished");
		return;
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

		Application.LoadLevel ("DemoMap");
	}

	public void TextChanged(string text)
	{
		Debug.Log ("TextChanged: " + text);
		m_StrText = text;
	}

	public void NextClicked () {
		int jumpto = -1;

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
			m_Answers [m_CurQuestion].m_Text = m_StrText;

			if (m_Radio1.GetComponent<Toggle> ().isOn) {
			Debug.Log ("Curquestion: " + m_CurQuestion + "Radio 1");
				m_Answers [m_CurQuestion].m_bCheck1 = true;
			/*
				if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 0) {
					if (m_Questions.questions [m_CurQuestion].answers [0].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [0].jumpto;
					}
				}*/
				if (m_CurQuestion == 5) {
					m_CurQuestion = m_NrQuestions;
				}
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
				Debug.Log ("Curquestion: " + m_CurQuestion + "Radio 6");
				m_Answers [m_CurQuestion].m_bCheck6 = true;
				/*if (m_Questions.questions [m_CurQuestion].answers != null && m_Questions.questions [m_CurQuestion].answers.Length > 5) {
					if (m_Questions.questions [m_CurQuestion].answers [5].jumpto != 0) {
						jumpto = m_Questions.questions [m_CurQuestion].answers [5].jumpto;
					}
				}*/

				if (m_CurQuestion == 3) {
					m_CurQuestion = m_NrQuestions;
				}
			
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

	/*
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
		}*/
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

		if (m_CurQuestion < m_NrQuestions) {
			updateStates ();
		} else {
			m_ImageUploading.SetActive (true);
			m_TextUploading.SetActive (true);
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

		if (m_CurQuestion >= 0) {
			/*if (m_Questions.questions [m_CurQuestion].jumptoprev != 0) {
				m_CurQuestion = getQuestionNr (m_Questions.questions [m_CurQuestion].jumptoprev);
			}*/
		} else {
			m_CurQuestion = 0;
			PlayerPrefs.SetInt ("CameraStartLastStep", 1);
			PlayerPrefs.Save ();
			Application.LoadLevel ("TestCamera");
		}
	if (m_CurQuestion >= 0) {
		updateStates ();
	} 
}

} 




