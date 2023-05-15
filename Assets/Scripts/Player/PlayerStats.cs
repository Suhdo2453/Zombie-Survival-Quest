using System;
using System.Collections;
using System.Collections.Generic;
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
    }
}