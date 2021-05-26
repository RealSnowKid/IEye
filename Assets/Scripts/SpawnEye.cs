
using TMPro;
using UnityEngine;

public class SpawnEye : MonoBehaviour
{  
    public AR_PlaceObject ar;
    public GameObject nextLevelText;

    private void Start()
    {
        nextLevelText.SetActive(true);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            nextLevelText.SetActive(false);
        }
    }

    public void NewMission()
    {
        if(ar.objectAlive)
        {
            ar.DestroyCurrentObject();           
        } else
        {
            nextLevelText.SetActive(true);
            //ar.PlaceObject();
        }
        
    }
}
