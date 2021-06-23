using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject popUp;
    public GameObject leaderboardPopUp;

    public void LoadScenes(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void OpenPopUp()
    {
        popUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUp.SetActive(false);
    }

    public void OpenLeaderboardPopUp()
    {
        leaderboardPopUp.SetActive(true);
    }

    public void CloseLeaderboardPopUp()
    {
        leaderboardPopUp.SetActive(false);
    }

}
