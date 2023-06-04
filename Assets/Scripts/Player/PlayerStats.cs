using System;
using Ultilites;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    public int maxHealth;

    public event Action DamageTaken;

    public int currentHealth { get; private set; }
    private GameManager GM;

    private void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void DecreaseHealth()
    {
        currentHealth--;

        if (DamageTaken != null) DamageTaken();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        MenuManager.Instance.OpenMenu(Menu.DIED_MENU, null);
        MenuManager.Instance.CloseMenu(Menu.TOPRIGHT_MENU);
        MenuManager.Instance.CloseMenu(Menu.TOPLEFT_MENU);
        GameManager.Instance.PauseGame();
    }
}