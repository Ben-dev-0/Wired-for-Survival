using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour {
    private Animator animator;
    [SerializeField] private bool startLocked;
    private bool isLocked;
    private BoxCollider2D boxCollider;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        setLocked(startLocked);
    }

    public void setLocked(bool isLocked) {
        this.isLocked = isLocked;
        animator.SetBool("Locked", isLocked);
        animator.SetTrigger("Close");
        boxCollider.isTrigger = !isLocked;
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        if (!isLocked && (collision.CompareTag("Player") || collision.CompareTag("Enemy"))) {
            animator.SetTrigger("Open");
        }
    }

    public void OnTriggerExit2D(Collider2D collision) {
        if (!isLocked && (collision.CompareTag("Player") || collision.CompareTag("Enemy"))) {
            animator.SetTrigger("Close");
        }
    }
}
