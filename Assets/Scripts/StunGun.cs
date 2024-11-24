using System;
using System.Collections;
using UnityEngine;

public class StunGun : MonoBehaviour {
    [SerializeField] private GameObject stunProjectile;
    [SerializeField] private int maxAmmo = 5;
    [SerializeField] private float cooldownTime = 2f;
    private bool isCoolingDown = false;
    private int currentAmmo;
    private HudController hud;

    private PauseMenu pauseScript;
    void Start() {
        currentAmmo = maxAmmo;
        hud = transform.Find("Hud").gameObject.GetComponent<HudController>();
        hud.SetMaxAmmo(maxAmmo);

        pauseScript = PauseMenu.Instance;
        if (pauseScript == null)
        {
            Debug.LogError("PauseMenu instance not found! Make sure the PauseMenu script is in the scene.");
        }
    }

    void Update() {
        if (isCoolingDown) {
            hud.IncrementAmmo(Time.deltaTime * (maxAmmo/cooldownTime));
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentAmmo > 0 && !isCoolingDown && !pauseScript.IsPaused() ) {
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
        hud.SetAmmo(currentAmmo);

        if (currentAmmo <= 0) {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown() {
        isCoolingDown = true;
        hud.SetAmmoCooldownColor(true);
        yield return new WaitForSeconds(cooldownTime);
        currentAmmo = maxAmmo;
        hud.SetAmmo(currentAmmo);
        hud.SetAmmoCooldownColor(false);
        isCoolingDown = false;
    }
}
