using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaMunicao : MonoBehaviour
{
    public int ammo;
    public int municoesRecarregar; // Número de munições a serem recarregadas
    private Gun gunScript; // Referência ao script Gun (será definido automaticamente)
    public GameObject voltar;
    public GameObject mesagem;
    public GameObject trigger;

    void Start()
    {
        // Automaticamente encontre e atribua o componente Gun no jogador.
        gunScript = FindObjectOfType<Gun>();
        if (gunScript == null)
        {
            Debug.LogError("Gun script não encontrado no jogador.");
        }
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, gunScript.transform.position) < 1.5)
        {
            mesagem.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F) && ammo > 0)
            {
                trigger.SetActive(true);
                gunScript.AddAmmo(municoesRecarregar); // Adicione o número definido de munições ao totalAmmo
                ammo -= municoesRecarregar; // Remova a munição da caixa
                // Destrua o objeto da caixa de munição ou desative-o, se necessário.
                // Por exemplo: Destroy(gameObject);
            }
        }
        else
        {
            mesagem.SetActive(false);
        }
        if(mesagem == false)
        {
            voltar.SetActive(true);
            if(voltar == true)
            {
                Destroy(voltar, 3.0f);
            }
        }
    }
}




