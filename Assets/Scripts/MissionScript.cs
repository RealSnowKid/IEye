using TMPro;
using UnityEngine;

public class MissionScript : MonoBehaviour
{

    public bool isCompleted;
    public GameObject textInput;
    public GameObject currentMission;
    public GameObject congratulationsText;
    public GameObject leaderBoard;

    public SpawnEye eye;

    public int points;

    public string[] congratulationsTextList;

    private string randomText;
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
            Invoke("CongratulationsText", 3f);
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
        RandomCongratulations();
        textInput.GetComponent<TMP_InputField>().text = "";
        isCompleted = true;
        eye.NewMission();
    }


    void CongratulationsText()
    {
        congratulationsText.SetActive(false);
    }

    void RandomCongratulations()
    {
        int randNumber = Random.Range(0, congratulationsTextList.Length);

        for(int i = 0; i < randNumber; i++)
        {
            randomText = congratulationsTextList[i];
        }

        congratulationsText.GetComponent<TMP_Text>().text = randomText;    
        
        congratulationsText.SetActive(true);
    }
}
