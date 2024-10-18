using UnityEngine;

public class StunProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyAI>().StunEnemy();
        }
        else if (collision.CompareTag("ElectricTrap"))
        {
            collision.GetComponent<ElectricTrap>().ActivateTrap();
        }

        Destroy(gameObject);
    }
}
