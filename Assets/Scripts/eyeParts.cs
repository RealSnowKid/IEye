using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class eyeParts : MonoBehaviour{
    public bool hasGravity;
    public bool areSelectable;

    public bool showLabels;
    public bool areMoveable;

    private Dropdown Drdown;
    private JSONnames JSONnames;

    [SerializeField] GameObject bounds;
    private GameObject cam;
    private GameObject UItext;

    public GameObject selectedObject;
    Transform eye = null;

    private void Start() {
        cam = GameObject.Find("AR Camera");
        UItext = GameObject.Find("SelectedObject");
        Drdown = GameObject.Find("LanguageDropdown").GetComponent<Dropdown>();
        if (Drdown != null)
        {
            JSONnames = Drdown.GetComponent<JSONnames>();
        }

        if (hasGravity) {
            foreach (Transform child in transform) {
                child.GetComponent<Rigidbody>().isKinematic = false;
                child.GetComponent<Rigidbody>().useGravity = true;

                child.GetComponent<MeshCollider>().convex = true;
            }
        }
        
        StartCoroutine(deleteBounds());
    }

    private IEnumerator deleteBounds() {
        yield return new WaitForSeconds(2);

        Destroy(bounds);
    }

    public void Update() {
        if (!areSelectable) {
            if (showLabels || areMoveable)
                Debug.LogError("Turn on areSelectable");
            return;
        }

        Ray gazeRay = new Ray(cam.transform.position, cam.transform.rotation * Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity) ) {
            if(hit.transform.gameObject.GetComponent<eyePart>() != null) {

                if (areSelectable) {
                    if (selectedObject != null) {
                        selectedObject.GetComponent<eyePart>().Deselect();
                    }
                    selectedObject = hit.transform.gameObject;
                    selectedObject.GetComponent<eyePart>().Select();

                    if (showLabels) {
                        if(selectedObject != null) {
                            if (Drdown != null)
                            {
                                UItext.GetComponent<Text>().text = JSONnames.SetPartsTexts(selectedObject.GetComponent<eyePart>().PartName);
                            }
                            else
                            {
                                UItext.GetComponent<Text>().text = selectedObject.GetComponent<eyePart>().PartName;
                            }
                        }
                    }

                    if(areMoveable && Input.touchCount > 0) {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began) {
                            UItext.GetComponent<Text>().color = Color.green;
                            selectedObject.transform.parent = cam.transform;

                            if (hasGravity) selectedObject.GetComponent<Rigidbody>().isKinematic = true;
                        } else if (touch.phase == TouchPhase.Ended) {
                            UItext.GetComponent<Text>().color = Color.red;
                            selectedObject.transform.parent = transform;

                            if(hasGravity) selectedObject.GetComponent<Rigidbody>().isKinematic = false;
                        }
                    }
                }
            } else {
                if (selectedObject != null) {
                    selectedObject.GetComponent<eyePart>().Deselect();
                    selectedObject = null;
                }
            }
        } else {
            if (selectedObject != null) {
                selectedObject.GetComponent<eyePart>().Deselect();
                selectedObject = null;
            }
            if (showLabels) {
                UItext.GetComponent<Text>().text = "";
            }
        }
        
    }
}
