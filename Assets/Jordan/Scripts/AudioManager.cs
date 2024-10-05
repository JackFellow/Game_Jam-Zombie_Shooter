using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;

    public Sounds[] music, sfx;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

    }






    public void Music(string name)
    {
        Sounds song = Array.Find(music, x => x.SongName == name);
        if (song != null)
        {
            musicSource.clip = song.SongSound;

            musicSource.Play();




        }

        else
        {
            Debug.Log("not found");
        }
    }



    public void SFX(string name)
    {
        Sounds song = Array.Find(sfx, x => x.SongName == name);
        if (song != null)
        {
            sfxSource.PlayOneShot(song.SongSound);
        }

        else
        {
            Debug.Log("not found");
        }
    }

    public static void PlayMusic(string name)
    {
        if (instance == null)
        {
            return;
        }
        Sounds song = Array.Find(instance.music, x => x.SongName == name);
        if (song != null)
        {
            instance.musicSource.clip = song.SongSound;

            instance.musicSource.Play();

        }
        else
        {
            Debug.Log("cant find it");
        }

    }

    public static void StopMusic()
    {
        if (instance == null)
        {
            return;
        }

        if (instance.musicSource.isPlaying)
        {
            instance.musicSource.Stop();
        }
    }

    public void MusicVolumeAmount(float volume)
    {
        musicSource.volume = volume;

    }

    public void SFXVolumeAmount(float volume)
    {
        sfxSource.volume = volume;

    }
}