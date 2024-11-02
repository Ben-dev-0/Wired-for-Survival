using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour {
    [SerializeField] GameObject player;
    UIDocument doc;
    ProgressBar ammoBar;

    void Awake() {
        doc = gameObject.GetComponent<UIDocument>();
        ammoBar = doc.rootVisualElement.Q("ammo-bar") as ProgressBar;
    }

    public void SetAmmo(float amount) {
        ammoBar.value = amount;
    }

    public void SetMaxAmmo(float amount) {
        ammoBar.highValue = amount;
        Debug.Log("HV="+ammoBar.highValue);
    }

    public void IncrementAmmo(float amount) {
        ammoBar.value += amount;
    }
}
