using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> sonidosImpacto;

    void Awake()
    {
        Instance = this; // NECESARIO
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayRandomImpactSounds()
    {
        if (sonidosImpacto.Count == 0) return;

        int index = Random.Range(0, sonidosImpacto.Count);
        PlaySound(sonidosImpacto[index]);
    }
}
