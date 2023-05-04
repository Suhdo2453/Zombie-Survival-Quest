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

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadSoundVolume();
        PlayMusic("MenuStart");
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
            StartCoroutine( FadeOut(sound, 0.01f));
        }
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

    private IEnumerator FadeOut(Sound newSound, float speed)
    {
        float audioVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            audioVolume -= speed;
            musicSource.volume = audioVolume;
            yield return new WaitForSeconds(0.01f);
        }
        musicSource.clip = newSound.audioClip;
        musicSource.Play();
        StartCoroutine(FadeIn(0.01f));
    }

    private IEnumerator FadeIn(float speed)
    {
        musicSource.volume = 0;
        float audioVolume = musicSource.volume;

        while (musicSource.volume < 1)
        {
            audioVolume += speed;
            musicSource.volume = audioVolume;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void LoadSoundVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("sfxVolume")) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume")) * 20);
    }
}