using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public void OnClick_Back()
    {
        MenuManager.Instance.OpenMenu(Menu.MAIN_MENU, gameObject);
    }
    
    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
