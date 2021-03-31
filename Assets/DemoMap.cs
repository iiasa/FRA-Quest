//#define DEBUGAPP

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using Unitycoding.UIWidgets;
using UnityEngine.UI;
//using Signalphire;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Text;
//using Signalphire;
//using  UTNotifications;
using Vatio.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;



public class PuzzlePin
{
	public int m_ChunkId;
	public int m_Id;
	public double m_Lat;
	public double m_Lng;

	public PuzzlePin()
	{
	}
}

public class DemoMap : MonoBehaviour
{
	public Transform camera2D;
	public Transform camera3D;

	public Shader tileShader;

	public float CameraChangeTime = 1;

	private GUIStyle activeRowStyle;
	private float animValue;
	private OnlineMaps api;
	private OnlineMapsTileSetControl control;
	private bool is2D = false;//true;
	private bool isCameraModeChange;
	private GUIStyle rowStyle;
	private string search = "";
	private OnlineMapsMarker searchMarker;

	private Transform fromTransform;
	private Transform toTransform;

	public GameObject m_MapDeactivated;

	bool m_bIn2dMap;
	bool m_bTo2dMap;
	float m_To2dMapTimer;
	public GameObject m_BtnTo2dMap;


	bool m_bTo3dMap;
	float m_To3dMapTimer;
	public GameObject m_BtnTo3dMap;

	bool m_bDebug;


	private MessageBoxNews messageBox;
	private MessageBox messageBoxSmall;
	private MessageBox messageBoxSmall2;/*
	int m_ShowMsgBox;
	bool m_bShownMsgBox;
	bool m_bShowingMsgBox;
	bool m_bMsgBoxLoaded;
	string m_MsgBoxText;
	public Image m_MsgBoxImg;*/


	private OnlineMapsMarker playerMarker;
	private OnlineMapsMarker3D playerMarker3D;
	//private OnlineMapsMarker playerDirection;
	private OnlineMapsMarker3D playerDirection2;
//	private OnlineMapsMarker3D playerDirection2White;
	float m_DirectionSize = 20.0f;
	float m_DirectionSizeWhite = 30.0f;

	public FotoQuestPin[] m_Pins;
	public int m_NrPins;
	public FotoQuestPin m_SelectedPin;
	public bool m_bSelectedPin = false;
//	public OnlineMapsDrawingLine m_LineToPin = null;
	/*public FotoQuestPin[] m_PinsDone;
	public int m_NrPinsDone;*/
	bool m_bHasAlreadyLoadedPins = false;

	//-------------------------------
	// Additional info
	private Vector2 m_PlayerPositionStart;
	int m_NrPlayerPositions;
	private Vector2 m_PlayerLastPosition;
	private Vector2[] m_PlayerPositions;
	private string m_QuestSelectedTime;
	float m_DistanceWalked;
	private Vector2 m_DistanceWalkedLastCheckpoint;
	//-------------------------------

	int m_InnerDistance = 30;
	int m_NearDistance = 100;
	int m_OuterDistance = 500;

	bool m_bInReachOfPoint;

	/*
	public PuzzlePin[] m_PuzzlePins;
	public int m_NrPuzzlePins;*/
	/*
	public Texture2D m_Pin;
	public Texture2D m_PinRed;
	public Texture2D m_PinYellow;*/

	float m_ConquerBackShiftX;
	bool m_bConquerShiftSet;
	int m_bConquerShiftPosition;

	public GameObject m_MenuSlidin;
	public GameObject m_MenuToggleButton;
	bool m_bMenuOpened;


/*	public GameObject m_MenuFilter;
	public GameObject m_MenuFilterToggleButton;
	bool m_bMenuFilterOpened;*/


/*	public GameObject m_MenuMap;
	public GameObject m_MenuMapToggleButton;*/
	bool m_bMenuMapOpened;

	public Texture2D m_LineTexture;
	/*

	public Texture2D m_SelectedPinBlue;
	public Texture2D m_SelectedPinRed;
	public Texture2D m_SelectedPinYellow;*/

	//public Texture2D m_PinPosition;
	//public Texture2D m_PinDirection;
	//public GameObject m_PinDirectionMesh;
	public GameObject m_PinPlane;
	public GameObject m_PinPlaneYellow;
	public GameObject m_PinPlaneRed;
	public GameObject m_PinPlaneGreen;
	public GameObject m_PinPlaneSelected;
	public GameObject m_PinPlaneGreenSelected;
	public GameObject m_PlanePosition;
	//public GameObject m_PinDirectionMeshWhite;
	public bool m_bNearPinSetup;
	public float m_NearPinX;
	public float m_NearPinY;
	public GameObject m_PinCluster;
	public GameObject m_PinClusterText;

	//public Texture2D m_Puzzle;

	int m_bLoadMarkers = 0;

	public GameObject m_DistanceBack;
	public GameObject m_DistanceBack2d;
	public GameObject m_DistanceBackHorizon;
	public GameObject m_DistanceText;
	public GameObject m_DistanceText2;
	//public GameObject m_ButtonZoomIn;
	//public GameObject m_ButtonZoomOut;
	//public GameObject m_ButtonFollowGPS;
	public GameObject m_ButtonZoomInTop;
	public GameObject m_ButtonZoomOutTop;
	public GameObject m_ButtonFollowGPSTop;
	//float m_ButtonHeightPosition;

	public GameObject m_ButtonToPosBright;
	public GameObject m_ButtonToPosDark;
	public GameObject m_ButtonToPosBrightBottom;
	public GameObject m_ButtonToPosDarkBottom;
	public GameObject m_ButtonLayerBright;
	public GameObject m_ButtonLayerDark;


	//public GameObject m_TextInput;

	bool m_bStartReadGPS = true;
	bool m_bFollowingGPS = true;//true;

	public GameObject m_IconLogin;
	public GameObject m_IconLogout;
	/*
	public GameObject m_MenuBack;
	public GameObject m_MenuButtonExit;
	public GameObject m_MenuButtonNews;
	public GameObject m_MenuButtonUpload;
	public GameObject m_MenuButtonLeaderboard;
	public GameObject m_MenuButtonPuzzle;
	public GameObject m_MenuButtonChat;
	public GameObject m_MenuButtonProfile;
	public GameObject m_MenuButtonMore;
	public GameObject m_MenuButtonFB;
	public GameObject m_MenuButtonTwitter;
	public GameObject m_MenuButtonMail;*/


	public GameObject m_TextTest;

	/*bool m_bMenuOpen;
	float m_MenuOpenTimer;*/

//	bool m_bMenuSelectionOpen;
	/*public GameObject m_MenuSelectionBack;
	public GameObject m_MenuSelectionBack2;
	public GameObject m_MenuSelectionHello;
	public GameObject m_MenuSelectionHelloPortrait;*/
	public GameObject m_MenuSelectionButtonLogout;
	public GameObject m_MenuSelectionButtonIntroduction;
	public GameObject m_MenuSelectionButtonTerms;
	public GameObject m_MenuSelectionButtonChat;
	public GameObject m_MenuSelectionButtonManual;
	public GameObject m_MenuSelectionButtonGuidelines;
	public GameObject m_MenuSelectionButtonContact;
	public GameObject m_MenuSelectionButtonHomepage;
	public GameObject m_MenuSelectionProfile;
	public GameObject m_MenuSelectionButtonCancel;
	public GameObject m_MenuSelectionButtonClose;

	public GameObject m_Sky;
	public GameObject m_Sky2;

	public GameObject m_Tooltip;
	public GameObject m_TooltipBack;
	public GameObject m_TooltipBackBig;
	public GameObject m_TooltipText;
	public GameObject m_ButtonShowPictures;

	public GameObject m_TooltipLeft;
	public GameObject m_TooltipBackLeft;
	public GameObject m_TooltipBackBigLeft;
	public GameObject m_TooltipBackBigLeftLeft;
	public GameObject m_TooltipTextLeft;
	public GameObject m_ButtonShowPicturesLeft;


	//public GameObject m_ButtonPickPuzzle;
	public GameObject m_ButtonStartQuest;
	public GameObject m_TextStartQuest;
//	public GameObject m_ButtonStartQuestHighlighted;
//	public GameObject m_ButtonNearlyStartQuest;
	public GameObject m_ButtonPointNotReachable;

	public GameObject m_StartQuestBackground;
	public GameObject m_StartQuestBackgroundLine;

	/*float m_FoundPuzzleTimer;
	public GameObject m_TextFoundPuzzle;
	public GameObject m_BackFoundPuzzle;*/

	bool m_bShowWelcome;
	float m_WelcomeTimer;
	public GameObject m_TextWelcome;
	public GameObject m_BackWelcome;

	bool m_bCheckInternet;
	float m_CheckInternetTimer;

	public GameObject m_TextDebug;
	public GameObject m_BackDebug;
	string m_StrTextDebug;
	public GameObject m_TextLocationOutside;
	public GameObject m_BackLocationOutside;


	public GameObject m_DebugLine;
	public GameObject m_DebugLine2;

	float m_LocationLatDisabled;
	float m_LocationLngDisabled;

	//===============================
	// Progress bar

	public float g_LevelProgress = 0.0f; //current progress
	public Vector2 g_LevelPos = new Vector2(20,40);
	public Vector2 g_LevelSize = new Vector2(800,2000);
	public Texture2D g_LevelEmptyText;
	public Texture2D g_LevelFullText;



	//===============================
	// Level reached

	public GameObject m_LevelReachedBack;
	public GameObject m_LevelReachedName;
	public GameObject m_LevelReachedProgBack;
	public GameObject m_LevelReachedFront;
	public GameObject m_LevelReachedScorePoints;
	public GameObject m_LevelReachedProgress;
	public GameObject m_LevelReachedOk;
	public GameObject m_LevelReachedShare;
	public GameObject m_LevelReachedShareFB;
	public GameObject m_LevelReachedShareTwitter;


	bool m_bZoomTouched;

	//-------------------
	// Animations
	//public Animator m_AnimLeaderboard;

	int m_NrQuestsDone;

	//int m_PuzzlesInReachWait;

	private void ChangeMode()
	{
		/*is2D = !is2D;

		animValue = 0;
		isCameraModeChange = true;

		Camera c = Camera.main;
		fromTransform = is2D ? camera3D : camera2D;
		toTransform = is2D ? camera2D : camera3D;

		c.orthographic = false;
		if (!is2D)
			c.fieldOfView = 28;//15;//28;
			*/
	}

	private void OnGUI()
	{
		/*if (api == null) api = OnlineMaps.instance;
		int labelFontSize = GUI.skin.label.fontSize;
		int buttonFontSize = GUI.skin.button.fontSize;
		int toggleFontSize = GUI.skin.toggle.fontSize;
		int textFieldFontSize = GUI.skin.textField.fontSize;
		GUI.skin.label.fontSize = 20;
		GUI.skin.button.fontSize = 20;
		GUI.skin.toggle.fontSize = 20;
		GUI.skin.toggle.contentOffset = new Vector2(5, -5);
		GUI.skin.textField.fontSize = 20;
/**/
		/*if (GUI.Button(new Rect(5, 5, 200, 200), is2D ? "3D" : "2D") && !isCameraModeChange)
		{
			ChangeMode();
		}/**/

	/*	if (rowStyle == null)
		{
			rowStyle = new GUIStyle(GUI.skin.button);
			RectOffset margin = rowStyle.margin;
			rowStyle.margin = new RectOffset(margin.left, margin.right, 1, 1);
		}

		if (activeRowStyle == null)
		{
			activeRowStyle = new GUIStyle(GUI.skin.button);
			activeRowStyle.normal.background = activeRowStyle.hover.background;
			RectOffset margin = activeRowStyle.margin;
			activeRowStyle.margin = new RectOffset(margin.left, margin.right, 1, 1);
		}
		/*
		if (GUI.Button (new Rect (5, 60, 50, 50), "+")) {
			api.zoom++;
			loadPins ();
		}
*/
	//	Color defBackgroundColor = GUI.backgroundColor;
		/*
            for (int i = 20; i > 2; i--)
            {
                if (api.zoom == i) GUI.backgroundColor = Color.green;
                if (GUI.Button(new Rect(5, 115 + (20 - i) * 15, 50, 10), "")) api.zoom = i;
                GUI.backgroundColor = defBackgroundColor;
            }*/

		//if (GUI.Button(new Rect(5, 390, 50, 50), "-")) api.zoom--;
		/*if (GUI.Button (new Rect (5, 120, 50, 50), "-")) {
			api.zoom--;
			loadPins ();
		}*/
		/*
		if (GUI.Button (new Rect (5, 200, 50, 50), "0")) {
			toPlayerPosition ();/*
			if (m_bLoadMarkers != 10) {
				m_bLoadMarkers = 10;
			} else {
				m_bLoadMarkers = 0;
			}*/
	//	}
		/*
            GUI.Box(new Rect(65, 5, Screen.width - 70, 75), "");

            GUI.Label(new Rect(75, 10, 150, 50), "Find place:");
            search = GUI.TextField(new Rect(200, 10, Screen.width - 320, 30), search);
            if (Event.current.type == EventType.KeyUp && (Event.current.keyCode == KeyCode.KeypadEnter || Event.current.keyCode == KeyCode.Return)) OnlineMapsFindLocation.Find(search).OnComplete += OnFindLocationComplete;
            if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 30), "Search")) OnlineMapsFindLocation.Find(search).OnComplete += OnFindLocationComplete;

            GUI.Label(new Rect(75, 45, 100, 30), "Show:");

            api.labels = GUI.Toggle(new Rect(200, 50, 100, 30), api.labels, "Labels");
            api.traffic = GUI.Toggle(new Rect(300, 50, 100, 30), api.traffic, "Traffic");
            control.useElevation = !is2D && GUI.Toggle(new Rect(400, 50, 110, 30), control.useElevation, "Elevation");
*/
		/*GUI.skin.label.fontSize = labelFontSize;
		GUI.skin.button.fontSize = buttonFontSize;
		GUI.skin.toggle.fontSize = toggleFontSize;
		GUI.skin.toggle.contentOffset = Vector2.zero;
		GUI.skin.textField.fontSize = textFieldFontSize;
			*/


			//---------------------------------
			// Progress bar

			//draw the background:
		/*	GUI.BeginGroup(new Rect(g_LevelPos.x, g_LevelPos.y, g_LevelSize.x, g_LevelSize.y));
			GUI.Box(new Rect(0,0, g_LevelSize.x, g_LevelSize.y), g_LevelEmptyText);

			//draw the filled-in part:
			GUI.BeginGroup(new Rect(0,0, g_LevelSize.x * g_LevelProgress, g_LevelSize.y));
			GUI.Box(new Rect(0,0, g_LevelSize.x, g_LevelSize.y), g_LevelFullText);
			GUI.EndGroup();
			GUI.EndGroup();*/

	}

	private void OnFindLocationComplete(string result)
	{
/*		Vector2 position = OnlineMapsFindLocation.GetCoordinatesFromResult(result);

		if (position == Vector2.zero) return;

		if (searchMarker == null) searchMarker = api.AddMarker(position, search);
		else
		{
			searchMarker.position = position;
			searchMarker.label = search;
		}

		if (api.zoom < 13) api.zoom = 13;

		api.position = position;
		api.Redraw();*/
	}

	void enableZoomButtons() {
		/*	if (api.zoom <= 6) {//10) {// 12) {
			m_ButtonZoomOutTop.SetActive (false);
		} else {*/
	/*		m_ButtonZoomOutTop.SetActive (true);
	//	}

		if (api.zoom >= 20) {
			m_ButtonZoomInTop.SetActive (false);
		} else {
			m_ButtonZoomInTop.SetActive (true);
		}*/
	}
	public void zoomOut()
	{
		Debug.Log (">> zoomOut");
		m_bHasZoomed = true;
		m_bZoomTouched = true;
		//if(api.zoom <= 10) {
			/*if(api.zoom <= 6) {//10) {//12) {
			m_ButtonZoomOutTop.SetActive (false);
			return;
		}*/
		
		api.zoom--;
		//closePinInfo ();
		enableZoomButtons ();
		m_bForceUpdate = true;
		Debug.Log ("Zoom: " + api.zoom);
		loadPins (); // Commented out
	}

	public void zoomOutSlow()
	{
		//Debug.Log(">> zoomOut");
		m_bHasZoomed = true;
		m_bZoomTouched = true;

		api.floatZoom *= 0.97f;// 0.985f;// 0.98f;//-= 0.15f;// 0.2f;// 0.25f;//*= 0.99f;// 0.98f;// 0.97f;// 0.95f;// 0.9f;//-= 0.25f;// 0.5f;// 0.3f;// 0.4f;// 0.3f;// 0.2f;
		//closePinInfo ();
		enableZoomButtons();
		m_bForceUpdate = true;
		//Debug.Log("Zoom: " + api.zoom);
		loadPins(); // Commented out
	}
	public void zoomIn()
	{
		Debug.Log (">> zoomIn");
		m_bHasZoomed = true;
		m_bZoomTouched = true;
		api.zoom++;
		m_bForceUpdate = true;
		//closePinInfo ();
		enableZoomButtons ();

		Debug.Log ("Zoom: " + api.zoom);
		loadPins (); // Commented out
	}
	public void followGPS()
	{
		m_bFollowingGPS = true;
	//	m_ButtonFollowGPS.SetActive (false);
		toPlayerPosition ();

		loadPins (); // Commented out
	}

		public void onFilterClicked()
		{
			ToggleMenuFilter ();
		}

		public void onMapTypeClicked()
		{
			/*OnlineMapsProvider[] providers = OnlineMapsProvider.GetProviders();
			foreach (OnlineMapsProvider provider in providers)
			{
				Debug.Log(provider.id);
				foreach (OnlineMapsProvider.MapType type in provider.types)
				{
					Debug.Log(type);
				}
			}*/
		//Debug.Log (">>> Maptype: " + OnlineMaps.instance.mapType);
		//OnlineMaps.instance.mapType = "google.relief";
		/*	int maptype = 1;
			if (PlayerPrefs.HasKey ("MapType")) {
				maptype = PlayerPrefs.GetInt ("MapType");
			}

		maptype++;
		if (maptype > 1) {
			maptype = 0;
		}
		PlayerPrefs.SetInt ("MapType", maptype);
		PlayerPrefs.Save ();
		Application.LoadLevel ("DemoMap");*/
		///"google.terrain";
			/// google.satellite
		//	OnlineMaps.instance.mapType = "google.satellite"; // providerID.typeID
	//		OnlineMaps.instance.mapType = "arcgis"; 
			ToggleMenuMap ();
		}

	public class MarkerComparer2 : System.Collections.Generic.IComparer<OnlineMapsMarker3D>
	{
		public DemoMap m_pDemoMap;

		public int Compare(OnlineMapsMarker3D m1, OnlineMapsMarker3D m2)
		{
			if (m1.position.y > m2.position.y) return -1;
			if (m1.position.y < m2.position.y) return 1;
			return 0;
		}
	}


	public class MarkerComparer : System.Collections.Generic.IComparer<OnlineMapsMarker>
	{
		public DemoMap m_pDemoMap;

		public int Compare(OnlineMapsMarker m1, OnlineMapsMarker m2)
		{
			if (m1.position.y > m2.position.y) return -1;
			if (m1.position.y < m2.position.y) return 1;
			return 0;
		}
	}


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

	ArrayList m_QuestsMade;

