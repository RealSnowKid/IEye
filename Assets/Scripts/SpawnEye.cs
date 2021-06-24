
using TMPro;
using UnityEngine;

public class SpawnEye : MonoBehaviour
{  
    public AR_PlaceObjectEye ar;

    public void NewMission()
    {
        if(ar.objectAlive)
        {
            ar.DestroyCurrentObject();
        } 
        
    }
}
