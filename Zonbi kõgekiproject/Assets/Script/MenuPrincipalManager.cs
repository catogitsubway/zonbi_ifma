using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]private string NomeDoLevelDoJogo;
    [SerializeField]private GameObject painelMenuInicial;
    [SerializeField]private GameObject painelOpcoes;
    [SerializeField]private GameObject painelCreditos;
    [SerializeField]private GameObject esc;


    public void Iniciar()
    {
        SceneManager.LoadScene(NomeDoLevelDoJogo);
    }

    public void AbrirOpcoes()
    {
        esc.SetActive(false);
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        esc.SetActive(true);
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void AbrirCreditos()
    {
        painelOpcoes.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelCreditos.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SairJogo();
        }
    }

    public void SairJogo()
    {
        Debug.Log("VAZOU");
        Application.Quit();
    }
}
