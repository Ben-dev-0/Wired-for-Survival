using System.Collections;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    public GameObject[] enemiesInRange;

    public void ActivateTrap()
    {
        foreach (GameObject enemy in enemiesInRange)
        {
            if (enemy != null)
            {
                enemy.GetComponent<EnemyAI>().StunEnemy();
            }
        }

        StartCoroutine(TrapEffect());
    }

    IEnumerator TrapEffect()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("StunProjectile"))
        {
            ActivateTrap();
            Destroy(other.gameObject); 
        }
    }
}
