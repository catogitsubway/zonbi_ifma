using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public GameObject mensagemAtirar;
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
        mensagemAtirar.SetActive(true);
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
