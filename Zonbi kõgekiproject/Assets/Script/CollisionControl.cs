using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CollisionControl : MonoBehaviour
{

    private void OnCollisionEnter(Collision collison)
    {
        print("Landed on the" + collison.gameObject.name);  
    }

    private void OnCollisionStay(Collision collision)
    {
        print("Walking on the" + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Leaveving the" + collision.gameObject.name);
    }

}
