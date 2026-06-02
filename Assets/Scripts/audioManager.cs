using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip[] playlist, sfxSound;
    public AudioSource audioSource;
    private int musicIndex = 0;
    private int sfxIndex;

    public static audioManager instance;


    private void Awake()
    {
        //permet de garder une seule instance commune pour tous les niveaux et de ne pas en créer pour chaque
        if (instance != null)
        {
            Debug.LogWarning("LUIGIIIIIIII");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            playNextSong();
        }
    }

    void playNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public void PlaySfx(int sfxIndex)
    {
        AudioSource.PlayClipAtPoint(sfxSound[sfxIndex], transform.position);
    }

    public void ChangeBGM(AudioClip music)
    {
        audioSource.Stop();
        audioSource.clip = music;
        audioSource.Play();
    }
}
