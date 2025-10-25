using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] private GeneradorProyectiles generadorProyectiles;
    [SerializeField] private Transform puntoDisparo;

    [Header("Offset al flip")]
    [SerializeField] private float offsetX = 1; // cuánto se mueve el punto al flip

    private Vector2 direccionActual = Vector2.right; // por defecto a la derecha
    private Vector3 posicionBase; // posición original del punto de disparo

    private void Awake()
    {
        if (puntoDisparo != null)
            posicionBase = puntoDisparo.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puntoDisparo != null)
            {
                // Mover el punto según la dirección
                Vector3 nuevaPos = posicionBase;
                nuevaPos.x += direccionActual.x > 0 ? offsetX : -offsetX;
                puntoDisparo.localPosition = nuevaPos;
            }

            generadorProyectiles.Disparar(direccionActual, puntoDisparo.position);
        }
    }

    // Llamado desde el jugador cuando cambia dirección
    public void CambiarDireccion(bool mirandoDerecha)
    {
        direccionActual = mirandoDerecha ? Vector2.right : Vector2.left;
    }
}
