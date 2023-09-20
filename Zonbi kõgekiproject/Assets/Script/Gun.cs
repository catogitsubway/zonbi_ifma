using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Animator animator;

    Transform shotSpawn;
    Transform shellSpawn;

    GameObject fpsCam;

    string gunName = ("Pistol");
    public float damage = 10;

    private void Awake()
    {
        animator = transform.Find(gunName).GetComponent<Animator>();

        fpsCam = GameObject.FindWithTag("Weapon");

        shotSpawn = transform.Find("shotSpawn");
        shellSpawn = transform.Find("shellSpawn");
    }

    void Start()
    {
        
    }

    void Update()
    {

    
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("fire", -1, 0);
            
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit , 50))
            {
                Debug.Log("Está colidindo");
                Debug.DrawLine (transform.position, hit.point);
            }

        }
    
    }
    

        //ShootRaycast();
        /*void ShootRaycast() 
        {

            RaycastHit hitInfo;
            int Layer = LayerMask.GetMask("hittable");

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Mathf.Infinity, Layer))
            {
            
            GameObject Inimigo = GameObject.FindWithTag("inimigo");

            GameObject Vaso = GameObject.FindWithTag ("vazo");

            IShotHit hitted = hitInfo.transform.GetComponent<IShotHit>();
            if(hitted != null)
            {

                hitted.Hit(fpsCam.transform.forward);

            }
        }*/
    
}