using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float moveSpeed;

    void Start() {
        
    }

    void Update() {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
    }
}
