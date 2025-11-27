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
        if (!other.CompareTag("Player")) return;

        Debug.Log("🧚‍♀️ Hada recolectada, disparando evento");

        // 🔔 Lanza el evento al recolectar (ContadorDeHadas y ObjectPool deben estar conectados aquí)
        alRecolectarHada?.Invoke();

        // 🎵 Reproduce sonido
        if (hadaAudioClip != null)
        {
            GameObject audioObject = new GameObject("FairySound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = hadaAudioClip;
            audioSource.volume = 0.4f;

            audioSource.Play();
            Destroy(audioObject, hadaAudioClip.length);
        }

        // 🧹 Destruye el hada
        Destroy(gameObject);
    }
}
