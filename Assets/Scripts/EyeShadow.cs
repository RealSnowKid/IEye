using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeShadow : MonoBehaviour {
    public EyePartsMinigameEye minigame;
    private GameObject prevObject = null;

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<eyePart>() != null && other.gameObject != prevObject) {
            prevObject = other.gameObject;
            minigame.CheckObject(other.gameObject);
        }
    }
}
