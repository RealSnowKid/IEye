using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.Experimental.XR
using UnityEngine.XR.ARSubsystems;


public class AR_PlaceObject : MonoBehaviour {
    public GameObject[] objectToPlace;
    public GameObject placementIndicator;

    private GameObject instance = null;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public bool objectAlive;
    public string eyesName;

    public int numberOfEyes;

    void Start() {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update() {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if(instance != null)
        {
            eyesName = instance.name.Replace("(Clone)", "");
        }
        
    }

    private void UpdatePlacementIndicator() {
        if (placementPoseIsValid) {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
            placementIndicator.transform.Rotate(new Vector3(90f, 0f, 0f));
        } else
            placementIndicator.SetActive(false);
    }

    private void UpdatePlacementPose() {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid) {
            PlacementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    public void PlaceObject() {
        if (!placementPoseIsValid) return;

        int randomObj = Random.Range(0, objectToPlace.Length);

        if (instance == null)
        {
            instance = Instantiate(objectToPlace[randomObj], PlacementPose.position, PlacementPose.rotation);
            instance.transform.Rotate(new Vector3(0f, 90f, 0f));
            objectAlive = true;
            numberOfEyes++;
        }
        else {
            instance.transform.position = PlacementPose.position;
            instance.transform.rotation = PlacementPose.rotation;
        }
    }

    public void DestroyCurrentObject()
    {


        if(objectAlive == true)
        {
            GameObject selected = instance.transform.GetChild(0).GetComponent<eyeParts>().selectedObject;
            if (selected != null) {
                Destroy(selected);
            }

            Destroy(instance);
            objectAlive = false;
        } 
    }

}