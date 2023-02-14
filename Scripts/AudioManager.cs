using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    private AudioSource _audioSource;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        _instance = this;
    }

    public void PlayAudio(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
