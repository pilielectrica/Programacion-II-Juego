using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float velocidad = 5f;

    [Header("Detección")]
    [SerializeField] private Transform jugador;
    [SerializeField] private float rangoDeteccion = 5f; // distancia a la que el enemigo empieza a seguir

    private Rigidbody2D miRigidbody2D;
    private Vector2 direccion;

    private void Awake()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Calcular distancia al jugador
        float distancia = Vector2.Distance(transform.position, jugador.position);

        if (distancia <= rangoDeteccion)
        {
            // Solo moverse si está dentro del rango
            direccion = (jugador.position - transform.position).normalized;
            miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
        }
    }

    // Opcional: dibujar el rango de detección en el editor
    private void OnDrawGizmosSelected()
    {
        if (jugador != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }
    }
}
