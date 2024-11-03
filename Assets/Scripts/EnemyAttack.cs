using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] private int damage;
    [SerializeField] public float knockback;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}