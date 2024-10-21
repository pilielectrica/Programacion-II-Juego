using UnityEngine;

public class Hada : MonoBehaviour
{
    public AudioSource HadaRecolectadaAudioSource;
    public AudioClip hadaAudioClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Llama al método CollectFairy() del contador
            FindObjectOfType<ContadorDeHadas>().CollectFairy();
            
            // Crear un objeto temporal solo para el sonido
            GameObject audioObject = new GameObject("FairySound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = hadaAudioClip;
            audioSource.Play();
            
            // Destruir el objeto de sonido después de que termine la reproducción
            Destroy(audioObject, hadaAudioClip.length);
            
            // Destruir el objeto hada inmediatamente
            Destroy(gameObject);
        }
    }
}

