using UnityEngine;

public class Victoria : MonoBehaviour
{
    public GameObject character; // Referencia al GameObject del personaje
    public Vector3 winPosition; // Posición a la que se moverá el personaje al ganar
    private bool hasKey = false; // Variable para rastrear si se tiene la llave

    private void OnColissionEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Key"
        if (collision.gameObject.CompareTag("Llave"))
        {
            Debug.Log("Has recogido la llave.");
            hasKey = true; // Marcar que se ha recogido la llave
    
        }

        // Verificar si el objeto que colisiona tiene la etiqueta "Door"
        if (collision.gameObject.CompareTag("Door"))
        { Debug.Log("puerta tocada");
            if (hasKey)
            {
                Debug.Log("¡Ganaste!");
                character.transform.position = winPosition; // Mover el personaje a la posición de victoria
            }
            else
            {
                Debug.Log("Necesitas la llave para abrir la puerta.");
            }
        }
    }
}
