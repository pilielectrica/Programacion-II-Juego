using UnityEngine;

public abstract class Proyectil : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 30f)]
    protected float speed = 10f;

    protected Rigidbody2D rb;
    protected SpriteRenderer sr; // Para ocultar/mostrar el sprite

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (sr != null)
            sr.enabled = false; // ocultar sprite al inicio
    }

    private void OnEnable()
    {
        if (sr != null)
            sr.enabled = true; // mostrar sprite al disparar

        Mover();
    }

    private void OnDisable()
    {
        // Cuando vuelva al pool, ocultar sprite y resetear velocidad
        if (sr != null) sr.enabled = false;
        if (rb != null) rb.velocity = Vector2.zero;
    }

    protected abstract void Mover();

    // 🔹 Método de colisión
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            // Buscar el componente de vida del enemigo
            EnemigoVida vida = other.GetComponent<EnemigoVida>();
            if (vida != null)
            {
                vida.RecibirDaño(1); // cada proyectil resta 1 de vida
            }

            // Desactivar proyectil al impactar
            gameObject.SetActive(false);
        }
        
    }
}
