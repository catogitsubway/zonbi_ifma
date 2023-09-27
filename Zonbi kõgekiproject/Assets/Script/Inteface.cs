using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    private bool isPaused;

    public GameObject pausePanel;
    public string cena;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen();
        }
    }

    void pauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = true;
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}

