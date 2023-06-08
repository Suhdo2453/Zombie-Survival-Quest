using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject bulletCounter;
    public void OnClick_Pause()
    {
        MenuManager.Instance.OpenMenu(Menu.PAUSE_MENU, null);
        MenuManager.Instance.CloseMenu(Menu.TOPLEFT_MENU);
        MenuManager.Instance.CloseMenu(Menu.TOPRIGHT_MENU);
        GameManager.Instance.PauseGame();
        SoundManager.Instance.PauseMusic();
        SoundManager.Instance.StopSFX();
        bulletCounter.SetActive(false);
    }

    public void OnClick_Resume()
    {
        MenuManager.Instance.CloseMenu(Menu.PAUSE_MENU);
        MenuManager.Instance.OpenMenu(Menu.TOPLEFT_MENU, null);
        MenuManager.Instance.OpenMenu(Menu.TOPRIGHT_MENU, null);
        GameManager.Instance.ResumeGame();
        SoundManager.Instance.UnPauseMusic();
        bulletCounter.SetActive(true);

    }
    
    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
