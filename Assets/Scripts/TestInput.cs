using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInput : MonoBehaviour
{
    private Dropdown Drdown;
    private JSONnames JSONnames;
    private GameObject UItext;

    void Start()
    {
        UItext = GameObject.Find("SelectedObject");
        Drdown = GameObject.Find("LanguageDropdown").GetComponent<Dropdown>();
        if (Drdown != null)
        {
            JSONnames = Drdown.GetComponent<JSONnames>();
        }
    }

    void Update()
    {
        UItext.GetComponent<Text>().text = JSONnames.SetPartsTexts("Vitreous Humour");
        //Debug.Log("Text " + UItext.GetComponent<Text>().text);
    }
}
