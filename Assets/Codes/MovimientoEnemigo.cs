using System.Collections;
using UnityEngine;

public class MovimientoEnemigoPorWaypoints : MonoBehaviour
{
    [Header("Waypoints y velocidad")]
    public Transform[] waypoints;
    public float speed = 2f;
    public float pausaEntreWaypoints = 0.1f;

    private int currentWaypoint = 0;
    private Animator animator;
    private bool esperando = false;

    [Header("Triggers de animación por waypoint")]
    public string[] triggersPorWaypoint; // ej: "WalkRight", "WalkUp", "WalkLeft", "WalkDown"

    void Start()
    {
        animator = GetComponent<Animator>();

        if (waypoints.Length == 0)
        {
            Debug.LogWarning("No hay waypoints asignados.");
            enabled = false;
            return;
        }

        if (triggersPorWaypoint.Length != waypoints.Length)
        {
            Debug.LogWarning("Debes asignar un trigger por cada waypoint.");
            enabled = false;
            return;
        }

        // Comenzar en el waypoint más cercano
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < waypoints.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, waypoints[i].position);
            if (dist < minDistance)
            {
                minDistance = dist;
                currentWaypoint = i;
            }
        }

        // Iniciar animación del primer waypoint
        animator.SetTrigger(triggersPorWaypoint[currentWaypoint]);
    }

    void Update()
    {
        if (waypoints.Length == 0 || esperando) return;

        Transform target = waypoints[currentWaypoint];
        Vector3 delta = target.position - transform.position;

        if (delta.magnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (delta.magnitude < 0.05f)
        {
            StartCoroutine(PasarAlSiguienteWaypoint());
        }
    }

    IEnumerator PasarAlSiguienteWaypoint()
    {
        esperando = true;

        // Pausar animación en un frame
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        float pausedFrameTime = 0.25f; // segundo frame aproximado
        animator.speed = 0f;           // pausa la animación
        animator.Play(state.fullPathHash, 0, pausedFrameTime);

        // Espera la pausa
        yield return new WaitForSeconds(pausaEntreWaypoints);

        // Continuar animación
        animator.speed = 1f;

        // Pasar al siguiente waypoint
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
            currentWaypoint = 0;

        // Activar trigger del waypoint siguiente
        animator.SetTrigger(triggersPorWaypoint[currentWaypoint]);

        esperando = false;
    }
}
