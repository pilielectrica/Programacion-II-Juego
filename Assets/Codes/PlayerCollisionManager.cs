using UnityEngine;

public class PlayerCollisionAgua : MonoBehaviour
{
    [SerializeField] private Collider2D colliderAgua;
    private Collider2D jugadorCollider;
    private int balsasEncima = 0;

    void Awake()
    {
        jugadorCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balsa"))
        {
            balsasEncima++;
            Physics2D.IgnoreCollision(jugadorCollider, colliderAgua, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Balsa"))
        {
            balsasEncima--;
            if (balsasEncima <= 0)
            {
                balsasEncima = 0;
                Physics2D.IgnoreCollision(jugadorCollider, colliderAgua, false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Agua") && balsasEncima == 0)
        {
            // Volver al punto inicial
            transform.position = Vector3.zero; // O la posición inicial que tengas
        }
    }
}
