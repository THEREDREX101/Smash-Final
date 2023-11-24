using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{


    public float vidaActual = 100;

    public float vidaMaxima = 100;

    [Header("Interfaz")]
    public Image barraDeVida;

    [Header("Muerto")]
    public GameObject Muerto;


    void Update()
    {

        ActualizarInterfaz();

    }

    public void RecibirDaño(float daño)
    {
        vidaActual -= daño;

        if(vidaActual <= 0)
        {
            Instantiate(Muerto);
            Destroy(gameObject);
        }
    }

    void ActualizarInterfaz()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }
}
