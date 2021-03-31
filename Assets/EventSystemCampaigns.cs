using UnityEngine;
using System.Collections;
using Unitycoding.UIWidgets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class LegendItem
{     public int m_LegendRed;     public int m_LegendGreen;     public int m_LegendBlue;     public string m_LegendName;     public int m_LegendItemId;     public string m_LegendValue;
    

    public LegendItem()
    {
    }
}


public class SamplePoint
{
    public int m_SampleId;
    public int m_SampleLegendId;
    public int m_SampleValidated;
    public string m_SampleLat;
    public string m_SampleLng;


    public SamplePoint()
    {
    }
}

public class EventSystemCampaigns : MonoBehaviour
{


    public GameObject m_ButtonBack;
    public GameObject m_ButtonNext;
    public GameObject m_TextTitle;


    private Rect windowRect = new Rect(20, 20, 120, 50);


    private MessageBox messageBox;
    private MessageBox verticalMessageBox;

    private int m_Show = 0;


    public GameObject m_LoadingBack;
    public GameObject m_LoadingText;
    public GameObject m_TextResult;

    public void ForceLandscapeLeft()
    {
        StartCoroutine(ForceAndFixLandscape());
    }

    IEnumerator ForceAndFixLandscape()
    {
        yield return new WaitForSeconds(0.01f);
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.autorotateToLandscapeLeft = false;
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.autorotateToPortrait = true;
        //  }
        yield return new WaitForSeconds(0.5f);
        //}
    }

