using UnityEngine;

public class StunProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        // Destroy the projectile after a certain time to prevent memory leaks
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with enemies or environment
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().StunEnemy();
        }
        else if (collision.CompareTag("ElectricTrap"))
        {
            collision.GetComponent<ElectricTrap>().ActivateTrap();
        }

        // Destroy the projectile after impact
        Destroy(gameObject);
    }
}
