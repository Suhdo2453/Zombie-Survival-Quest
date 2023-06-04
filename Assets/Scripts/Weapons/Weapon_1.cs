using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Weapon_1 : Weapon
{
    public LookAtMouseState LookAtMouseState { get; private set; }
    public FireState FireState { get; private set; }
    public ReloadState ReloadState { get; private set; }

    private Player player;
    private float _fireRate;
    private int _quantityOfBullets;
    private bool isReload;
    InputHandler _inputHandler;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TextMeshProUGUI bulletCounter;


    protected virtual void Awake()
    {
        player = GetComponentInParent<Player>();
        _fireRate = weaponData.fireRate;
        _quantityOfBullets = weaponData.quantityOfBullets;
    }

    protected override void Start()
    {
        base.Start();

        LookAtMouseState = new LookAtMouseState(player, this, StateMachine, "");
        FireState = new FireState(firePoint, weaponData, this, this, StateMachine, "");
        ReloadState = new ReloadState(this, weaponData, this, StateMachine, "");

        ReloadState.onExit += ResetBullets;
        StateMachine.Initialize(LookAtMouseState);
        SoundManager.Instance.sfxSounds.Add(weaponData.sound);
        _inputHandler = InputHandler.Instance;
        bulletCounter.SetText(_quantityOfBullets.ToString());
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        _fireRate = _fireRate > 0 ? _fireRate - Time.fixedDeltaTime : 0;

        if (_inputHandler.AttackInput && _fireRate <= 0 && !isReload)
        {
            StateMachine.ChangeState(FireState);
            _fireRate = weaponData.fireRate;
            _quantityOfBullets--;
            bulletCounter.SetText(_quantityOfBullets.ToString());

            if (_quantityOfBullets <= 0)
            {
                ChangeToReloadState();
            }
        }

        if (_inputHandler.ReloadInput && _quantityOfBullets < weaponData.quantityOfBullets && !isReload)
        {
            ChangeToReloadState();
        }
    }

    private void ChangeToReloadState()
    {
        isReload = true;
        StateMachine.ChangeState(ReloadState);
    }

    private void ResetBullets()
    {
        isReload = false;
        _quantityOfBullets = weaponData.quantityOfBullets;
        bulletCounter.SetText(_quantityOfBullets.ToString());
    }
}