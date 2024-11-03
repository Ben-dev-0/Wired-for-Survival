using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    private Animator animator;
    
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        direction.Normalize();
        rb.velocity = direction * moveSpeed;
        animator.SetFloat("xMovement", direction.x);
        animator.SetFloat("yMovement", direction.y);
        Debug.Log(direction);
    }
}
