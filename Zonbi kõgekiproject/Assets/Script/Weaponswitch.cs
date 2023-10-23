using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponswitch : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject Rifle;

    public bool PistolB;
    public bool RifleB;
    void Start()
    {
        Rifle.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !RifleB)
        {
            Rifle.SetActive(true);
            Pistol.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2) && !PistolB)
        {
            Rifle.SetActive(false);
            Pistol.SetActive(true);
        }
    }
}
