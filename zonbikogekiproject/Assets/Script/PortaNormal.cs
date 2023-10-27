using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaNormal : MonoBehaviour
{
    public GameObject codigo;
    public Transform player;
    public Vector3 novaPosicao;

    private bool jogadorSobreTrigger = false;

    void Start()
    {
        codigo.SetActive(false);
    }

    void Update()
    {
        if (jogadorSobreTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                MoverJogadorParaNovaPosicao();
            }
        }
    }

    void MoverJogadorParaNovaPosicao()
    {
        player.position = novaPosicao;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            codigo.SetActive(true);
            jogadorSobreTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            codigo.SetActive(false);
            jogadorSobreTrigger = false;
        }
    }
}
