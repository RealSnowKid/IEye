using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public Button myButton;
    public Button openContextMenu;
    public GameObject contextMenu;

    public Button normalButton;
    public Button moveButton;
    public Button gravityButton;
    public Button exitButton;

    private void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadNextScene);

        Button contextButton = openContextMenu.GetComponent<Button>();
        contextButton.onClick.AddListener(ToggleContext);

        normalButton.GetComponent<Button>().onClick.AddListener(LoadNormalScene);
        moveButton.GetComponent<Button>().onClick.AddListener(LoadMoveScene);
        gravityButton.GetComponent<Button>().onClick.AddListener(LoadGravityScene);
        exitButton.GetComponent<Button>().onClick.AddListener(ToggleContext);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToggleContext() {
        contextMenu.SetActive(!contextMenu.activeSelf);
    }

    void LoadNormalScene() {
        LoadCustomScene("Normal_Eye");
    }

    void LoadMoveScene() {
        LoadCustomScene("Move_Eye");
    }

    void LoadGravityScene() {
        LoadCustomScene("Gravity_Eye");
    }

    public void LoadMainMenu() {
        LoadCustomScene("OpenApp");
    }

    void LoadCustomScene(string name) {
        SceneManager.LoadScene(name);
    }


}
