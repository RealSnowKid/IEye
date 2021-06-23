using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyePart : MonoBehaviour {
    public string name;
    private Color color;

    private void Awake() {
        color = GetComponent<Renderer>().material.color;
    }

    public void Select() {
        GetComponent<Renderer>().material.color = Color.black;
    }

    public void Deselect() {
        GetComponent<Renderer>().material.color = color;
    }
}
