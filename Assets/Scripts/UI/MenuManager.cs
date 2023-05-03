using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class MenuManager : Ultilites.Singleton<MenuManager>
{
    //public static bool IsInitialised { get; private set; }
    [SerializeField]
    public GameObject mainMenu, settingsMenu, pauseMenu;
    
    /*public void Init()
    {
        IsInitialised = true;
    }*/

    public void OpenMenu(Menu menu, [CanBeNull] GameObject callingMenu)
    {
        //if(!IsInitialised) Init();
        callingMenu?.GetComponent<Animator>().SetTrigger("Close");
        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                settingsMenu.SetActive(true);
                break;
            case Menu.PAUSE_MENU:
                pauseMenu.SetActive(true);
                break;
        }
        
    }

    public void CloseMenu(GameObject callingMenu)
    {
        callingMenu.GetComponent<Animator>().SetTrigger("Close");
    }
}
