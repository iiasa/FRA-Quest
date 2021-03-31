using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using UnityEngine.UI;

public class EventSystemLogin : MonoBehaviour
{
    public GameObject m_ButtonBack;
    public GameObject m_TextTitle;
    public GameObject m_TextEMail;
    public GameObject m_TextPassword;
    public GameObject m_TextForgot;

    public GameObject m_ButtonLogin;


    public GameObject m_InputLogin;
    public GameObject m_InputPassword;
    public GameObject m_InputFieldLogin;
    public GameObject m_InputFieldPassword;

    private Rect windowRect = new Rect(20, 20, 120, 50);


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


    public GameObject m_ToggleAgree;
    public GameObject m_BtnTerms;
    public GameObject m_BtnDataPolicy;



    public GameObject m_TermsBack2;
    public GameObject m_TermsBtnAccept2;
    public GameObject m_TermsBtnDecline2;
    public GameObject m_ToggleAgree2;
    public GameObject m_ToggleAgreeText2;
    public GameObject m_PanelAgree2;


    public CanvasScaler m_Scaler;
    public GameObject m_BackgroundPortrait;
    public GameObject m_BackgroundLandscape;

    string m_PlayerId = "";


    public void ForceLandscapeLeft()
    {
        StartCoroutine(ForceAndFixLandscape());
    }

    IEnumerator ForceAndFixLandscape()
    {
        yield return new WaitForSeconds(0.01f);

        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = true;
        yield return new WaitForSeconds(0.5f);
    }


    public void ForcePortrait()
    {
        StartCoroutine(ForceAndFixPortrait());
    }

    IEnumerator ForceAndFixPortrait()
    {
        yield return new WaitForSeconds(0.01f);
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = true;
        yield return new WaitForSeconds(0.5f);
    }


    void UpdateBackgroundImage()
    {
        if (Screen.width > Screen.height)
        {
            m_BackgroundPortrait.SetActive(false);
            m_BackgroundLandscape.SetActive(true);
        }
        else
        {
            m_BackgroundPortrait.SetActive(true);
            m_BackgroundLandscape.SetActive(false);
        }
    }


    // Use this for initialization
    void Start()
    {

        if ((!LocalizationSupport.StringsLoaded))
            LocalizationSupport.LoadStrings();

#if UNITY_WEBGL
        ForceLandscapeLeft ();
#else
        ForcePortrait();
#endif

        UpdateBackgroundImage();
        /*
        Screen.orientation = ScreenOrientation.Portrait;

        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;


        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;*/

        updateStates();


        m_LoadingText.SetActive(false);
        m_LoadingBack.SetActive(false);
        messageBox = UIUtility.Find<MessageBox>("MessageBox");
        //  verticalMessageBox = UIUtility.Find<MessageBox> ("VerticalMessageBox");

        /*
            messageBox.Show(title,message,icon,null,options);
        */


        if (messageBox == null)
        {
            Debug.Log("No message box set");
        }
        else
        {
            Debug.Log("Message set");
        }

        hideTerms();
        hideTerms2();

        UpdateScaler();
    }


    void OnGUI()
    {
        //      windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
    }



    void WindowFunction(int windowID)
    {
        // Draw any Controls inside the window here
    }

    bool m_bShown = false;

    void UpdateScaler()
    {
        if (Screen.width > Screen.height)
        {
            m_Scaler.referenceResolution = new Vector2(Screen.width * 1.5f, 700);
        }
        else
        {
            m_Scaler.referenceResolution = new Vector2(800, 700);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("StartScreen");
        }

        UpdateScaler();
        UpdateBackgroundImage();
        /*
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.LoadLevel ("DemoMap");*/

        /*m_Show++;
        if (m_Show >= 3 && !m_bShown) {
            if (Application.systemLanguage == SystemLanguage.German) {
                string[] options = { "OK" };
                messageBox.Show ("", "Verwende deinen Geo-Wiki Account (www.geo-wiki.org) um dich einzuloggen.", options);
            } else {
                string[] options = { "OK" };
                messageBox.Show ("", "Use your excisting Geo-Wiki Account (www.geo-wiki.org) to login.", options);
            }
            m_bShown = true;
        }*/
    }

