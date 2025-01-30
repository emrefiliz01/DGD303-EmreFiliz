using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    private AudioSource audioSource;

    public bool isMusicOn = true;
    public bool isSoundOn = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isMusicOn)
        {
            PlayBackgroundMusic();
        }
    }

    public void PlayBackgroundMusic()
    {
        if (audioSource != null && backgroundMusic != null && isMusicOn)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            PlayBackgroundMusic();
        }
        else
        {
            StopBackgroundMusic();
        }
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
    }

}
