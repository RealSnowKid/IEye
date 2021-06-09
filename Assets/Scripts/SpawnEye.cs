
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

    public void NewMission()
    {
        if(ar.objectAlive)
        {
            ar.DestroyCurrentObject();

        } else
        {
            nextLevelText.SetActive(true);

        }
        
    }
}