    public void updateStates()
    {
        if (Application.systemLanguage == SystemLanguage.German)
        {
         //   m_ToggleAgreeText2.GetComponent<UnityEngine.UI.Text>().text = "Bitte setze dieses Häkchen, wenn du zustimmst, dass dein Benutzername auf den unten genannten Internetseiten von IIASA, in der App und den Social Media Kanälen veröffentlicht werden darf:\n\n- www.Geo-Wiki.org\n- www.LandSense.eu\n- www.iiasa.ac.at\n\nSowie auch auf unseren Social Media Kanälen:\n- Facebook (www.facebook.com, geführt von Facebook, Inc., 1601 Willow Road, Menlo Park, California 94025; und Facebook Ireland Ltd, 4 Grand Canal Square, Grand Canal Harbour, Dublin 2 Ireland)\n- Twitter (www.twitter.com/, geführt von Twitter International Company, One Cumberland Place, Fenian Street Dublin 2, D02 AX07 Ireland; and 1355 Market Street, Suite 900, San Francisco, CA 94103, United States)";

            m_TextTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Login";

            m_ButtonLogin.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginLogin");//"EINLOGGEN";
            m_TextForgot.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginForgotPassword");//"Passwort vergessen?";
            m_TextEMail.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginMail");//"E-Mail:";
            m_TextPassword.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginPassword");//"Passwort:";

            m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Zurück";

            m_LoadingText.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Loading");//"Laden...";

            m_TermsBtnAccept.GetComponentInChildren<UnityEngine.UI.Text>().text = "ANNEHMEN";
            m_TermsBtnDecline.GetComponentInChildren<UnityEngine.UI.Text>().text = "ABLEHNEN";


            m_TermsBtnAccept2.GetComponentInChildren<UnityEngine.UI.Text>().text = "WEITER";
            m_TermsBtnDecline2.GetComponentInChildren<UnityEngine.UI.Text>().text = "ZURÜCK";
           // m_ToggleAgree.GetComponentInChildren<UnityEngine.UI.Text>().text = "Ich stimme zu, die Picture Pile Terms of Use und Privacy Policy gelesen und akzeptiert zu haben. Verantwortlich für die ordnungsgemäße Verwendung dieser Daten ist das Internationale Institut für angewandte Systemanalyse (IIASA) in Laxenburg, Österreich. Diese Zustimmungserklärung kann jederzeit, jedoch nicht rückwirkend bei picturepile@iiasa.ac.at widerrufen werden.";


            m_ToggleAgree.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("TermsAcceptText");

            m_ToggleAgreeText2.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("TermsAcceptText2");

            m_BtnTerms.GetComponentInChildren<UnityEngine.UI.Text>().text = "Terms of Use";
            m_BtnDataPolicy.GetComponentInChildren<UnityEngine.UI.Text>().text = "Privacy Policy";
        }
        else
        {
            m_TextTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Login";

            m_ButtonLogin.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginLogin");//"LOGIN";
            m_TextForgot.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginForgotPassword");//"Forgot password?";
            m_TextEMail.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginMail");//"E-Mail:";
            m_TextPassword.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("LoginPassword");//"Password:";
            m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Back";
            m_LoadingText.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Loading");//"Loading...";


            m_TermsBtnAccept2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Next");//"NEXT";
            m_TermsBtnDecline2.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("BtnBack");//"BACK";
            m_ToggleAgree.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("TermsAcceptText");

            m_ToggleAgreeText2.GetComponent<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("TermsAcceptText2");

            m_BtnTerms.GetComponentInChildren<UnityEngine.UI.Text>().text = "Terms of Use";
            m_BtnDataPolicy.GetComponentInChildren<UnityEngine.UI.Text>().text = "Privacy Policy";
        }

        if (Application.systemLanguage == SystemLanguage.German)
        {
            m_TermsTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Teilnahmebedingungen";


            m_TermsBtnAccept.GetComponentInChildren<UnityEngine.UI.Text>().text = "ANNEHMEN";
            m_TermsBtnDecline.GetComponentInChildren<UnityEngine.UI.Text>().text = "ABLEHNEN";
        }
        else
        {
            m_TermsTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = "Terms and Conditions";
            m_TermsBtnAccept.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("BtnAccept");//"ACCEPT";
            m_TermsBtnDecline.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("BtnDecline");//"DECLINE";

        }
    }

