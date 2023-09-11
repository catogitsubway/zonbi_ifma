using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int bullets = 30;
    public int maxBullets = 30;
    public int ammo = 90;

    public float range = 90;
    public float timeToShoot = 0.1f;
    public float timeToReload = 3f;
    public float damage = 30;

    bool canShoot;
    bool reloading;
    float intialTimeToShoot;
    float intialTimeToReload;
    void Start()
    {
        intialTimeToShoot = timeToShoot;
        intialTimeToReload = timeToReload;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if(Physics.Raycast(ray, out hit, range))
            {
                
                if(hit.transform.tag == "inimigo")
                {
                    hit.transform.GetComponent<Inimigo>().Damage(amount: damage);   
                }

                if(hit.transform.tag == "cabecainimigo")
                {
                    hit.transform.GetComponent<Inimigo>().Damage(amount: 100);
                }    
            }
        }
    }
}
