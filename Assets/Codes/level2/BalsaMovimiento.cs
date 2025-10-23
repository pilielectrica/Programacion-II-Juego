using UnityEngine;

public class BalsaMovimiento : MonoBehaviour
{
    [Header("Movimiento vertical")]
    public float distancia = 3f;
    public float velocidad = 2f;

    private Vector2 puntoInicial;
    private Vector2 puntoDestino;
    private bool movimientoActivo = true;

    private Rigidbody2D rb;

    private Transform jugadorEncima = null;
    private Vector3 offsetJugador;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        puntoInicial = rb.position;
        puntoDestino = puntoInicial + Vector2.up * distancia;
    }

    void FixedUpdate()
    {
        if (!movimientoActivo) return;

        // Mover la balsa
        Vector2 nuevaPos = Vector2.MoveTowards(rb.position, puntoDestino, velocidad * Time.fixedDeltaTime);

        // Calcular delta de movimiento
        Vector2 delta = nuevaPos - rb.position;
        rb.MovePosition(nuevaPos);

        // Mover manualmente al jugador si está encima
        if (jugadorEncima != null)
        {
            jugadorEncima.position += (Vector3)delta;
        }

        // Si llegó al destino, detener movimiento
        if (Vector2.Distance(rb.position, puntoDestino) < 0.05f)
        {
            movimientoActivo = false;
            jugadorEncima = null; // jugador ya no sigue
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        jugadorEncima = other.transform;        // <- usar transform
        offsetJugador = other.transform.position - transform.position; // <- también transform
    }
}

private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        if (jugadorEncima == other.transform)  // <- usar transform
        {
            jugadorEncima = null;
        }
    }
}

}
