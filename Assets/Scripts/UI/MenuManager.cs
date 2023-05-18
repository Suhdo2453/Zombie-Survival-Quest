using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Ultilites.Singleton<MenuManager>
{
    [SerializeField] public GameObject mainMenu, settingsMenu, pauseMenu, topLeftMenu, topRightMenu, endGameMenu;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject heartBar;

    public List<Image> hearts;
    private PlayerStats playerStats;

    public void OpenMenu(Menu menu, [CanBeNull] GameObject callingMenu)
    {
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
            case Menu.TOPLEFT_MENU:
                topLeftMenu.SetActive(true);
                break;
            case Menu.TOPRIGHT_MENU:
                topRightMenu.SetActive(true);
                break;
            case Menu.END_MENU:
                endGameMenu.SetActive(true);
                break;
        }
    }

    public void CloseMenu(Menu callingMenu)
    {
        switch (callingMenu)
        {
            case Menu.MAIN_MENU:
                mainMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
            case Menu.SETTINGS:
                settingsMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
            case Menu.PAUSE_MENU:
                pauseMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
            case Menu.TOPLEFT_MENU:
                topLeftMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
            case Menu.TOPRIGHT_MENU:
                topRightMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
            case Menu.END_MENU:
                endGameMenu.GetComponent<Animator>().SetTrigger("Close");
                break;
        }
    }


    public void LoadHeart()
    {
        playerStats = PlayerStats.Instance;
        playerStats.DamageTaken += UpdateHearts;
        for (int i = 0; i < playerStats.maxHealth; i++)
        {
            GameObject h = Instantiate(heart, heartBar.transform);
            hearts.Add(h.transform.GetChild(0).GetComponent<Image>());
        }
        hearts.Reverse();
    }

    private void UpdateHearts()
    {
        foreach (Image i in hearts)
        {
            if (i.fillAmount > 0)
            {
                i.fillAmount = 0;
                return;
            }
        }
    }
}