    // Use this for initialization
    void Start()
    {
        ForceLandscapeLeft();

       // PlayerPrefs.DeleteAll();
        if ((!LocalizationSupport.StringsLoaded))
            LocalizationSupport.LoadStrings();

        updateStates();


        m_LoadingText.SetActive(false);
        m_LoadingText.SetActive(true);
        m_LoadingBack.SetActive(false);
        messageBox = UIUtility.Find<MessageBox>("MessageBox");


        if (messageBox == null)
        {
            Debug.Log("No message box set");
        }
        else
        {
            Debug.Log("Message set");
        }

        //     loginSuccessful("laco-wiki-app:///#access_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IndwWDRxblFtTzVOWG1kbExUUXd6Vk53WWlZMCIsImtpZCI6IndwWDRxblFtTzVOWG1kbExUUXd6Vk53WWlZMCJ9.eyJpc3MiOiJodHRwczovL2Rldi5sYWNvLXdpa2kubmV0L2lkZW50aXR5IiwiYXVkIjoiaHR0cHM6Ly9kZXYubGFjby13aWtpLm5ldC9pZGVudGl0eS9yZXNvdXJjZXMiLCJleHAiOjE1NTU0MTIxMjgsIm5iZiI6MTU1NTQwODUyOCwiY2xpZW50X2lkIjoid2ViYXBpIiwic2NvcGUiOiJ3ZWJhcGkiLCJzdWIiOiI3MSIsImF1dGhfdGltZSI6MTU1NTQwODUyNywiaWRwIjoiR2VvV2lraSIsIm5hbWUiOiJUb2JpYXMgU3R1cm4iLCJlbWFpbCI6InRvYmlhcy5zdHVybkB2b2wuYXQiLCJyb2xlIjoiVXNlciIsImFtciI6WyJleHRlcm5hbCJdfQ.Yhw9SxK_mxEFpGCgHuhL11eI-SmTANAOBx2X-QzMx5D9LHFJmhTwwcMQvvQjIM9KBvhUmJxNTGlh4oeYlfoJM8uJvcBfLozuyy_n2qPh4FwWWYihZcn-iFEqm8PJqSA6Nm3tYe4H1MiDZyuidF6fXPgW0o6eUhEGGWB2EwbaeSvxXj7ow0xG_XWrU6ipKVrPLk79Jt4YZnH6tOa7pNe2MIcMmG2lxA-L4ccAj3OowvNTqJ8ifRYIXGN5octDTa9-Px4x4fL6ivrukeUjhedQoPNpY0jXyNAtrKdvRS-STdU13o-1toSDb4JbiADx0BIu7i5OZpSdByKFl9nzRxPLiw&token_type=Bearer&expires_in=3600&scope=webapi");


        m_AddedTexts = new ArrayList();
        // createValidationsList();

        //loadValidationSessions();

        string activesessions = PlayerPrefs.GetString("ActiveSessions");
        Debug.Log("Active Sessions: " + activesessions);

        m_ValidationSessionIds = new ArrayList();
        m_ValidationSessionNames = new ArrayList();
        m_ValidationSessionSampleIds = new ArrayList();

        loadCampaigns();
        /*
        m_ValidationSessionIds.Add("1");
        m_ValidationSessionNames.Add("Italy");

        m_ValidationSessionIds.Add("1");
        m_ValidationSessionNames.Add("Africa Campaign");

        m_ValidationSessionIds.Add("1");
        m_ValidationSessionNames.Add("South America Campaign");

        createValidationsList();
        m_LoadingText.SetActive(false);

        */


        m_SessionBtnBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Zurück";

        m_SessionBtnStart.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Start");
        m_SessionBtnStop.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Stop");

       // m_SessionBtnDownloadSamples.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("DownloadSamples");

        showSession(false);

        /* bool isSessionActive = false;
         string sessions = PlayerPrefs.GetString("ActiveSessions");
         string newsessions = "";
         string[] splitArray = sessions.Split(char.Parse(" "));
         for (int i = 0; i < splitArray.Length; i++)
         {
             string valid = splitArray[i];
             if (valid != "" && valid != " ")
             {
                 isSessionActive = true;
             }
         }
         if (!isSessionActive)
         {
             m_ButtonNext.SetActive(false);
         } else {
             m_ButtonNext.SetActive(true);
         }*/

        if (PlayerPrefs.HasKey("CampaignJoined"))
        {
            m_ButtonNext.SetActive(true);
        } else
        {
            m_ButtonNext.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updateStates()
    {

        m_TextTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Campaigns");
        m_ButtonBack.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Back");//"Back";
        m_ButtonNext.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("BtnBack");//"Back";
        m_LoadingText.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Loading");//"Loading...";

    }


    ArrayList m_ValidationSessionIds;
    ArrayList m_ValidationSessionNames;
    ArrayList m_ValidationSessionSampleIds;

    public GameObject m_Content;
    public GameObject m_NameS;
    public GameObject m_UploadQuest;
    public GameObject m_DownloadQuest;
    public GameObject m_StopQuest;

    ArrayList m_AddedTexts;
    ArrayList m_Buttons;
    ArrayList m_ButtonsIds;
    ArrayList m_ButtonsStart;
    ArrayList m_ButtonsStop;

    public void createValidationsList()
    {
        int nrentries = m_ValidationSessionNames.Count;
        int nrentriesactive = m_ValidationSessionNames.Count;

        m_Buttons = new ArrayList();
        m_ButtonsStart = new ArrayList();
        m_ButtonsStop = new ArrayList();
        m_ButtonsIds = new ArrayList();


        RectTransform rectTransform2 = m_Content.GetComponent<RectTransform>();
        float scalex = rectTransform2.sizeDelta.x;
        float scaley = rectTransform2.sizeDelta.y;
        float heightentry = 260.0f;//280.0f;//350.0f;
        rectTransform2.sizeDelta = new Vector2(scalex, heightentry * nrentriesactive + 100.0f);


      /*  string sessions = PlayerPrefs.GetString("ActiveSessions");
        string[] splitArray = sessions.Split(char.Parse(" "));
      */

        float posoffset = 0;
        int nrentriesadded = 0;
        int curreport = 1;
        for (int i = nrentries - 1; i >= 0; i--)
        {
            Debug.Log("Create validation entry: " + i);

            GameObject copy;
            RectTransform rectTransform;
            float curpos;
            float curposx;
            int currank;
            string text;

            nrentriesadded++;

            copy = (GameObject)GameObject.Instantiate(m_NameS);
            copy.transform.SetParent(m_Content.transform, false);
            copy.SetActive(true);
            rectTransform = copy.GetComponent<RectTransform>();
            curpos = rectTransform.localPosition.y;
            curposx = rectTransform.localPosition.x;
            curpos -= posoffset;//i * heightentry;
            rectTransform.localPosition = new Vector2(curposx, curpos);
            m_AddedTexts.Add(copy);
            copy.GetComponentInChildren<UnityEngine.UI.Text>().text = (string)m_ValidationSessionNames[i];

            /*
            copy = (GameObject)GameObject.Instantiate(m_UploadQuest);
            copy.transform.SetParent(m_Content.transform, false);
            copy.SetActive(true);
            rectTransform = copy.GetComponent<RectTransform>();
            curpos = rectTransform.localPosition.y;
            curposx = rectTransform.localPosition.x;
            curpos -= posoffset;//i * heightentry;
            rectTransform.localPosition = new Vector2(curposx, curpos);
            m_AddedTexts.Add(copy);

            m_Buttons.Add(copy);
            m_ButtonsIds.Add(i + "");
            copy.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("ShowDetails");//"UPLOAD";

            UnityEngine.UI.Button b = copy.GetComponent<UnityEngine.UI.Button>();
            AddListener(b, i + "");
            */
            UnityEngine.UI.Button b;

            string curvalidationid = (string)m_ValidationSessionIds[i];

          /*  bool bActive = false;
            for (int active = 0; active < splitArray.Length && !bActive; active++)
            {
                if (splitArray[active] == curvalidationid)
                {
                    bActive = true;
                }
            }
          */

            /*if (bActive == false)
            {*/
                copy = (GameObject)GameObject.Instantiate(m_DownloadQuest);
                copy.transform.SetParent(m_Content.transform, false);
                copy.SetActive(true);
                rectTransform = copy.GetComponent<RectTransform>();
                curpos = rectTransform.localPosition.y;
                curposx = rectTransform.localPosition.x;
                curpos -= posoffset;//i * heightentry;
                rectTransform.localPosition = new Vector2(curposx, curpos);
                m_AddedTexts.Add(copy);

                m_Buttons.Add(copy);
                m_ButtonsStart.Add(copy);
                m_ButtonsStop.Add(copy);
                copy.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("ShowDetails");//"UPLOAD";

                b = copy.GetComponent<UnityEngine.UI.Button>();
                AddListener(b, i + "");
           /* }
            else
            {
                copy = (GameObject)GameObject.Instantiate(m_DownloadQuest);
                copy.transform.SetParent(m_Content.transform, false);
                copy.SetActive(false);
                rectTransform = copy.GetComponent<RectTransform>();
                curpos = rectTransform.localPosition.y;
                curposx = rectTransform.localPosition.x;
                curpos -= posoffset;//i * heightentry;
                rectTransform.localPosition = new Vector2(curposx, curpos);
                m_AddedTexts.Add(copy);

                m_ButtonsStart.Add(copy);
                copy.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Start");//"UPLOAD";

                b = copy.GetComponent<UnityEngine.UI.Button>();
                AddListenerDownload(b, i + "");



                copy = (GameObject)GameObject.Instantiate(m_StopQuest);
                copy.transform.SetParent(m_Content.transform, false);
                copy.SetActive(true);
                rectTransform = copy.GetComponent<RectTransform>();
                curpos = rectTransform.localPosition.y;
                curposx = rectTransform.localPosition.x;
                curpos -= posoffset;//i * heightentry;
                rectTransform.localPosition = new Vector2(curposx, curpos);
                m_AddedTexts.Add(copy);

                m_ButtonsStop.Add(copy);
                copy.GetComponentInChildren<UnityEngine.UI.Text>().text = LocalizationSupport.GetString("Stop");//"UPLOAD";

                b = copy.GetComponent<UnityEngine.UI.Button>();
                AddListenerStop(b, i + "");
            }*/


            posoffset += heightentry;


        }

        Debug.Log("Validation list created");

    }


    void AddListener(UnityEngine.UI.Button b, string value)
    {
        b.onClick.AddListener(() => OnValidationClickedValue(value));
    }


    string m_ValidationId;
    string m_ValidationName;
    string m_ValidationDataSet;
    string m_ValidationSample;
    string m_ValidationDescription;
    string m_ValidationMethod;
    int m_ValidationSamplesTotal;
    int m_ValidationSamplesValidated;
    ArrayList m_ValidationLegend;

    int m_CurLegendRed;
    int m_CurLegendGreen;
    int m_CurLegendBlue;
    string m_CurLegendName;
    int m_CurLegendItemId;
    string m_CurLegendValue;


    int m_CurLegendSettingsDistance;
    int m_CurCardinalDirectionPhotosOptional;     int m_CurOpportunisticValidationsEnabled;     int m_CurPointPhotoOptional;     int m_CurTakeCardinalDirectionPhotos;     int m_CurTakePointPhoto; 

    public void OnValidationClickedValue(string param)
    {
        Debug.Log("OnValidationClickedValue: " + param);

        int index = int.Parse(param);

        m_ValidationName = (string)m_ValidationSessionNames[index];
        m_ValidationId = (string)m_ValidationSessionIds[index];
        m_CampaignSampleId = int.Parse((string)m_ValidationSessionSampleIds[index]);
        m_CampaignSampleIdStr = m_CampaignSampleId + "";
        Debug.Log("ValidationClicked ValidationId: " + m_ValidationSessionIds[index] + " SampleId " + m_CampaignSampleId + " Name: " + m_ValidationName);
        loadValidationSession((string)m_ValidationSessionIds[index]);
    }

    public void OnStartValidation()
    {
        m_LoadingText.SetActive(true);
        m_LoadingBack.SetActive(true);

        string sessions = PlayerPrefs.GetString("ActiveSessions");
        string[] splitArray = sessions.Split(char.Parse(" "));
        bool bAlreadyAdded = false;
        for (int i = 0; i < splitArray.Length && !bAlreadyAdded; i++)
        {
            if (splitArray[i] == m_CampaignSampleIdStr)// m_ValidationId)
            {
                bAlreadyAdded = true;
            }
        }

        if (!bAlreadyAdded)
        {
            sessions = sessions + " " + m_CampaignSampleIdStr;//m_ValidationId;
        }
        PlayerPrefs.SetString("ActiveSessions", sessions);
        PlayerPrefs.SetInt("CampaignJoined", 1);
        
        PlayerPrefs.Save();

        Application.LoadLevel("DemoMap");
    }


    void AddListenerStop(UnityEngine.UI.Button b, string value)
    {
        b.onClick.AddListener(() => OnStopClickedValue(value));
    }


    public void OnStopClickedValue(string param)
    {
        Debug.Log("OnStopClickedValue: " + param);


        int index = int.Parse(param);

        m_ValidationName = (string)m_ValidationSessionNames[index];
        m_ValidationId = (string)m_ValidationSessionIds[index];

        string sessions = PlayerPrefs.GetString("ActiveSessions");
        string newsessions = "";
        string[] splitArray = sessions.Split(char.Parse(" "));
        bool bAlreadyAdded = false;
        for (int i = 0; i < splitArray.Length; i++)
        {
            if (splitArray[i] != m_CampaignSampleIdStr)//m_ValidationId)
            {
                if (newsessions == "")
                {
                    newsessions = splitArray[i];
                } else {
                    newsessions = newsessions + " " + splitArray[i];
                }
            }
        }

        PlayerPrefs.SetString("ActiveSessions", newsessions);
        PlayerPrefs.Save();


        int buttonindex = m_ButtonsStart.Count - index - 1;
        GameObject go = (GameObject)m_ButtonsStart[buttonindex];
        go.SetActive(true);

        go = (GameObject)m_ButtonsStop[buttonindex];
        go.SetActive(false);
    }

    void disableStopButton(string valid) 
    {
        Debug.Log("disableStopButton: " + valid);
        for (int i = 0; i < m_ValidationSessionIds.Count; i++) {
            Debug.Log("m_ValidationSessionIds: " + m_ValidationSessionIds[i]);
            if(m_ValidationSessionIds[i] == valid) {
                int index = m_ValidationSessionIds.Count - i - 1;
                Debug.Log("Stop validation");
                GameObject go = (GameObject)m_ButtonsStop[index];
                go.SetActive(false);

                go = (GameObject)m_ButtonsStart[index];
                go.SetActive(true);
            }   
        }
    }

    public void OnBackClicked()
    {
        Application.LoadLevel("DemoMap");
    }
    public void OnNextClicked()
    {
        Application.LoadLevel("DemoMap");
    }


    public void stopSession()
    {
        string sessions = PlayerPrefs.GetString("ActiveSessions");
        string newsessions = "";
        string[] splitArray = sessions.Split(char.Parse(" "));
        bool bAlreadyAdded = false;
        for (int i = 0; i < splitArray.Length; i++)
        {
            if (splitArray[i] != m_CampaignSampleIdStr)//m_ValidationId)
            {
                if (newsessions == "")
                {
                    newsessions = splitArray[i];
                }
                else
                {
                    newsessions = newsessions + " " + splitArray[i];
                }
            }
        }

        Debug.Log("stopSessions: " + newsessions);
        PlayerPrefs.SetString("ActiveSessions", newsessions);
        PlayerPrefs.Save();

        m_SessionBtnStart.SetActive(true);
        m_SessionBtnStop.SetActive(false);

        disableStopButton(m_ValidationId);
    }

    public void loadValidationSession(string sessionid)
    {
        Debug.Log("loadValidationSession: " + sessionid);
        m_LoadingText.SetActive(true);
        m_LoadingBack.SetActive(true);

        string url = "https://geo-wiki.org/Application/api/Campaign/GetFraQuestCampaignStats/" + sessionid;
        WWW www = new WWW(url);

        StartCoroutine(WaitForCampaign(www));

        /*
        m_LoadingText.SetActive(false);
        m_LoadingBack.SetActive(false);

        showSession(true);
        /*
        m_LoadingText.SetActive(true);
        m_LoadingBack.SetActive(true);*/

        /*  //string url = "http://dev.laco-wiki.net/api/mobile/validationsessions/" + sessionid;
          string url = "https://laco-wiki.net/api/mobile/validationsessions/" + sessionid;
          Debug.Log("Url: " + url);

          string token = PlayerPrefs.GetString("Token");
          Debug.Log("token: " + token);

          WWWForm form = new WWWForm();
          form.AddField("param", "param");


          Dictionary<string, string> headers = new Dictionary<string, string>();
          headers.Add("Authorization", "Bearer " + token);

          WWW www = new WWW(url, form.data, headers);

          StartCoroutine(WaitForValidationSession(www));
          */
        //StartCoroutine(ReadingValidationSession(sessionid));
    }

    public GameObject m_SessionBack;
    public GameObject m_SessionBtnBack;
    public GameObject m_SessionImageBack;
    public GameObject m_SessionTitle;
    public GameObject m_SessionScrollView;
    public GameObject m_SessionMethod;
    public GameObject m_SessionDataset;
    public GameObject m_SessionSample;
    public GameObject m_SessionDescription;
    public GameObject m_SessionProgress;
    public GameObject m_SessionCircle;
    public GameObject m_SessionCircleProc;
    public GameObject m_SessionBtnStart;
    public GameObject m_SessionBtnStop;
  //  public GameObject m_SessionBtnDownloadSamples;

    public void showSession(bool bShow)
    {
        m_SessionTitle.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationName;
        m_SessionMethod.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationMethod;
        m_SessionDataset.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationDataSet;
        m_SessionSample.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationSample;
        m_SessionDescription.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationDescription;
        m_SessionProgress.GetComponentInChildren<UnityEngine.UI.Text>().text = m_ValidationSamplesValidated + " / " + m_ValidationSamplesTotal + " validated";
        float proc = (float)m_ValidationSamplesValidated / (float)m_ValidationSamplesTotal;
        m_SessionCircle.GetComponent<Image>().material.SetFloat("_Circle", proc);
        proc *= 100.0f;
        int iproc = (int)proc;
        m_SessionCircleProc.GetComponentInChildren<UnityEngine.UI.Text>().text = iproc + " %";

        m_SessionTitle.SetActive(bShow);
        m_SessionBack.SetActive(bShow);
        m_SessionBtnBack.SetActive(bShow);
        m_SessionImageBack.SetActive(bShow);
        m_SessionScrollView.SetActive(bShow);
        m_SessionBtnStart.SetActive(bShow);
        m_SessionBtnStop.SetActive(bShow);
      //  m_SessionBtnDownloadSamples.SetActive(bShow);

        if (bShow) {
            string sessions = PlayerPrefs.GetString("ActiveSessions");
            string[] splitArray = sessions.Split(char.Parse(" "));
            bool bAlreadyAdded = false;
            for (int i = 0; i < splitArray.Length && !bAlreadyAdded; i++)
            {
                if (splitArray[i] == m_CampaignSampleIdStr)//m_ValidationId)
                {
                    bAlreadyAdded = true;
                }
            }

            if(bAlreadyAdded) {
                m_SessionBtnStop.SetActive(true);
            } else {
                m_SessionBtnStop.SetActive(false);
            }
        }
    }

    public void closeSession()
    {
        showSession(false);
    }



    void loadCampaigns()
    {
        string url = "https://geo-wiki.org/Application/api/Campaign/GetFraQuestCampaigns";
        /* string param = "{";

         param += "\"app_id\":" + "\"" + 21 + "\",\"location\":{\"lat\":" + posx + ",\"lng\":" + posy + "}";

         param += "}";
         Debug.Log("loadMessage param: " + param);


         WWWForm form = new WWWForm();
         form.AddField("parameter", param);*/

        //Debug.Log ("Url data: " + System.Text.Encoding.UTF8.GetString(form.data));
        //WWW www = new WWW(url, form);
        WWW www = new WWW(url);

        StartCoroutine(WaitForCampaigns(www));
    }

    int m_ReadingWhichMessage;
    string m_MessageText;
    int m_CampaignId;
    int m_CampaignSampleId;
    string m_CampaignSampleIdStr;
    string m_CampaignName;
    IEnumerator WaitForCampaigns(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Campaigns!: " + www.text);
            m_ReadingWhichMessage = -1;
            JSONObject j = new JSONObject(www.text);
            accessCampaigns(j);

            int nrsessions = m_ValidationSessionIds.Count;
            PlayerPrefs.SetInt("NrValidationSessions", nrsessions);
            for(int i=0; i<nrsessions; i++)
            {
                PlayerPrefs.SetString("Session_" + i + "_Id", (string)m_ValidationSessionIds[i]);
                PlayerPrefs.SetString("Session_" + i + "_SampleId", (string)m_ValidationSessionSampleIds[i]);
                PlayerPrefs.SetString("Session_" + i + "_SampleName", (string)m_ValidationSessionNames[i]);
            }
            PlayerPrefs.Save();

            createValidationsList();
            m_LoadingText.SetActive(false);
        }
        else
        {
            Debug.Log("Could not load campaigns");
            Debug.Log("WWW Error message: " + www.error);
            Debug.Log("WWW Error message 2: " + www.text);
        }
    }
    void accessCampaigns(JSONObject obj)
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
                    else if (key == "name")
                    {
                        m_ReadingWhichMessage = 1;
                    }
                    else if (key == "sample_id")
                    {
                        m_ReadingWhichMessage = 3;
                    }
                    else
                    {
                        m_ReadingWhichMessage = 0;
                    }
                    accessCampaigns(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                //	Debug.Log ("Array");
                foreach (JSONObject j in obj.list)
                {
                    accessCampaigns(j);
                }
                break;
            case JSONObject.Type.STRING:
                if (m_ReadingWhichMessage == 1)
                {
                    m_CampaignName = obj.str;/*
                    m_ValidationSessionIds.Add("" + m_CampaignId);
                    m_ValidationSessionSampleIds.Add("" + m_CampaignSampleId);
                    m_ValidationSessionNames.Add(obj.str);
                    Debug.Log("Added campaign: " + obj.str + " id: " + m_CampaignId + " sampleid: " + m_CampaignSampleId);*/
                }
                break;
            case JSONObject.Type.NUMBER:
                if (m_ReadingWhichMessage == 2)
                {
                    m_CampaignId = (int)obj.n;
                }
                if (m_ReadingWhichMessage == 3)
                {
                    m_CampaignSampleId = (int)obj.n;


                    m_ValidationSessionIds.Add("" + m_CampaignId);
                    m_ValidationSessionSampleIds.Add("" + m_CampaignSampleId);
                    m_ValidationSessionNames.Add(m_CampaignName);
                    Debug.Log("Added campaign: " + m_CampaignName + " id: " + m_CampaignId + " sampleid: " + m_CampaignSampleId);
                }
                break;

        }
    }


