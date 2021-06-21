using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
//using UnityEngine.Experimental.XR
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;


public class AR_PlaceObject : MonoBehaviour {
    public GameObject objectToPlace;
    public GameObject placementIndicator;

    private GameObject instance = null;

    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    public bool objectAlive;
    public string eyesName;

    public int numberOfEyes;

    public bool hasGravity;
    public bool areSelectable;
    public bool showLabels;
    public bool areMoveable;

    public bool diseases = false;

    void Start() {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update() {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
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

        if (instance == null)
        {
            instance = Instantiate(objectToPlace, PlacementPose.position, PlacementPose.rotation);
            instance.transform.Rotate(new Vector3(0f, 90f, 0f));
            objectAlive = true;
            numberOfEyes++;

            instance.transform.GetChild(0).GetComponent<eyeParts>().StartManual(hasGravity, areSelectable, showLabels, areMoveable);

            if (diseases) {
                int rng = Random.Range(0, 2);

                GameObject dis = instance.transform.GetChild(1).GetChild(rng).gameObject;
                dis.SetActive(true);

                instance.name = dis.name;
            }
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