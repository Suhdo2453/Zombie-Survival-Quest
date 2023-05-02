using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnClick_Settings()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, gameObject);
    }

    public void OnClick_Start()
    {
        SceneManager.LoadScene(1);
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
