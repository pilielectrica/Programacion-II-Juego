using UnityEngine;

public class InteractWithRopero : MonoBehaviour
{
    public GameObject character; // Referencia al GameObject del personaje
    public Vector3 moveAwayPosition; // Posición a la que el personaje se moverá
    private SpriteRenderer characterSpriteRenderer; // Referencia al SpriteRenderer del personaje
    private bool isInCollision = false; // Para rastrear si el personaje está en colisión con el Ropero
    private bool enelropero = false; // Para rastrear si el personaje está dentro del Ropero
    public Vector3 posicioninicial; // Posición inicial para devolver al personaje

    // Referencia al script de movimiento del personaje
    public Mover movementScript; // Cambia "MovementScript" por el nombre real de tu script de movimiento

    private void Start()
    {
        // Obtener el componente SpriteRenderer del personaje
        characterSpriteRenderer = character.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Ropero"
        if (collision.gameObject.CompareTag("Ropero"))
        {
            Debug.Log("colisionó con el Ropero");
            isInCollision = true; // Marcar que está en colisión
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Marcar que ya no está en colisión cuando sale de ella
        if (collision.gameObject.CompareTag("Ropero"))
        {
            Debug.Log("salió de la colisión con el Ropero");
            isInCollision = false; // Desmarcar colisión
        }
    }

    private void Update()
    {
        // Comprobar si está en colisión y se ha presionado "E"
        if (isInCollision && Input.GetKeyDown(KeyCode.E))
        {
            if (!enelropero)
            {
                Debug.Log("apretó E - entrar al ropero");
                MoveCharacterAway(); // Mover el personaje
                enelropero = true; // Marcar que está dentro del Ropero

                // Desactivar el movimiento
                if (movementScript != null)
                {
                    movementScript.enabled = false; // Desactivar el script de movimiento
                }
            }
            else
            {
                Debug.Log("apretó E - salir del ropero");
                ExitRopero(); // Salir del Ropero
            }
        }
    }

    private void MoveCharacterAway()
    {
        // Mover el personaje a la posición deseada
        character.transform.position = moveAwayPosition;

        // Desactivar el SpriteRenderer
        if (characterSpriteRenderer != null)
        {
            characterSpriteRenderer.enabled = false;
            Debug.Log("SpriteRenderer desactivado.");
        }
    }

    private void ExitRopero()
    {
        // Volver a la posición inicial
        character.transform.position = posicioninicial;

        // Activar el SpriteRenderer
        if (characterSpriteRenderer != null)
        {
            characterSpriteRenderer.enabled = true;
            Debug.Log("SpriteRenderer activado.");
        }

        // Reactivar el movimiento
        if (movementScript != null)
        {
            movementScript.enabled = true; // Reactivar el script de movimiento
        }

        enelropero = false; // Marcar que ha salido del Ropero
    }
}
