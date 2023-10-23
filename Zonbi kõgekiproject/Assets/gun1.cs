using UnityEngine;

public class gun1 : MonoBehaviour
{

    public float range = 20;
    public float fireRate = 15f;
    public float damageAmount = 20;
    public float impactForce = 30;

    Animator animator;

    Transform shotSpawn;
    Transform shellSpawn;

    public Camera fpsCam;
    public ParticleSystem muzzeFlash;
    private float nextTimeToFire = 0f;

    void Update()
    {

    
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }
    
    private void Fire()
    {
        muzzeFlash.Play();
        animator.Play("Fire", -1, 0);

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
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
