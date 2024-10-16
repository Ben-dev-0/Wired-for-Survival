using System.Collections;
using UnityEngine;

public class StunGun : MonoBehaviour
{
    public GameObject stunProjectile;
    public Transform firePoint;
    public int maxAmmo = 5;
    private int currentAmmo;
    public float cooldownTime = 2f;
    private bool isCoolingDown = false;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && !isCoolingDown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(stunProjectile, firePoint.position, firePoint.rotation);
        currentAmmo--;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownTime);
        currentAmmo = maxAmmo;
        isCoolingDown = false;
    }
}
