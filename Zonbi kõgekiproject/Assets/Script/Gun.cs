using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float ammo;
    public float totalAmmo;
    public float range;
    public float impactForce;
    public float damageAmount;
    public float nextShoot;
    public float shootTime;
    public float num;
    public float magazine;
    public float reloadTime;
    public float maxTime;
    public bool shoot;
    public bool isReloading; // Nova variável para controlar o processo de recarga

    void Start()
    {
        reloadTime = maxTime;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && Time.time > nextShoot)
        {
            shoot = true;
            nextShoot = Time.time + shootTime;
            ammo--;
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R) && ammo < magazine && !isReloading) // Verifica se não está recarregando
        {
            StartReload();
        }

        if (isReloading)
        {
            Reload();
        }
    }

    void StartReload()
    {
        if (totalAmmo > 0)
        {
            isReloading = true;
        }
    }

    void Reload()
    {
        reloadTime -= Time.deltaTime;
        if (reloadTime <= 0)
        {
            float bulletsToReload = Mathf.Min(magazine - ammo, totalAmmo);
            ammo += bulletsToReload;
            totalAmmo -= bulletsToReload;
            isReloading = false;
            reloadTime = maxTime;
        }
    }

    void Fire()
    {
        if (shoot)
        {
            shoot = false;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                Inimigo e = hit.transform.GetComponent<Inimigo>();
                if (e != null)
                {
                    e.TakeDamage(damageAmount);
                    return;
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
            }
        }
    }
}
