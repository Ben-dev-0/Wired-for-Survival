using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StunProjectile : MonoBehaviour {
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lifetime = 0.3f;
    private float timeLeft;
    private Vector3 moveVector;

    void Start() {
        float rotation = transform.rotation.eulerAngles.z * (float)(Math.PI / 180d);
        moveVector = new Vector3((float)Math.Cos(rotation),(float)Math.Sin(rotation),0) * speed;
        timeLeft = lifetime;
    }

    void Update() {
        transform.position += moveVector * Time.deltaTime;
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy")) {
            collision.GetComponent<EnemyAI>().StunEnemy();
        }
        else if (collision.CompareTag("ElectricTrap")) {
            //collision.GetComponent<ElectricTrap>().ActivateTrap();
        }
        else if (collision.CompareTag("Player")) {
            return;
        }
        Destroy(gameObject);
    }
}
