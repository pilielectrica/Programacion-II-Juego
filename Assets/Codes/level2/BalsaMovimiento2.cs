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
    private Transform jugadorEncima = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        // Guardamos posición inicial y destino
        puntoInicial = rb.position;
        puntoDestino = puntoInicial + Vector2.up * distancia;

        // Desactivamos solo el script de movimiento
        this.enabled = false;
    }

    void FixedUpdate()
    {
        Vector2 objetivo = subiendo ? puntoDestino : puntoInicial;
        Vector2 nuevaPos = Vector2.MoveTowards(rb.position, objetivo, velocidad * Time.fixedDeltaTime);
        Vector2 delta = nuevaPos - rb.position;

        rb.MovePosition(nuevaPos);

        if (jugadorEncima != null)
            jugadorEncima.position += (Vector3)delta;

        if (Vector2.Distance(rb.position, objetivo) < 0.05f)
            subiendo = !subiendo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            jugadorEncima = other.transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && jugadorEncima == other.transform)
            jugadorEncima = null;
    }

    // Método público para activar el movimiento desde un evento
    public void ActivarMovimiento()
    {
        this.enabled = true;
    }
}
