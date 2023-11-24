using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScriptPausa : MonoBehaviour
{
    public GameObject GrupoPausa;
    public bool Pausa = false;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa == false)
            {
                GrupoPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }else if(Pausa == true) 
            {
                Resumir();
            }
        }
    }

    public void Resumir ()
    {
        GrupoPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void irMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    } 

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Juego Finalizado");
    }
}
