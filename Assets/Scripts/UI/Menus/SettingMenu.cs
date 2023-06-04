using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void OnClick_Back()
    {
        MenuManager.Instance.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
    
    public void SetActive()
    {
        gameObject.SetActive(false);
    }

    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(sfxSlider.value);
    }
}
