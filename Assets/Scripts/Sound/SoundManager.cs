using System;
using System.Collections;
using System.Collections.Generic;
using Ultilites;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    public List<Sound> musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public AudioMixer audioMixer;
    public AudioMixerSnapshot pause, unPause;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadSoundVolume();
    }

    public void PlayMusic(string musicName)
    {
        Sound sound = musicSounds.Find(x => x.name == musicName);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
           
        }
    }

    public void PlayDefaultMusic(string name)
    {
        Sound sound = musicSounds.Find(x => x.name == name);
        
        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = sound.audioClip;
            musicSource.Play();
            StartCoroutine(FadeIn(0.01f));
        }
    }

    public void PauseMusic()
    {
        pause.TransitionTo(0);
    }

    public void UnPauseMusic()
    {
        unPause.TransitionTo(0);
    }

    public void PlaySFX(string sfxName)
    {
        Sound sound = sfxSounds.Find(x => x.name == sfxName);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.clip = sound.audioClip;
            sfxSource.Play();
        }
    }

    public void MusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void FadeOut()
    {
        float audioVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            audioVolume -= 0.01f;
            musicSource.volume = audioVolume;
        }
        // musicSource.clip = newSound.audioClip;
        // musicSource.Play();
        // StartCoroutine(FadeIn(0.01f));
    }

    private IEnumerator FadeIn(float speed)
    {
        musicSource.volume = 0;
        float audioVolume = musicSource.volume;

        while (musicSource.volume < 1)
        {
            audioVolume += speed;
            musicSource.volume = audioVolume;
            yield return null;
        }
    }

    private void LoadSoundVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("sfxVolume")) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume")) * 20);
    }
}