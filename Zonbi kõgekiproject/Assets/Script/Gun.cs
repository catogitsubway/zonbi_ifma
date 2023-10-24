using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Munição")]
    public float ammo;
    public float totalAmmo;

    [Header("Distancia, Força e Dano")]
    public float range;
    public float impactForce;
    public float damageAmount;

    [Header("Tempo de Disparo")]
    public float nextShoot;
    public float shootTime;

    [Header("Número de Balas no pente")]
    public float num;
    public float magazine;


    [Header("Tempo de recarregamento")]
    public float reloadTime;
    public float maxTime;
    
    [Header("Contador de Munição e Balas")]
    public TextMeshProUGUI ammoText; 
    public TextMeshProUGUI totalammoText;

    public AudioSource FireSound;

    public bool shoot;
    public bool isReloading;

    Animator anim;

    public GameObject MuzzeFlash;
    public GameObject MuzzeLight;

    void Start()
    {
        reloadTime = maxTime;
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        ammoText.text = "" + ammo;
        totalammoText.text = "" + totalAmmo;

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
            anim.Play("ReloadRifle");
            anim.Play("ReloadPistol");
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
            anim.Play("FireRifle");
            anim.Play("FirePistol");
            FireSound.Play();

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
