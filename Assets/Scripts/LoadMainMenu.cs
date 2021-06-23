using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadMainMenu : MonoBehaviour
{
    //Minigame
    public Button buttonQuitMinigame;
    public Button buttonClosePopUpMinigame;
    public Button buttonOpenPopUpMinigame;
    public GameObject popUpMenuMinigame;

    //Leaderboard
    public Button buttonQuitLeaderBoard;
    public Button buttonClosePopUpLeaderboard;
    public Button buttonOpenPopUpLeaderboard;
    public GameObject popUpMenuLeaderboard;

    private void Start()
    {
        //Minigame
        Button btnMinigame = buttonQuitMinigame.GetComponent<Button>();
        Button btnClosePopUpMinigame = buttonClosePopUpMinigame.GetComponent<Button>();
        Button btnOpenPopUpMinigame = buttonOpenPopUpMinigame.GetComponent<Button>();

        btnMinigame.onClick.AddListener(LoadMenu);
        btnClosePopUpMinigame.onClick.AddListener(ClosePopUpMinigame);
        btnOpenPopUpMinigame.onClick.AddListener(OpenPopUpMinigame);

        //Leaderboard
        Button btnLeaderboard = buttonQuitLeaderBoard.GetComponent<Button>();
        Button btnClosePopUpLeaderboard = buttonClosePopUpLeaderboard.GetComponent<Button>();
        Button btnOpenPopUpLeaderboard = buttonOpenPopUpLeaderboard.GetComponent<Button>();
        
        btnLeaderboard.onClick.AddListener(LoadMenu);
        btnClosePopUpLeaderboard.onClick.AddListener(ClosePopUpLeaderboard);
        btnOpenPopUpLeaderboard.onClick.AddListener(OpenPopUpLeaderboard);
    }



    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenPopUpMinigame()
    {
        popUpMenuMinigame.SetActive(true);
    }

    private void ClosePopUpMinigame()
    {
        popUpMenuMinigame.SetActive(false);
    }

    private void OpenPopUpLeaderboard()
    {
        popUpMenuLeaderboard.SetActive(true);
    }

    private void ClosePopUpLeaderboard()
    {
        popUpMenuLeaderboard.SetActive(false);
    }


}
