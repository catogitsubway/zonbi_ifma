using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 20;
    public float damageAmount = 20;
    public float impactForce = 30;

    Animator animator;

    Transform shotSpawn;
    Transform shellSpawn;

    GameObject fpsCam;

    string gunName = ("Pistol");
    public ParticleSystem muzzeFlash;


    private void Awake()
    {
        animator = transform.Find(gunName).GetComponent<Animator>();

        fpsCam = GameObject.FindWithTag("Weapon");

        shotSpawn = transform.Find("shotSpawn");
        shellSpawn = transform.Find("shellSpawn");
    }


    void Update()
    {

    
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("fire", -1, 0);
            Fire();
        }
    }
    
    private void Fire()
    {
        muzzeFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Inimigo e = hit.transform.GetComponent<Inimigo>();
            if(e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }
}