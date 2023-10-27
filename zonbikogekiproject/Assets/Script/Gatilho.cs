using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gatilho : MonoBehaviour
{
    [SerializeField]private UnityEvent OnEnter;

    private void OnTriggerEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnEnter.Invoke();
        }
    }
}

