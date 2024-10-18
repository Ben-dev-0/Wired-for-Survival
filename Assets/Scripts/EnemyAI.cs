using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] patrolPoints;
    private int currentPoint = 0;

    public float detectionRadius = 5f;
    private Transform player;
    private bool isChasing = false;

    private bool isStunned = false;
    public float stunDuration = 3f;

    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        animator.SetBool("IsPatrolling", true);
    }

    void Update()
    {
        if (isStunned) return;

        if (isChasing)
        {
            ChasePlayer();

            if (Vector2.Distance(transform.position, player.position) > detectionRadius)
            {
                isChasing = false;
                animator.SetBool("IsChasing", false);
                animator.SetBool("IsPatrolling", true);
            }
        }
        else
        {
            Patrol();
            DetectPlayer();
        }
    }

    void Patrol()
    {
        animator.SetBool("IsPatrolling", true);
        animator.SetBool("IsChasing", false);

        Transform targetPoint = patrolPoints[currentPoint];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < detectionRadius)
        {
            isChasing = true;
            animator.SetBool("IsChasing", true);
            animator.SetBool("IsPatrolling", false);
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void StunEnemy()
    {
        StartCoroutine(Stunned());
    }

    IEnumerator Stunned()
    {
        isStunned = true;
        isChasing = false;
        animator.SetBool("IsStunned", true);
        animator.SetBool("IsChasing", false);
        animator.SetBool("IsPatrolling", false);

        yield return new WaitForSeconds(stunDuration);

        isStunned = false;
        animator.SetBool("IsStunned", false);

        animator.SetBool("IsPatrolling", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<HealthManager>().TakeDamage(1);
        }
    }
}
