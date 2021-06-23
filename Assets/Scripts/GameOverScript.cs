using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    //Game Over
    public Button buttonGameOver;
    public MissionScript missionScript;
    public GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Button btnGameOver = buttonGameOver.GetComponent<Button>();
        btnGameOver.onClick.AddListener(LoadMainMenu);        
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy)
            scoreText.GetComponent<TMP_Text>().text = "" + missionScript.score;
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