		bool m_bBlackGui = false;
	/*ArrayList m_PuzzlesPicked_ChunkId;
	ArrayList m_PuzzlesPicked_Id;
	int m_NrPuzzlesPicked;*/
	private void Start()
	{
		StartCoroutine(changeFramerate());
		ForceLandscapeLeft ();

		if ((!LocalizationSupport.StringsLoaded))
			LocalizationSupport.LoadStrings();

			m_UploadImageTest.SetActive (false);

		m_DistanceBack2d.SetActive (false);
		m_DistanceText2.SetActive (false);
		m_DistanceText.SetActive (false);
		m_DistanceBack.SetActive (false);

		m_TextLocationOutside.SetActive (false);
			m_BackLocationOutside.SetActive (false);
		UnityEngine.UI.Text textdebug = m_TextLocationOutside.GetComponent<UnityEngine.UI.Text> ();
		if (Application.systemLanguage == SystemLanguage.German ) {
		//	m_ButtonStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Ich befinde mich genau am Punkt.";
	//		m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Ich kann den Punkt nicht erreichen.";

			//textdebug.text = "FotoQuest Go ist momentan nur in Österreich verfübar.";
		}  else {
			//m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().text = "I can't reach\nthe point.";
			//textdebug.text = "FotoQuest Go is currently only available in Austria.";
		}
		m_BackLocationOutside.GetComponent<Image> ().color = new Color32 (255, 255, 255, 240);//new Color32(255,255,255,240);
	
			m_TextStartQuest.GetComponent<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("StartQuest");
			m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("CantReach");//"Ich kann den Punkt nicht erreichen.";


		m_MenuToggleLayer1.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("SatelliteMap");
		m_MenuToggleLayer2.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("StreetMap");
		m_MenuToggleLayer3.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("OfflineMap");

		m_bHasAlreadyLoadedPins = false;

		m_PinInfoClosedIter = 0;
		m_bPinInfoClosed = false; 

		m_NotificationIter = 0;
		m_bMenuOpened = false;
		m_MenuToggleButton.SetActive (false);


		/*	m_bMenuFilterOpened = false;
		m_MenuFilterToggleButton.SetActive (false);
        */

			m_bMenuMapOpened = false;
			//m_MenuMapToggleButton.SetActive (false);

		m_bInReachOfPoint = false;

		m_bZoomTouched = false;

		m_ButtonFollowGPSTop.SetActive (false);

		m_bIn2dMap = true;//false;
		m_CameraPitch = 90.0f;
		m_bTo2dMap = false;
		m_bTo3dMap = false;
		m_To2dMapTimer = 0.0f;
		/*m_BtnTo2dMap.SetActive (true);
		m_BtnTo3dMap.SetActive (false);*/
		m_BtnTo2dMap.SetActive (false);
		m_BtnTo3dMap.SetActive (true);
		m_BtnTo3dMap.SetActive (false);


	//	PlayerPrefs.DeleteAll ();
		m_bConquerShiftSet = false;

		m_bDebug = false;//false;//true;//false;//false;//true;// true;//true;// true;//true;//false;//true;//false;//false;//false;//true;//true;
		if (PlayerPrefs.HasKey ("DebugEnabled")) {
			if (PlayerPrefs.GetInt ("DebugEnabled") == 1) {
				m_bDebug = true;
			}
		}
		//m_bDebug = true;

		if(!m_bDebug)
        {
			m_MapDeactivated.SetActive(true);
        }
        else
        {
			m_MapDeactivated.SetActive(false);
		}
	

		hidePics ();

		messageBox = UIUtility.Find<MessageBoxNews> ("MessageBoxNews");
		messageBoxSmall = UIUtility.Find<MessageBox> ("MessageBoxSmall");
		messageBoxSmall2 = UIUtility.Find<MessageBox> ("MessageBoxSmall2");
			/*
		int openmsg = PlayerPrefs.GetInt ("OpenMsg");
		if (PlayerPrefs.HasKey("OpenMsg") && openmsg != 1) {
			m_bShownMsgBox = true;
		} else {
			PlayerPrefs.SetInt ("OpenMsg", 0);
			PlayerPrefs.Save ();
		}*/


		m_bLineInited = false;
		m_bLineVisible = false;
		g_LevelPos = new Vector2(20,40);
		g_LevelSize = new Vector2(500,50);

		m_PlayerPositions = new Vector2[50];

	//	m_LocationLatDisabled = 48.210033f;
	//	m_LocationLngDisabled = 16.363449f;
		m_LocationLatDisabled = -10.0f;
		m_LocationLngDisabled = 0.0f;

		// Todo: comment this out again
		m_LocationLatDisabled = 48.210033f;
		m_LocationLngDisabled = 16.363449f;
		// RELEASE MODE: turn this to 0, 0

		m_InnerDistance = 30;
		m_NearDistance = 100;
		m_OuterDistance = 500;

		if (m_bDebug /*|| true*/) { // Todo: comment true out again
			m_LocationLatDisabled = 48.210033f;
			m_LocationLngDisabled = 16.363449f;

			// Argentinia
			m_LocationLatDisabled = -24.1858f;
			m_LocationLngDisabled = -65.2995f;

			// Cordoba
			/*m_LocationLatDisabled = 37.8882f;
			m_LocationLngDisabled = -4.7794f;


			// Buenos Aires
			m_LocationLatDisabled = -34.6037f;
			m_LocationLngDisabled = -58.3816f;
			*/

			// Rome
			/*m_LocationLatDisabled = 41.9028f;
			m_LocationLngDisabled = 12.4964f;*/




			/*	m_LocationLatDisabled = 48.210033f;
				m_LocationLngDisabled = 17.363449f;*/


			//m_LocationLatDisabled = 48.210033f + 0.002f;//- 0.005f;
			//	m_LocationLngDisabled = 17.363449f - 0.02f;

			/*m_InnerDistance = 1000;
			m_NearDistance = 100000;
			m_OuterDistance = 100000000;
*/

			m_InnerDistance =  50000000;
			m_NearDistance =   50000000;


				m_OuterDistance = 50000000;

				/*
				m_InnerDistance =  5;
				m_NearDistance =   5;
				m_OuterDistance = 10;*/
				/*
				m_LocationLatDisabled = 52.3619f;//52.379189f;//48.210033f;
				m_LocationLngDisabled = 4.84782f;//16.363449f;
				m_LocationLngDisabled = 4.84882f;//16.363449f;*/
		}

		/*	m_InnerDistance = 30;
			m_NearDistance = 100;
			m_OuterDistance = 500;
*/


		



		//======================

		m_bShowWelcome = false;
		m_WelcomeTimer = 0.0f;
		m_TextWelcome.SetActive (false);
		m_BackWelcome.SetActive (false);

		OnCloseLevelReached ();


		m_bCheckInternet = false;
		m_CheckInternetTimer = 0.0f;

	/*	m_MenuSelectionHello.SetActive (false);
		m_MenuSelectionHelloPortrait.SetActive (false);
*/
		m_bCameraHeadingSet = false;

		m_bLocationGPSDisabled = false;
		m_LocationGPSDisabledIter = 0;

		//m_PuzzlesInReachWait = 0;

		m_StrTextDebug = "";

		m_bNearPinSetup = false;

		m_TextDebug.SetActive (true);
		m_BackDebug.SetActive (true);
		
		textdebug = m_TextDebug.GetComponent<UnityEngine.UI.Text>();
		/*if (Application.systemLanguage == SystemLanguage.German) {
			textdebug.text = "GPS-Position wird ermittelt..";
		} else {
			textdebug.text = "Loading GPS location...";
		}*/
			textdebug.text = LocalizationSupport.GetString("LoadingGPS");

		m_BackDebug.GetComponent<Image>().color = new Color32(255,255,255,240);//new Color32(255,255,255,240);







/*		m_bSelectedPuzzle = false;
		m_bPuzzleInReach = false;
		m_PuzzleInReachMarker = null;*/

		/*m_ButtonPickPuzzle.SetActive (false);
		m_TextFoundPuzzle.SetActive (false);
		m_BackFoundPuzzle.SetActive (false);*/

		m_bLoadMarkers = 0;

		//PlayerPrefs.DeleteAll (); // Comment this out
		m_bLocationEnabled = false;
		




//		m_bMenuOpen = false;
	//	m_bMenuSelectionOpen = false;
	//	m_MenuSelectionBack.SetActive (false);
//		m_MenuSelectionBack2.SetActive (false);
			/*
		m_MenuSelectionButtonLogout.SetActive (false);
		m_MenuSelectionButtonIntroduction.SetActive (false);
		m_MenuSelectionButtonManual.SetActive (false);
		m_MenuSelectionButtonGuidelines.SetActive (false);
		m_MenuSelectionButtonContact.SetActive (false);
		m_MenuSelectionButtonHomepage.SetActive (false);
		m_MenuSelectionButtonCancel.SetActive (false);*/

		if (PlayerPrefs.HasKey ("NrQuestsDone")) {
			m_NrQuestsDone = PlayerPrefs.GetInt ("NrQuestsDone");
		} else {
			m_NrQuestsDone = 0;
		}
        /*
		m_bAskSurvey = false;
		if (m_NrQuestsDone >= 5) {
			//if (PlayerPrefs.HasKey ("SurveyParkDone") == false) {
			if (PlayerPrefs.HasKey ("ProfileSaved") == false && PlayerPrefs.HasKey ("PlayerMail")) {
				m_bAskSurvey = true;
			}
		}*/


		//Debug.Log ("Quests made: " + m_NrQuestsDone);
		m_QuestsMade = new ArrayList();
		for (int i = 0; i < m_NrQuestsDone; i++) {
			string strdeleted = "Quest_" + i + "_Del";
			int deleted = 0;
			if (PlayerPrefs.HasKey (strdeleted)) {
				deleted = PlayerPrefs.GetInt (strdeleted);
			}

			if (deleted == 0) {
				//string stralreadyuploadedquest = "Quest_" + i + "_Uploaded";
				//if (PlayerPrefs.HasKey (stralreadyuploadedquest) == false) {
				string questdone = PlayerPrefs.GetString ("Quest_" + i + "_Id");
				m_QuestsMade.Add (questdone);

			//	Debug.Log ("Quest made: " + questdone);
			}
		}

		/*m_PuzzlesPicked_ChunkId = new ArrayList();
		m_PuzzlesPicked_Id = new ArrayList();
		m_NrPuzzlesPicked = 0;
		if (PlayerPrefs.HasKey ("NrPuzzlesPicked")) {
			m_NrPuzzlesPicked = PlayerPrefs.GetInt ("NrPuzzlesPicked");
		}  
		Debug.Log ("NrPuzzlesPicked: " + m_NrPuzzlesPicked);
		for (int i = 0; i < m_NrPuzzlesPicked; i++) {
			int puzzlechunkid = PlayerPrefs.GetInt("Puzzle_" + i + "_ChunkId");
			int puzzleid = PlayerPrefs.GetInt("Puzzle_" + i + "_Id");

		Debug.Log ("Chunkid: " + puzzlechunkid + " id: " + puzzleid);
			m_PuzzlesPicked_ChunkId.Add (puzzlechunkid);
			m_PuzzlesPicked_Id.Add (puzzleid);
		}
*/

		if (Application.systemLanguage == SystemLanguage.German ) {
			if (PlayerPrefs.HasKey ("PlayerId")) {
					m_MenuSelectionButtonLogout.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Logout");//"Ausloggen";
				m_IconLogin.SetActive (false);
				m_IconLogout.SetActive (true);
			} else {
					m_MenuSelectionButtonLogout.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("RegisterLogin");//"Registrieren/Einloggen";
				m_IconLogin.SetActive (true);
				m_IconLogout.SetActive (false);
			}

		/*	string welcomemsg = "Hallo, Gast.";
			if (PlayerPrefs.HasKey ("PlayerName")) {
				welcomemsg = "Hallo, " + PlayerPrefs.GetString ("PlayerName") + ".";
			} else if (PlayerPrefs.HasKey ("PlayerMail")) {
					welcomemsg = "Hallo, " + PlayerPrefs.GetString ("PlayerMail") + ".";
			}

			m_MenuSelectionHello.GetComponent<UnityEngine.UI.Text> ().text = welcomemsg;
			m_MenuSelectionHelloPortrait.GetComponent<UnityEngine.UI.Text> ().text = welcomemsg;
*/
				m_TextLocationOutside.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoadingPoints");
				m_MenuSelectionButtonIntroduction.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuIntroduction");//"Einleitung";
				m_MenuSelectionButtonTerms.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuTerms");//"Teilnahmebedingungen";
				m_MenuSelectionButtonChat.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuNotifications");//"Benachrichtigungen";
				m_MenuSelectionButtonManual.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuIntroduction");//MenuManual");//"Anleitung";
				m_MenuSelectionButtonGuidelines.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuOfflineMap");//"Richtlinien";
				m_MenuSelectionButtonContact.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuImpressum");//"Impressum";
				m_MenuSelectionButtonHomepage.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuContact");//"Kontakt";
				m_MenuSelectionButtonCancel.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuClose");//"Schließen";
			m_MenuSelectionButtonClose.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("MenuClose");//"Schließen";
			m_MenuSelectionProfile.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("MenuProfile");//"Schließen";

			//	m_ButtonStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Starte\nQuest!";
			//	m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Punkt\nnicht\nerreichbar";
			//		m_ButtonNearlyStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Komme\nnicht\nnäher";

			//	m_ButtonPickPuzzle.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Puzzle\neinsammeln!";
			//		m_TextFoundPuzzle.GetComponent<UnityEngine.UI.Text> ().text = "Du hast ein Puzzleteil gefunden!";

			//	m_TextWelcome.GetComponent<UnityEngine.UI.Text> ().text = "Willkommen zu FotoQuest Go. Da ist ein Punkt in deiner Nähe. Versuche ihn zu erreichen.";
			m_TextWelcome.GetComponent<UnityEngine.UI.Text> ().text = "Willkommen.";

		/*	m_MenuButtonNews.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Neuigkeiten";
			m_MenuButtonUpload.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Quests\nhochladen";
			m_MenuButtonLeaderboard.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Rangliste";
			m_MenuButtonPuzzle.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Erfolge";
			m_MenuButtonProfile.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Profil";

			m_MenuButtonMore.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Mehr";


			m_MenuButtonExit.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Zurück";*/

			m_ButtonShowPictures.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Bilder zeigen";
			m_ButtonShowPicturesLeft.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Bilder zeigen";

		} else {
			if (PlayerPrefs.HasKey ("PlayerId")) {
					m_MenuSelectionButtonLogout.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("Logout");//"Logout";
				m_IconLogin.SetActive (false);
				m_IconLogout.SetActive (true);
			} else {
					m_MenuSelectionButtonLogout.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("RegisterLogin");//"Register/Login";
				m_IconLogin.SetActive (true);
				m_IconLogout.SetActive (false);
			}
				m_TextLocationOutside.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("LoadingPoints");

				m_MenuSelectionButtonIntroduction.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuIntroduction");//"Einleitung";
				m_MenuSelectionButtonTerms.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuTerms");//"Teilnahmebedingungen";
				m_MenuSelectionButtonChat.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuNotifications");//"Benachrichtigungen";
				m_MenuSelectionButtonManual.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuIntroduction");//"Anleitung";
            m_MenuSelectionButtonGuidelines.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuOfflineMap");//"Richtlinien";
				m_MenuSelectionButtonContact.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuImpressum");//"Impressum";
				m_MenuSelectionButtonHomepage.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuContact");//"Kontakt";
				m_MenuSelectionButtonCancel.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuClose");//"Schließen";
				m_MenuSelectionButtonClose.GetComponentInChildren<UnityEngine.UI.Text> ().text = LocalizationSupport.GetString("MenuClose");//"Schließen";
			m_MenuSelectionProfile.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("MenuProfile");//"Schließen";


			//m_ButtonStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Start\nQuest!";
			//	m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Can't\nreach\npoint";
			//	m_ButtonNearlyStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Can't\nget\ncloser";

			//m_ButtonPickPuzzle.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Pick up\npuzzle!";
			//m_TextFoundPuzzle.GetComponent<UnityEngine.UI.Text> ().text = "You have found a puzzle piece!";


			//m_TextWelcome.GetComponent<UnityEngine.UI.Text> ().text = "Welcome to FotoQuest Go. There's a point right in your reach. Try to go there.";
			m_TextWelcome.GetComponent<UnityEngine.UI.Text> ().text = "Welcome.";

		/*	m_MenuButtonUpload.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Upload\nQuests";
			m_MenuButtonNews.GetComponentInChildren<UnityEngine.UI.Text> ().text = "News";
			m_MenuButtonLeaderboard.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Leaderboard";
			m_MenuButtonPuzzle.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Achievements";
			m_MenuButtonProfile.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Profile";


			m_MenuButtonMore.GetComponentInChildren<UnityEngine.UI.Text> ().text = "More";


			m_MenuButtonExit.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Back";
*/

			m_ButtonShowPictures.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Show Pictures";
			m_ButtonShowPicturesLeft.GetComponentInChildren<UnityEngine.UI.Text> ().text = "Show Pictures";
		}


		float proc = 1.0f;
		byte alpha = (byte)(220 * proc);
		byte alpha2 = (byte)(255 * proc);
		m_TooltipBack.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
		m_TooltipBackBig.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
		m_TooltipText.GetComponent<UnityEngine.UI.Text> ().color = new Color32 (0, 0, 0, alpha2);


			m_TooltipBackLeft.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
			m_TooltipBackBigLeft.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
			m_TooltipBackBigLeftLeft.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
		m_TooltipTextLeft.GetComponent<UnityEngine.UI.Text> ().color = new Color32 (0, 0, 0, alpha2);

		m_ButtonStartQuest.SetActive (false);
		//m_ButtonStartQuestHighlighted.SetActive (false);
		m_ButtonPointNotReachable.SetActive (false);
		//m_ButtonNearlyStartQuest.SetActive (false);
			m_StartQuestBackground.SetActive(false);
		m_StartQuestBackgroundLine.SetActive (false);


		m_bStartReadGPS = true;
		m_bDragging = false;

		Input.compass.enabled = true;
		Input.compensateSensors = true;
	
		Input.location.Start ();

		/*	m_ButtonToPosBrightBottom.SetActive (true);
			m_ButtonToPosDarkBottom.SetActive (false);
			m_ButtonToPosBright.SetActive (false);
			m_ButtonToPosDark.SetActive (false);*/

			m_ButtonLayerBright.SetActive (false);
			m_ButtonLayerDark.SetActive (true);
			OnlineMaps.instance.mapType = "google.satellite";
		m_ToggleLayer1.GetComponent<Toggle>().isOn = true;
		m_ToggleLayer2.GetComponent<Toggle>().isOn = false;
		m_ToggleLayer3.GetComponent<Toggle>().isOn = false;
		m_bBlackGui = false;

		m_bOfflineMode = false;
        if(PlayerPrefs.HasKey("OfflineMode"))
        {
            if(PlayerPrefs.GetInt("OfflineMode") == 1)
            {
				m_ToggleLayer3.GetComponent<Toggle>().isOn = true;
				m_bOfflineMode = true;
			}
            else
            {
				m_ToggleLayer3.GetComponent<Toggle>().isOn = false;
			}
        }

		//m_bBlackGui = true;
		if (PlayerPrefs.HasKey("MapType"))
		{
			int maptype = PlayerPrefs.GetInt("MapType");
			if (maptype == 0)
			{

				m_bBlackGui = false;
				m_ButtonLayerBright.SetActive(true);
				m_ButtonLayerDark.SetActive(false);

				OnlineMaps.instance.mapType = "google.terrain";
				m_ToggleLayer1.GetComponent<Toggle>().isOn = false;
				m_ToggleLayer2.GetComponent<Toggle>().isOn = true;


				m_ButtonToPosBright.SetActive(true);
				m_ButtonToPosDark.SetActive(false);

				//	m_ButtonStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().color = new Color32 (40, 40, 40, 255);
				//	m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().color = new Color32 (40, 40, 40, 255);
			}
			else //if (maptype == 1)
			{
				OnlineMaps.instance.mapType = "google.satellite";

				m_ToggleLayer1.GetComponent<Toggle>().isOn = true;
				m_ToggleLayer2.GetComponent<Toggle>().isOn = false;

				m_bBlackGui = true;
				m_ButtonLayerBright.SetActive(false);
				m_ButtonLayerDark.SetActive(true);


				m_ButtonToPosBright.SetActive(false);
				m_ButtonToPosDark.SetActive(true);
				//		m_ButtonStartQuest.GetComponentInChildren<UnityEngine.UI.Text> ().color = new Color32 (40, 40, 40, 255);
				//			m_ButtonPointNotReachable.GetComponentInChildren<UnityEngine.UI.Text> ().color = new Color32 (40, 40, 40, 255);
			}
		} else
		{
			OnlineMaps.instance.mapType = "google.satellite";

			m_ToggleLayer1.GetComponent<Toggle>().isOn = true;
			m_ToggleLayer2.GetComponent<Toggle>().isOn = false;

			m_bBlackGui = true;
			m_ButtonLayerBright.SetActive(false);
			m_ButtonLayerDark.SetActive(true);


			m_ButtonToPosBright.SetActive(false);
			m_ButtonToPosDark.SetActive(true);
		}

		m_bLayersInited = true;

		updateToPositionButtons (true);

		control = (OnlineMapsTileSetControl) OnlineMapsControlBase.instance;
		api = OnlineMaps.instance;

		Debug.Log ("Start map");
		m_SelectedPin = new FotoQuestPin();
		m_SelectedPin.m_Marker = null;
		m_SelectedPin.m_Marker2 = null;
		m_bSelectedPin = false;

		m_Pins = new FotoQuestPin[2001];
		for (int i = 0; i < 2001; i++) {
			m_Pins[i] = new FotoQuestPin();
		}
		m_NrPins = 0;

			/*
		m_PinsDone = new FotoQuestPin[401];
		for (int i = 0; i < 401; i++) {
			m_PinsDone[i] = new FotoQuestPin();
		}
		m_NrPinsDone = 0;*/



		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();

		playerMarker3D = control2.AddMarker3D (Vector2.zero, m_PlanePosition);


		if (control2 == null)
		{
			Debug.Log("You must use the 3D control (Texture or Tileset).");
			return;
		}
			

		OnlineMapsControlBase.instance.allowUserControl = true;// false;//true;//false;
		OnlineMaps.instance.OnChangeZoom = OnChangeZoom;
		toUserLocation ();

		MarkerComparer pComparer = new MarkerComparer ();
		MarkerComparer2 pComparer2 = new MarkerComparer2 ();
		pComparer.m_pDemoMap = this;
		pComparer2.m_pDemoMap = this;

		/*RectTransform rect = m_ButtonZoomIn.GetComponent<RectTransform> ();
		m_ButtonHeightPosition = rect.localPosition.y;
*/


		OnlineMapsTile.OnTileDownloaded = OnTileDownloaded;
		OnlineMaps.instance.OnStartDownloadTile = OnStartDownloadTile;


//			OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
			control2.OnMapPress = OnMapPress;
			control2.OnMapRelease = OnMapRelease;
		control2.OnMapZoom = OnMapZoom;

		//----------------
		// Set 3d mode
		Camera cam = Camera.main;
	//	fromTransform = is2D ? camera3D : camera2D;
	//	toTransform = is2D ? camera2D : camera3D;
		cam.orthographic = false;
		//c.fieldOfView = 28;
		//---------------

		//updateProgress ();
		//loadProgress ();
		//loadPinsAlreadyDone ();

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

