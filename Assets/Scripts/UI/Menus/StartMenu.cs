using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlayDefaultMusic("MenuStart");
    }

    public void OnClick_Settings()
    {
        MenuManager.Instance.OpenMenu(Menu.SETTINGS, gameObject);
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
