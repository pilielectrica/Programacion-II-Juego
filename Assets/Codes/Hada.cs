using UnityEngine;
using UnityEngine.Events;

public class Hada : MonoBehaviour
{
    [Header("Evento que se dispara al recolectar un hada")]
    [SerializeField] public UnityEvent alRecolectarHada;

    [Header("Audio del hada")]
    public AudioClip hadaAudioClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { Debug.Log("Hada: disparando evento");
            // 🔔 Lanza el evento al recolectar
            alRecolectarHada.Invoke();

            // 🎵 Reproduce sonido
            GameObject audioObject = new GameObject("FairySound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = hadaAudioClip;
            audioSource.Play();
            Destroy(audioObject, hadaAudioClip.length);

            // 🧚‍♀️ Destruye el hada
            Destroy(gameObject);
        }
    }
}




