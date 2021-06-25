using TMPro;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using SimpleJSON;


public class LeaderBoardScriptEyeParts : MonoBehaviour
{
    public Button btnClose;
    public Button btnSubmit;
    public GameObject namePopUp;
    public TMP_InputField userInputField;
    public GameObject warningMsg;
    public MissionScript missionScript;
    public EyePartsMinigameEye eyeScript;

    public GameObject Info;
    public GameObject LeaderboardLines;
    public Text YourPoints;
    public GameObject YourColor;
    public GameObject MessageBox;
    public GameObject NoResultsYet;
    public GameObject NoInternet;

    public GameObject askNameMenu;
    public Button buttonQuitLeaderBoard;

    public string username;

    private int leaderboardScore;

    private void Start()
    {
        Button btnAnon = btnClose.GetComponent<Button>();
        Button btnSubmitName = btnSubmit.GetComponent<Button>();
        btnAnon.onClick.AddListener(DeactivateAskName);
        btnSubmitName.onClick.AddListener(SubmitUsername);
        StartCoroutine(GetLeaderboards());
    }

    private void Update()
    {
        if(missionScript != null)
        {
            YourPoints.text = missionScript.score.ToString();
            leaderboardScore = missionScript.score;
        }
        else
        {
            YourPoints.text = eyeScript.score.ToString();
            leaderboardScore = eyeScript.score;
        }
        
        if (askNameMenu.activeInHierarchy)
        {
            buttonQuitLeaderBoard.interactable = false;
        } else
        {
            buttonQuitLeaderBoard.interactable = true;
        }

        
    }

    IEnumerator GetLeaderboards()
    {
        NoResultsYet.SetActive(false);
        string uri = "https://factualchicken.backendless.app/api/services/IEyeLeaderboards/getEyePartsLeaderboards";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Info.GetComponent<Text>().text = request.error;
            else
            {
                Info.SetActive(false);

                JSONNode leaderboardsInfo = JSON.Parse(request.downloadHandler.text);
                if (leaderboardsInfo.Count > 0)
                {
                    LeaderboardLines.SetActive(true);
                    for (int i = 0; i < leaderboardsInfo.Count; i++)
                    {
                        LeaderboardLines.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>().text = leaderboardsInfo[i]["name"];
                        LeaderboardLines.transform.GetChild(i).transform.GetChild(2).GetComponent<Text>().text = leaderboardsInfo[i]["score"];
                    }
                }
                else
                {
                    NoResultsYet.SetActive(true);
                }
            }
        }
    }

    private void SubmitUsername()
    {
        if(userInputField.GetComponent<TMP_InputField>().text != "")
        {
            username = userInputField.GetComponent<TMP_InputField>().text;
            FinalizeScore();
        }
        else
        {
            warningMsg.SetActive(true);
        }
    }

    private void DeactivateAskName()
    {
        username = "Anoniem";
        FinalizeScore();
    }

    private void FinalizeScore()
    {
        StartCoroutine(PostScore());
        ClosePopUp();
    }

    IEnumerator PostScore()
    {
        Info.SetActive(true);
        Info.GetComponent<Text>().text = "Versturen...";
        string uri = "https://factualchicken.backendless.app/api/services/IEyeLeaderboards/postEyePartsScore";

        Score sendScore = new Score
        {
            name = username,
            score = leaderboardScore
        };
        

        string jsonData = JsonUtility.ToJson(sendScore);

        UnityWebRequest request = UnityWebRequest.Post(uri, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            Info.SetActive(false);
            NoInternet.SetActive(true);
        }
        else
        {
            int resp;
            if (Int32.TryParse(request.downloadHandler.text, out resp))
            {
                resp = Convert.ToInt32(request.downloadHandler.text);
                YourPosition(resp);
            }
            else
            {
                MessageBox.SetActive(true);
                YourPosition(Convert.ToInt32(request.downloadHandler.text.Replace("\"", "").Split('.')[1]));
            }
            StartCoroutine(GetLeaderboards());
        }
    }

    private void YourPosition(int position)
    {
        if (position > 10)
        {
            LeaderboardLines.transform.GetChild(10).gameObject.SetActive(true);
            LeaderboardLines.transform.GetChild(10).transform.GetChild(1).GetComponent<Text>().text = position.ToString();
        }
        else
        {
            Color highlight = new Color(0.8666667f, 0.8123309f, 0.1529412f, 0.3921569f);
            switch (position)
            {
                case 1:
                    LeaderboardLines.transform.GetChild(0).GetComponent<Image>().color = highlight;
                    break;
                case 2:
                    LeaderboardLines.transform.GetChild(1).GetComponent<Image>().color = highlight;
                    break;
                case 3:
                    LeaderboardLines.transform.GetChild(2).GetComponent<Image>().color = highlight;
                    break;
                case 4:
                    LeaderboardLines.transform.GetChild(3).GetComponent<Image>().color = highlight;
                    break;
                case 5:
                    LeaderboardLines.transform.GetChild(4).GetComponent<Image>().color = highlight;
                    break;
                case 6:
                    LeaderboardLines.transform.GetChild(5).GetComponent<Image>().color = highlight;
                    break;
                case 7:
                    LeaderboardLines.transform.GetChild(6).GetComponent<Image>().color = highlight;
                    break;
                case 8:
                    LeaderboardLines.transform.GetChild(7).GetComponent<Image>().color = highlight;
                    break;
                case 9:
                    LeaderboardLines.transform.GetChild(8).GetComponent<Image>().color = highlight;
                    break;
                case 10:
                    LeaderboardLines.transform.GetChild(9).GetComponent<Image>().color = highlight;
                    break;
                default:
                    Debug.Log(position);
                    break;
            }
            YourColor.SetActive(true);
        }
    }

    private void ClosePopUp()
    {
        namePopUp.SetActive(false);
    }

    public void CloseBox(string name)
    {
        if (name == "MessageBox")
        {
            MessageBox.SetActive(false);
        }
        else if (name == "Internet")
        {
            NoInternet.SetActive(false);
        }
        
    }
}
