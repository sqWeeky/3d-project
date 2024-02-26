using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;

    public float fireRate = 0.5f;
    public int maxAmmo = 30;
    public float reloadTime = 2f;

    private int currentAmmo;
    private float nextFireTime;
    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    public void Shoot()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            currentAmmo--;

            GameObject bullet = ObjectPool.Instance.GetBulletFromPool().gameObject;

            bullet.transform.parent = null;
            bullet.transform.position = firePoint.position;

            var mousePosition = Vector3.zero;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                mousePosition = raycastHit.point;
            }

            mousePosition.y = 1;

            Vector3 direction = (mousePosition - firePoint.position).normalized;

            bullet.GetComponent<Rigidbody>().velocity = direction * bullet.GetComponent<Bullet>().Speed;
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
