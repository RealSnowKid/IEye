using TMPro;
using UnityEngine;

public class MissionScript : MonoBehaviour
{

    //UI
    public TMP_InputField textInput;
    public GameObject currentMission;
    public GameObject congratulationsText;
    public GameObject failureText;
    public GameObject leaderBoard;
    public GameObject gameUI;
    public GameObject gameOverUI;
    public GameObject gameOverText;

    public SpawnEye eye;
    public Player player;
    public AR_PlaceObject ar;
    public TimerScript timer;
    public int replay = 3;

    [HideInInspector]
    public bool isCompleted;
    [HideInInspector]
    public int points;
    public int score;
    public string[] congratulationsTextList;

    private string randomText;
    private int damage = 1;
    private string text;

    void Start()
    {
        gameOverText.SetActive(false);
        leaderBoard.SetActive(false);
        congratulationsText.SetActive(false);
        failureText.SetActive(false);
        gameOverUI.SetActive(false);
        eye.NewMission();

        timer.BeginTimer();
    }

    void LockInput(TMP_InputField input)
    {
        if(input.text.Length > 0)
        {
            PlayMinigame();
        }
    }

    bool check = false;

    // Update is called once per frame
    void Update()
    {
        if(TouchScreenKeyboard.visible == true) {
            check = true;
        }else if(TouchScreenKeyboard.visible == false && check == true) {
            check = false;

            if (textInput.text.Length > 0) {
                PlayMinigame();
            }
        }

        text = textInput.GetComponent<TMP_InputField>().text;

        // checks if player is dead
        GameOver();

        // win minigame, show leaderboard
        WinMinigame();
        score = points;
    }


    void PlayMinigame()
    {
        if (!isCompleted)
        {
            if (textInput.GetComponent<TMP_InputField>().text != "")
            {
                if (text == ar.eyesName)
                {
                    CompleteMission();
                }
                else
                {
                    FailMission();
                }

                textInput.GetComponent<TMP_InputField>().text = "";
            }
        }

    }

    // shows that the player answered correct
    void CompleteMission()
    {
        points++;
        RandomCongratulations();
        isCompleted = true;
        eye.NewMission();
    }

    // shows that the player answered wrong
    void FailMission()
    {
        FailureText();
        player.DoDamage(damage);
        Invoke("ActivateFailureText", 2f);
    }

    // correct answer text
    void CongratulationsText()
    {
        isCompleted = false;
        congratulationsText.SetActive(false);
    }

    // wrong answer text
    void FailureText()
    {
        failureText.SetActive(true);
    }

    void ActivateFailureText()
    {
        failureText.SetActive(false);
    }

    // picks a random congratulations word when answering correct
    void RandomCongratulations()
    {
        int randNumber = Random.Range(0, congratulationsTextList.Length);

        for(int i = 0; i < randNumber; i++)
        {
            randomText = congratulationsTextList[i];
        }

        congratulationsText.GetComponent<TMP_Text>().text = randomText;    
        
        congratulationsText.SetActive(true);

        Invoke("CongratulationsText", 2f);
       
    }

    // player wins the minigame, goes to leaderboard
    void WinMinigame()
    {
        if (ar.numberOfEyes >= replay)
        {
            timer.EndTimer();
            WinningGameBonusPoints();
            gameUI.SetActive(false);
            leaderBoard.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    // player is dead, game over. Starts from menu screen
    void GameOver()
    {
        if(!player.isAlive)
        {
            textInput.GetComponent<TMP_InputField>().interactable = false;
            gameOverText.SetActive(true);
            Invoke("PlayerDeath", 6f);
        }
    }

    // if the player runs out of health, game over
    void PlayerDeath()
    {
        gameOverText.SetActive(false);
        gameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    // awards the player bonus points for finishing the game in a certain time
    void WinningGameBonusPoints()
    {
        
        if(timer.elapsedTime <= 60)
        {
            points += 30;
        } else if (timer.elapsedTime > 60  && timer.elapsedTime <= 120)
        {
            points += 20;
        } else
        {
            points += 10;
        }
    }

}
