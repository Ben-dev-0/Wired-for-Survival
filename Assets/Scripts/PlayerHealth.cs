using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int maxHealth;
    private int currentHealth;
    private HudController hud;

    void Start() {
        currentHealth = maxHealth;
        hud = transform.Find("Hud").gameObject.GetComponent<HudController>();
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
        }
    }

    void Update() {
        
    }
}
