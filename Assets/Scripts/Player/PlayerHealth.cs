using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int maxHealth;
    [Tooltip("Number of frames that the player is invincible after being hit")]
    [SerializeField] private int iFrames;
    private int iFramesLeft = 0;
    private int currentHealth;
    private HudController hud;

    void Start() {
        currentHealth = maxHealth;
        hud = transform.Find("Hud").gameObject.GetComponent<HudController>();
        hud.SetMaxHealth(maxHealth);
        hud.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage) {
        if (iFramesLeft <= 0) {
            currentHealth -= damage;
            hud.SetHealth(currentHealth);
            iFramesLeft = iFrames;
        }

        if (currentHealth <= 0) {
            Debug.Log("Player is dead!");
        }
    }

    void Update() {
        if (iFramesLeft > 0)
            iFramesLeft--;
    }
}
