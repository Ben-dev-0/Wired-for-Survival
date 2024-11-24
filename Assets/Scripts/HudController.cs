using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour {
    [SerializeField] GameObject player;
    UIDocument doc;
    ProgressBar healthBar;
    ProgressBar ammoBar;

    void Awake() {
        doc = gameObject.GetComponent<UIDocument>();
        healthBar = doc.rootVisualElement.Q("status-bars").Q("health-bar") as ProgressBar;
        ammoBar = doc.rootVisualElement.Q("status-bars").Q("ammo-bar") as ProgressBar;
    }

    public void SetHealth(float amount) {
        healthBar.value = amount;
    }

    public void SetMaxHealth(float amount) {
        healthBar.highValue = amount;
    }

    public void IncrementHealth(float amount) {
        healthBar.value += amount;
    }

    public void SetAmmo(float amount) {
        ammoBar.value = amount;
    }

    public void SetMaxAmmo(float amount) {
        ammoBar.highValue = amount;
    }

    public void IncrementAmmo(float amount) {
        ammoBar.value += amount;
    }

    public void SetAmmoCooldownColor(bool isCoolingDown) {
        if (isCoolingDown) {
            ammoBar.AddToClassList("ammo-bar-cooldown");
        }
        else {
            ammoBar.RemoveFromClassList("ammo-bar-cooldown");
        }
    }
}
