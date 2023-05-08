using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    
    public void OnClick_Pause()
    {
        MenuManager.Instance.OpenMenu(Menu.PAUSE_MENU, null);
        GameManager.Instance.PauseGame();
        SoundManager.Instance.PauseMusic();
    }

    public void OnClick_Resume()
    {
        MenuManager.Instance.CloseMenu(gameObject);
        GameManager.Instance.ResumeGame();
        SoundManager.Instance.UnPauseMusic();
    }
    
    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
