using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

    public Button myButton;

    private void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadNextScene);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
