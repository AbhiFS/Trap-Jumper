using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure the music plays on start
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    // Optionally, you can add methods to stop or pause the music
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void UnpauseMusic()
    {
        if (audioSource != null)
        {
            audioSource.UnPause();
        }
    }
}
