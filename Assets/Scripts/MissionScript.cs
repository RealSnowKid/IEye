using TMPro;
using UnityEngine;

public class MissionScript : MonoBehaviour
{

    public bool isCompleted;
    public GameObject textInput;
    public GameObject currentMission;
    public GameObject congratulationsText;

    public SpawnEye eye;

    public GameObject leaderBoard;

    public int points;
    void Start()
    {
        leaderBoard.SetActive(false);
        congratulationsText.SetActive(false);
        eye.NewMission();
    }

    // Update is called once per frame
    void Update()
    {
        string text = textInput.GetComponent<TMP_InputField>().text;

        if(!isCompleted)
        {
            if (text == "Test")
            {
                CompleteMission();
            }
        } else
        {
            Invoke("CongratulationsText", 5f);
            isCompleted = false;
        }

        if(points >= 5)
        {
            leaderBoard.SetActive(true);
        }
    }

    void CompleteMission()
    {
        points++;
        congratulationsText.SetActive(true);
        textInput.GetComponent<TMP_InputField>().text = "";
        isCompleted = true;
        eye.NewMission();
    }


    void CongratulationsText()
    {
        congratulationsText.SetActive(false);
    }
}
