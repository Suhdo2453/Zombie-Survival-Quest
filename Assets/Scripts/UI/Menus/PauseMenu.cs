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
    }

    public void OnClick_Resume()
    {
        MenuManager.Instance.CloseMenu(gameObject);
        GameManager.Instance.ResumeGame();
    }
    
    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
