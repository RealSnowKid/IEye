using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class eyeParts : MonoBehaviour{
    public bool hasGravity;
    public bool areSelectable;

    public bool showLabels;
    public bool areMoveable;
    [SerializeField] GameObject bounds;
    private GameObject cam;
    private GameObject UItext;

    public GameObject selectedObject;
    Transform eye = null;

    public void StartManual(bool gravity, bool selectable, bool labels, bool move) {
        hasGravity = gravity;
        areSelectable = selectable;
        showLabels = labels;
        areMoveable = move;

        Begin();
    }
   
    private void Begin() {
        cam = GameObject.Find("AR Camera");
        UItext = GameObject.Find("SelectedObject");
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
                            UItext.GetComponent<Text>().text = selectedObject.GetComponent<eyePart>().name;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("shadow"))
        {
            selectedObject.GetComponent<Rigidbody>().mass = 0; // This can be changed to whatever you want, this is if you want the mass changed;
            selectedObject.GetComponent<Rigidbody>().useGravity = false; // This is if you want to turn the gravity off;
            selectedObject.GetComponent<Rigidbody>().isKinematic = true;
           // selectedObject.GetComponent<eyePart>().Deselect();
        }    
    }
    void OnTriggerExit(Collider other)
    {
        selectedObject.GetComponent<Rigidbody>().mass = 1; // Back to normal here using mass;
        selectedObject.GetComponent<Rigidbody>().useGravity = true; // This is if you want the gravity to be turned back on;
          //selectedObject.GetComponent<eyePart>().Select();
    }
}
