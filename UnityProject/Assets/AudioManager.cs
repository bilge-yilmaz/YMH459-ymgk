using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource audioSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip == null) return;
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}