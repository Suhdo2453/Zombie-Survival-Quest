using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : Ultilites.Singleton<MenuManager>
{
    [SerializeField] public GameObject mainMenu, settingsMenu, pauseMenu;
    [SerializeField] private GameObject heart;
    [SerializeField] private GameObject heartBar;

    public List<Image> hearts;
    private PlayerStats playerStats;

    private void Start()
    {
        LoadHeart();
    }

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
        }
    }

    public void CloseMenu(GameObject callingMenu)
    {
        callingMenu.GetComponent<Animator>().SetTrigger("Close");
    }


    private void LoadHeart()
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