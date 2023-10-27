using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject zombies;
    public GameObject mensagem;
    public Transform player;
    public Vector3 novaPosicao;

    private bool jogadorSobreTrigger = false;

    void Start()
    {
        mensagem.SetActive(false);
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
        zombies.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensagem.SetActive(true);
            jogadorSobreTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensagem.SetActive(false);
            jogadorSobreTrigger = false;
        }
    }
}
