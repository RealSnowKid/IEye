
using UnityEngine;

public class SpawnEye : MonoBehaviour
{  
    public AR_PlaceObject ar; 

    // Update is called once per frame
    void Update()
    {

    }


    public void NewMission()
    {
        if(ar.objectAlive)
        {
            ar.DestroyCurrentObject();
            Invoke("NewObject", 5f);
        } else
        {
            ar.PlaceObject();
        }
        
    }


    private void NewObject()
    {
        ar.PlaceObject();
    }
}
