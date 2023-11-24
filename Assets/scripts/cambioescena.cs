using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambioescena : MonoBehaviour
{
    public int NumScena;

    public void camBiarScena()
    {
        SceneManager.LoadScene(NumScena);
    }

    public void salir()
    {
        Application.Quit();
        Debug.Log("Juego Finalizado");
    }



}
