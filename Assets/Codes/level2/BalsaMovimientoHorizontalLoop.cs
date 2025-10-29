using UnityEngine;

public class BalsaMovimientoHorizontalLoop : MonoBehaviour
{
    [Header("Movimiento horizontal")]
    public float distancia = 3f;    // Distancia total a recorrer
    public float velocidad = 2f;    // Velocidad del movimiento

    private Vector2 puntoInicial;
    private Vector2 puntoDestino;
    private bool moviendoDerecha = true;

    private Rigidbody2D rb;
    private Transform jugadorEncima = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // Guardamos posición inicial y destino horizontal
        puntoInicial = rb.position;
        puntoDestino = puntoInicial + Vector2.right * distancia;
    }

    void FixedUpdate()
    {
        Vector2 objetivo = moviendoDerecha ? puntoDestino : puntoInicial;
        Vector2 nuevaPos = Vector2.MoveTowards(rb.position, objetivo, velocidad * Time.fixedDeltaTime);
        Vector2 delta = nuevaPos - rb.position;

        rb.MovePosition(nuevaPos);

        // Mover al jugador solo si no tiene input
        if (jugadorEncima != null)
        {
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                jugadorEncima.position += (Vector3)delta;
            }
        }

        if (Vector2.Distance(rb.position, objetivo) < 0.05f)
            moviendoDerecha = !moviendoDerecha;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = other.transform;

            // Posición inicial del jugador sobre la balsa
            Vector3 puntoJugador = new Vector3(0, 0.5f, 0); // ajustar según sprite
            jugadorEncima.position = transform.position + puntoJugador;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && jugadorEncima == other.transform)
        {
            jugadorEncima = null;
        }
    }

    public void ActivarMovimiento()
    {
        this.enabled = true;
    }
}
