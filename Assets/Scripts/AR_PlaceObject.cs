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

    public bool objectAlive;
    public string eyesName;

    public int numberOfEyes;

    public bool hasGravity;
    public bool areSelectable;
    public bool showLabels;
    public bool areMoveable;

    public bool diseases = false;
    public bool shadow = false;

    private void Start() {
        PlaceObject();
    }


    public void PlaceObject() {
        if (instance == null) {
            instance = Instantiate(objectToPlace, Camera.main.transform.position, Quaternion.identity);
            instance.transform.Rotate(new Vector3(0f, 90f, 0f));
            instance.transform.Translate(new Vector3(0f, -.25f, 0f));

            objectAlive = true;
            numberOfEyes++;


            instance.transform.GetChild(0).GetComponent<eyeParts>().hasShadow = shadow;
            instance.transform.GetChild(0).GetComponent<eyeParts>().StartManual(hasGravity, areSelectable, showLabels, areMoveable);

            if (shadow) {
                gameObject.GetComponent<EyePartsMinigame>().shadow = instance.transform.GetChild(2).gameObject;
                instance.transform.GetChild(2).GetComponent<EyeShadow>().minigame = gameObject.GetComponent<EyePartsMinigameEye>();
            }

            if (diseases) {
                int rng = Random.Range(0, 2);

                GameObject dis = instance.transform.GetChild(1).GetChild(rng).gameObject;
                dis.SetActive(true);

                instance.name = dis.name;
                eyesName = instance.name;
            }
        } else {
            instance.transform.position = Camera.main.transform.position;
            instance.transform.Translate(new Vector3(0f, -.25f, 0f));
        }
    }

    public void DestroyCurrentObject() {
        if (objectAlive == true) {
            GameObject selected = instance.transform.GetChild(0).GetComponent<eyeParts>().selectedObject;
            if (selected != null) {
                Destroy(selected);
            }

            Destroy(instance);
            objectAlive = false;
        }
    }

    public void ScaleUp() {
        AlterScale(.02f);
    }

    public void ScaleDown() {
        AlterScale(-.02f);
    }

    public void RotateLeft() {
        RotateInstance(20f);
    }

    public void RotateRight() {
        RotateInstance(-20f);
    }

    private void AlterScale(float amount) {
        if (instance == null) return;

        instance.transform.localScale += new Vector3(amount, amount, amount);
    }

    private void RotateInstance(float amount) {
        if (instance == null) return;

        instance.transform.Rotate(new Vector3(0f, amount, 0f));
    }
}
