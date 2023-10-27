using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganhou : MonoBehaviour
{
    public string proximaFase;
    public GameObject final;
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            final.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(proximaFase);
            }
        }
        else
        {
            final.SetActive(false);
        }
    }
}
