using UnityEngine;

public class BalsaMovimientoLoop : MonoBehaviour
{
    [Header("Movimiento vertical")]
    public float distancia = 3f;
    public float velocidad = 2f;

    private Vector2 puntoInicial;
    private Vector2 puntoDestino;
    private bool subiendo = true;

    private Rigidbody2D rb;

    // Jugador encima
    private Transform jugadorEncima = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        puntoInicial = rb.position;
        puntoDestino = puntoInicial + Vector2.up * distancia;
    }

   void FixedUpdate()
{
    Vector2 objetivo = subiendo ? puntoDestino : puntoInicial;
    Vector2 nuevaPos = Vector2.MoveTowards(rb.position, objetivo, velocidad * Time.fixedDeltaTime);
    Vector2 delta = nuevaPos - rb.position;

    rb.MovePosition(nuevaPos);

    if (jugadorEncima != null)
    {
        // 🔹 Si no hay input del jugador, la balsa lo mueve
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            jugadorEncima.position += (Vector3)delta;
        }
    }

    if (Vector2.Distance(rb.position, objetivo) < 0.05f)
        subiendo = !subiendo;
}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEncima = other.transform;
            // Posicion inicial en la balsa
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
