using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float stunDuration = 3f;
    private Rigidbody2D rb;
    private int currentPoint = 0;
    private Transform playerPos;
    private bool isChasing = false;
    private bool isStunned = false;

    void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (isStunned) return;
        if (isChasing) {
            ChasePlayer();
            if (Vector2.Distance(transform.position, playerPos.position) > detectionRadius) {
                isChasing = false;
            }
        }
        else {
            Patrol();
            DetectPlayer();
        }
    }

    void Patrol() {
        Transform targetPoint = patrolPoints[currentPoint];
        Vector3 direction = (targetPoint.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f) {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer() {
        if (Vector2.Distance(transform.position, playerPos.position) < detectionRadius) {
            isChasing = true;
        }
    }

    void ChasePlayer() {
        Vector3 direction = (playerPos.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    public void StunEnemy() {
        StartCoroutine(Stunned());
    }

    IEnumerator Stunned() {
        isStunned = true;
        isChasing = false;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
    }
}
