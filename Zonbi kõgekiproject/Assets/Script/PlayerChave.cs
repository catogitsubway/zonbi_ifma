using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChave : MonoBehaviour
{
    public static bool peguei = false;
    public GameObject chaveObjeto;
    public GameObject mensagemChave;

    void Update()
    {
        if (!peguei)
        {
            if (Vector3.Distance(transform.position, chaveObjeto.transform.position) < 1.5)
            {
                mensagemChave.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    peguei = true;
                    PegarChave();
                }
            }
            else
            {
                mensagemChave.SetActive(false);
            }
        }
    }

    void PegarChave()
    {
        Destroy(chaveObjeto);
        mensagemChave.SetActive(false);
    }
}
