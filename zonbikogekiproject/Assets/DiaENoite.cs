using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaENoite : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.Play("Diaenoite");
    }
}
