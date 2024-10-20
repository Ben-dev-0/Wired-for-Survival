using System;
using System.Collections;
using UnityEngine;

public class StunGun : MonoBehaviour {
    [SerializeField] private GameObject stunProjectile;
    [SerializeField] private int maxAmmo = 5;
    [SerializeField] private float cooldownTime = 2f;
    private bool isCoolingDown = false;
    private int currentAmmo;

    void Start() {
        currentAmmo = maxAmmo;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isCoolingDown) {
            Shoot();
        }
    }

    void Shoot() {
        Vector3 mouseWorldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldpos.z = 0f;
        Vector3 vectToMouse = mouseWorldpos - transform.position;
        float shootRotation = (float)(Math.Acos(vectToMouse.x/vectToMouse.magnitude) * (180d/Math.PI));
        if (mouseWorldpos.y < transform.position.y) {
            shootRotation *= -1f;
        }

        Instantiate(stunProjectile, transform.position, Quaternion.Euler(new Vector3(0, 0, shootRotation)));
        currentAmmo--;

        if (currentAmmo <= 0) {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownTime);
        currentAmmo = maxAmmo;
        isCoolingDown = false;
    }
}
