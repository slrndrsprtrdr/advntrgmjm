using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        int numOfMusicObjects = FindObjectsOfType<Music>().Length;
        if (numOfMusicObjects > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        else
        {
            audioSource.Play();
        }

    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
