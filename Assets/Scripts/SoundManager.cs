using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("SoundManager instance set.");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Duplicate SoundManager detected and destroyed.");
            Destroy(gameObject);
            return;
        }

        source = GetComponent<AudioSource>();
        if (source == null)
        {
            Debug.LogError("AudioSource component is missing on SoundManager.");
        }
    }


    public void PlaySound(AudioClip _sound)
    {
        if (source != null && _sound != null)
        {
            source.PlayOneShot(_sound);
        }
    }
}