		//LoadIntroMsg(48.188620f, 16.367920f);
	}

	//---------------------------
	// Line
	private bool m_bLineInited;
	private bool m_bLineVisible;
	public Material material;
	private Vector2[] coords;
	private MeshFilter meshFilter;
	private MeshRenderer meshRenderer;
	private Mesh mesh;
	GameObject m_ContainerLine;
		int m_LineNrVertices = -1;

	public float m_SizeLine = 10;
	public Vector2 uvScale = new Vector2(2, 1);
	private float _size;

	void showLine()
	{
		if (!m_bLineInited) {
			initLine ();
		}
		if (m_bLineVisible) {
			return;
		}
		m_ContainerLine.SetActive (true);
		m_bLineVisible = true;
	}

	void hideLine()
	{
		if (!m_bLineInited) {
			return;
		}
		if (!m_bLineVisible) {
			return;
		}

		m_ContainerLine.SetActive (false);
		m_bLineVisible = false;
	}
	
	void initLine()
	{
		OnlineMaps api = OnlineMaps.instance;


		// Create a new GameObject.
		GameObject container = new GameObject("Dotted Line");
		m_ContainerLine = container;

		// Create a new Mesh.
		meshFilter = container.AddComponent<MeshFilter>();
		meshRenderer = container.AddComponent<MeshRenderer>();

		mesh = meshFilter.sharedMesh = new Mesh();
		mesh.name = "Dotted Line";

		meshRenderer.material = material;
		material.renderQueue = 2950;
		if (m_bBlackGui == false)
		{
			//material.color = new Color(130.0f / 255.0f, 130.0f / 255.0f, 130.0f / 255.0f, 1.0f);
			//material.color = new Color(72.0f / 255.0f, 72.0f / 255.0f, 72.0f / 255.0f, 1.0f);
			//material.color = new Color(100.0f / 255.0f, 100.0f / 255.0f, 100.0f / 255.0f, 1.0f);
			//material.color = new Color(115.0f / 255.0f, 115.0f / 255.0f, 115.0f / 255.0f, 1.0f);
			//material.color = new Color(120.0f / 255.0f, 120.0f / 255.0f, 120.0f / 255.0f, 1.0f);
			material.color = new Color(125.0f / 255.0f, 125.0f / 255.0f, 125.0f / 255.0f, 1.0f);
		} else
        {
			material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}

		// Init coordinates of points.
		coords = new Vector2[2];

		coords[0] = new Vector2(16.363449f, 48.210033f);
		coords[1] = new Vector2(16.353449f, 48.220033f);

		m_bLineInited = true;
		m_bLineVisible = true;
	}

	private void UpdateLine()
	{
		if (m_bLineInited == false) {
			return;
		}
		if (!m_bLineVisible) {
			return;
		}
		_size = m_SizeLine;

		float totalDistance = 0;
		Vector3 lastPosition = Vector3.zero;

		List<Vector3> vertices = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		List<Vector3> normals = new List<Vector3>();
		List<int> triangles = new List<int>();
		List<Vector3> positions = new List<Vector3>();


		for (int i = 0; i < coords.Length; i++)
		{
			// Get world position by coordinates
			Vector3 position = OnlineMapsTileSetControl.instance.GetWorldPosition(coords[i]);
			positions.Add(position);

			if (i != 0)
			{
				// Calculate angle between coordinates.
				float a = OnlineMapsUtils.Angle2DRad(lastPosition, position, 90);

				// Calculate offset
				Vector3 off = new Vector3(Mathf.Cos(a) * m_SizeLine, 0, Mathf.Sin(a) * m_SizeLine);

				// Init verticles, normals and triangles.
				int vCount = vertices.Count;

				vertices.Add(lastPosition + off);
				vertices.Add(lastPosition - off);
				vertices.Add(position + off);
				vertices.Add(position - off);

				normals.Add(Vector3.up);
				normals.Add(Vector3.up);
				normals.Add(Vector3.up);
				normals.Add(Vector3.up);

				triangles.Add(vCount);
				triangles.Add(vCount + 3);
				triangles.Add(vCount + 1);
				triangles.Add(vCount);
				triangles.Add(vCount + 2);
				triangles.Add(vCount + 3);

				totalDistance += (lastPosition - position).magnitude;
			}

			lastPosition = position;
		}

		float tDistance = 0;

		for (int i = 1; i < positions.Count; i++)
		{
			float distance = (positions[i - 1] - positions[i]).magnitude;

			// Updates UV
			uvs.Add(new Vector2(0.0f, 0));
			uvs.Add(new Vector2(0.0f, 1));

			tDistance += distance;

			float proc = distance / 500.0f;
			uvs.Add(new Vector2(proc, 0));
			uvs.Add(new Vector2(proc, 1));
		}

		if (m_LineNrVertices == -1) {
			m_LineNrVertices = vertices.Count;
		} else if (m_LineNrVertices != vertices.Count) {
			m_LineNrVertices = vertices.Count;
			mesh = meshFilter.sharedMesh = new Mesh ();
			mesh.name = "Dotted Line";
		}

		// Update mesh
		mesh.vertices = vertices.ToArray();
		mesh.normals = normals.ToArray();
		mesh.uv = uvs.ToArray();
		mesh.triangles = triangles.ToArray();

		//Debug.Log ("Update line nrverts: " + vertices.Count + " tris: " + triangles.Count);

		// Scale texture
		Vector2 scale = new Vector2(totalDistance / m_SizeLine, 1);
		scale.Scale(uvScale);
		meshRenderer.material.mainTextureScale = scale;


	}
	//---------------------------



	private static string GetTilePath(OnlineMapsTile tile)
	{
		string[] parts =
		{
			Application.persistentDataPath,
			"OnlineMapsTileCache",
			tile.mapType.provider.id,
			tile.mapType.id,
			tile.zoom.ToString(),
			tile.x.ToString(),
			tile.y + ".png"
		};
		return string.Join("/", parts);
	}

	private static string GetTilePathRessource(OnlineMapsTile tile, int x, int y, int zoom)
	{
		string[] parts =
		{
			Application.persistentDataPath,
			"OnlineMapsTileCache",
			tile.mapType.provider.id,
			tile.mapType.id,
			zoom.ToString(),
			x.ToString(),
			y + ".png"
		};
		return string.Join("/", parts);
	}

	private void OnStartDownloadTile(OnlineMapsTile tile)
	{
		// Get local path.
		string path = GetTilePath(tile);

		//Debug.Log("OnStartDownloadTile: " + path);

		// If the tile is cached.
		if (File.Exists(path) )
		{
		//	Debug.Log ("Tile already downloaded: " + path);

			// Load tile texture from cache.
			Texture2D tileTexture = new Texture2D(256, 256);
			tileTexture.LoadImage(File.ReadAllBytes(path));
			tileTexture.wrapMode = TextureWrapMode.Clamp;

			// Send texture to map.
			/*if (OnlineMaps.instance.target == OnlineMapsTarget.texture)
			{
				tile.ApplyTexture(tileTexture);
				OnlineMaps.instance.buffer.ApplyTile(tile);
			}
			else
			{*/
				tile.texture = tileTexture;
				tile.status = OnlineMapsTileStatus.loaded;
			/*}*/

			// Redraw map.
			OnlineMaps.instance.Redraw();
		}
		else
		{
			if (!m_bOfflineMode)
			{
				OnlineMaps.instance.StartDownloadTile(tile);
			}
			else
			{
				double latsmall;
				double lngsmall;
				api.projection.TileToCoordinates(tile.x, tile.y, tile.zoom, out latsmall, out lngsmall);


				double latsmall2;
				double lngsmall2;
				api.projection.TileToCoordinates(tile.x + 1.0, tile.y + 1.0, tile.zoom, out latsmall2, out lngsmall2);

				/*double centerlat = (latsmall - latsmall2) * 0.5 + latsmall2;
				double centerlng = (lngsmall - lngsmall2) * 0.5 + lngsmall2;*/

				int curzoom = tile.zoom;
				curzoom--;

				while (curzoom > 1)
				{
					double px;
					double py;
					api.projection.CoordinatesToTile(latsmall, lngsmall, curzoom, out px, out py);
					//api.projection.CoordinatesToTile(centerlat, centerlng, curzoom, out px, out py);
					px = (int)px;
					py = (int)py;

					string newpath = GetTilePathRessource(tile, (int)px, (int)py, curzoom);
					if (File.Exists(newpath))
					{
						//Debug.Log ("Tile already downloaded: " + path);

						double latbig;
						double lngbig;
						api.projection.TileToCoordinates(px, py, curzoom, out latbig, out lngbig);


						double latbig2;
						double lngbig2;
						api.projection.TileToCoordinates(px + 1.0, py + 1.0, curzoom, out latbig2, out lngbig2);

					/*	Debug.Log(">>> Created tile small (" + latsmall + "," + lngsmall + "," + latsmall2 + "," + lngsmall2 + " z: " + tile.zoom +
							"), big (" + latbig + "," + lngbig + "," + latbig2 + "," + lngbig2 + " z: " + curzoom + ")");*/

						double widthbig = latbig2 - latbig;
						double heightbig = lngbig - lngbig2;

						double startlat = (latsmall - latbig) / widthbig;
						double endlat = (latsmall2 - latbig) / widthbig;

						double startlng = (lngsmall2 - lngbig2) / heightbig;
						double endlng = (lngsmall - lngbig2) / heightbig;
					//	Debug.Log("x1: " + startlat + " x2: " + endlat + " y1: " + startlng + " y2: " + endlng);


						// Load tile texture from cache.
						Texture2D tileTexture = new Texture2D(256, 256);
						tileTexture.LoadImage(File.ReadAllBytes(newpath));
						tileTexture.wrapMode = TextureWrapMode.Clamp;




						Texture2D tileTextureArea = new Texture2D(256, 256);
						tileTextureArea.wrapMode = TextureWrapMode.Clamp;

						/*startlat = 1.0f - startlat;
						endlat = 1.0f - endlat;*/

						double startx = startlat * 256;
						double endx = endlat * 256;

						double starty = startlng * 256;
						double endy = endlng * 256;

						if (startx < 0) startx = 0;
						if (startx >= 256) startx = 255;
						if (endx < 0) endx = 0;
						if (endx >= 256) endx = 255;


						if (starty < 0) starty = 0;
						if (starty >= 256) starty = 255;
						if (endx < 0) endx = 0;
						if (endy >= 256) endy = 255;

						/*	startx = 0;
							starty = 0;
							endx = 255;
							endy = 255;*/


						Color color;
						for (int x = 0; x < 256; x++)
						{
							float procx = (float)x / 255.0f;
							for (int y = 0; y < 256; y++)
							{
								float procy = (float)y / 255.0f;

								int curposx = (int)(startx + (endx - startx) * procx);
								int curposy = (int)(starty + (endy - starty) * procy);

								if (curposx >= 0 && curposx <= 255 && curposy >= 0 && curposy <= 255)
								{
									color = tileTexture.GetPixel(curposx, curposy);

									tileTextureArea.SetPixel(x, y, color);
								}
							}
						}


						tileTextureArea.Apply();
						tile.texture = tileTextureArea;
						tile.status = OnlineMapsTileStatus.loaded;

						// Redraw map.
						OnlineMaps.instance.Redraw();

						return;
					}

					curzoom--;
				}
			}
		}
	}

	void OnTileDownloaded(OnlineMapsTile tile)
	{
	//	Debug.Log ("OnTileDownloaded");
		string path = GetTilePath(tile);
		Debug.Log ("OnTileDownloaded: " + path);

		// Cache tile.
		FileInfo fileInfo = new FileInfo(path);
		DirectoryInfo directory = fileInfo.Directory;
		if (!directory.Exists) directory.Create();

		File.WriteAllBytes(path, tile.www.bytes);
	}

		public GameObject m_UploadImageTest;
		public GameObject m_UploadText;
		bool m_bDownloadImagesStarted = false;
		int m_DownloadImagesStartedIter = 0;
		public void OnTileDownloadTest()
		{
		//m_bDownloadImagesStarted = true;
		//m_DownloadImagesStartedIter = 0;
			Application.targetFrameRate = 30;
			Application.LoadLevel ("OfflineMap");


        //    Application.LoadLevel("Report");
	}

	

	void toUserLocation()
	{
		Debug.Log ("Start location service");
			m_bLocationGPSDisabledReading = true;

		StartCoroutine (StartLocations ());
	}



	private Vector2 m_PlayerPosition;
	bool m_bPlayerPositionRead = false;
	private void OnLocationChanged(Vector2 position)
	{
		// Change the position of the marker.
		m_PlayerPosition = position;
		m_bPlayerPositionRead = true;

		//-----------------------------
		// Update distance walked
		if(m_bSelectedPin) {
			float stepDistance = OnlineMapsUtils.DistanceBetweenPoints(m_PlayerPosition, m_DistanceWalkedLastCheckpoint).magnitude;
			stepDistance *= 1000.0f;
			if (stepDistance > 10.0f) {
				m_DistanceWalkedLastCheckpoint = position;
				m_DistanceWalked += stepDistance;
			}
		}
		//-----------------------------

		if (m_bSelectedPin) {
			float distanceToLast = OnlineMapsUtils.DistanceBetweenPoints(m_PlayerPosition, m_PlayerLastPosition).magnitude;
			distanceToLast *= 1000.0f;
			if (distanceToLast > 100.0f) {
				m_PlayerLastPosition = position;
				if (m_NrPlayerPositions < 50) {
					m_PlayerPositions [m_NrPlayerPositions] = m_PlayerPosition;
					m_NrPlayerPositions++;
				}
			}
		}

		//if (!m_bIn2dMap) {
			/*if (m_bInReachOfPoint) {
				Vector2 pinpos;
				pinpos.x = (float)m_SelectedPin.m_Lng;
				pinpos.y = (float)m_SelectedPin.m_Lat;

				OnlineMaps.instance.position = pinpos;
			} else {
				OnlineMaps.instance.position = m_PlayerPosition;
			}*/
		if (m_bFollowingGPS) {
			OnlineMaps.instance.position = m_PlayerPosition;
		}
		//}

		OnlineMaps api = OnlineMaps.instance;
		if (playerMarker3D != null) {
			playerMarker3D.SetPosition (position.x, position.y);
            /*

			OnlineMaps map = OnlineMaps.instance;
			double tlx, tly, brx, bry;
			map.GetTopLeftPosition (out tlx, out tly);
			map.GetBottomRightPosition (out brx, out bry);

			playerMarker3D.Update (tlx, tly, brx, bry, map.zoom);*/
		}
		
		addLineToPin ();
	}

	private void toPlayerPosition()
	{
		/*if (m_bInReachOfPoint) {
			Vector2 pinpos;
			pinpos.x = (float)m_SelectedPin.m_Lng;
			pinpos.y = (float)m_SelectedPin.m_Lat;

			OnlineMaps.instance.position = pinpos;
		} else {*/
			OnlineMaps.instance.position = m_PlayerPosition;
		//}
		/*
		OnlineMaps.instance.position = m_PlayerPosition;*/
	//	OnlineMaps.instance.zoom = 16;//7;
	}

	float playerrot = 0.0f;
	int m_ChangePositionIter = 0;
	bool m_bLocationEnabled = false;
	//float m_Walking = 0.0f;

	int m_LocationGPSDisabledIter = 0;

	bool m_bCameraHeadingSet;
	float m_CameraHeading;

	float m_CameraAngle = 90.0f;
	float m_CameraAngleMove = 90.0f;
	float m_CameraAngleTransition = 90.0f;
	float m_CameraPitch = 37.0f;
	float m_TouchPosX;
	float m_TouchPosY;

	int m_NotificationIter = 0;


	int m_frameCounter = 0;
	float m_timeCounter = 0.0f;
	float m_lastFramerate = 0.0f;
	public float m_refreshTime = 0.5f;

	bool m_bUpdatePins = true;
	public void shouldPinsBeUpdated()
	{
		m_bUpdatePins = !m_bUpdatePins;
		/*OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
			control2.setUpdateControl (m_bUpdatePins);*/
	}



	public void testRemoveAllPins()
	{
	/*	OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
		control2.RemoveAllMarker3D ();*/
	}


	public GameObject m_TextFPS;
	public GameObject m_TextStatus;
	int m_NrItersUpdate = 0;
	int m_NrItersLoad = 0;
	bool m_bTouchMoved = false;
	bool m_bTouchMoving = false;
	float m_MoveOffsetTest = 0.0f;
	bool m_bForceUpdate = true;
	bool m_bInitCamera = true;
		float m_CurTouchMove = 0.0f;
		int m_FrameRateIter = 0;
		int m_FrameRate = 30;

		#if DEBUGAPP
		int updateTool = 0;
		int updateText = 0;
		int updateRotation = 0;
		#endif

		bool m_bZoom = false;
		float m_ZoomDistance = 0.0f;
		bool m_bHasZoomed = false;

	/*	int m_AskSurvey = 0;
		bool m_bAskedSurvey = false;
		bool m_bAskSurvey = false;*/

	//-----------
	// Start message
	bool m_bOpenStartMessage = false;//true;
	int m_OpenStartMessageIter = 0;
	bool m_bLoadedStartMessage = false;
	void OnIntroMsgBoxClicked(string text)
    {

    }
	void LoadIntroMsg(float posx, float posy)
    {
		//m_bOpenStartMessage = true;

		string url = "https://geo-wiki.org/Application/api/campaign/GetAppMessage";
		string param = "{";

		param += "\"app_id\":" + "\"" + 21 + "\",\"location\":{\"lat\":" + posx + ",\"lng\":" + posy + "}";

		param += "}";
		Debug.Log("loadMessage param: " + param);


		WWWForm form = new WWWForm();
		form.AddField("parameter", param);

		//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForMessage(www));
	}

	int m_ReadingWhichMessage;
	string m_MessageText;
	int m_MessageId;
	IEnumerator WaitForMessage(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Message data!: " + www.text);
			m_ReadingWhichMessage = -1;
			JSONObject j = new JSONObject(www.text);
			accessMessageInfo(j);
			Debug.Log("Message text: " + m_MessageText);
			Debug.Log("Message id: " + m_MessageId);

			if(PlayerPrefs.GetInt("LastMessageId") != m_MessageId/* || true*/) // Todo: Comment true out again
            {
				PlayerPrefs.SetInt("LastMessageId", m_MessageId);
				PlayerPrefs.Save();
				m_bOpenStartMessage = true;
			}
		}
		else
		{
			Debug.Log("Could not load message");
			Debug.Log("WWW Error message: " + www.error);
			Debug.Log("WWW Error message 2: " + www.text);
		}
	}
	void accessMessageInfo(JSONObject obj)
	{
		switch (obj.type)
		{
			case JSONObject.Type.OBJECT:
				for (int i = 0; i < obj.list.Count; i++)
				{
					string key = (string)obj.keys[i];
					//Debug.Log("Message Key: " + key);
					JSONObject j = (JSONObject)obj.list[i];
					if (key == "id")
					{
						m_ReadingWhichMessage = 2;
					}
					else if (key == "text")
					{
						m_ReadingWhichMessage = 1;
					}
					else
					{
						m_ReadingWhichMessage = 0;
					}
					accessMessageInfo(j);
				}
				break;
			case JSONObject.Type.ARRAY:
				//	Debug.Log ("Array");
				foreach (JSONObject j in obj.list)
				{
					accessMessageInfo(j);
				}
				break;
			case JSONObject.Type.STRING:
				if (m_ReadingWhichMessage == 1)
				{
					m_MessageText = obj.str;
				}
				break;
			case JSONObject.Type.NUMBER:
				if (m_ReadingWhichMessage == 2)
				{
					m_MessageId = (int)obj.n;
				}
				break;

		}
	}
	//----------------

	private void Update()
	{
		if(m_bOpenStartMessage)
        {
			m_OpenStartMessageIter++;
			if(m_OpenStartMessageIter > 10)
            {
				UnityEngine.Events.UnityAction<string> ua = new UnityEngine.Events.UnityAction<string>(OnIntroMsgBoxClicked);
				string[] options = { LocalizationSupport.GetString("Ok") };
				messageBoxSmall.Show("", m_MessageText, ua, options);
				m_bOpenStartMessage = false;
			}
		}

		if(m_bAutoZoomOut)
        {
			/*m_AutoZoomIter++;
			if(m_AutoZoomIter > 1)//2)//2)//10)
            {*/
				zoomOutSlow();
				//zoomOut();
				m_AutoZoomIter = 0;
			//}
        }
#if DEBUGAPP
		// Stop time
		if( m_timeCounter < m_refreshTime )
		{
			m_timeCounter += Time.deltaTime;
			m_frameCounter++;
		}
		else
		{
			//This code will break if you set your m_refreshTime to 0, which makes no sense.
			m_lastFramerate = (float)m_frameCounter/m_timeCounter;
			m_frameCounter = 0;
			m_timeCounter = 0.0f;
			m_TextFPS.GetComponent<UnityEngine.UI.Text> ().text = "fps: " + m_lastFramerate;
		}
#endif

        /*
		if (m_bDownloadImagesStarted) {
			m_DownloadImagesStartedIter++;
			if (m_DownloadImagesStartedIter > 4) {
				m_bDownloadImagesStarted = false;
				StartCoroutine (DownloadTilesTest ());
			}
		}

		if (m_bDownloadingImages) {
			if (m_bDownloadingImage == false && m_bDownloadedImage == false) {
				if (m_DownloadingImageIter < m_DownloadTilesZoom.Count) {
					m_bDownloadingImage = true;
					StartCoroutine (DownloadTilesTest (m_DownloadingImageIter));
				} else {
					m_bDownloadingImages = false;
					m_UploadImageTest.SetActive (false);
					m_UploadText.SetActive (false);
				}
			} else if (m_bDownloadedImage) {
				m_DownloadingImageIter++;
				int imageiter = m_DownloadingImageIter + 1;
					m_UploadText.GetComponent<UnityEngine.UI.Text> ().text = "Download " + imageiter + " / "  + m_DownloadTilesZoom.Count;
				if (m_DownloadingImageIter < m_DownloadTilesZoom.Count) {
					m_bDownloadingImage = true;
					m_bDownloadedImage = false;
					StartCoroutine (DownloadTilesTest (m_DownloadingImageIter));
				} else {
					m_bDownloadingImages = false;
					m_UploadImageTest.SetActive (false);
					m_UploadText.SetActive (false);
				}
			}
		}
*/


		//-----------------
		// Ask if wanting to do survey
		/*if (m_bAskSurvey && !m_bAskedSurvey) {
			m_AskSurvey++;
			if (m_AskSurvey > 10) {
				m_bAskedSurvey = true;
				UnityEngine.Events.UnityAction<string> ua = new UnityEngine.Events.UnityAction<string> (OnMsgBoxSurveyClicked);
					string[] options = { LocalizationSupport.GetString("QuestionProfileTimeNo"), LocalizationSupport.GetString("QuestionProfileTimeYes")};
					messageBoxSmall.Show ("", LocalizationSupport.GetString("QuestionProfileTime"), ua, options);
			}
		}*/
		//-----------------
	


		if (!m_bUpdatePins) {
			return;
		}
#if DEBUGAPP
		m_NrItersUpdate++;
#endif

		if (m_bPinInfoClosed) {
			m_PinInfoClosedIter++;
			if (m_PinInfoClosedIter > 3) {
				m_bPinInfoClosed = false;
				m_PinInfoClosedIter = 0;
			}
		}
		
		// For test
		/*if (m_bSelectedPin) {
				System.DateTime date = System.DateTime.Parse (m_QuestSelectedTime);
				System.TimeSpan travelTime = System.DateTime.Now - date; 
			Debug.Log ("Time passed in seconds since selection: " + travelTime.Seconds);
		}*/

		//===========================
		// Handling input
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (m_bMenuOpened) {
				SideMenu menu = (SideMenu) m_MenuSlidin.GetComponent(typeof(SideMenu));
				menu.SlideOut ();
				m_MenuToggleButton.SetActive (false);
				m_bMenuOpened = false;
			} else {
				Application.Quit (); 
			}/*
			if (m_bMenuSelectionOpen) {
				OnCloseMenuSelection ();
			} else if (m_bMenuOpen) {
				OnMenuCloseClicked ();
			} else {
				Application.Quit (); 
			}*/
		}

		if (Input.touchCount == 2 && !m_bIn2dMap) {
			m_bHasZoomed = true;
			float touchposx1 = Input.GetTouch (0).position.x;
			float touchposy1 = Input.GetTouch (0).position.y;


			float touchposx2 = Input.GetTouch (1).position.x;
			float touchposy2 = Input.GetTouch (1).position.y;

			float vecx = touchposx1 - touchposx2;
			float vecy = touchposy1 - touchposy2;
			float distance = Mathf.Sqrt (vecx * vecx + vecy * vecy);
			if (m_bZoom == false) {
				m_ZoomDistance = distance;
				m_bZoom = true;
			} else {
				float distchange = distance - m_ZoomDistance;
				if (distchange > m_ZoomDistance * 0.2f || distchange < m_ZoomDistance * -0.2f) {
					if (distchange < 0.0f) {
						zoomOut ();
						m_ZoomDistance = distance;
					} else {
						zoomIn ();
						m_ZoomDistance = distance;
					}
				}
			}

			//m_TextInput.GetComponent<UnityEngine.UI.Text> ().text = "x1: " + touchposx1 + " y: " + touchposy1 + "\nx2: " + touchposx2 + " y2: " + touchposy2;
		} else {
			m_bZoom = false;
			m_ZoomDistance = 0.0f;
		}


	//	Debug.Log ("m_bTouchMoved: " + m_bTouchMoved + " haszoomed: " + m_bHasZoomed);
		if(Input.GetMouseButtonUp(0) && !m_bTouchMoved && !m_bHasZoomed)
		{
			Debug.Log ("#### CLICK #####");
			PointerEventData pointerData = new PointerEventData(EventSystem.current) {
				pointerId = -1,
			};

			pointerData.position = Input.mousePosition;
			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerData, results);

			if (results.Count > 0) {
				Debug.Log ("Nr results pick gui: " + results.Count);
				Debug.Log ("pick gui element name: " + results [0].gameObject.name);
			} else {
				Debug.Log ("Mouse down -> check hit");
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					Debug.Log ("Mouse Down Hit the following object: " + hit.collider.name);
					if (hit.collider.name == "Map") {
						Debug.Log ("> Clicked on map");
					} else {
						Debug.Log ("> Clicked on marker");
						//hit.collider.gameObject
						OnGOClick (hit.collider.gameObject);
					}
				}
			}
		}

		if (Input.touchCount == 1) {    
			// touch on screen
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				m_TouchPosX = Input.GetTouch (0).position.x;
				m_TouchPosY = Input.GetTouch (0).position.y;

				Debug.Log ("Touch began");
				m_bTouchMoved = false;
				m_CurTouchMove = 0.0f;
			}
			
			if (Input.GetTouch (0).phase == TouchPhase.Moved && m_bLocationEnabled) {
				float difmovex = Input.GetTouch (0).position.x - m_TouchPosX;
				float curdifmovex = difmovex;
				if (curdifmovex < 0.0f) {
					curdifmovex *= -1.0f;
				}
				m_CurTouchMove += curdifmovex;

				if (m_bFollowingGPS) {
					m_CameraAngleMove = -m_CameraHeading + 90;//m_CameraHeading;
				}
				m_bFollowingGPS = false;
				if (m_CurTouchMove > 10.0f) {
					m_bTouchMoved = true;
				}

				m_bTouchMoving = true;

				Debug.Log ("Touch moved");


				if (!m_bIn2dMap) {
					m_CameraAngleMove += difmovex * 0.3f;
				}

				if (m_CameraAngleMove > 360) {
					m_CameraAngleMove -= 360;
				} else if (m_CameraAngleMove < 0) {
					m_CameraAngleMove += 360;
				}


				/*float difmovey = Input.GetTouch (0).position.y - m_TouchPosY;
				m_CameraPitch -= difmovey * 0.3f;
				if (m_CameraPitch <= 37.0f) {
					m_CameraPitch = 37.0f;
				} else if (m_CameraPitch >= 90.0f) {
					m_CameraPitch = 90.0f;
				}*/

				m_TouchPosX = Input.GetTouch (0).position.x;
				m_TouchPosY = Input.GetTouch (0).position.y;
			}
		} else if (Input.touchCount <= 0) {
			m_bTouchMoving = false;
			m_bHasZoomed = false;
		}

			/*NSLog(@"
		if (Input.touchCount > 0 && m_bIn2dMap) {*/
		//	UpdateLine ();
