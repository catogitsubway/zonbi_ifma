using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IShotHit;

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
        rigidbody.AddForce(Vector3.Scale(direction, new Vector3(50, 100, 50)));
    }

}