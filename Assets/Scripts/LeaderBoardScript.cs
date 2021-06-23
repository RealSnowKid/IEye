using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour
{
    public Button btnClose;
    public Button btnSubmit;
    public GameObject namePopUp;
    public TMP_InputField userInputField;
    public GameObject warningMsg;
    public TMP_Text usernameLeaderboard;
    public TMP_Text scoreLeaderboard;
    public MissionScript missionScript;

    public GameObject askNameMenu;
    public Button buttonQuitLeaderBoard;

    public string username;


    private void Start()
    {
        Button btnAnon = btnClose.GetComponent<Button>();
        Button btnSubmitName = btnSubmit.GetComponent<Button>();
        btnAnon.onClick.AddListener(DeactivateAskName);
        btnSubmitName.onClick.AddListener(SubmitUsername);

    }

    private void Update()
    {
        if(askNameMenu.activeInHierarchy)
        {
            buttonQuitLeaderBoard.interactable = false;
        } else
        {
            buttonQuitLeaderBoard.interactable = true;
        }
    }

    private void SubmitUsername()
    {
        if(userInputField.GetComponent<TMP_InputField>().text != "")
        {
            username = userInputField.GetComponent<TMP_InputField>().text;
            FinalizeScore(username);
        }
        else
        {
            warningMsg.SetActive(true);
        }
        
    }

    private void DeactivateAskName()
    {
        username = "Anonymous";
        FinalizeScore(username);
    }

    private void FinalizeScore(string name)
    {
        usernameLeaderboard.text = name;
        scoreLeaderboard.text = "" + missionScript.score;
        ClosePopUp();
    }


    private void ClosePopUp()
    {
        namePopUp.SetActive(false);
    }


}