    IEnumerator WaitForCampaign(WWW www)
    {
        yield return www;
        // check for errors
        if (www.error == null)
        {
            Debug.Log("WWW Campaign data!: " + www.text);
            m_ReadingWhichMessage = -1;
            JSONObject j = new JSONObject(www.text);
            accessCampaignInfo(j);

            m_LoadingText.SetActive(false);
            m_LoadingBack.SetActive(false);

            m_ValidationName = m_Name;
            m_ValidationMethod = "std";
            m_ValidationDataSet = "std";
            m_ValidationSample = "std";
            m_ValidationDescription = m_Description;
            m_ValidationSamplesValidated = m_NrLocationsVisited;
            m_ValidationSamplesTotal = m_NrLocations;


            showSession(true);
        }
        else
        {
            Debug.Log("Could not load campaigns");
            Debug.Log("WWW Error message: " + www.error);
            Debug.Log("WWW Error message 2: " + www.text);
        }
    }


    string m_Name;
    string m_Description;
    int m_NrLocations;
    int m_NrLocationsVisited;
    void accessCampaignInfo(JSONObject obj)
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
                    else if (key == "name")
                    {
                        m_ReadingWhichMessage = 1;
                    }
                    else if (key == "description")
                    {
                        m_ReadingWhichMessage = 3;
                    }
                    else if (key == "nr_locations")
                    {
                        m_ReadingWhichMessage = 4;
                    }
                    else if (key == "nr_points_visited")
                    {
                        m_ReadingWhichMessage = 5;
                    }
                    else
                    {
                        m_ReadingWhichMessage = 0;
                    }
                    accessCampaignInfo(j);
                }
                break;
            case JSONObject.Type.ARRAY:
                //	Debug.Log ("Array");
                foreach (JSONObject j in obj.list)
                {
                    accessCampaignInfo(j);
                }
                break;
            case JSONObject.Type.STRING:
                if (m_ReadingWhichMessage == 1)
                {
                    m_Name = obj.str;
                }

                if (m_ReadingWhichMessage == 3)
                {
                    m_Description = obj.str;
                }
                break;
            case JSONObject.Type.NUMBER:
                if (m_ReadingWhichMessage == 2)
                {
                    m_CampaignId = (int)obj.n;
                }
                if (m_ReadingWhichMessage == 4)
                {
                    m_NrLocations = (int)obj.n;
                }
                if (m_ReadingWhichMessage == 5)
                {
                    m_NrLocationsVisited = (int)obj.n;
                }
                break;

        }
    }
}
