using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;

    public void OnRayCastHit(Gun gun)
    {
        health.TakeDamage(gun.damage);
    }
}
