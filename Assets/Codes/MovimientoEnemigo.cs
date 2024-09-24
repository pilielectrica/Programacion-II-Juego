using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform[] waypoints;  // Define los puntos del recorrido
private int currentWaypoint = 0; // Índice del waypoint actual
public float speed = 2f; // Velocidad de movimiento
private Animator animator; // Referencia al Animator

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
        void Update()
    {
        if (waypoints.Length == 0) return; // Si no hay waypoints, salir

        // Mover al enemigo hacia el waypoint actual
        Transform target = waypoints[currentWaypoint];
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        // Llamar a la animación correcta basada en el waypoint
        SetAnimationForWaypoint();

        // Mover al enemigo hacia el waypoint
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Si el enemigo llegó al waypoint, pasar al siguiente
        if (distance < 0.1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0; // Reiniciar recorrido
            }
        }
    }

    // Cambiar animación según el waypoint actual
    void SetAnimationForWaypoint()
    {
        switch (currentWaypoint)
        {
            case 0:
                animator.SetTrigger("WalkUpEnemigo"); 
                break;
            case 1:
                animator.SetTrigger("WalkLeftEnemigo"); 
                break;
            case 2:
                animator.SetTrigger("WalkRightEnemigo"); 
                break;
            case 3:
                animator.SetTrigger("WalkDownEnemigo");
                break;
        }
    }
}
