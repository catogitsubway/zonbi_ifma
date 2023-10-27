using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaRecepcao : MonoBehaviour
{
    public GameObject AcheChave;
    public GameObject mensagemPortaTrancada;
    public GameObject mensagemPorta;
    public Transform player;
    public Vector3 novaPosicao;

    private bool jogadorSobreTrigger = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorSobreTrigger = true;

            if (PlayerChave.peguei == true)
            {
                mensagemPorta.SetActive(true);
                AcheChave.SetActive(false);
            }
            else
            {
                mensagemPortaTrancada.SetActive(true);
                AcheChave.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorSobreTrigger = false;
            mensagemPorta.SetActive(false);
            mensagemPortaTrancada.SetActive(false);
            AcheChave.SetActive(true);

            if(AcheChave == true)
            {
                Destroy(AcheChave, 3.0f);
            }
        }

    }

    void Update()
    {
        if (jogadorSobreTrigger && Input.GetKeyDown(KeyCode.E) && PlayerChave.peguei)
        {
            MoverJogadorParaNovaPosicao();
        }
    }

    void MoverJogadorParaNovaPosicao()
    {
        player.position = novaPosicao;
    }
}


