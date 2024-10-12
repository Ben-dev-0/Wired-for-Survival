using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour {
    private UIDocument doc;
    private Label label;
    void Start() {
        doc = GetComponent<UIDocument>();
        label = doc.rootVisualElement.Q("label") as Label;
    }

    public void SetLabelText(string text) {
        Debug.Log("Event " + text);
        label.text = text;
    }

    public void SetLabelText(int n) {
        Debug.Log("Event " + n);
        label.text = String.Format("{0}",n);
    }
}
