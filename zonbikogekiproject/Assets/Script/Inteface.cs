using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    [SerializeField]private GameObject mira;
    private bool isPaused;

    public GameObject pausePanel;
    public string cena;
    void Start()
    {
        Time.timeScale = 1f;
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
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            mira.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            mira.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(cena);
    }

}

