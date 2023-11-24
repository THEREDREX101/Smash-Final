using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public float CantidadDaño;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent("Player") && other.GetComponent<BarraVida>())
        {
            other.GetComponent<BarraVida>().RecibirDaño(CantidadDaño);
        }
    }
}
