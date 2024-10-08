using UnityEngine;

public class Hada : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si el jugador colisiona con el hada
        if (other.CompareTag("Player"))
        {
            // Llama al método CollectFairy() del contador
            FindObjectOfType<ContadorDeHadas>().CollectFairy();
            
            // Destruye el hada o realiza alguna acción
            Destroy(gameObject);
        }
    }
}
