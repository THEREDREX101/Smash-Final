using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLadron : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;

    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavidadDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true;

    [Header("Salto")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;  // Capa que representa el suelo
    [SerializeField] private Transform controlSuelo;  // Objeto que verifica si el personaje está en el suelo
    [SerializeField] private Vector3 dimensionCaja;  // Dimensiones del área de detección de suelo
    [SerializeField] private bool enSuelo;  // Indica si el personaje está en el suelo
    private bool salto = false;  // Indica si se debe realizar un salto

    [Header("Animacion")]
    private Animator animator;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();  // Obtener el componente Rigidbody2D al inicio
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;  // Obtener la entrada horizontal del teclado
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        if (Input.GetButtonDown("Jump"))
        {
            salto = true;  // Marcar que se debe realizar un salto al presionar el botón de salto
        }
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapBox(controlSuelo.position, dimensionCaja, 0f, queEsSuelo);
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);  // Llamar al método Mover con los parámetros de movimiento y salto
    }

    private void Mover(float mover, bool saltar)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2D.velocity.y);
        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocidadObjetivo, ref velocidad, suavidadDeMovimiento);

        if ((mover > 0 && !mirandoDerecha) || (mover < 0 && mirandoDerecha))
        {
            Girar();  // Girar el personaje si está moviéndose en la dirección opuesta a su orientación actual
        }

        if (enSuelo && saltar)
        {
            enSuelo = false;
            rb2D.AddForce(new Vector2(0f, fuerzaSalto));  // Aplicar fuerza vertical para realizar un salto
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;  // Invertir la orientación del personaje
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;  // Aplicar la inversión en la escala para girar el personaje
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controlSuelo.position, dimensionCaja);  // Dibujar un cubo alrededor del área de detección de suelo
    }
}
