using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    RaycastHit hit;
    public float Distancia;
    public LayerMask LayerM;
    public bool Right;
    public float speed;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void OndrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right* Distancia);
    }

    // Update is called once per frame
    void Update()
    {
        if(Right)
        {
            ani.SetBool("idle", false);
            ani.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            ani.SetBool("idle", false);
            ani.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Physics2D.Raycast(transform.position, transform.right, Distancia, LayerM))
        {
            Right =! Right;
        }
    }
}
