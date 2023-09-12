using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    Animator animator;

    Transform shotSpawn;
    Transform shellSpawn;

    PlayerController fpsCam;


    private void Awake()
    {
        animator = transform.Find("Pistol").GetComponent<Animator>();

        fpsCam = transform.GetComponent<PlayerController>();
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
            
            ShootRaycast();
        }
    }

        void ShootRaycast() 
        {

            RaycastHit hitInfo;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.GetForwardDirection(), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable"))) {

            IShotHit hitted = hitInfo.transform.GetComponent<IShotHit>();
            if(hitted != null) {

                hitted.Hit(fpsCam.GetForwardDirection());

            }
        }
    }  
}
