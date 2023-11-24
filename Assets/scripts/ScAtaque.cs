using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScAtaque : MonoBehaviour
{
    [SerializeField] private Transform CAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float fuerzagolpe;
    private Animator animator;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(CAtaque.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                Enemigo enemigo = colisionador.transform.GetComponent<Enemigo>();
                if (enemigo != null)
                {
                    enemigo.Tomardano(fuerzagolpe);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CAtaque.position, radioGolpe);
    }
}
