using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasoScript : MonoBehaviour, IShotHit
{
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void IShotHit.Hit(Vector3 direction)
    {
        print("IShotHit");
        rigidbody.AddForce(Vector3.Scale(direction, new Vector3(900, 900, 900)));
    }

}