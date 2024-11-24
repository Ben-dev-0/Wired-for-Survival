using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRadius = 5f;
    [SerializeField] private float stunDuration = 3f;
    private int currentPoint = 0;
    private Transform playerPos;
    private NavMeshAgent agent;
    private bool isChasing = false;
    private bool isStunned = false;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        animator.SetBool("Moving", agent.velocity.magnitude > 0.01f);
        spriteRenderer.flipX = agent.velocity.x < 0f;

        if (isStunned) return;
        if (isChasing) {
            ChasePlayer();
            if (Vector2.Distance(transform.position, playerPos.position) > detectionRadius) {
                isChasing = false;
            }
        }
        else {
            if (patrolPoints.Length > 0)
                Patrol();
            DetectPlayer();
        }
    }

    void Patrol() {
        Transform targetPoint = patrolPoints[currentPoint];
        agent.SetDestination(targetPoint.position);

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
        agent.SetDestination(playerPos.position);
    }

    public void StunEnemy() {
        StartCoroutine(Stunned());
    }

    IEnumerator Stunned() {
        isStunned = true;
        isChasing = false;
        Vector3 destination = agent.destination;
        agent.SetDestination(gameObject.transform.position);
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;
        agent.SetDestination(destination);
    }
}
