using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    public Button buttonQuitTutorial;
    public Button buttonClosePopUpTutorial;
    public Button buttonOpenPopUpTutorial;

    public Button buttonPreviousTut;
    public Button buttonNextTut;

    public GameObject popUpMenuTutorial;

    public GameObject[] tutPanel;
    public GameObject tutImgHolder;

    public int minTutorial = 0;
    public int maxTutorial = 5;

    private int imgIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Button btnQuitTutorial = buttonQuitTutorial.GetComponent<Button>();
        Button btnClosePopUpTutorial = buttonClosePopUpTutorial.GetComponent<Button>();
        Button btnOpenPopUpTutorial = buttonOpenPopUpTutorial.GetComponent<Button>();

        Button btnPreviousTut = buttonPreviousTut.GetComponent<Button>();
        Button btnNextTut = buttonNextTut.GetComponent<Button>();

        btnQuitTutorial.onClick.AddListener(LoadMenu);
        btnClosePopUpTutorial.onClick.AddListener(ClosePopUpTutorial);
        btnOpenPopUpTutorial.onClick.AddListener(OpenPopUpTutorial);

        btnPreviousTut.onClick.AddListener(PreviousTut);
        btnNextTut.onClick.AddListener(NextTut);

    }

    private void Update()
    {
        imgIndex = Mathf.Clamp(imgIndex, minTutorial, maxTutorial);
        tutPanel[imgIndex].SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OpenPopUpTutorial()
    {
        popUpMenuTutorial.SetActive(true);
    }

    private void ClosePopUpTutorial()
    {
        popUpMenuTutorial.SetActive(false);
    }

    private void PreviousTut()
    {
        DisableAll();
        imgIndex--;
        
    }

    private void NextTut()
    {
        DisableAll();
        imgIndex++;
    }

    private void DisableAll()
    {
        for(int i = 0; i < tutPanel.Length; i++)
        {
            tutPanel[i].SetActive(false);
        }
    }


}
