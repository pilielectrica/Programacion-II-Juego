using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton simple
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // permanece en todas las escenas
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void PlayRandom(List<AudioClip> clips)
    {
        if (clips.Count == 0) return;

        int index = Random.Range(0, clips.Count);
        PlaySound(clips[index]);
    }
}
