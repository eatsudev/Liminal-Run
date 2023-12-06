using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public int maxAmmo = 3;
    public float reloadTime = 1f;

    private int currentAmmo;
    private bool isReloading = false;
    [SerializeField] private AudioSource shootSound;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1")) // mouse 0
        {
            GameObject newProjectileObj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            Projectile newProjectile = newProjectileObj.GetComponent<Projectile>();

            
            Vector3 playerScale = transform.localScale;
            newProjectile.SetDirection(playerScale.x > 0 ? Vector3.right : Vector3.left);
            shootSound.Play();

            
            currentAmmo--;
        }
    }


    private IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
