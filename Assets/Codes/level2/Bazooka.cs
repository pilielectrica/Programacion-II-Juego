using UnityEngine;

public class Bazooka : MonoBehaviour
{


    private Vector2 direccionActual = Vector2.right; // por defecto a la derecha
    public bool _mirandoDerecha = false;

    // Llamado desde el jugador cuando cambia dirección
    public void CambiarDireccion(bool mirandoDerecha)
    {
        direccionActual = mirandoDerecha ? Vector2.right : Vector2.left;
        _mirandoDerecha = mirandoDerecha;
    }

    public void playAudioBazookaTaken()
    {
        AudioSource bazookaAudio = gameObject.GetComponent<AudioSource>();
        if (bazookaAudio != null) bazookaAudio.Play();
    }
}
