using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
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

        if (animator != null) {
            animator.SetFloat("MoveX", direction.x);
            animator.SetFloat("MoveY", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);

            if (direction != Vector2.zero) {
                animator.SetFloat("LastMoveX", direction.x);
                animator.SetFloat("LastMoveY", direction.y);
            }
        }
    }
}
