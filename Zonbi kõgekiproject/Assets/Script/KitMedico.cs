using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitMedico : MonoBehaviour
{
    public int vida = 10;
    public int vidaRecarregar = 10;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        if(playerController == null)
        {
            Debug.LogError("PlayerController script não encontrado no jogador.");
        }
    }

    void Update()
    {

        if (Vector3.Distance(transform.position, playerController.transform.position) < 1.5)
        {
            if (Input.GetKeyDown(KeyCode.F) && vida > 0)
            {
                playerController.AddVida(vidaRecarregar); 
                vida -= vidaRecarregar;
            }
        }
    }
}