//		}

		if (m_bTo2dMap) {
			m_To2dMapTimer += 6.0f * Time.deltaTime;
			float proc = m_To2dMapTimer / 5.0f;
			if (proc > 1.0f) {
				proc = 1.0f;
				m_bTo2dMap = false;
				m_CameraPitch = 90.0f;
				m_bTouchMoving = true;
				Debug.Log ("to map 2d 1");
			} else {
				m_CameraPitch = 37.0f + (90.0f - 37.0f) * proc;
					m_bTouchMoving = true;
					Debug.Log ("to map 2d 2");
			}
			float dif = (90.0f - m_CameraAngleTransition);
			if (dif > 180)
				dif = 360 - dif;
			else if (dif < -180)
				dif = 360 + dif;
					
			m_CameraAngleMove = dif * proc + m_CameraAngleTransition;
			//	m_CameraAngleMove = (90.0f - m_CameraAngleTransition) * proc + m_CameraAngleTransition;
			//	byte alpha = (byte)(238 * proc);
			//	m_DistanceBack2d.GetComponent<Image>().color = new Color32(68,154,231,alpha);
		} else if (m_bTo3dMap) {
			m_To3dMapTimer += 6.0f * Time.deltaTime;
			float proc = m_To3dMapTimer / 5.0f;
			if (proc > 1.0f) {
				m_bTo3dMap = false;
				m_CameraPitch = 37.0f;
				m_bTouchMoving = true;
				Debug.Log ("to map 3d 1");

				//Debug.Log ("Zoom: " + api.zoom);
				loadPins (); //Commented out
			} else {
				m_CameraPitch = 90.0f + (37.0f - 90.0f) * proc;
					m_bTouchMoving = true;
					Debug.Log ("to map 3d 2");
			}
		}

		

		


		//===========================
		// Update line

		// If size changed, then update line.
		/*if (m_SizeLine != _size) UpdateLine();
		addLineToPin (); */
			

		Camera cam = Camera.main;



		//===========================
		// Check if map in Austria

		UnityEngine.UI.Text textdebug;
		/*if (m_bLocationEnabled) {
			if (OnlineMaps.instance.position.x >= 8.935 && OnlineMaps.instance.position.x <= 17.62669 &&
			   OnlineMaps.instance.position.y >= 45.3919 && OnlineMaps.instance.position.y <= 49.9062) {
				m_BackLocationOutside.SetActive (false);
				m_TextLocationOutside.SetActive (false);
			} else {
				m_TextLocationOutside.SetActive (true);
				m_BackLocationOutside.SetActive (true);
			}
		}
*/

		//===========================
		// Location updates

		bool bPositionChanged = false;
		m_ChangePositionIter++;
		if (m_ChangePositionIter > 20 && m_bLocationEnabled && !m_bDragging) {
			m_ChangePositionIter = 0;
				Vector2 pos;
			if (m_bLocationEnabled) {
				//m_MoveOffsetTest += 0.001f;
				pos.y = Input.location.lastData.latitude;// + m_MoveOffsetTest;// 30.0f;//48.210033f;
				pos.x = Input.location.lastData.longitude;//12.0f;//16.363449f;

					if(m_bPlayerPositionRead) {
						float distanceDif = OnlineMapsUtils.DistanceBetweenPoints(m_PlayerPosition, pos).magnitude;
						distanceDif *= 1000.0f;
						if(distanceDif > 5.0f) {
							OnLocationChanged (pos);
							OnChangePosition ();
							bPositionChanged = true;
						}
					} else {
						OnLocationChanged (pos);
						OnChangePosition ();
						bPositionChanged = true;
					}
			} else {
				pos.y = m_LocationLatDisabled;
				pos.x = m_LocationLngDisabled;// + m_Walking;
				
				OnLocationChanged (pos);
			}
		}

		// Check if location service running/still running
		if (m_bLocationGPSDisabled && (!m_bDebug) /*false*/) {//TODO: Comment false out again
			m_LocationGPSDisabledIter++;
			if (m_LocationGPSDisabledIter > 30) {//100) {
				m_LocationGPSDisabledIter = 0;
				if (!m_bLocationGPSDisabledReading) {
					toUserLocation ();
				}
			}
		} else if(m_bLocationEnabled) {
			// If location has been enabled check that gps is still available
			if (!Input.location.isEnabledByUser || Input.location.status == LocationServiceStatus.Failed 
				|| Input.location.status != LocationServiceStatus.Running) {
				m_TextDebug.SetActive (true);
				m_BackDebug.SetActive (true);



				textdebug = m_TextDebug.GetComponent<UnityEngine.UI.Text>();

				if (!Input.location.isEnabledByUser) {
						textdebug.text = LocalizationSupport.GetString("GPSGivePermission");/*
					if (Application.systemLanguage == SystemLanguage.German) {
						textdebug.text = "Bitte gib Urban Roots die Erlaubnis GPS benutzen zu dürfen.";
					} else {
						textdebug.text = "Please give Urban Roots the permission to use the location service.";
					}*/
				} else {
						textdebug.text = LocalizationSupport.GetString("GPSFailed");/*
					if (Application.systemLanguage == SystemLanguage.German) {
						textdebug.text = "Deine Position konnte nicht ermittelt werden.";
					} else {
						textdebug.text = "Your position could not be read.";
					}*/
				}
				m_BackDebug.GetComponent<Image>().color = new Color32(255,255,255,240);//new Color32(243,26,26,240);//new Color32(219,32,32,240);//Color32(255,20,20,240);
				m_bLocationGPSDisabled = true;
				m_bLocationGPSDisabledReading = false;
				m_bLocationEnabled = false;
			}
		}



		//===========================
		// Updating menu

		/*if (m_bMenuSelectionOpen) {
			return;
		}
		if (m_bMenuOpen == false) {
			m_MenuBack.SetActive (false);
			m_MenuButtonExit.SetActive (false);
			m_MenuButtonUpload.SetActive (false);
			m_MenuButtonNews.SetActive (false);
			m_MenuButtonLeaderboard.SetActive (false);
			m_MenuButtonPuzzle.SetActive (false);
			m_MenuButtonChat.SetActive (false);
			m_MenuButtonProfile.SetActive (false);
			m_MenuButtonMore.SetActive (false);
			m_MenuButtonFB.SetActive (false);
			m_MenuButtonTwitter.SetActive (false);
			m_MenuButtonMail.SetActive (false);
			m_MenuSelectionHello.SetActive (false);
			m_MenuSelectionHelloPortrait.SetActive (false);
		} else {
			m_MenuBack.SetActive (true);
			m_MenuButtonUpload.SetActive (true);
			m_MenuButtonNews.SetActive (true);
			m_MenuButtonLeaderboard.SetActive (true);
			m_MenuButtonPuzzle.SetActive (true);
			m_MenuButtonChat.SetActive (true);
			m_MenuButtonProfile.SetActive (true);
			m_MenuButtonMore.SetActive (true);
			m_MenuButtonFB.SetActive (true);
			m_MenuButtonTwitter.SetActive (true);
			m_MenuButtonMail.SetActive (true);
			if (Screen.width > Screen.height) {
				m_MenuSelectionHello.SetActive (true);
				m_MenuSelectionHelloPortrait.SetActive (false);
			} else {
				m_MenuSelectionHello.SetActive (false);
				m_MenuSelectionHelloPortrait.SetActive (true);
			}

			m_MenuButtonExit.SetActive (true);
			m_MenuOpenTimer += 50.0f;
			float proc = m_MenuOpenTimer / 500.0f;
			if (proc > 1.0f)
				proc = 1.0f;
			//byte alpha = (byte)(220 * proc);
			byte alpha = (byte)(230 * proc);
			m_MenuBack.GetComponent<UnityEngine.UI.Image>().color = new Color32(216,236,248,alpha);
	
			return;
		}*/

		if (m_bCheckInternet) {
			m_CheckInternetTimer += 50.0f;
			if (m_CheckInternetTimer > 10000.0f) {
				startCheckingInternet ();
				m_CheckInternetTimer = 0.0f;
			}
		}

		/*if (m_bShowWelcome) {
			m_WelcomeTimer += 50.0f;
			float proc = 1.0f;
			bool bTooltipActive = true;
			if (m_WelcomeTimer < 0.0f) {
				proc = 0.0f;
				m_TextWelcome.SetActive (false);
				m_BackWelcome.SetActive (false);
			} else if (m_WelcomeTimer < 600.0f) {
				proc = m_WelcomeTimer / 600.0f;
				m_TextWelcome.SetActive (true);
				m_BackWelcome.SetActive (true);
			} else if (m_WelcomeTimer < 6000.0f) {
				proc = 1.0f;
				m_TextWelcome.SetActive (true);
				m_BackWelcome.SetActive (true);
			} else if (m_WelcomeTimer < 8600.0f) {
				proc = (m_WelcomeTimer - 8000.0f) / (8600.0f - 8000.0f);
				proc = 1.0f - proc;
				m_TextWelcome.SetActive (true);
				m_BackWelcome.SetActive (true);
			} else {
				m_TextWelcome.SetActive (false);
				m_BackWelcome.SetActive (false);
				bTooltipActive = false;
				m_bShowWelcome = false;
			}

			if (bTooltipActive) {
				if (proc > 1.0f)
					proc = 1.0f;
				byte alpha = (byte)(200 * proc);
				m_BackWelcome.GetComponent<UnityEngine.UI.Image> ().color = new Color32 (255, 255, 255, alpha);
				m_TextWelcome.GetComponent<UnityEngine.UI.Text> ().color = new Color32 (0, 0, 0, alpha);
			}
		}*/


		//===========================
		// Making quest (show message how far away from point and show pin info)

			if (m_bTouchMoving || m_bForceUpdate || m_bFollowingGPS || true) {
#if DEBUGAPP
			updateTool++;
#endif

			if (m_bSelectedPin) {
				float proc = 1.0f;
				bool bTooltipActive = true;
				float duration = 10000000.0f; // 10000.0f
				if (m_SelectedPinTimer < duration /*+ 10000000.0f*/) {
				} else {
					bTooltipActive = false;
				}
					//hallihallo
				if (bTooltipActive) {
					updatePinInfo ();
				}
			}
		}

		//===========================
		// Camera heading

		playerrot += 1.0f;
		/*float accx = Input.acceleration.x;
		float accy = Input.acceleration.y;
		float accz = Input.acceleration.z;
		float lenacc = Mathf.Sqrt (accx * accx + accy * accy + accz * accz);
		accx /= lenacc;
		accy /= lenacc;
		accz /= lenacc;
		float compx = Input.compass.rawVector.x;
		float compy = Input.compass.rawVector.y;
		float compz = Input.compass.rawVector.z;

		float lencomp = Mathf.Sqrt (compx * compx + compy * compy + compz * compz);
		compx /= lencomp;
		compy /= lencomp;
		compz /= lencomp;*/

		if (Input.acceleration.y < -0.75f) {
			playerrot = Mathf.Rad2Deg * Mathf.Atan2 (Input.compass.rawVector.z, Input.compass.rawVector.x);
			playerrot += 90.0f;
			playerrot = 360 - playerrot;
		} else {
			playerrot = Input.compass.trueHeading;
		}

		if (playerMarker3D != null) {
			if (m_bCameraHeadingSet == false) {
				m_CameraHeading = playerrot;
				m_bCameraHeadingSet = true;
			} else {
				float dif = (playerrot - m_CameraHeading);
				if (dif > 180) {
					dif -= 360.0f;
				} else if (dif < -180) {
					dif += 360.0f;
				}

				m_CameraHeading += dif * 6.0f * Time.deltaTime;
				if (m_CameraHeading > 360) {
					m_CameraHeading -= 360;
				} else if (m_CameraHeading < 0) {
					m_CameraHeading += 360;
				}
			}



			Transform markerTransformPlayer = playerMarker3D.transform;
			if (markerTransformPlayer != null)
				markerTransformPlayer.rotation = Quaternion.Euler (0, m_CameraHeading, 0);//playerrot, 0);	
		}

		if (/*m_bTouchMoving || m_bFollowingGPS || */m_bInitCamera /*|| m_bForceUpdate*/) {
			m_bInitCamera = false;
#if DEBUGAPP
			updateRotation++;
#endif

			/*
			float prevangle = m_CameraAngle;
			m_CameraAngle = -m_CameraHeading + 90;

			Debug.Log ("Camera ANGLE: " + m_CameraAngle);
			if (!m_bFollowingGPS) {
					m_CameraAngle = m_CameraAngleMove;
					Debug.Log ("Camera set to move: " + m_CameraAngleMove);
			}*//**/
			/*
				//-------------------
				// Move sky
				float angledif = m_CameraAngle - prevangle;

				RectTransform rectTransform2;// = m_TooltipBack.GetComponent<RectTransform> ();
				rectTransform2 = m_Sky.GetComponent<RectTransform> ();
				Vector2 pos = rectTransform2.anchoredPosition;
				pos.x += angledif * 5.0f;
			if (pos.x > rectTransform2.rect.width) {
				pos.x = -rectTransform2.rect.width;
			} else if (pos.x < -rectTransform2.rect.width) {
					pos.x = rectTransform2.rect.width;
			}

				rectTransform2.anchoredPosition = pos;
			Vector3 scale = rectTransform2.localScale;
					scale.x = 1.1f;
			rectTransform2.localScale = scale;


				rectTransform2 = m_Sky2.GetComponent<RectTransform> ();
			
			if (pos.x >= 0.0f) {
					pos.x -= rectTransform2.rect.width;
			} else {
					pos.x += rectTransform2.rect.width;
			}
				//pos.x -= rectTransform2.rect.width;

				rectTransform2.anchoredPosition = pos;
				//------------------




			updatePinOrientations ();

			float rad = -prevangle - 90;// * Mathf.Rad2Deg;
			//		rad = -90.0f;
			Quaternion rotprev = new Quaternion ();
				rotprev.eulerAngles = new Vector3 (m_CameraPitch, rad, 0); //Vector3(40, rad, 0);

				Vector3 relativePos;
				Vector3 up1;
			up1.x = 0.0f;
			up1.y = 1.0f;
			up1.z = 0.0f;
				up1 = rotprev * up1;
				Vector3 up2;

			rad = -m_CameraAngle - 90;// * Mathf.Rad2Deg;
			Quaternion rotnext = new Quaternion ();
				rotnext.eulerAngles = new Vector3 (m_CameraPitch, rad, 0);//Vector3(40, rad, 0);

				up2.x = 0.0f;
				up2.y = 1.0f;
				up2.z = 0.0f;
				up2 = rotnext * up2;

			cam.transform.rotation = Quaternion.Lerp (rotprev, rotnext, 0.0f);

			float heightoffset2d = 0.0f;
			float to2dmapproc = 0.0f;
			if (m_bIn2dMap) {
				if (m_bTo2dMap) {
					to2dmapproc = m_To2dMapTimer / 5.0f;
					//	heightoffset2d = 200.0f * to2dmapproc;
				} else {
					//		heightoffset2d = 200.0f;
					to2dmapproc = 1.0f;
				}
			} else if (m_bTo3dMap) {
					to2dmapproc = 1.0f - (m_To3dMapTimer / 5.0f);
			}
			if (to2dmapproc < 0.0f) {
				to2dmapproc = 0.0f;
			} else if (to2dmapproc > 1.0f) {
				to2dmapproc = 1.0f;
			}
			rad = prevangle * Mathf.Deg2Rad;

			float cosangle = Mathf.Cos (rad);
			float sinangle = Mathf.Sin (rad);

			float centerx = 2560 / 2.0f;
			float centery = 2560 / 2.0f;

			//float offset = 1320 - 1024;

			float dist = 400 + to2dmapproc * 400.0f;
			float width = Mathf.Cos (Mathf.Deg2Rad * m_CameraPitch) * dist;
			float height = Mathf.Sin(Mathf.Deg2Rad * m_CameraPitch) * dist;
			float offset = width;

			//Debug.Log ("CameraPitch: " + m_CameraPitch + " offset: " + offset);

			float vecmovex = offset * cosangle - 0.0f * sinangle;
			float vecmovey = 0.0f * cosangle + offset * sinangle;

			float camoffsetlen = 60.0f * (1.0f - to2dmapproc);
			float camoffsetx = 0.0f;//camoffsetlen * cosangle;
			float camoffsety = 0.0f;//100.0f;//camoffsetlen * sinangle;

			Vector3 oldpos = new Vector3 ();
			oldpos.x = -centerx + vecmovex + up1.x * camoffsetlen;
			oldpos.y = height + up1.y * camoffsetlen + heightoffset2d;//// 380;//700;//380;
			oldpos.z = centery + vecmovey + up1.z * camoffsetlen;

			rad = m_CameraAngle * Mathf.Deg2Rad;

			cosangle = Mathf.Cos (rad);
			sinangle = Mathf.Sin (rad);
			vecmovex = offset * cosangle - 0.0f * sinangle;
			vecmovey = 0.0f * cosangle + offset * sinangle;

			camoffsetx = 0.0f;//camoffsetlen * cosangle;
			camoffsety = 0.0f;//100.0f;//camoffsetlen * sinangle;

			Vector3 vecnewpos = new Vector3 ();
			vecnewpos.x = -centerx + vecmovex + up2.x * camoffsetlen;
			vecnewpos.y = height + up2.y * camoffsetlen + heightoffset2d;//300;//380;//700;//380;
			vecnewpos.z = centery + vecmovey + up2.z * camoffsetlen;

			cam.transform.position = Vector3.Lerp (oldpos, vecnewpos, 0.0f);
            */

			cam.transform.position = new Vector3(-512, 512, 512);
			/*
			if (!isCameraModeChange)
				return;

			animValue += Time.deltaTime / CameraChangeTime;

			if (animValue > 1) {
				animValue = 1;
				isCameraModeChange = false;
			}

			c.transform.position = Vector3.Lerp (fromTransform.position, toTransform.position, animValue);
			c.transform.rotation = Quaternion.Lerp (fromTransform.rotation, toTransform.rotation, animValue);

			float fromFOV = is2D ? 60 : 28;
			float toFOV = is2D ? 28 : 60;

			c.fieldOfView = Mathf.Lerp (fromFOV, toFOV, animValue);

			if (!isCameraModeChange && is2D)
				c.orthographic = true;*/
		}
		
		//------------------------
		// Update text
		//Debug.Log ("### Update...");
		if (bPositionChanged || m_bForceUpdate) {
#if DEBUGAPP
			updateText++;
#endif

			Debug.Log ("### Update text");
			m_bForceUpdate = false;
			RectTransform rect;

			bool bWasInReachOfPoint = m_bInReachOfPoint;
			m_bInReachOfPoint = false; 
			if (m_bSelectedPin) {
				if (m_bIn2dMap == false) {
					m_DistanceBack.SetActive (true);
					m_DistanceBackHorizon.SetActive (true);

					//m_DistanceText.SetActive (true);
				}
				//	m_ButtonZoomIn.SetActive (false);
				//		m_ButtonZoomOut.SetActive (false);
				/*m_ButtonZoomInTop.SetActive (true);
				m_ButtonZoomOutTop.SetActive (true);*/

				/*if (m_bStartReadGPS || m_bFollowingGPS) {
					m_ButtonFollowGPSTop.SetActive (false);
				} else {
					m_ButtonFollowGPSTop.SetActive (true);
				}*/
			//	m_ButtonFollowGPS.SetActive (false);

				Vector2 pinpos;
				pinpos.x = (float)m_SelectedPin.m_Lng;
				pinpos.y = (float)m_SelectedPin.m_Lat;
				float stepDistance = OnlineMapsUtils.DistanceBetweenPoints (m_PlayerPosition, pinpos).magnitude;
				stepDistance *= 1000.0f;
				int meters = (int)stepDistance;

				UnityEngine.UI.Text text;
				UnityEngine.UI.Text text2;

				/*if (m_SelectedPin.m_bDone || m_SelectedPin.m_NrVisits > 0) {
					m_ButtonShowPictures.SetActive (true);
					m_ButtonShowPicturesLeft.SetActive (true);
				} else {*/
					m_ButtonShowPictures.SetActive (false);
					m_ButtonShowPicturesLeft.SetActive (false);
				//}

				if (true /*m_SelectedPin.m_bDone == false && m_SelectedPin.m_NrVisits <= 0*/) {
					/*text = m_DistanceText.GetComponent<UnityEngine.UI.Text> ();
					text2 = m_DistanceText2.GetComponent<UnityEngine.UI.Text> ();*/

					text = m_TooltipText.GetComponent<UnityEngine.UI.Text> (); // In IGN app show this info as pin info not in top bar
					text2 = m_TooltipTextLeft.GetComponent<UnityEngine.UI.Text> ();


					bool bInReachOfPoint = false;
					if (meters > m_InnerDistance && !m_bZoomTouched && !m_bIn2dMap) {
						if (meters >= 2000.0f) {
						} else if (meters <= 2000.0f) {
							if (api.zoom < 13) { // Zoom in but don't zoom out
								api.zoom = 13;
								enableZoomButtons ();
							}
						} else if (meters > 500.0f) {
							if (api.zoom < 14) { // Zoom in but don't zoom out
								api.zoom = 14;
								enableZoomButtons ();
							}
						} else if (meters > 400.0f) {
							if (api.zoom < 15) { // Zoom in but don't zoom out
								api.zoom = 15;
								enableZoomButtons ();
							}
						} else if (meters > 250.0f) {
							if (api.zoom < 16) { // Zoom in but don't zoom out
								api.zoom = 16;
								enableZoomButtons ();
							}
						} else if (meters > 100.0f) {
							if (api.zoom < 17) { // Zoom in but don't zoom out
								api.zoom = 17;
								enableZoomButtons ();
							}
						} else {
							if (api.zoom < 18) { // Zoom in but don't zoom out
								api.zoom = 18;
								enableZoomButtons ();
							}
						}
					}

					if (meters <= m_InnerDistance) {
						m_ButtonStartQuest.SetActive (true);
						m_ButtonStartQuest.GetComponent<Button>().interactable = true;

						m_ButtonPointNotReachable.SetActive (true);

						bInReachOfPoint = true;
						m_bInReachOfPoint = true;
						//m_bFollowingGPS = false; // Dont follow as soon as in reach of point
						//m_ButtonFollowGPSTop.SetActive (false);

					/*	if (!bWasInReachOfPoint && !m_bIn2dMap) { // Change location to pin if it wasnt at player position
							if (api.zoom < 19) {
								api.zoom = 19;
								enableZoomButtons ();
								updatePins ();
							}

							OnLocationChanged (m_PlayerPosition);
						}*/
						m_StartQuestBackground.SetActive (true);
						m_StartQuestBackgroundLine.SetActive (true);
						updateToPositionButtons (false);
					} else if (meters <= m_NearDistance) {
						
						m_ButtonStartQuest.SetActive (true);
						m_ButtonStartQuest.GetComponent<Button>().interactable = false;

						m_ButtonPointNotReachable.SetActive (true);

						m_StartQuestBackground.SetActive (true);
						m_StartQuestBackgroundLine.SetActive (true);
						updateToPositionButtons (false);
					} else if (meters <= m_OuterDistance) {
					//	m_ButtonNearlyStartQuest.SetActive (false);

						m_ButtonStartQuest.SetActive (true);
						m_ButtonStartQuest.GetComponent<Button>().interactable = false;

					//	m_ButtonStartQuestHighlighted.SetActive (false);
						m_ButtonPointNotReachable.SetActive (true);

						m_StartQuestBackground.SetActive (true);
						m_StartQuestBackgroundLine.SetActive (true);

						updateToPositionButtons (false);
					} else {
						m_ButtonStartQuest.SetActive (false);
					//	m_ButtonStartQuestHighlighted.SetActive (false);
				//		m_ButtonNearlyStartQuest.SetActive (false);
						m_ButtonPointNotReachable.SetActive (false);

						m_StartQuestBackground.SetActive (false);
						m_StartQuestBackgroundLine.SetActive (false);

						updateToPositionButtons (true);
					}


					if (!bInReachOfPoint) {

						/*	string move1 = LocalizationSupport.GetString("Move1");
							string move2 = LocalizationSupport.GetString("Move2");
							text.text = move1 + " " + meters + " " + move2;
							text2.text = move1 + " " + meters + " " + move2;*/
						string score = m_SelectedPin.m_Weight;
						string move1 = LocalizationSupport.GetString("Score1");
						string move2 = LocalizationSupport.GetString("Score2");
						text.text = move1 + " " + score + " " + move2;
						text2.text = move1 + " " + score + " " + move2;

						/*if (Application.systemLanguage == SystemLanguage.German) {
							text.text = "Bewege dich " + meters + " m näher zum Ziel...";
							text2.text = "Bewege dich " + meters + " m näher zum Ziel...";
						} else {
							text.text = "Move " + meters + " m closer to the target...";
							text2.text = "Move " + meters + " m closer to the target...";
						}*/


						updatePinBackgrounds (false);
					} else {

						string score = m_SelectedPin.m_Weight;
						string move1 = LocalizationSupport.GetString("Score1");
						string move2 = LocalizationSupport.GetString("Score2");
						text.text = move1 + " " + score + " " + move2;
						text2.text = move1 + " " + score + " " + move2;

						/*if (Application.systemLanguage == SystemLanguage.German) {
						//	text.text = "Zielpunkt erreicht.\nDu kannst jetzt Bilder machen.";
							//text.text = "Zielpunkt erreicht.\nDu kannst jetzt Bilder vom Punkt machen!";
							text.text = "Super, du bist jetzt sehr nahe. GPS ist jetzt zu ungenau. Verwende deshalb nur die Karte als Orientierung um so nahe wie möglich an den Punkt zu gelangen.";
							text2.text = "Super, du bist jetzt sehr nahe. GPS ist jetzt zu ungenau. Verwende deshalb nur die Karte als Orientierung um so nahe wie möglich an den Punkt zu gelangen.";
						} else {
					//		text.text = "Target point reached.\nYou can now take pictures.\nYou can now take pictures.";
							//		text.text = "You are now very close to the point.\nLook at the map and try to get as close to the point as possible.\nThen start taking pictures.";
							text.text = "Great, you are very close. Ignore your GPS location now and just use the map as guidance to get as close to the point as possible.";
							text2.text = "Great, you are very close. Ignore your GPS location now and just use the map as guidance to get as close to the point as possible.";
						}*/
						updatePinBackgrounds (true);
					}
				} else {
					// Quest has been already done
					text = m_DistanceText.GetComponent<UnityEngine.UI.Text> ();
					text2 = m_DistanceText2.GetComponent<UnityEngine.UI.Text> ();
					string selectquest = LocalizationSupport.GetString("SelectQuest");
					text.text = selectquest;
					text2.text = selectquest;/*
					if (Application.systemLanguage == SystemLanguage.German ) {
						text.text = "Wähle eine Quest aus!";
						text2.text = "Wähle eine Quest aus!";
					} else {
						text.text = "Select a point to start your quest!";
						text2.text = "Select a point to start your quest!";
					}*/

					m_ButtonStartQuest.SetActive (false);
				//	m_ButtonStartQuestHighlighted.SetActive (false);
			//		m_ButtonNearlyStartQuest.SetActive (false);
					m_ButtonPointNotReachable.SetActive (false);

					m_StartQuestBackground.SetActive (false);
					m_StartQuestBackgroundLine.SetActive (false);

					updateToPositionButtons (true);
				}


				m_SelectedPinTimer += 1000.0f/*1600.0f */* Time.deltaTime;
				float proc = 1.0f;
				bool bTooltipActive = true;
				float duration = 10000000.0f; // 10000.0f
				if (m_SelectedPinTimer < duration /*+ 10000000.0f*/) {
					proc = 1.0f;
				} /*else if (m_SelectedPinTimer < (duration + 300.0f)) {
					proc = (m_SelectedPinTimer - duration) / (300.0f);
				proc = 1.0f - proc;
			} */else {
					bTooltipActive = false;
				}

				if (bTooltipActive) {
							#if ASDFASDFASDFASDFASDFASDF
					text = m_TooltipText.GetComponent<UnityEngine.UI.Text> ();
					text2 = m_TooltipTextLeft.GetComponent<UnityEngine.UI.Text> ();
					if (m_SelectedPin.m_bDone == false) {
						if (Application.systemLanguage == SystemLanguage.German) {
							if (m_SelectedPin.m_NrVisits <= 0) {
								//text.text = "Sei der erste der diesen Punkt besucht und hilf damit beim Umweltschutz.\n<i>Wert: " + m_SelectedPin.m_Weight + " Punkte</i>";
						

								float money = float.Parse (m_SelectedPin.m_Weight) / 100.0f;
								string strtotal = money.ToString ("F2");//4F9F56FF//20A0DABF
								text.text = LocalizationSupport.GetString("ToolTipBeFirst");//"Besuche als Erste(r) diesen Punkt!";	
								if (m_bInReachOfPoint) {
									text.text = LocalizationSupport.GetString("ToolTipInReach");//"Mache wenn du dich genau auf dem Punkt befindest die Bilder!";
								}
							} else {
								string conqueredby = m_SelectedPin.m_Conquerer;
								if (conqueredby.Length <= 0) {
									conqueredby = LocalizationSupport.GetString("ToolTipUnknown");//"Unbekannt";
								}
								//	text.text = "Bereits besucht von " + conqueredby + ".\nAnzahl Besucher: " + m_SelectedPin.m_NrVisits+ "\n<i>Wert: " + m_SelectedPin.m_Weight + " Punkte.</i>";
								//		text.text = "Bereits besucht von " + conqueredby + ".\n<i>Bilder ansehen.</i>";
							//	text.text = "Bereits besucht von " + conqueredby + ".\n";
								//text.text = "Die Quest wurde bereits von " + conqueredby + " gemacht.";
								text.text = LocalizationSupport.GetString("ToolTipAlreadyDone1") + " " + conqueredby + " " + LocalizationSupport.GetString("ToolTipAlreadyDone2");
							}
						} else {
							if (m_SelectedPin.m_NrVisits <= 0) {
								//text.text = "Be the first to photograph this point to help protect nature.\n<i>Score Points: " + m_SelectedPin.m_Weight + "</i>";
								//text.text = "Be the first to visit this point to help protect nature.\n<i>Score Points: " + m_SelectedPin.m_Weight + "</i>";

								float money = float.Parse (m_SelectedPin.m_Weight) / 100.0f;
								string strtotal = money.ToString ("F2");//4F9F56FF//20A0DABF
								text.text = LocalizationSupport.GetString("ToolTipBeFirst");//"Be the first to visit this point!";

								if (m_bInReachOfPoint) {
									text.text = LocalizationSupport.GetString("ToolTipInReach");//"When you think you are exactly at the point, take the pictures!";
								}

							} else {
								string conqueredby = m_SelectedPin.m_Conquerer;
								if (conqueredby.Length <= 0) {
									conqueredby = LocalizationSupport.GetString("ToolTipUnknown");//"unknown";
								}
								/*text.text = "Quest already visited by " + conqueredby  +  ".\nNumber of visitors: " + m_SelectedPin.m_NrVisits + "\n<i>Score Points: " + m_SelectedPin.m_Weight + "</i>";
								text.text = "Already visited by " + conqueredby  +  ".\n<color=#41A2F8FF><i>See pictures</i></color>";
								text.text = "Already visited by " + conqueredby  +  ".\n<color=#41A2F8FF>See pictures</color>";
							*/
							//	text.text = "Already visited by " + conqueredby + ".\n";
								//text.text = "Quest already done by " + conqueredby + ".";
								text.text = LocalizationSupport.GetString("ToolTipAlreadyDone1") + " " + conqueredby + " " + LocalizationSupport.GetString("ToolTipAlreadyDone2");

							}
						}
					} else {

						if (Application.systemLanguage == SystemLanguage.German) {
									string username = LocalizationSupport.GetString("ToolTipUnknown");//"Unbekannt";
							if (PlayerPrefs.HasKey ("PlayerName")) {
								username = PlayerPrefs.GetString ("PlayerName");
							}

							//	text.text = "Bereits besucht von " + username + ".\n<i>Bilder ansehen.</i>";
						//	text.text = "Bereits besucht von " + username + ".\n";
							//text.text = "Die Quest wurde bereits von " + username + " gemacht.";
							text.text = LocalizationSupport.GetString("ToolTipAlreadyDone1") + " " + username + " " + LocalizationSupport.GetString("ToolTipAlreadyDone2");

						} else {
									string username = LocalizationSupport.GetString("ToolTipUnknown");//"unknown";
							if (PlayerPrefs.HasKey ("PlayerName")) {
								username = PlayerPrefs.GetString ("PlayerName");
							}

							/*	text.text = "Already visited by " + username + ".\n<color=#41A2F8FF><i>See pictures.</i></color>";
							text.text = "Already visited by " + username + ".\n<color=#41A2F8FF>See pictures</color>";
						*/
										//text.text = "Already visited by " + username + ".\n";
						//	text.text = "Quest already done by " + username + ".";
							text.text = LocalizationSupport.GetString("ToolTipAlreadyDone1") + " " + username + " " + LocalizationSupport.GetString("ToolTipAlreadyDone2");

						}
					}

					text2.text = text.text;
							#endif

				} else {
					m_Tooltip.SetActive (false);
					m_TooltipLeft.SetActive (false);
				}

			} else {
				/*if (!m_bIn2dMap) {
					m_DistanceBack.SetActive (true);
					m_DistanceBackHorizon.SetActive (true);
					//m_DistanceText.SetActive (true);
				}*/

				UnityEngine.UI.Text text;
				UnityEngine.UI.Text text2;
				text = m_DistanceText.GetComponent<UnityEngine.UI.Text> ();
				text2 = m_DistanceText2.GetComponent<UnityEngine.UI.Text> ();

				string selectquest = LocalizationSupport.GetString("SelectQuest");
				text.text = selectquest;
				text2.text = selectquest;/*
				if (Application.systemLanguage == SystemLanguage.German) {
					text.text = "Wähle eine Quest aus!";
					text2.text = "Wähle eine Quest aus!";
				} else {
					text.text = "Select a point to start your quest!";
					text2.text = "Select a point to start your quest!";
				}*/

				/*float newpos = m_ButtonHeightPosition;

			m_ButtonZoomIn.SetActive (false);
			m_ButtonZoomOut.SetActive (false);*/
				/*m_ButtonZoomInTop.SetActive (true);
				m_ButtonZoomOutTop.SetActive (true);*/


				m_Tooltip.SetActive (false);
				m_TooltipLeft.SetActive (false);


				/*

				if (m_bStartReadGPS || m_bFollowingGPS) {
					m_ButtonFollowGPSTop.SetActive (false);
				} else {
					m_ButtonFollowGPSTop.SetActive (true);
				}*/
			//	m_ButtonFollowGPS.SetActive (false);
			}
		}

		if (m_bIn2dMap || m_bTo2dMap || m_bTo3dMap) {
			UpdateLine ();
		}

		if (m_bTouchMoving == false && Input.touchCount <= 0 && !m_bFollowingGPS) {
			if (m_FrameRate == 30) {
				m_FrameRateIter++;
				if (m_FrameRateIter > 400/*500*/) {
					m_FrameRate = 10;
					Application.targetFrameRate = 5;//5;
				}
			}
			
		} else {
			m_FrameRateIter = 0;
			if (m_FrameRate != 30) {
				m_FrameRate = 30;
				Application.targetFrameRate = 30;
			}
		}


