using System;
using System.Text;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class PlayerKnockback : MonoBehaviour {
    [SerializeField] float deceleration;
    [Tooltip("Number of frames until the player is pushed out while continuously colliding with an enemy." +
    " The frame count is reset after the player is pushed or the player stops colliding with an enemy.")]
    [SerializeField] int unstuckFrames;
    private Vector3 knockbackDirection;
    private float knockbackMagnitude;
    private int enemyCollidedWithFrames = 0;
    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (knockbackMagnitude > 0) {
            rb.AddForce(knockbackMagnitude * knockbackDirection * Time.deltaTime);
            knockbackMagnitude -= deceleration * Time.deltaTime;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            knockbackMagnitude = collision.gameObject.GetComponent<EnemyAttack>().knockback;
            Vector3 knockbackSource = collision.gameObject.transform.position;
            knockbackDirection = (gameObject.transform.position - knockbackSource).normalized;
        }
    }

    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyCollidedWithFrames++;

            if (enemyCollidedWithFrames >= unstuckFrames) {
                double randAngle = UnityEngine.Random.Range(0, (float)(2 * Math.PI));
                knockbackMagnitude = collision.gameObject.GetComponent<EnemyAttack>().knockback;
                knockbackDirection = new Vector3((float)Math.Cos(randAngle), (float)Math.Sin(randAngle), 0);
                enemyCollidedWithFrames = 0;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            enemyCollidedWithFrames = 0;
        }
    }
}