using System;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, settingsMenu;
    public static Animator mainAnim, settingsAnim;
    
    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("StartMenuPanel").gameObject;
        settingsMenu = canvas.transform.Find("SettingMenuPanel").gameObject;
        mainAnim = mainMenu.GetComponent<Animator>();
        settingsAnim = settingsMenu.GetComponent<Animator>();
        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if(!IsInitialised) Init();
        callingMenu.GetComponent<Animator>().SetTrigger("Close");
        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
               // mainAnim.SetTrigger("Open");
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
               // settingsAnim.SetTrigger("Open");
                break;
        }
        
    }
}