#if DEBUGAPP
			m_TextStatus.GetComponent<UnityEngine.UI.Text> ().text = "m_bUpdatePins: " + m_bUpdatePins + " updateTool: " + updateTool + 
				" updateText: " + updateText + " updateRotation: " + updateRotation +
				" update: " + m_NrItersUpdate + " nrloads: " + m_NrItersLoad + " m_FrameRate: " + m_FrameRate + " m_FrameRateIter: " + m_FrameRateIter;
#endif
	}


	bool m_bPinsLoaded = false;
	private void loadPins()
	{
		//return;// Todo comment out again
		/*if (m_bLoadMarkers >= 10) {
			return;
		}*/
		if (m_bLoadMarkers == 1) {
			return;
		}

		if(m_bLocationEnabled == false && m_bDebug == false)
        {
			return;
        }
		int nrpins = 0;
		if (PlayerPrefs.HasKey ("CacheNrPins")) {
			nrpins = PlayerPrefs.GetInt ("CacheNrPins");
		}

		if(m_bPinsLoaded)
        {
			removePins();
			addPins();
			return;
        }
		m_bPinsLoaded = true;

		/*if (nrpins > 1000 && m_bHasAlreadyLoadedPins) {
		//if (nrpins > 0) {
		//	loadPinsFromCache ();
	//		return;
		}*/


		/*m_TextLocationOutside.SetActive (true);
		m_BackLocationOutside.SetActive (true);*/
		m_TextLocationOutside.SetActive (false);
		m_BackLocationOutside.SetActive (false);

		m_bHasAlreadyLoadedPins = true;
		Debug.Log ("loadPins from internet");

		m_NrItersLoad++;
		m_bLoadMarkers = 1;
		//createPuzzlePins ();

		OnlineMaps api = OnlineMaps.instance;

		//Debug.Log ("mapx : " + api.bottomRightPosition.x + " y: " + api.bottomRightPosition.y + " x: " + api.topLeftPosition.x + " y: " + api.topLeftPosition.y);

		//string url = "https://geo-wiki.org/Application/api/campaign/FraQuestLocations";
		string url = "https://geo-wiki.org/Application/api/campaign/FraQuestLocations";
		string param = "{";

		if (PlayerPrefs.HasKey ("PlayerId")) {
		//	param += "\"userid\":\"" + PlayerPrefs.GetString("PlayerId") + "\",";
		}

		if (PlayerPrefs.HasKey ("PlayerMail")) {
			string email = PlayerPrefs.GetString ("PlayerMail");
			string password = PlayerPrefs.GetString ("PlayerPassword");
			string passwordmd5 = ComputeHash (password);

			param += "\"email\":" + "\"" + email + "\",\"md5password\":" + "\"" + passwordmd5 + "\"" + ",";
		}


		/*	param += "\"bbox\":{\"xmin\":\"" + "-26.63607" + "\",\"xmax\":\"" + "85.86393" + "\",\"ymin\":\"" +
				"-59.40792" + "\",\"ymax\":\"" + "35.66308" + "\"}"; // Load all pins
	*/
		//param += "\"bbox\":{\"xmin\":\"" + api.topLeftPosition.x + "\",\"xmax\":\"" + api.bottomRightPosition.x + "\",\"ymin\":\"" + api.bottomRightPosition.y + "\",\"ymax\":\"" + api.topLeftPosition.y + "\"}";
		float km = 50;
		float xmin = m_PlayerPosition.x - (0.009f * km);
		float xmax = m_PlayerPosition.x + (0.009f * km);
		float ymin = m_PlayerPosition.y - (0.009f * km);
		float ymax = m_PlayerPosition.y + (0.009f * km);

		/*float xmin = m_PlayerPosition.x - 0.5f;
		float xmax = m_PlayerPosition.x + 0.5f;
		float ymin = m_PlayerPosition.y - 0.5f;
		float ymax = m_PlayerPosition.y + 0.5f;*/
		param += "\"bbox\":{\"xmin\":\"" + xmin + "\",\"xmax\":\"" + xmax + "\",\"ymin\":\"" + ymin + "\",\"ymax\":\"" + ymax + "\"}";

		//param += "\"bbox\":{\"xmin\":\"" + 4.79291f + "\",\"xmax\":\"" + 4.902773f + "\",\"ymin\":\"" + 52.32833f + "\",\"ymax\":\"" + 52.39542 + "\"}";


		/*if (api.zoom < 13) {
			param += ",\"limit\":\"500\"";
		} else {
			param += ",\"limit\":\"100\"";
		}*/
		//param += ",\"limit\":\"2000\"";
		//param += ",\"limit\":\"500\"";
		param += ",\"limit\":\"1000\"";
		//	param += ",\"limit\":\"5\"";
		param += ",\"sampleids\":\"";
		string sampleids = "";
		string sessions = PlayerPrefs.GetString("ActiveSessions");
		string[] splitArray = sessions.Split(char.Parse(" "));
		for (int i = 0; i < splitArray.Length; i++)
		{
			if (splitArray[i].Length > 0)
			{
				if (sampleids == "")
				{
					sampleids = splitArray[i];
				}
				else
				{
					sampleids = sampleids + "," + splitArray[i];
				}
			}
		}
		//Debug.Log("Sessions: " + sessions + " len: " + splitArray.Length);
		param += sampleids;
		param += "\"";


		//	param += ",\"platform\":{\"app\""+ ":" + "\"21\"" + "}";//Android
		//param += ",\"platform\":{\"app\""+ ":" + "\"20\"" + "}";//Android
		param += ",\"platform\":{\"app\""+ ":" + "\"21\"" + "}";//Android
		param += "}";
		Debug.Log ("loadPins param: " + param);


		WWWForm form = new WWWForm();
		form.AddField ("parameter", param);

		//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
		WWW www = new WWW(url, form);

		StartCoroutine(WaitForPins(www));
	}

	int m_CurrentPin = 0;
	int m_ReadingWhich = 0;
	int m_NearPinId = -1;
	int g_LoadMapsError = 0;

	bool m_bAutoZoomOut = false;
	int m_AutoZoomIter = 1;//0;

	IEnumerator WaitForPins(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Pins data!: " + www.text);
			m_NrPins = 0;
			m_CurrentPin = -1;
			m_ReadingWhich = 0;
			JSONObject j = new JSONObject(www.text);
			accessPinData(j);
			m_NrPins = m_CurrentPin + 1;
			cachePinData ();
			//createNearPin ();
			removePins ();

			//selectNearestPinOnStart ();
			addPins ();
			m_bLoadMarkers = 0;


			if (m_NrPins > 0 && !m_bOnePinVisible)
            {
				m_bAutoZoomOut = true;
			}

			//clickOnNearestPin ();
			Debug.Log(m_NrPins + " pins loaded");

			m_TextLocationOutside.SetActive (false);
			m_BackLocationOutside.SetActive (false);

		} else {
			Debug.Log ("Could not load points");
			Debug.Log("WWW Error Pins: "+ www.error);
			Debug.Log("WWW Error Pins 2: "+ www.text);
			loadPinsFromCache ();
		}   
	} 

	void loadPinsFromCache() {
		Debug.Log ("loadPinsFromCache");
		m_bLoadMarkers = 0;


		m_NrPins = 0;
		m_CurrentPin = -1;
		m_ReadingWhich = 0;
		loadCacheData();
		//createNearPin ();
		m_NrPins = m_CurrentPin;// + 1;
		removePins ();

		//selectNearestPinOnStart ();
		addPins ();
		m_bLoadMarkers = 0;

		//clickOnNearestPin ();

		m_TextLocationOutside.SetActive (false);
		m_BackLocationOutside.SetActive (false);
	}

	void accessPinData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				//	Debug.Log("key: " + key);
				if (key == "id") {
					m_CurrentPin++;
					if (m_CurrentPin >= 2000) {
						m_CurrentPin = 1999;
					}
					m_ReadingWhich = 1;
				} else if (key == "lat") {
					m_ReadingWhich = 2;
				} else if (key == "lon") {
					m_ReadingWhich = 3;
				} else if (key == "weight") {
					m_ReadingWhich = 4;
				} else if (key == "color") {
					m_ReadingWhich = 5;
				} else if (key == "first_visitor") {
					m_ReadingWhich = 6;
				} else if (key == "count_visits") {
					m_ReadingWhich = 7;
				} else {
					m_ReadingWhich = 0;
				}
				accessPinData(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			//	Debug.Log ("Array");
			foreach(JSONObject j in obj.list){
				accessPinData(j);
			}
			break;
		case JSONObject.Type.STRING:
			if (m_ReadingWhich == 1) {
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
			}
			break;
		case JSONObject.Type.NUMBER:
			if (m_ReadingWhich == 4) {
				m_Pins [m_CurrentPin].m_Weight = "" + obj.n;
			} else if (m_ReadingWhich == 7) {
				m_Pins [m_CurrentPin].m_NrVisits = (int)obj.n;
			}
			break;
		case JSONObject.Type.BOOL:
			//		Debug.Log("bool: " + obj.b);
			break;
		case JSONObject.Type.NULL:
			//	Debug.Log("NULL");
			break;

		}
	}

	void cachePinData()
	{
		int nrpins = m_CurrentPin + 1;
		Debug.Log ("cachePinData nr pins: " + nrpins);
		PlayerPrefs.SetInt("CacheNrPins", nrpins);

		for (int i = 0; i < nrpins; i++) {
			PlayerPrefs.SetString ("CachePin_" + i + "_Id", m_Pins [i].m_Id);
			PlayerPrefs.SetString ("CachePin_" + i + "_Weight", m_Pins [i].m_Weight);
			PlayerPrefs.SetString ("CachePin_" + i + "_Color", m_Pins [i].m_Color);

			float lat = (float)m_Pins [i].m_Lat;
			float lng = (float)m_Pins [i].m_Lng;
			PlayerPrefs.SetFloat ("CachePin_" + i + "_Lat", lat);
			PlayerPrefs.SetFloat ("CachePin_" + i + "_Lng", lng);

			int nrvisits = m_Pins [i].m_NrVisits;
			PlayerPrefs.SetInt ("CachePin_" + i + "_NrVisits", nrvisits);

			//string conquerer = m_Pins [i].m_Conquerer;
			//PlayerPrefs.SetString ("CachePin_" + i + "_Conquerer", conquerer);
		}
		PlayerPrefs.Save ();
	}

	void loadCacheData()
	{
		int nrpins = PlayerPrefs.GetInt ("CacheNrPins");
		for (int i = 0; i < nrpins; i++) {
			m_Pins [i].m_Id = PlayerPrefs.GetString ("CachePin_" + i + "_Id");
			m_Pins [i].m_Weight = PlayerPrefs.GetString ("CachePin_" + i + "_Weight");
			m_Pins [i].m_Color = PlayerPrefs.GetString ("CachePin_" + i + "_Color");

			float lat;
			float lng;
			lat = PlayerPrefs.GetFloat ("CachePin_" + i + "_Lat");
			lng = PlayerPrefs.GetFloat ("CachePin_" + i + "_Lng");
			m_Pins [i].m_Lat = (double)lat;
			m_Pins [i].m_Lng = (double)lng;

			if (PlayerPrefs.HasKey ("CachePin_" + i + "_NrVisits")) {
				m_Pins [i].m_NrVisits = PlayerPrefs.GetInt ("CachePin_" + i + "_NrVisits");
			} else {
				m_Pins [i].m_NrVisits = 0;
			}

			/*if (PlayerPrefs.HasKey ("CachePin_" + i + "_Conquerer")) {
				m_Pins [i].m_Conquerer = PlayerPrefs.GetString ("CachePin_" + i + "_Conquerer");
			} else {
				m_Pins [i].m_Conquerer = "";
			}*/
		}

		m_CurrentPin = nrpins;
	}


	private bool pinAlreadyDone(string pinid) {
		int nrquestsmade = m_QuestsMade.Count;
		//Debug.Log ("pinAlreadyDone nr: " + nrquestsmade);
		for(int i=0; i<nrquestsmade; i++) { 
			if(pinid.Equals(m_QuestsMade [i])) {
				//	Debug.Log ("Pin already done: " + pinid);
				return true;
			}

		}
		return false;
	}

	/*private bool puzzleAlreadyPicked(int puzzlechunkid, int puzzleid) {
	//	return false; // For testing comment this out
		for(int i=0; i<m_NrPuzzlesPicked; i++) { 
		int curchunk = (int)m_PuzzlesPicked_ChunkId [i];
			int curid = (int)m_PuzzlesPicked_Id [i];
			if(curchunk == puzzlechunkid && curid == puzzleid) {
				return true;
			}
		}
		return false;
	}*/
	/*
private void loadPinsAlreadyDone()
{
	OnlineMaps api = OnlineMaps.instance;

	Debug.Log ("mapx : " + api.bottomRightPosition.x + " y: " + api.bottomRightPosition.y + " x: " + api.topLeftPosition.x + " y: " + api.topLeftPosition.y);

	string url = "https://geo-wiki.org/Application/api/campaign/FotoQuestCompletedQuests";
	string param = "{";

	if (PlayerPrefs.HasKey ("PlayerId") && PlayerPrefs.HasKey ("PlayerMail")) {
		string email = PlayerPrefs.GetString ("PlayerMail");
		param += "\"email\":\"" + PlayerPrefs.GetString ("PlayerMail") + "\",";

		string password = PlayerPrefs.GetString ("PlayerPassword");
		string passwordmd5 = ComputeHash (password);

		//param += "\"md5password\":\"" + passwordmd5 + "\",";
		param += "\"md5password\":\"" + passwordmd5 + "\"";
	} else {
		Debug.Log ("loadPinsAlreadyDone -> not logged in");
		return;
	}

	param += "}";
	Debug.Log ("loadPinsAlreadyDone param: " + param);


	WWWForm form = new WWWForm();
	form.AddField ("parameter", param);

	//Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
	WWW www = new WWW(url, form);

	StartCoroutine(WaitForPinsAlreadyDone(www));
}*/


	/*int m_CurrentPinAlreadyDone;
	int m_ReadingWhichAlreadyDone;
	IEnumerator WaitForPinsAlreadyDone(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW PinsAlreadyDone data: " + www.data);

			string strdata = www.data;
			strdata = strdata.Replace ("NOTICE</b> [8] Undefined property: stdClass::$lucasid<br />", "");
			strdata = strdata.Replace ("<b>", "");
			strdata = strdata.Replace ("\n", "");

			Debug.Log("PinsAlreadyDone str: " + strdata);

			m_CurrentPinAlreadyDone = -1;
			m_ReadingWhichAlreadyDone = 0;
			JSONObject j = new JSONObject(strdata);
			accessPinDataAlreadyDone(j);
			m_NrPinsDone = m_CurrentPinAlreadyDone + 1;
			for (int i = 0; i < m_NrPinsDone; i++) {
				Debug.Log ("pin done: " + i + " id: " + m_PinsDone [i].m_Id + " lat: " + m_PinsDone [i].m_Lat + " lng: " + m_PinsDone [i].m_Lng);
			}

			removePins ();
			addPins ();

		} else {
			Debug.Log ("Could not LoadPinsAlreadyDone");
			Debug.Log("WWW Error: "+ www.error);
			Debug.Log("WWW Error 2: "+ www.data);
		}   
	} 

	void accessPinDataAlreadyDone(JSONObject obj){
		Debug.Log ("accessPinDataAlreadyDone");
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
			//	Debug.Log("Pin already done key: " + key);
				if (key == "id") {
					m_CurrentPinAlreadyDone++;
					if (m_CurrentPinAlreadyDone >= 500) {
						m_CurrentPinAlreadyDone = 499;
					}
					m_ReadingWhichAlreadyDone = 1;
				} else if (key == "lat") {
					m_ReadingWhichAlreadyDone = 2;
				} else if (key == "lon") {
					m_ReadingWhichAlreadyDone = 3;
				} else if (key == "weight") {
					m_ReadingWhichAlreadyDone = 4;
				} else if (key == "color") {
					m_ReadingWhichAlreadyDone = 5;
				} else {
					m_ReadingWhichAlreadyDone = 0;
				}
				accessPinDataAlreadyDone(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			//	Debug.Log ("Array");
			foreach(JSONObject j in obj.list){
				accessPinDataAlreadyDone(j);
			}
			break;
		case JSONObject.Type.STRING:
			if (m_ReadingWhichAlreadyDone == 1) {
				m_PinsDone [m_CurrentPinAlreadyDone].m_Id = obj.str;
			} else if (m_ReadingWhichAlreadyDone == 2) {
				m_PinsDone [m_CurrentPinAlreadyDone].m_Lat = double.Parse(obj.str);
			} else if (m_ReadingWhichAlreadyDone == 3) {
				m_PinsDone [m_CurrentPinAlreadyDone].m_Lng = double.Parse(obj.str);
			} else if (m_ReadingWhichAlreadyDone == 5) {
				m_PinsDone [m_CurrentPinAlreadyDone].m_Color = obj.str;
			}
			break;
		case JSONObject.Type.NUMBER:
			if (m_ReadingWhichAlreadyDone == 4) {
				m_PinsDone [m_CurrentPinAlreadyDone].m_Weight = "" + obj.n;
			}
			break;
		case JSONObject.Type.BOOL:
			//		Debug.Log("bool: " + obj.b);
			break;
		case JSONObject.Type.NULL:
			//	Debug.Log("NULL");
			break;

		}
	}*/

	bool m_bOnePinVisible = false;
	void clusterPins()
	{
		m_bOnePinVisible = false;

		// Calculate screen positions
		for (int i = 0; i < m_NrPins; i++)
		{
			Vector2 markerpos;
			markerpos.x = (float)m_Pins[i].m_Lng;
			markerpos.y = (float)m_Pins[i].m_Lat;
			Vector2 screenPosition = OnlineMapsControlBase.instance.GetScreenPosition(markerpos);
			m_Pins[i].m_ScreenPositionX = screenPosition.x;
			m_Pins[i].m_ScreenPositionY = screenPosition.y;
			m_Pins[i].m_Cluster = null;
			m_Pins[i].m_bVisible = true;

			/*if (pinAlreadyDone(m_Pins[i].m_Id))
			{
				m_Pins[i].m_bVisible = false;
			} else */if(m_Pins[i].m_ScreenPositionX < 0.0f || m_Pins[i].m_ScreenPositionX > Screen.width ||
				m_Pins[i].m_ScreenPositionY < 0.0f || m_Pins[i].m_ScreenPositionY > Screen.height)
            {
				m_Pins[i].m_bVisible = false;
            } else
            {
				m_bOnePinVisible = true;
			}
		}

		if(m_bOnePinVisible)
        {
			if (m_bAutoZoomOut)
			{
				m_bAutoZoomOut = false;
				zoomOutSlow();// One last zoom out that pins are not completely on edge
			}
			m_bAutoZoomOut = false;
		}

		/* if (api.zoom > 15)
         {
           //  return;
         }*/
		if (api.zoom > 17)
		{
			return;
		}

		float clusterdist = 100.0f;
		if(api.zoom <= 11)
        {
			clusterdist = 150.0f;
        }
		// Merge clusters
		for (int i = 0; i < m_NrPins; i++)
		{
			if (m_Pins[i].m_Cluster == null && m_Pins[i].m_bVisible)
			{
				for (int i2 = 0; i2 < m_NrPins; i2++)
				{
					if (i != i2)
					{
						if (/*m_FilterActivites == null || */(m_Pins[i2].m_bVisible && m_Pins[i2].m_Cluster == null))
						{
							float vecx = m_Pins[i].m_ScreenPositionX - m_Pins[i2].m_ScreenPositionX;
							float vecy = m_Pins[i].m_ScreenPositionY - m_Pins[i2].m_ScreenPositionY;
							float dist = (float)Math.Sqrt(vecx * vecx + vecy * vecy);
							if (dist < clusterdist)//100)// 50)// 100)// 40)
							{
								if (m_Pins[i].m_Cluster == null && m_Pins[i2].m_Cluster == null)
								{
									m_Pins[i].m_Cluster = new FotoQuestPinCluster();
									m_Pins[i2].m_Cluster = m_Pins[i].m_Cluster;
									m_Pins[i].m_Cluster.m_Childs.Add(m_Pins[i]);
									m_Pins[i].m_Cluster.m_Childs.Add(m_Pins[i2]);
								}
								else if (m_Pins[i].m_Cluster == null && m_Pins[i2].m_Cluster != null)
								{
									m_Pins[i].m_Cluster = m_Pins[i2].m_Cluster;
									m_Pins[i2].m_Cluster.m_Childs.Add(m_Pins[i]);
								}
								else if (m_Pins[i2].m_Cluster == null && m_Pins[i].m_Cluster != null)
								{
									m_Pins[i2].m_Cluster = m_Pins[i].m_Cluster;
									m_Pins[i].m_Cluster.m_Childs.Add(m_Pins[i2]);
								}
								else if (m_Pins[i].m_Cluster != m_Pins[i2].m_Cluster)
								{
									FotoQuestPinCluster oldcluster = m_Pins[i2].m_Cluster;
									for (int i3 = 0; i3 < m_NrPins; i3++)
									{
										if (m_Pins[i3].m_Cluster == oldcluster)
										{
											m_Pins[i3].m_Cluster = m_Pins[i].m_Cluster;
											m_Pins[i3].m_Cluster.m_Childs.Add(m_Pins[i3]);
										}
									}

								}
							}
						}
					}
				}
			}
		}
	}

	private void addPins()
	{
		//Debug.Log ("addPins nrpints: " + m_NrPins);
		clusterPins();

		//OnlineMaps api = OnlineMaps.instance;
		OnlineMaps api = OnlineMaps.instance;
		//Debug.Log ("mapx : " + api.bottomRightPosition.x + " y: " + api.bottomRightPosition.y + " x: " + api.topLeftPosition.x + " y: " + api.topLeftPosition.y);

		int nrpinsadded = 0;
		for (int i = 0; i < m_NrPins && nrpinsadded < 1000/*500*/; i++) {
			if (/*m_FilterActivites == null ||*/ m_Pins[i].m_bVisible)
			{
				if (m_Pins[i].m_Cluster != null)
				{
					if (m_Pins[i].m_Cluster.m_Marker == null)
					{
						double lat = 0.0f;
						double lng = 0.0f;
						for (int i2 = 0; i2 < m_Pins[i].m_Cluster.m_Childs.Count; i2++)
						{
							lat += m_Pins[i].m_Cluster.m_Childs[i2].m_Lat;
							lng += m_Pins[i].m_Cluster.m_Childs[i2].m_Lng;
						}
						lat /= (double)m_Pins[i].m_Cluster.m_Childs.Count;
						lng /= (double)m_Pins[i].m_Cluster.m_Childs.Count;

						OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();

						int nrpins = m_Pins[i].m_Cluster.m_Childs.Count;



						OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D_3(lng, lat, m_PinCluster, m_PinClusterText, nrpins);//m_PinPlaneYellow);

						//OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D(lng, lat, m_PinPlaneGreen/*m_PinPlane*/);//m_PinPlaneRed);//m_PinPlaneYellow);


						//dynamicMarker.OnClick = OnMarkerClick;
						m_Pins[i].m_Cluster.m_Marker = dynamicMarker;
					}
				}
				else
				{
					if ((m_Pins[i].m_Lng >= api.topLeftPosition.x && m_Pins[i].m_Lng <= api.bottomRightPosition.x &&
					m_Pins[i].m_Lat >= api.bottomRightPosition.y && m_Pins[i].m_Lat <= api.topLeftPosition.y) /*|| true*/)
					{
						Vector2 markerpos;
						markerpos.x = (float)m_Pins[i].m_Lng;//pos.x + Random.Range (-0.1f, 0.1f);
						markerpos.y = (float)m_Pins[i].m_Lat;//pos.y + Random.Range (-0.1f, 0.1f);

						nrpinsadded++;


						OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();

						/*if (m_Pins[i].m_NrVisits > 0)
						{
							//if (m_Pins [i].m_Color == "yellow") {
							OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D(markerpos, m_PinPlaneGreen);//m_PinPlaneYellow);

							dynamicMarker.OnClick = OnMarkerClick;
							m_Pins[i].m_Marker = dynamicMarker;

							Transform markerTransform = dynamicMarker.transform;
							//	if (markerTransform != null) markerTransform.localScale = new Vector3(m_DirectionSize, m_DirectionSize, m_DirectionSize);


						} 
						else
						{*/
						if (pinAlreadyDone(m_Pins[i].m_Id))
						{
							OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D(markerpos, m_PinPlaneGreen);

							dynamicMarker.OnClick = OnMarkerClick;
							m_Pins[i].m_Marker = dynamicMarker;

							Transform markerTransform = dynamicMarker.transform;
						}
						else
						{
							OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D(markerpos, m_PinPlane);

							dynamicMarker.OnClick = OnMarkerClick;
							m_Pins[i].m_Marker = dynamicMarker;

							Transform markerTransform = dynamicMarker.transform;
						}
						/*}*/
					}
				}
			}
		}



		//updatePinOrientations ();

		addSelectedPinMarker ();

	}

		private void OnGOClick(GameObject go)
		{
			if (go == null) {
				Debug.Log ("On go clicked == null");
				return;
			}
			if (m_bPinInfoClosed) {
				Debug.Log (">> On marker click info just closed");
				return;
			}
			// Show in console marker label.
			Debug.Log(">> On GO clicked");
			bool bMarkerFound = false;

		if (m_SelectedPin.m_Marker != null && m_SelectedPin.m_Marker.instance == go) {
			m_SelectedPinTimer = 0.0f;
		}


		for (int i = 0; i < m_NrPins && bMarkerFound == false; i++)
		{
			/*if (m_Pins[i].m_Marker == null)
			{
				Debug.Log("Marker " + i + " = NULL!");
			}*/
			if (m_Pins[i].m_Cluster != null)
			{
				if (m_Pins[i].m_Cluster != null && m_Pins[i].m_Cluster.m_Marker.instance == go)
				{
					bMarkerFound = true;
					//       Debug.Log("CLUSTER clicked");
					api.zoom++;
					Vector2 newpos = new Vector2();

					double lat = 0.0f;
					double lng = 0.0f;
					for (int i2 = 0; i2 < m_Pins[i].m_Cluster.m_Childs.Count; i2++)
					{
						lat += m_Pins[i].m_Cluster.m_Childs[i2].m_Lat;
						lng += m_Pins[i].m_Cluster.m_Childs[i2].m_Lng;
					}
					lat /= (double)m_Pins[i].m_Cluster.m_Childs.Count;
					lng /= (double)m_Pins[i].m_Cluster.m_Childs.Count;

					m_bFollowingGPS = false;
					newpos.x = (float)lng;
					newpos.y = (float)lat;
					api.position = newpos;
					return;
				}
			}
			else if (m_Pins[i].m_Marker != null && m_Pins[i].m_Marker.instance == go && !pinAlreadyDone(m_Pins[i].m_Id))
			{
				bMarkerFound = true;
				Debug.Log(">>># Pin selected: " + m_Pins[i].m_Id);

				//	m_bSelectedPuzzle = false;
				m_bSelectedPin = true;
				m_SelectedPinTimer = 0.0f;
				m_SelectedPin.m_Id = m_Pins[i].m_Id;
				m_SelectedPin.m_Lat = m_Pins[i].m_Lat;
				m_SelectedPin.m_Lng = m_Pins[i].m_Lng;
				m_SelectedPin.m_Color = m_Pins[i].m_Color;
				m_SelectedPin.m_Weight = m_Pins[i].m_Weight;
				m_SelectedPin.m_NrVisits = m_Pins[i].m_NrVisits;
				m_SelectedPin.m_Conquerer = m_Pins[i].m_Conquerer;
				m_SelectedPin.m_bDone = false;
				m_bConquerShiftSet = false;

				bool bWasInReachOfPoint = m_bInReachOfPoint;
				m_bInReachOfPoint = false;

				m_QuestSelectedTime = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				m_PlayerPositionStart.x = m_PlayerPosition.x;
				m_PlayerPositionStart.y = m_PlayerPosition.y;
				m_PlayerLastPosition.x = m_PlayerPosition.x;
				m_PlayerLastPosition.y = m_PlayerPosition.y;
				m_NrPlayerPositions = 0;


				m_DistanceWalkedLastCheckpoint.x = m_PlayerPosition.x;
				m_DistanceWalkedLastCheckpoint.y = m_PlayerPosition.y;
				m_DistanceWalked = 0.0f;

				/*if (m_SelectedPin.m_bDone || m_SelectedPin.m_NrVisits > 0) {
					m_ButtonShowPictures.SetActive (true);
					m_ButtonShowPicturesLeft.SetActive (true);
				} else {*/
				m_ButtonShowPictures.SetActive(false);
				m_ButtonShowPicturesLeft.SetActive(false);
				//}

				m_bForceUpdate = true;

				updatePinInfo();

				m_bPathLoaded = false;
				OnlineMapsFindDirection.Find(new Vector2((float)m_Pins[i].m_Lng, (float)m_Pins[i].m_Lat),
					new Vector2((float)m_PlayerPosition.x, (float)m_PlayerPosition.y
					)).OnComplete += OnGoogleDirectionsComplete;
				/*if(m_SelectedPin.m_NrVisits <= 0) { // Change zoom
					Vector2 pinpos;
					pinpos.x = (float)m_SelectedPin.m_Lng;
					pinpos.y = (float)m_SelectedPin.m_Lat;
					float stepDistance = OnlineMapsUtils.DistanceBetweenPoints(m_PlayerPosition, pinpos).magnitude;
					stepDistance *= 1000.0f;
					int meters = (int)stepDistance;

					if (meters > m_InnerDistance && !m_bIn2dMap) {
						if (meters >= 2000.0f) {
						} else if (meters <= 2000.0f) {
							if (api.zoom < 13) { // Zoom in but don't zoom out
								api.zoom = 13;
								enableZoomButtons ();
								updatePins ();
							}
						} else if (meters > 500.0f) {
							if (api.zoom < 14) { // Zoom in but don't zoom out
								api.zoom = 14;
								enableZoomButtons ();
								updatePins ();
							}
						} else if (meters > 400.0f) {
							if (api.zoom < 15) { // Zoom in but don't zoom out
								api.zoom = 15;
								enableZoomButtons ();
								updatePins ();
							}
						} else if (meters > 250.0f) {
							if (api.zoom < 16) { // Zoom in but don't zoom out
								api.zoom = 16;
								enableZoomButtons ();
								updatePins ();
							}
						} else if (meters > 100.0f) {
							if (api.zoom < 17) { // Zoom in but don't zoom out
								api.zoom = 17;
								enableZoomButtons ();
								updatePins ();
							}
						} else {
							if (api.zoom < 18) { // Zoom in but don't zoom out
								api.zoom = 18;
								enableZoomButtons ();
								updatePins ();
							}
						}
					}

					if (meters <= m_InnerDistance) {
						m_bInReachOfPoint = true;	
						m_bFollowingGPS = false; // Dont follow as soon as in reach of point
					//	m_ButtonFollowGPSTop.SetActive (false);

						if (!bWasInReachOfPoint && !m_bIn2dMap) {
							if(api.zoom < 19) {
								api.zoom = 19;
								enableZoomButtons ();
								updatePins ();
							}
						}
					}
					// Change position -> camera focus might be on pin now
					OnLocationChanged (m_PlayerPosition);
				}*/
			}
		}


		removePins();
		addPins();
	}


	bool m_bPathLoaded = false;
	private Vector2[] m_PathCoords;

	private void OnGoogleDirectionsComplete(string response)
	{
        Debug.Log("****** ONGOOGLEDIRECTIONSCOMPLETE ******");
        Debug.Log(response);

        m_bPathLoaded = false;
        //TextAsset textAsset = (TextAsset)Resources.Load(response);
        XmlDocument xmldoc = new XmlDocument();
        try
        {
            xmldoc.LoadXml(response);
            //xmldoc.LoadXml(textAsset.text);


            List<Vector2> coords = new List<Vector2>();

            bool bFirst = true;
            XmlNodeList steps = xmldoc.GetElementsByTagName("step");//.Item(0).ChildNodes;
            Debug.Log("Google direction. Nr steps: " + steps.Count);
            if (steps.Count < 500)
            {
                foreach (XmlNode step in steps)
                {
                    //  Debug.Log ("Node: " + step.Name);
                    XmlNodeList childs = step.ChildNodes;
                    foreach (XmlNode child in childs)
                    {
                        //   Debug.Log("Child: " + child.Name);
                        if (child.Name.CompareTo("start_location") == 0)
                        {
                            //      Debug.Log ("> startlocation");
                            XmlNodeList coordinate = child.ChildNodes;
                            //      Debug.Log ("Lat: " + coordinate.Item (0).InnerText);
                            //  Debug.Log ("Lng: " + coordinate.Item (1).InnerText);

                            if (bFirst)
                            {
                                coords.Add(new Vector2(float.Parse(coordinate.Item(1).InnerText), float.Parse(coordinate.Item(0).InnerText)));
                            }
                            bFirst = false;
                        }
                        else if (child.Name.CompareTo("end_location") == 0)
                        {
                            //  Debug.Log ("> endlocation");
                            XmlNodeList coordinate = child.ChildNodes;
                            //  Debug.Log ("Lat: " + coordinate.Item (0).InnerText);
                            //      Debug.Log ("Lng: " + coordinate.Item (1).InnerText);

                            coords.Add(new Vector2(float.Parse(coordinate.Item(1).InnerText), float.Parse(coordinate.Item(0).InnerText)));
                        }
                    }
                }

                if (coords.Count > 0)
                {
                    Debug.Log("Path created with " + coords.Count + " coordinates");

                    m_PathCoords = new Vector2[coords.Count];
                    for (int i = 0; i < coords.Count; i++)
                    {
                        m_PathCoords[i] = coords[i];
                    }
                    m_bPathLoaded = true;
                }
            } else {
                m_bPathLoaded = false;
            }
        }
        catch (Exception)
        {
            throw new Exception("Could not load directions");
        }
		addLineToPin ();
	}

	private void OnMarkerClick(OnlineMapsMarkerBase marker)
	{
		return;
	}

	private void OnMarkerClickDone(OnlineMapsMarkerBase marker)
	{
		return;
		/*	if (m_bPinInfoClosed) {
				Debug.Log (">> On marker click info just closed");
			return;
		}

		bool bMarkerFound = false;
		for (int i = 0; i < m_NrPinsDone && bMarkerFound == false; i++) {
			if (m_PinsDone [i].m_Marker == marker) {
				bMarkerFound = true;
				Debug.Log ("Pin selected: " + m_Pins [i].m_Id);

				m_bSelectedPuzzle = false;
				m_bSelectedPin = true;
				m_SelectedPinTimer = 0.0f;
				m_SelectedPin.m_Id = m_PinsDone [i].m_Id;
				m_SelectedPin.m_Lat = m_PinsDone [i].m_Lat;
				m_SelectedPin.m_Lng = m_PinsDone [i].m_Lng;
				m_SelectedPin.m_Color = m_PinsDone [i].m_Color;
				m_SelectedPin.m_Weight = m_PinsDone [i].m_Weight;
				m_SelectedPin.m_bDone = true;
				m_SelectedPin.m_NrVisits = 1;
				m_bConquerShiftSet = false;

				m_ButtonShowPictures.SetActive (true);
				m_ButtonShowPicturesLeft.SetActive (true);

				m_QuestSelectedTime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");

			}
		}
		if (!bMarkerFound) {
			Debug.Log ("No pin found");

			m_bSelectedPin = false;
			m_bSelectedPuzzle = false;

			m_ButtonStartQuest.SetActive (false);
			m_ButtonStartQuestHighlighted.SetActive (false);
			m_ButtonNearlyStartQuest.SetActive (false);
			m_ButtonPointNotReachable.SetActive (false);
		}

		removePins ();
		addPins ();*/
	}

	public void addSelectedPinMarker()
	{
		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
			
		if (m_SelectedPin.m_Marker != null) {
			OnlineMaps api = OnlineMaps.instance;
			control2.RemoveMarker3D (m_SelectedPin.m_Marker);
//			api.RemoveMarker (m_SelectedPin.m_Marker);
			m_SelectedPin.m_Marker = null;
		}
		if (m_bSelectedPin == false) {
			return;
		}
		Vector2 markerpos;
		markerpos.x = (float)m_SelectedPin.m_Lng;//pos.x + Random.Range (-0.1f, 0.1f);
		markerpos.y = (float)m_SelectedPin.m_Lat;//pos.y + Random.Range (-0.1f, 0.1f);


		/*if (m_SelectedPin.m_bDone) {
			OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlaneGreenSelected);
			m_SelectedPin.m_Marker = dynamicMarker;
		} else if (m_SelectedPin.m_Color == "yellow") {
			OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlaneGreenSelected);// m_PinPlaneYellow);
			m_SelectedPin.m_Marker = dynamicMarker;
		} else if (m_SelectedPin.m_Color == "red") {
			OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlaneGreenSelected);// m_PinPlaneRed);
			m_SelectedPin.m_Marker = dynamicMarker;
		} else {*/
		/*if (m_SelectedPin.m_NrVisits > 0) {
			OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlaneGreen);
			m_SelectedPin.m_Marker = dynamicMarker;
		} else {*/
		//	OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlaneSelected);
			OnlineMapsMarker3D dynamicMarker = control2.AddMarker3D (markerpos, m_PinPlane);
			m_SelectedPin.m_Marker = dynamicMarker;
		//}
		//}

//		updatePinOrientations ();
		addLineToPin ();
	}

	public void addLineToPin()
	{
		OnlineMaps api = OnlineMaps.instance;


		/*if (m_bSelectedPuzzle) {
			return;
		}*/
		if (m_bSelectedPin == false /*|| m_SelectedPin.m_bDone || m_SelectedPin.m_NrVisits > 0*/) {
			/*if (m_LineToPin != null) {
				api.RemoveDrawingElement (m_LineToPin);
				m_LineToPin = null;
			}*/
			if (m_bLineInited && m_bLineVisible) {
				hideLine ();
			}
			return;
		}


		List<Vector2> points;
		Vector2 pos;
		Vector2 targpos;
		Color color;

		points = new List<Vector2>();
		pos.x = m_PlayerPosition.x;
		pos.y = m_PlayerPosition.y;
		points.Add (pos);

		targpos.x = (float)m_SelectedPin.m_Lng;
		targpos.y = (float)m_SelectedPin.m_Lat;
		points.Add (targpos);


		color.r = 1.0f;
		color.g = 1.0f;
		color.b = 1.0f;
		color.a = 1.0f;

		if (!m_bLineInited) {
			initLine ();
		} else if (!m_bLineVisible) {
			showLine ();
		}

		if (m_bPathLoaded == false) {
			coords = new Vector2[2];
			coords [0] = new Vector2 (m_PlayerPosition.x, m_PlayerPosition.y);//new Vector2(48.210033f, 16.363449f);//new Vector2();
			coords [1] = new Vector2 ((float)m_SelectedPin.m_Lng, (float)m_SelectedPin.m_Lat);
		} else {
			coords = m_PathCoords;
		}
		UpdateLine ();
	}

	bool m_bLastPositionSet = false;
	float m_SelectedPinTimer = 0.0f;
	int m_LastZoom;
	Vector2 m_LastPosition;

	float m_MapPressX;
	float m_MapPressY;
	bool m_bDragging = false;
	private void OnMapPress()
	{
		m_bDragging = true;
		Debug.Log ("OnMapPress");

/*		if (m_bIn2dMap) {
			OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D> ();
			control2.setUpdateControl (true);
			control2.setAlwaysUpdateControl (true);
		}*/

		/*m_MapPressX = OnlineMaps.instance.position.x;
		m_MapPressY = OnlineMaps.instance.position.y;*/
	}

	private void OnMapRelease()
	{
		m_bDragging = false;
		Debug.Log ("OnMapReleased");

		if (m_bIn2dMap) {
	/*		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D> ();
			control2.setUpdateControl (true);
			control2.setAlwaysUpdateControl (false);*/

			OnChangePosition ();
		}

		/*float difx = OnlineMaps.instance.position.x - m_MapPressX;
		float dify = OnlineMaps.instance.position.y - m_MapPressY;
		if (difx < 0.0f)
			difx *= -1.0f;
		if (dify < 0.0f)
			dify *= -1.0f;


		if (difx > 0.0001f || dify > 0.0001f) {
			
			Debug.Log ("OnMapReleased -> moved");
				
			if (m_bStartReadGPS) {
				return;
			}
			Debug.Log ("OnMapReleased -> Start follow gps: " + m_bStartReadGPS);
			m_bFollowingGPS = false;
		}*/
	}


	private void OnMapZoom()
	{
		m_bForceUpdate = true;

		//closePinInfo ();
		enableZoomButtons ();

		loadPins (); // Commented out
	}

	private void OnChangePosition()
	{
		if (m_bLastPositionSet == false) {
			m_LastPosition = OnlineMaps.instance.position;
			m_LastZoom = OnlineMaps.instance.zoom;
			m_bLastPositionSet = true;
			loadPins ();
		} else /*if(!m_bIn2dMap)*/ {
			float difx = OnlineMaps.instance.position.x - m_LastPosition.x;
			float dify = OnlineMaps.instance.position.y - m_LastPosition.y;

			if (difx < 0.0f)
				difx *= -1.0f;
			if (dify < 0.0f)
				dify *= -1.0f;

			Vector2 topleft = OnlineMaps.instance.topLeftPosition;
			Vector2 bottomright = OnlineMaps.instance.bottomRightPosition;
		/*	Debug.Log ("tl x: " + topleft.x + " tly: " + topleft.y + " brx: " + bottomright.x + " bry: " + bottomright.y);
			Debug.Log ("m_LastPosition x: " + m_LastPosition.x + " y: " + m_LastPosition.y);
			Debug.Log ("Map change pos difx: " + difx + " dify: " + dify);
*/
			float mapwidth = topleft.x - bottomright.x;
			float mapheight = topleft.y - bottomright.y;
			if (mapwidth < 0.0f)
				mapwidth *= -1.0f;
			if (mapheight < 0.0f)
				mapheight *= -1.0f;

			float maxdifx = mapwidth * 0.05f;
			float maxdify = mapheight * 0.05f;
		
			if (difx > maxdifx || dify > maxdify || OnlineMaps.instance.zoom != m_LastZoom) {
				m_LastPosition = OnlineMaps.instance.position;
				m_LastZoom = OnlineMaps.instance.zoom;
				m_bLastPositionSet = true;
				loadPins (); // Commented out
			}
		}

		//UpdateLine ();

	}

	bool m_bLocationGPSDisabled;
	bool m_bLocationGPSDisabledReading;

	private void removePins()
	{
		Debug.Log ("removePins");

		OnlineMaps api = OnlineMaps.instance;

		//if (m_bLoadMarkers == 0) {
		api.RemoveAllMarkers ();
		//	}
		//		if (m_bLoadMarkers == 2) {
		api.RemoveAllDrawingElements ();
		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
		if (control2 != null) {
			control2.RemoveAllMarker3D ();
		}

		//m_LineToPin = null;
		m_SelectedPin.m_Marker = null;

		if (m_bLineInited && m_bLineVisible) {
			hideLine ();
		}


		playerMarker3D = control2.AddMarker3D(m_PlayerPosition, m_PlanePosition);

		if (playerMarker3D != null)
		{
			Transform markerTransformPlayer = playerMarker3D.transform;
			if (markerTransformPlayer != null) markerTransformPlayer.rotation = Quaternion.Euler(0, m_CameraHeading, 0);
		}



		if (control2 == null)
		{
			Debug.Log("You must use the 3D control (Texture or Tileset).");
			return;
		}
	}


	static bool g_locationstarted = false;

	IEnumerator StartLocations()
	{
		UnityEngine.UI.Text textdebug;
		textdebug = m_TextDebug.GetComponent<UnityEngine.UI.Text>();


		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser) {

			m_bLocationGPSDisabled = true;
			m_bLocationGPSDisabledReading = false;

			Debug.Log ("Location ->disabled");
			Vector2 pos;
			pos.y = m_LocationLatDisabled;
			pos.x = m_LocationLngDisabled;
			OnLocationChanged (pos);
		
			loadPins ();



			if (m_bDebug == false) {
				m_TextDebug.SetActive (true);
				m_BackDebug.SetActive (true);

				textdebug.text = LocalizationSupport.GetString("GPSGivePermission");
				/*if (Application.systemLanguage == SystemLanguage.German) {
					textdebug.text = "Bitte gib FotoQuest Go die Erlaubnis GPS benutzen zu dürfen.";
				} else {
					textdebug.text = "Please give FotoQuest Go the permission to use the location service.";
				}*/
				m_BackDebug.GetComponent<Image> ().color = new Color32 (255, 255, 255, 240);//new Color32(243,26,26,240);//new Color32(219,32,32,240);//new Color32(255,20,20,240);
			} else {
					m_TextDebug.SetActive (false);
					m_BackDebug.SetActive (false);
			}

				yield break;
		}

		Input.location.Stop();
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;

		while (Input.location.status == LocationServiceStatus.Initializing /*&& maxWait > 0*/)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}


		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed) {

			m_bLocationGPSDisabled = true;
			m_bLocationGPSDisabledReading = false;

			Debug.Log ("Location -> Unable to determine device location");
			Vector2 pos;
			pos.y = m_LocationLatDisabled;
			pos.x = m_LocationLngDisabled;
			OnLocationChanged (pos);
			loadPins ();


			m_TextDebug.SetActive (true);
			m_BackDebug.SetActive (true);
			textdebug.text = LocalizationSupport.GetString("GPSFailed");
			/*
			if (Application.systemLanguage == SystemLanguage.German) {
				textdebug.text = "Deine Position konnte nicht ermittelt werden.";
			} else {
				textdebug.text = "Your position could not be read.";
			}*/

			m_BackDebug.GetComponent<Image>().color = new Color32(255,255,255,240);//new Color32(243,26,26,240);//new Color32(219,32,32,240);//new Color32(255,20,20,240);

			TextGenerator textGen = new TextGenerator();
			TextGenerationSettings generationSettings = textdebug.GetGenerationSettings(textdebug.rectTransform.rect.size); 
			float width = textGen.GetPreferredWidth("asf", generationSettings);
			float height = textGen.GetPreferredHeight("asf", generationSettings);

			/*m_BackDebug.GetComponent<RectTransform> ().sizeDelta = new Vector2(m_TextDebug.GetComponent<RectTransform>().sizeDelta.x, 
				m_TextDebug.GetComponent<RectTransform>().sizeDelta.y);*/
			yield break;
		} else {	

			m_bLocationGPSDisabled = false;
			m_bLocationGPSDisabledReading = false;
			m_bLocationEnabled = true;

			m_StrTextDebug += "readLocation 5 ";
			textdebug.text = m_StrTextDebug;
		

			Vector2 pos;
			pos.y = Input.location.lastData.latitude;// 30.0f;//48.210033f;
			pos.x = Input.location.lastData.longitude;//12.0f;//16.363449f;
			m_bFollowingGPS = true;
			OnLocationChanged (pos);
			m_bStartReadGPS = false;

			Debug.Log ("GPS has been read");
			loadPins ();

			if(m_bLoadedStartMessage == false)
            {
				LoadIntroMsg(pos.y, pos.x);
			}


			m_TextDebug.SetActive (false);
			m_BackDebug.SetActive (false);
			m_MapDeactivated.SetActive (false);

			startCheckingInternet ();

			// Access granted and location value could be retrieved
			Debug.Log ("Location successful -> " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
	
			//yield return new WaitForSeconds (1);
			yield break;
		}


		m_StrTextDebug += "readLocation 6 ";
		textdebug.text = m_StrTextDebug;
	}

	private void OnChangeZoom()
	{
		UpdateLine ();
	}

	public void OnMenuClicked()
	{
/*		m_bMenuOpen = true;
		m_MenuOpenTimer = 0.0f;

		Debug.Log ("OnMenuClicked");*/
	}
	public void OnMenuCloseClicked()
	{
	/*	m_bMenuOpen = false;
		m_MenuOpenTimer = 0.0f;*/
	}

	public void OnOpenMenuSelection()
	{
	//	m_bMenuSelectionOpen = true;
	//	m_MenuSelectionBack.SetActive (true);
//		m_MenuSelectionBack2.SetActive (true);
			/*
		m_MenuSelectionButtonLogout.SetActive (true);
		m_MenuSelectionButtonIntroduction.SetActive (true);
		m_MenuSelectionButtonManual.SetActive (true);
		m_MenuSelectionButtonGuidelines.SetActive (true);
		m_MenuSelectionButtonContact.SetActive (true);
		m_MenuSelectionButtonHomepage.SetActive (true);
		m_MenuSelectionButtonCancel.SetActive (true);*/
	}
	public void OnCloseMenuSelection()
	{
	/*	m_bMenuSelectionOpen = false;
		m_MenuSelectionBack.SetActive (false);
		m_MenuSelectionBack2.SetActive (false);

			/*
		m_MenuSelectionButtonLogout.SetActive (false);
		m_MenuSelectionButtonIntroduction.SetActive (false);
		m_MenuSelectionButtonManual.SetActive (false);
		m_MenuSelectionButtonGuidelines.SetActive (false);
		m_MenuSelectionButtonContact.SetActive (false);
		m_MenuSelectionButtonHomepage.SetActive (false);
		m_MenuSelectionButtonCancel.SetActive (false);*/
	}

	public void OnLogutClicked()
	{
		if (PlayerPrefs.HasKey ("PlayerId")) {
			PlayerPrefs.SetInt("LoggedOut", 1);
			PlayerPrefs.SetInt ("RegisterMsgShown", 0);

			PlayerPrefs.Save ();
		}

		Application.targetFrameRate = 30;
		Application.LoadLevel ("StartScreen");
	}
	public void OnIntroductionClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Introduction");
	}
	public void OnTermsClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Terms");
	}
	public void OnManualClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Introduction");//Instructions2");
	}
	public void OnReportClicked()
	{
		PlayerPrefs.SetFloat ("CurQuestEndPositionX", m_PlayerPosition.x);
		PlayerPrefs.SetFloat ("CurQuestEndPositionY", m_PlayerPosition.y);
		PlayerPrefs.Save ();

		Application.targetFrameRate = 30;
		Application.LoadLevel ("Report");
    }
    public void OnGuidelinesClicked()
    {
        Application.targetFrameRate = 30;
        Application.LoadLevel("Guidelines");
    }
    public void OnDownloadMapClicked()
    {
        Application.targetFrameRate = 30;
        Application.LoadLevel("OfflineMap");
    }
	public void OnContactClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Contact");
	}
	public void OnLeaderboardClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Leaderboard");
	}

	public void OnChatClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Notifications");
	}

	void OnMsgBoxLoginClicked(string result) {
		m_bHasZoomed = true;
		Debug.Log ("OnMsgBoxClicked: " + result);
        if (result == LocalizationSupport.GetString("BtnLogin")) {
			PlayerPrefs.SetInt ("LoginReturnToQuests", 0);
			PlayerPrefs.SetInt ("RegisterMsgShown", 0);
			PlayerPrefs.Save ();

			Application.targetFrameRate = 30;
			Application.LoadLevel ("StartScreen");
		}
	}

	void OnMsgBoxSurveyClicked(string result) {
		if (result.CompareTo( LocalizationSupport.GetString("QuestionProfileTimeYes")) == 0) {
			Application.targetFrameRate = 30;
		//	Application.LoadLevel ("DynamicQuestionsPark");
			Application.LoadLevel ("Profile");
		}
	}


	bool checkLoggedIn() {
		if (PlayerPrefs.HasKey ("PlayerMail") == false) {
			UnityEngine.Events.UnityAction<string> ua = new UnityEngine.Events.UnityAction<string> (OnMsgBoxLoginClicked);
			if (Application.systemLanguage == SystemLanguage.German ) {
				string[] options = { "SPÄTER", "LOGIN" };
				messageBoxSmall.Show ("", "Du musst dich anmelden, um auf deine Profilseite zu gelangen.", ua, options);
			} else {
                string[] options = { LocalizationSupport.GetString("BtnLater"), LocalizationSupport.GetString("BtnLogin") };
                messageBoxSmall.Show ("", LocalizationSupport.GetString("LoginFirst"), ua, options);
			}
			return false;
		}
		return true;
	}

	public void OnProfileClicked()
	{
		if (checkLoggedIn () == false) {
			return;
		}
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Profile");
	}
		/*
	public void OnPuzzleClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Puzzle");
	}*/
	public void OnUploadClicked()
	{
		/*int nrquests = PlayerPrefs.GetInt ("NrQuestsDone");
		if (nrquests <= 0) {
			if (Application.systemLanguage == SystemLanguage.German ) {
				string[] options = { "Ok" };
				messageBoxSmall.Show ("", "Du hast noch keine Quests gemacht.", options);
			} else {
				string[] options = { "Ok" };
				messageBoxSmall.Show ("", "You have not made a quest yet.", options);
			}
			return;
		}*/

		Application.targetFrameRate = 30;
		Application.LoadLevel ("Quests");
	}

	public void OnCampaignClicked()
	{
		Application.LoadLevel("Campaigns");
	}
		public void OnHomepageClicked()
	{
		Application.OpenURL("http://www.fotoquest-go.org");
	}


	public void OnProgressClicked()
	{
		Application.targetFrameRate = 30;
		Application.LoadLevel ("Introduction");//Progress");
	}

	void saveQuestStats()
	{
		bool m_bPointInReach = true;
		if(PlayerPrefs.HasKey("CurQuestReached")) {
			int inreach = PlayerPrefs.GetInt("CurQuestReached");
			if(inreach == 0) {
				m_bPointInReach = false;
			}
		}

		int nrquestsdone = 0;

		if (PlayerPrefs.HasKey ("NrQuestsDone")) {
			nrquestsdone = PlayerPrefs.GetInt ("NrQuestsDone");
		} else {
			nrquestsdone = 0;
		}

		int iPointInReach = m_bPointInReach ? 1 : 0;
		PlayerPrefs.SetInt ("Quest_" + nrquestsdone + "_PointReached", iPointInReach);

		string curquestid = PlayerPrefs.GetString ("CurQuestId");
		PlayerPrefs.SetString ("Quest_" + nrquestsdone + "_Id", curquestid);
		PlayerPrefs.SetInt ("Quest_" + nrquestsdone + "_TrainingPoint", 0);

		PlayerPrefs.SetInt ("MadeQuest", 1);
		PlayerPrefs.Save ();
	}

	public void OnStartQuest()
	{
		if (m_bLocationGPSDisabled && !m_bDebug) {
			return;
		}

		if (!m_bLocationEnabled && !m_bDebug) {
			return;
		}



		PlayerPrefs.SetInt("PickedPuzzle", 0);
		PlayerPrefs.SetString("CurQuestId", m_SelectedPin.m_Id);
		PlayerPrefs.SetFloat ("CurQuestLat", (float)m_SelectedPin.m_Lat);
		PlayerPrefs.SetFloat ("CurQuestLng", (float)m_SelectedPin.m_Lng);
		PlayerPrefs.SetString ("CurQuestSelectedTime", m_QuestSelectedTime);
		PlayerPrefs.SetFloat ("CurQuestStartPositionX", m_PlayerPositionStart.x);
		PlayerPrefs.SetFloat ("CurQuestStartPositionY", m_PlayerPositionStart.y);
		PlayerPrefs.SetFloat ("CurQuestEndPositionX", m_PlayerPosition.x);
		PlayerPrefs.SetFloat ("CurQuestEndPositionY", m_PlayerPosition.y);
		PlayerPrefs.SetFloat ("CurDistanceWalked", m_DistanceWalked);

		PlayerPrefs.SetInt ("CurQuestNrPositions", m_NrPlayerPositions);
		for (int i = 0; i < m_NrPlayerPositions; i++) {
			PlayerPrefs.SetFloat ("CurQuestPositionX_" + i, m_PlayerPositions[i].x);
			PlayerPrefs.SetFloat ("CurQuestPositionY_" + i, m_PlayerPositions[i].y);
		}

		float weight = float.Parse (m_SelectedPin.m_Weight );
		PlayerPrefs.SetFloat ("CurQuestWeight",weight);
		PlayerPrefs.SetInt ("CurQuestReached", 1);

		string startquesttime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("CurQuestStartQuestTime", startquesttime);

		saveQuestStats ();
		Application.targetFrameRate = 30;
		//		Application.LoadLevel ("Minigram");

		Debug.Log("StartQuest pointid: " + m_SelectedPin.m_Id + " lat: " + m_SelectedPin.m_Lat + " lng: " + m_SelectedPin.m_Lng);
		Application.LoadLevel ("DynamicQuestionsFRA");
		/*
		if (PlayerPrefs.HasKey ("MadeQuest") == false) {
			PlayerPrefs.SetInt ("MadeQuest", 1);


			PlayerPrefs.Save ();

			Application.targetFrameRate = 30;

		//	Application.LoadLevel ("DebugSelectPinType");
			//Application.LoadLevel ("ExplainQuests");
			Application.LoadLevel ("TestCamera");
		} else {
			PlayerPrefs.SetInt ("CameraStartLastStep", 0);

			PlayerPrefs.Save ();
			Application.targetFrameRate = 30;
		//	Application.LoadLevel ("DebugSelectPinType");
			Application.LoadLevel ("TestCamera");
			//Application.LoadLevel ("DynamicQuestions");
		}*/

	}

	public void OnPointNotReachable()
	{
		if (m_bLocationGPSDisabled && !m_bDebug) {
			return;
		}
		if (!m_bLocationEnabled && !m_bDebug) {
			return;
		}

		PlayerPrefs.SetInt("PickedPuzzle", 0);
		PlayerPrefs.SetString("CurQuestId", m_SelectedPin.m_Id);
		PlayerPrefs.SetFloat ("CurQuestLat", (float)m_SelectedPin.m_Lat);
		PlayerPrefs.SetFloat ("CurQuestLng", (float)m_SelectedPin.m_Lng);
		PlayerPrefs.SetString ("CurQuestSelectedTime", m_QuestSelectedTime);
		PlayerPrefs.SetFloat ("CurQuestStartPositionX", m_PlayerPositionStart.x);
		PlayerPrefs.SetFloat ("CurQuestStartPositionY", m_PlayerPositionStart.y);
		PlayerPrefs.SetFloat ("CurQuestEndPositionX", m_PlayerPosition.x);
		PlayerPrefs.SetFloat ("CurQuestEndPositionY", m_PlayerPosition.y);
		PlayerPrefs.SetFloat ("CurDistanceWalked", m_DistanceWalked);
		float weight = float.Parse (m_SelectedPin.m_Weight );
		PlayerPrefs.SetFloat ("CurQuestWeight", weight);
		PlayerPrefs.SetInt ("CurQuestReached", 0);

		PlayerPrefs.SetInt ("CurQuestNrPositions", m_NrPlayerPositions);
		for (int i = 0; i < m_NrPlayerPositions; i++) {
			PlayerPrefs.SetFloat ("CurQuestPositionX_" + i, m_PlayerPositions[i].x);
			PlayerPrefs.SetFloat ("CurQuestPositionY_" + i, m_PlayerPositions[i].y);
		}

		string startquesttime = System.DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss");
		PlayerPrefs.SetString ("CurQuestStartQuestTime", startquesttime);
		PlayerPrefs.Save ();

		Application.targetFrameRate = 30;


		saveQuestStats ();

//		Application.LoadLevel ("Minigram");
		Application.LoadLevel ("NotInReach");
	//	Application.LoadLevel ("DebugSelectPinType");
	}

		/*
	public void OnPickUpPuzzle()
	{
		PlayerPrefs.SetInt("PickedPuzzle", 1);
		PlayerPrefs.SetInt("CurPuzzleChunkId", m_SelectedPuzzleChunkId);
		PlayerPrefs.SetInt("CurPuzzleId", m_SelectedPuzzleId);
		PlayerPrefs.SetFloat ("CurPuzzleLat", (float)m_SelectedPuzzleLat);
		PlayerPrefs.SetFloat ("CurPuzzleLng", (float)m_SelectedPuzzleLng);

		PlayerPrefs.SetInt ("Questions_FromQuestFinished", 0);
		PlayerPrefs.Save ();

		Application.targetFrameRate = 30;
		Application.LoadLevel ("DynamicQuestions");

	}*/

	void internetEnabled(bool bEnabled) {
		m_bCheckInternet = false;
		m_TextDebug.SetActive (false);
		m_BackDebug.SetActive (false);

		/*
		Debug.Log ("internetEnabled: " + bEnabled);
		if (bEnabled == false) {
			m_TextDebug.SetActive (true);
			m_BackDebug.SetActive (true);
			UnityEngine.UI.Text textdebug;
			textdebug = m_TextDebug.GetComponent<UnityEngine.UI.Text> ();
			textdebug.text = LocalizationSupport.GetString("CheckInternet");
			m_BackDebug.GetComponent<Image>().color = new Color32(255,255,255,240);//new Color32(243,26,26,240);//new Color32(219,32,32,240);// new Color32(255,20,20,240);

			m_bCheckInternet = true;
			m_CheckInternetTimer = 0.0f;
		} else {
			m_bCheckInternet = false;
			m_TextDebug.SetActive (false);
			m_BackDebug.SetActive (false);
		}*/
	}

	/*IEnumerator checkInternetConnection(){
		internetEnabled (true);
		WWW www = new WWW("https://google.com");
		yield return www;
		if (www.error != null) {
			internetEnabled (false);
		} else {
			internetEnabled (true);
		}
	} */
	void startCheckingInternet(){
		internetEnabled (true);
		//StartCoroutine(checkInternetConnection());
	}









	public static string ComputeHash(string s) {
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


	/*
	void loadMsgBox()
	{
		string url = "http://fotoquest-go.org/news.txt?rand=" + Random.value;

		if (Application.systemLanguage == SystemLanguage.German  ) {
			url = "http://fotoquest-go.org/newsde.txt?rand=" + Random.value;
		}

		WWW www = new WWW(url);

		StartCoroutine(WaitForMsgBoxData(www));
	}

	IEnumerator WaitForMsgBoxData(WWW www)
	{
		yield return www;

		string[] options = { "Ok" };
		if (www.error == null)
		{
			string data = www.data;
			//string[] parts = data.Split (":", 2);

			Debug.Log ("loadMsgBox result: " + data);

			string[] strArr;
			strArr= data.Split(new string[] { ";" }, System.StringSplitOptions.None);

			m_MsgBoxText = strArr[1];
				m_bMsgBoxLoaded = true;

			if (PlayerPrefs.HasKey("MsgBoxLastId")) {
					string msgboxid = PlayerPrefs.GetString ("MsgBoxLastId");
				if (msgboxid == strArr [0] && msgboxid != "-1") {
						m_bShownMsgBox = true;
						//m_bShownMsgBox = false; // Comment this out again
					}
			}

				if (!m_bShownMsgBox) {
					string strimg = "http://www.fotoquest-go.org/img/" + strArr [2];
					Texture2D tex;
					tex = new Texture2D(512, 512, TextureFormat.DXT1, false);
					WWW www2 = new WWW(strimg);
					yield return www2;
					www2.LoadImageIntoTexture(tex);

				m_MsgBoxImg.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));

				}

			PlayerPrefs.SetString ("MsgBoxLastId", strArr[0]);
			PlayerPrefs.Save ();


		} else {
			
		}   
	} */



	
	public void OnCloseLevelReached() {

		m_LevelReachedBack.SetActive (false);
		m_LevelReachedName.SetActive (false);
		m_LevelReachedProgBack.SetActive (false);
		m_LevelReachedFront.SetActive (false);
		m_LevelReachedScorePoints.SetActive (false);
		m_LevelReachedProgress.SetActive (false);
		m_LevelReachedOk.SetActive (false);
		m_LevelReachedShare.SetActive (false);
		m_LevelReachedShareFB.SetActive (false);
		m_LevelReachedShareTwitter.SetActive (false);
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";

	public void OnNewsClicked() {
		Application.OpenURL("http://www.fotoquest-go.org");
	}

	public void OpenTwitterPage() {
		Application.OpenURL("https://twitter.com/fotoquest_go");
	}
	public void OpenFacebookPage() {
		Application.OpenURL("https://www.facebook.com/GeoWiki");
	}
	public void SendEmail (string email,string subject,string body)
	{
		subject = MyEscapeURL(subject);
		//body = MyEscapeURL(body);
		Application.OpenURL ("mailto:" + email + "?subject=" + subject);// + "&body=" + body);
	}
	public string MyEscapeURL (string url)
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}

	public void OnContactUsClicked() {
		SendEmail ("info@fotoquest.at", "FotoQuestGo", "Text");
	}

	public void ShareLevelReachedTwitter() {
		
	}
	public void ShareLevelReachedFB() {
		
	}


	void OnMsgBoxClicked(string param) {
		
	}

	public GameObject m_CloseMenuBack;
	public void ToggleMenu() {
		SideMenu menu = (SideMenu) m_MenuSlidin.GetComponent(typeof(SideMenu));
		m_bMenuOpened = !m_bMenuOpened;

		if (m_bMenuOpened) {
			menu.SlideIn ();
			m_MenuToggleButton.SetActive (true);
			m_CloseMenuBack.SetActive(true);
		} else {
			menu.SlideOut ();
			m_MenuToggleButton.SetActive (false);
			m_CloseMenuBack.SetActive(false);
		}
	}

	public void ToggleMenuFilter() {
		/*SideMenu menu = (SideMenu) m_MenuFilter.GetComponent(typeof(SideMenu));
		m_bMenuFilterOpened = !m_bMenuFilterOpened;

		if (m_bMenuFilterOpened) {
			menu.SlideIn ();
			m_MenuFilterToggleButton.SetActive (true);
		} else {
			menu.SlideOut ();
			m_MenuFilterToggleButton.SetActive (false);
		}*/
	}


		public GameObject m_ShowPicsBack;
		public GameObject m_ShowPicsTitle;
		public GameObject m_ShowPicsText;
		public GameObject m_ShowPicsClose;
		public GameObject m_ShowPicsReport;
		public GameObject m_ShowPics1;
		public GameObject m_ShowPics2;
		public GameObject m_ShowPics3;
		public GameObject m_ShowPics4;
		public GameObject m_ShowPics5;

		public void showPics() {
			Debug.Log ("Show Pictures");
			UnityEngine.UI.Text textdebug;
			textdebug = m_ShowPicsTitle.GetComponent<UnityEngine.UI.Text>();
			if (Application.systemLanguage == SystemLanguage.German) {
				textdebug.text = "Punkt 1032";
				m_ShowPicsText.GetComponent<UnityEngine.UI.Text>().text = "Melde bitte die Bilder wenn sie von schlechter Qualität sind, Personen zeigen oder privates Eigentum identifizieren könnten.";

				m_ShowPicsClose.GetComponentInChildren<UnityEngine.UI.Text>().text = "Schließen";
				m_ShowPicsReport.GetComponentInChildren<UnityEngine.UI.Text>().text = "Melden";
			} else {
				textdebug.text = "Point 1032";

				m_ShowPicsText.GetComponent<UnityEngine.UI.Text>().text = "Please report the images if they are of bad quality, show persons or could identify private property like car plates.";
				m_ShowPicsClose.GetComponentInChildren<UnityEngine.UI.Text>().text = "Close";
				m_ShowPicsReport.GetComponentInChildren<UnityEngine.UI.Text>().text = "Report";
			}


			m_ShowPicsBack.SetActive (true);
			m_ShowPicsTitle.SetActive (true);
			m_ShowPicsClose.SetActive (true);
			m_ShowPicsReport.SetActive (true);
			m_ShowPics1.SetActive (true);
			m_ShowPics2.SetActive (true);
			m_ShowPics3.SetActive (true);
			m_ShowPics4.SetActive (true);
			m_ShowPics5.SetActive (true);
			m_ShowPicsText.SetActive (true);

			string url = "https://geo-wiki.org/Application/api/Campaign/FotoQuestGetPictures/" + m_SelectedPin.m_Id;
			string param = "";

			/*
		Debug.Log (url);
			WWWForm form = new WWWForm();
			//form.AddField ("parameter", param);
			WWW www = new WWW(url, form);

		Debug.Log (">>> Load pictures");
			StartCoroutine(WaitForPictures(www));*/
		//StartCoroutine (WaitForPictures ());
			WWW www = new WWW(url);

			Debug.Log (">>> Load pictures");
			StartCoroutine(WaitForPictures(www));
		}

		IEnumerator WaitForPictures(WWW www)
		{
			yield return www;
			// check for errors
		if (www.error == null) {
			Debug.Log ("WWW Pictures received: " + www.text);

			}  else {
				Debug.Log("Pictures NOT received Error: "+ www.error);
				Debug.Log("WWW Error Pictures 2: "+ www.text);
			} 
		}  /*
		IEnumerator WaitForPictures()
		{
			string url = "https://geo-wiki.org/Application/api/Campaign/FotoQuestGetPictures/" + m_SelectedPin.m_Id;
			UnityWebRequest www = UnityWebRequest.Get(url);
			yield return www.Send();

			if(www.isError) {
				Debug.Log(www.error);
			}
			else {
				// Show results as text
				Debug.Log("Get pictures: " + www.downloadHandler.text);

				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
		}*/

		public void hidePics() {
			Debug.Log ("Hide Pictures");
			m_ShowPicsBack.SetActive (false);
			m_ShowPicsTitle.SetActive (false);
			m_ShowPicsClose.SetActive (false);
			m_ShowPicsReport.SetActive (false);
			m_ShowPics1.SetActive (false);
			m_ShowPics2.SetActive (false);
			m_ShowPics3.SetActive (false);
			m_ShowPics4.SetActive (false);
			m_ShowPics5.SetActive (false);
			m_ShowPicsText.SetActive (false);
		}

		int m_PinInfoClosedIter = 0;
		bool m_bPinInfoClosed = false;
	public void closePinInfo()
	{
		Debug.Log (">> closePinInfo");
		m_SelectedPinTimer = 10000000.0f;
		m_bPinInfoClosed = true;
		m_PinInfoClosedIter = 0;
		m_bForceUpdate = true;
	}

	public void to2dMap()
	{
		m_bIn2dMap = true;
		m_bTo2dMap = true;
		m_To2dMapTimer = 0.0f;
		m_bTo3dMap = false;
		m_To2dMapTimer = 0.0f;
		m_bHasZoomed = true;
		m_CameraAngleTransition = m_CameraAngleMove;
		m_BtnTo2dMap.SetActive (false);
		m_BtnTo3dMap.SetActive (true);
		closePinInfo ();

		m_DistanceBack.SetActive (false);
		m_DistanceBackHorizon.SetActive (false);
		m_DistanceText.SetActive (false);/*
		m_DistanceText2.SetActive (true);
		m_DistanceBack2d.SetActive (true);*/

		m_DistanceText2.SetActive (false);
		m_DistanceBack2d.SetActive (false);

		m_Sky.SetActive (false);
		m_Sky2.SetActive (false);


		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
	//	control2.setUpdateControl (true);
	//	control2.setAlwaysUpdateControl (true);
		control2.allowUserControl = true;
	}

	public void to3dMap()
	{
		m_bIn2dMap = false;
		m_bTo2dMap = false;
		m_To2dMapTimer = 0.0f;
		m_bTo3dMap = true;
		m_To3dMapTimer = 0.0f;
//		m_CameraPitch = 37.0f;
		m_bHasZoomed = true;
		closePinInfo ();

		m_BtnTo2dMap.SetActive (true);
		m_BtnTo3dMap.SetActive (false);

		m_DistanceBack.SetActive (true);
		m_DistanceBackHorizon.SetActive (true);
		m_DistanceText.SetActive (true);
		m_DistanceText2.SetActive (false);

		m_Sky.SetActive (true);
		m_Sky2.SetActive (true);
		m_DistanceBack2d.SetActive (false);

		toPlayerPosition ();

		if (api.zoom < 13) {
			api.zoom = 13;
		}
		enableZoomButtons ();


		//updatePins ();
		//Debug.Log ("Zoom: " + api.zoom);
		//loadPins ();

		OnlineMapsControlBase3D control2 = GetComponent<OnlineMapsControlBase3D>();
/*		control2.setUpdateControl (true);
		control2.setAlwaysUpdateControl (false);*/
		control2.allowUserControl = false;
	}

	void updatePinBackgrounds(bool bInReach) {
	//	Debug.Log ("m_bConquerShiftPosition: " + m_bConquerShiftPosition);
		if (m_bConquerShiftPosition == 0) {
			m_TooltipLeft.SetActive (true);
			m_Tooltip.SetActive (false);

			m_TooltipBackBigLeftLeft.SetActive (false);

			if (!bInReach && false) {
				m_TooltipBackBigLeft.SetActive (false);
				m_TooltipBackLeft.SetActive (true);
			} else {
				m_TooltipBackBigLeft.SetActive (true);
				m_TooltipBackLeft.SetActive (false);
			}

			m_TooltipBackBig.SetActive (false);
			m_TooltipBack.SetActive (false);
		} else if (m_bConquerShiftPosition == 1) {
			m_TooltipLeft.SetActive (true);
			m_Tooltip.SetActive (false);

			m_TooltipBackBigLeft.SetActive (false);

			if (!bInReach && false) {
				m_TooltipBackBigLeft.SetActive (false);
				m_TooltipBackLeft.SetActive (true);
			} else {
				m_TooltipBackBigLeftLeft.SetActive (true);
				m_TooltipBackLeft.SetActive (false);
			}

			m_TooltipBackBig.SetActive (false);
			m_TooltipBack.SetActive (false);
		} else if (m_bConquerShiftPosition == 2) {

			m_TooltipLeft.SetActive (false);
			m_Tooltip.SetActive (true);

			m_TooltipBackBigLeft.SetActive (false);
			m_TooltipBackBigLeftLeft.SetActive (false);
			m_TooltipBackLeft.SetActive (false);

			if (!bInReach && false) {
				m_TooltipBackBig.SetActive (false);
				m_TooltipBack.SetActive (true);
			} else {
				m_TooltipBackBig.SetActive (true);
				m_TooltipBack.SetActive (false);
			}
		}
	}

	void updatePinInfo() {
		Vector2 markerpos = new Vector2 ();
		markerpos.x = (float)m_SelectedPin.m_Lng;
		markerpos.y = (float)m_SelectedPin.m_Lat;

		Vector2 screenPosition = OnlineMapsControlBase.instance.GetScreenPosition (markerpos);

		RectTransform rectTransform2;// = m_TooltipBack.GetComponent<RectTransform> ();
		rectTransform2 = m_Tooltip.GetComponent<RectTransform> ();

		UnityEngine.UI.Text textdebugline;
		textdebugline = m_DebugLine.GetComponent<UnityEngine.UI.Text> ();
		float procx = (float)screenPosition.x / (float)Screen.width;
		float procy = (float)screenPosition.y / (float)Screen.height;
		float procy2 = procy - 0.1f;
		procy2 *= 1.111111111111111f;
		float offsety = (1.0f - procy2) * Screen.height * 0.13f + Screen.height * 0.08f;
		offsety = (1.0f - procy2) * Screen.height * 0.11f + Screen.height * 0.06f;

		float screenposx = screenPosition.x;
		screenposx += Screen.width * 0.25f;//0.54f;//0.52f;

		float procxshift = procx;
		float shiftpos = 0.5f - procxshift;
		if (m_bConquerShiftSet == false || true) {
			m_bConquerShiftSet = true;
			if (procx < 0.3f) {
				m_ConquerBackShiftX = -Screen.width * 0.25f;
				m_bConquerShiftPosition = 1;
			} else if (procx > 0.7f) {
				m_ConquerBackShiftX = -Screen.width * 0.255f;
				m_bConquerShiftPosition = 2;
			} else {
				m_ConquerBackShiftX = -Screen.width * 0.59f;//0.535f;//0.45f;// 0.6f;//0.5f;
				m_bConquerShiftPosition = 0;
			}
		}

		if (m_bIn2dMap) {
			offsety = Screen.height * 0.095f;
		}

		screenposx += m_ConquerBackShiftX;//shiftpos * Screen.width * 0.44f;//0.4f;//8f;

		rectTransform2.position = new Vector2 (screenposx, screenPosition.y + offsety);

		rectTransform2 = m_TooltipLeft.GetComponent<RectTransform> ();
		rectTransform2.position = new Vector2 (screenposx, screenPosition.y + offsety);

		updatePinBackgrounds (m_bInReachOfPoint);


		if (procx < 0.0f || procx > 1.0f) { // Hide tooltip if out of screen
			m_TooltipBackBigLeft.SetActive (false);
			m_TooltipBackBigLeftLeft.SetActive (false);
			m_TooltipBackLeft.SetActive (false);
			m_TooltipBackBig.SetActive (false);
			m_TooltipBack.SetActive (false);
			m_TooltipLeft.SetActive (false);
			m_Tooltip.SetActive (false);
		}
	}

	void updateToPositionButtons(bool bBottom)
	{
		if (!bBottom) {
			if (!m_bBlackGui) {
				m_ButtonToPosBrightBottom.SetActive (false);
				m_ButtonToPosDarkBottom.SetActive (false);
				m_ButtonToPosBright.SetActive (true);
				m_ButtonToPosDark.SetActive (false);
			} else {
				m_ButtonToPosBrightBottom.SetActive (false);
				m_ButtonToPosDarkBottom.SetActive (false);
				m_ButtonToPosBright.SetActive (false);
				m_ButtonToPosDark.SetActive (true);
			}
		} else {
			if (!m_bBlackGui) {
				m_ButtonToPosBrightBottom.SetActive (true);
				m_ButtonToPosDarkBottom.SetActive (false);
				m_ButtonToPosBright.SetActive (false);
				m_ButtonToPosDark.SetActive (false);
			} else {
				m_ButtonToPosBrightBottom.SetActive (false);
				m_ButtonToPosDarkBottom.SetActive (true);
				m_ButtonToPosBright.SetActive (false);
				m_ButtonToPosDark.SetActive (false);
			}
		}
	}


	public GameObject m_MenuMapType;
	public GameObject m_MenuToggleLayer1;
	public GameObject m_MenuToggleLayer2;
	public GameObject m_MenuToggleLayer3;
	public GameObject m_ToggleLayer1;
	public GameObject m_ToggleLayer2;
	public GameObject m_ToggleLayer3;
	bool m_bOfflineMode = false;
	bool m_bLayersInited = false;


	public void ShowLayer1(bool bLayer)
	{
		int value = 1;// m_ToggleHeatMap.GetComponent<Toggle>().isOn == true ? 1 : 0;

		Debug.Log("value: " + value);

		if (m_bLayersInited == false)
		{
			return;
		}
		PlayerPrefs.SetInt("MapType", value);
		PlayerPrefs.Save();
		Application.LoadLevel("DemoMap");

	}
	public void ShowLayer2(bool bLayer)
	{
		int value = 0;// m_ToggleHeatMap.GetComponent<Toggle>().isOn == true ? 1 : 0;

		Debug.Log("value: " + value);

		if (m_bLayersInited == false)
		{
			return;
		}
		PlayerPrefs.SetInt("MapType", value);
		PlayerPrefs.Save();
		Application.LoadLevel("DemoMap");
	}


	public void ToggleOfflineMode(bool bValue)
	{
		if (m_bLayersInited == false)
		{
			return;
		}

		Debug.Log("ToggleOfflineMode" + bValue);
        if(bValue)
        {
			PlayerPrefs.SetInt("OfflineMode", 1);
			PlayerPrefs.Save();
        }
        else
        {
			PlayerPrefs.SetInt("OfflineMode", 0);
			PlayerPrefs.Save();
		}
		m_bOfflineMode = bValue;
	}


	public void ToggleMenuMap()
	{
		SlidingMenu menu = (SlidingMenu)m_MenuMapType.GetComponent(typeof(SlidingMenu));
		m_bMenuMapOpened = !m_bMenuMapOpened;
		if (m_bMenuMapOpened)
		{
			menu.SlideToValue(0.8f);// (0.6f);
			m_MenuMapType.SetActive(true);
		}
        else
        {
			menu.SlideToValue(-0.1f);
		}
	}

	void CloseMenuMap()
	{
		SlidingMenu menu = (SlidingMenu)m_MenuMapType.GetComponent(typeof(SlidingMenu));
		m_bMenuMapOpened = false;

		menu.SlideToValue(-0.1f);
	}




	public void SlidingMenuFinished(int id)
	{
		if (id == 6)
		{
			if (!m_bMenuMapOpened)
			{
				m_MenuMapType.SetActive(false);
			}
		}
	}


	bool m_bIgnoreClick = false;
	int m_IgnoreClickIter = 0;

	public void SlidingMenu()
	{
		m_bIgnoreClick = true;
		m_IgnoreClickIter = 0;
		//Debug.Log("###SlidingMenu");
	}

	public void OpenMenu(int id)
	{
		m_bIgnoreClick = true;
		m_IgnoreClickIter = 0;

		
	}

	public void CloseMenu(int id)
	{
		m_bIgnoreClick = true;
		m_IgnoreClickIter = 0;

		if (id == 6)
		{
			CloseMenuMap();
		}
	}


	}
