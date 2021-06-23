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
    }

    public void LoadNextScene()
    {
        
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
