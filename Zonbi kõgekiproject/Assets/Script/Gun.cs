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
            
            ShootRaycast();
        }
    }

        void ShootRaycast() 
        {

            RaycastHit hitInfo;
            int Layer = LayerMask.GetMask("hittable");

            print("Valor de Layer" + Layer);
            print("Valor de fPScAM" + fpsCam);
            // print("Valor de Position" + fpsCam.transform.position);
            // print("Valor de Direction" + fpsCam.GetForwardDirection);

            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Mathf.Infinity, Layer))
            {
            print("ShotRayCast" + hitInfo);

            GameObject Vaso = GameObject.FindWithTag ("vazo");
            print("Vaso");

            Rigidbody rb = Vaso.transform.GetComponent<Rigidbody>();

            rb.AddForce(Vector3.Scale(fpsCam.transform.forward, new Vector3(50, 100, 50)));
            IShotHit hitted = hitInfo.transform.GetComponent<IShotHit>();
            if(hitted != null)
            {

                hitted.Hit(fpsCam.transform.forward);

            }
        }
    }  
}
