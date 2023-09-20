using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Inimigo inimigo;

    public void OnRayCastHit(Gun gun)
    {
        inimigo.TakeDamage(gun.damage);
    }
}