    public static string ComputeHash(string s)
    {
        // Form hash
        System.Security.Cryptography.MD5 h = System.Security.Cryptography.MD5.Create();
        byte[] data = h.ComputeHash(System.Text.Encoding.Default.GetBytes(s));
        // Create string representation
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < data.Length; ++i)
        {
            sb.Append(data[i].ToString("x2"));
        }
        return sb.ToString();
    }

    public void LoginClicked()
    {
        /*  string[] options = { "OK" };
        //  messageBox.Show("Title","Message",null,null,options);
            messageBox.Show("Title","Message",options);
    */

        //messageBox.Show(

        Debug.Log("LoginClicked");

        //string user = m_InputLogin.GetComponent<UnityEngine.UI.Text> ().text;
        //  string password = m_InputPassword.GetComponent<UnityEngine.UI.InputField> ().text;
        UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField>();
        string user = inputfield.text;
        Debug.Log("user2: " + user);


        UnityEngine.UI.InputField textinput;
        textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
        string password = textinput.text;

        string value = user + "," + password;
        string[] options = { "OK" };
        //messageBox.Show ("", value, options);

        if (user.Length <= 0)
        {
            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoMail"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoMail"), options);
            }
            return;
        }

        if (password.Length <= 0)
        {
            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoPassword"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoPassword"), options);
            }
            return;
        }


        /*if (m_ToggleAgree.GetComponent<Toggle> ().isOn == false) {
            if (Application.systemLanguage == SystemLanguage.German) {
                messageBox.Show ("", "Du musst zuerst die Teilnahmebedingungen und Datenschutzrichtlinien akzeptieren.", options);
            } else {
                messageBox.Show ("", "You need to accept the terms and conditions and data policy usage in order to be able to register.", options);
            }
            return;
        }*/

        //showTerms ();
        startLoggingIn();
        //acceptedTerms ();



        /*
            if (Application.systemLanguage == SystemLanguage.German) {
                string[] options = { "OK" };
                messageBox.Show ("", "erwende deinen Geo-Wiki (www.geo-wiki.org) Account um dich einzuloggen.", options);
            } else {
                string[] options = { "OK" };
                messageBox.Show ("", "Use your excisting Geo-Wiki Account (www.geo-wiki.org) to login.", options);
            }*/

    }

    void startLoggingIn()
    {
        UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField>();
        string user = inputfield.text;
        Debug.Log("user2: " + user);

        string[] options = { "OK" };

        UnityEngine.UI.InputField textinput;
        textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
        string password = textinput.text;

        string value = user + "," + password;
        //messageBox.Show ("", value, options);

        if (user.Length <= 0)
        {
            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoMail"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoMail"), options);
            }
            return;
        }

        if (password.Length <= 0)
        {
            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoPassword"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginNoPassword"), options);
            }
            return;
        }


        m_LoadingText.SetActive(true);
        m_LoadingBack.SetActive(true);

        string passwordmd5 = ComputeHash(password);

        /*string url = "https://geo-wiki.org/Application/api/game/login";
        string param = "";
        //param += "{\"username\":\"" + user + "\",\"passwordMD5\":\"" + passwordmd5 + "\"";
        param += "{\"name\":\"" + user + "\",\"pass\":\"" + passwordmd5 + "\"";
        param += "}";*/

        /*
        string url = "https://geo-wiki.org/Application/api/User/checkCredentials";
        string param = "";
        param += "{\"username\":\"" + user + "\",\"passwordMD5\":\"" + passwordmd5 + "\"";
        param += "}";*/


        string url = "https://geo-wiki.org/Application/api/User/checkCredentials";
        string param = "";
        param += "{\"username\":\"" + user + "\",\"passwordMD5\":\"" + passwordmd5 + "\"";
        param += "}";



        Debug.Log("login param: " + param);


        WWWForm form = new WWWForm();
        form.AddField("parameter", param);

        //Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
        WWW www = new WWW(url, form);

        StartCoroutine(WaitForData(www));
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
            string part3 = parts2[0];

            Debug.Log("WWW Ok!: " + www.text);
            Debug.Log("part1: " + parts[0]);
            Debug.Log("part2: " + parts[1]);
            Debug.Log("part3: " + part3);

            part3 = part3.Replace("\"", "");
            part3 = part3.Replace("}", "");

            Debug.Log("parts2 len: " + parts2.Length);
            if (parts.Length > 2)
            {
                string part4 = parts[2];
                Debug.Log("Part4: " + part4);


                part4 = part4.Replace("\"", "");
                part4 = part4.Replace("}", "");


                Debug.Log("Part4: " + part4);

                PlayerPrefs.SetString("PlayerName", part4);
            }

            if (part3.Equals("null"))
            {

                m_LoadingText.SetActive(false);
                m_LoadingBack.SetActive(false);

                if (Application.systemLanguage == SystemLanguage.German)
                {
                    messageBox.Show("", LocalizationSupport.GetString("LoginFailed"), options);
                }
                else
                {
                    messageBox.Show("", LocalizationSupport.GetString("LoginFailed"), options);
                }
                yield return www;
            }
            else
            {
                m_PlayerId = part3 + "";
                m_LoadingText.SetActive(false);
                m_LoadingBack.SetActive(false);
                showTerms();
            }
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Error 2: " + www.text);


            m_LoadingText.SetActive(false);
            m_LoadingBack.SetActive(false);

            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginFailedNoInternet"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("LoginFailedNoInternet"), options);
            }
        }
    }


    public void RegisterClicked()
    {
    }
    public void OnBackClicked()
    {
        Application.LoadLevel("StartScreen");
    }
    public void OnForgotClicked()
    {
        Application.OpenURL("http://www.geo-wiki.org/Security/lostpassword");
    }


    public void hideTerms()
    {
        m_TermsBack.SetActive(false);
        m_TermsTitle.SetActive(false);
        m_TermsScrollbarAT.SetActive(false);
        m_TermsTextBack.SetActive(false);
        m_TermsImageAT.SetActive(false);
        m_TermsBtnAccept.SetActive(false);
        m_TermsBtnDecline.SetActive(false);
        m_TermsScrollbarEN.SetActive(false);
        m_TermsImageEN.SetActive(false);
        m_ToggleAgree.SetActive(false);

        m_BtnTerms.SetActive(false);
        m_BtnDataPolicy.SetActive(false);
    }
    void showTerms()
    {
        m_TermsBack.SetActive(true);
        //  m_TermsTitle.SetActive (true);
        /*
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
        }*/

        m_ToggleAgree.SetActive(true);
        m_BtnTerms.SetActive(true);
        m_BtnDataPolicy.SetActive(true);
        //m_TermsTextBack.SetActive (true);
        m_TermsBtnAccept.SetActive(true);
        m_TermsBtnDecline.SetActive(true);
    }

    public void acceptedTerms()
    {
        string[] options = { "OK" };
        if (m_ToggleAgree.GetComponent<Toggle>().isOn == false)
        {
            if (Application.systemLanguage == SystemLanguage.German)
            {
                messageBox.Show("", LocalizationSupport.GetString("MsgTermsAccept"), options);
            }
            else
            {
                messageBox.Show("", LocalizationSupport.GetString("MsgTermsAccept"), options);
            }
            return;
        }


        showTerms2();/*
        string[] options = { "OK" };
        if (m_ToggleAgree.GetComponent<Toggle> ().isOn == false) {
            if (Application.systemLanguage == SystemLanguage.German) {
                messageBox.Show ("", "Du musst zuerst die Teilnahmebedingungen und Datenschutzrichtlinien akzeptieren.", options);
            } else {
                messageBox.Show ("", "You need to accept the terms and conditions and data policy usage in order to be able to register.", options);
            }
            return;
        }

        PlayerPrefs.SetString("PlayerId",m_PlayerId);


        UnityEngine.UI.InputField textinput;
        textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
        string password = textinput.text;

        PlayerPrefs.SetString("PlayerPassword",password);

        UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField> ();
        string mail = inputfield.text;
        //string mail = m_InputLogin.GetComponent<UnityEngine.UI.Text> ().text;
        PlayerPrefs.SetString("PlayerMail",mail);


        PlayerPrefs.SetInt ("TermsAndConditionsAccepted", 1);

        PlayerPrefs.SetInt ("LoggedOut", 0);

        PlayerPrefs.Save ();

        Debug.Log ("Saved Mail: " + mail + " password: " + password);




        bool bDontGoToQuestsPage = false;
        if (PlayerPrefs.HasKey ("LoginReturnToQuests")) {
            int returntoquests = PlayerPrefs.GetInt ("LoginReturnToQuests");
            if (returntoquests == 1) {
                Application.LoadLevel ("Quests");
                bDontGoToQuestsPage = true;
            }
        }

        if (bDontGoToQuestsPage == false) {
            Application.LoadLevel ("DemoMap");
        }*/
    }

    public void declineTerms()
    {
        hideTerms();
    }

    public void hideTerms2()
    {
        m_TermsBack2.SetActive(false);
        m_ToggleAgree2.SetActive(false);
        m_TermsBtnAccept2.SetActive(false);
        m_TermsBtnDecline2.SetActive(false);
        m_PanelAgree2.SetActive(false);
    }
    void showTerms2()
    {
        m_TermsBack2.SetActive(true);
        m_ToggleAgree2.SetActive(true);
        m_TermsBtnAccept2.SetActive(true);
        m_TermsBtnDecline2.SetActive(true);
        m_PanelAgree2.SetActive(true);
    }

    void OnDontAcceptTerms2Clicked(string result)
    {
        Debug.Log("OnDontAcceptTerms2Clicked: " + result);
        if (result == LocalizationSupport.GetString("BtnNo"))
        {
            makeLogin();
        }
    }

    public void acceptedTerms2()
    {
        if (m_ToggleAgree2.GetComponent<Toggle>().isOn == false)
        {
            UnityEngine.Events.UnityAction<string> ua = new UnityEngine.Events.UnityAction<string>(OnDontAcceptTerms2Clicked);
            if (Application.systemLanguage == SystemLanguage.German)
            {
                string[] options = { LocalizationSupport.GetString("BtnBack"), LocalizationSupport.GetString("BtnNo") };
                messageBox.Show("", LocalizationSupport.GetString("MsgReallyNoUsername"), ua, options);
            }
            else
            {
                string[] options = { LocalizationSupport.GetString("BtnBack"), LocalizationSupport.GetString("BtnNo") };
                messageBox.Show("", LocalizationSupport.GetString("MsgReallyNoUsername"), ua, options);
            }
            return;
        }



        makeLogin();
    }

    public void declineTerms2()
    {
        hideTerms2();
    }

    void makeLogin()
    {
        PlayerPrefs.SetString("PlayerId", m_PlayerId);


        UnityEngine.UI.InputField textinput;
        textinput = m_InputPassword.GetComponent<UnityEngine.UI.InputField>();
        string password = textinput.text;

        PlayerPrefs.SetString("PlayerPassword", password);

        UnityEngine.UI.InputField inputfield = m_InputFieldLogin.GetComponent<UnityEngine.UI.InputField>();
        string mail = inputfield.text;
        //string mail = m_InputLogin.GetComponent<UnityEngine.UI.Text> ().text;
        PlayerPrefs.SetString("PlayerMail", mail);


        PlayerPrefs.SetInt("TermsAndConditionsAccepted", 1);

        PlayerPrefs.SetInt("LoggedOut", 0);

        PlayerPrefs.Save();

        Debug.Log("Saved Mail: " + mail + " password: " + password);



        bool bDontGoToQuestsPage = false;
        if (PlayerPrefs.HasKey("LoginReturnToQuests"))
        {
            int returntoquests = PlayerPrefs.GetInt("LoginReturnToQuests");
            if (returntoquests == 1)
            {
                Application.LoadLevel("Quests");
                bDontGoToQuestsPage = true;
            }
        }

        if (bDontGoToQuestsPage == false)
        {
            Application.LoadLevel("DemoMap");
        }
    }


    public void OnOpenTerms()
    {
        /*if (Application.systemLanguage == SystemLanguage.German) {
            Application.OpenURL("https://www.geo-wiki.org/assets/legal/FotoQuestGO/1.0/DE/terms-of-use.html");
        } else {
            Application.OpenURL("https://www.geo-wiki.org/assets/legal/FotoQuestGO/1.0/EN/terms-of-use.html");
        }*/
        if (Application.systemLanguage == SystemLanguage.German)
        {
            Application.OpenURL("http://www.fotoquest-go.org/de/terms-of-use/");
        }
        else
        {
            Application.OpenURL("http://www.fotoquest-go.org/en/terms-of-use/");
        }
    }
    public void OnOpenDataPolicy()
    {
        /*if (Application.systemLanguage == SystemLanguage.German) {
            Application.OpenURL("https://www.geo-wiki.org/assets/legal/FotoQuestGO/1.0/DE/privacy-statement.html");
        } else {
            Application.OpenURL("https://www.geo-wiki.org/assets/legal/FotoQuestGO/1.0/EN/privacy-statement.html");
        }*/
        if (Application.systemLanguage == SystemLanguage.German)
        {
            Application.OpenURL("http://www.fotoquest-go.org/de/privacy-policy/");
        }
        else
        {
            Application.OpenURL("http://www.fotoquest-go.org/en/privacy-policy/");
        }
    }
}
