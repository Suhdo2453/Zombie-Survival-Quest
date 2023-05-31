using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_1 : Weapon
{
    public LookAtMouseState LookAtMouseState { get; private set; }
    public FireState FireState { get; private set; }

    private Player player;
    private float _fireRate;
    [SerializeField] private Transform firePoint;


    protected virtual void Awake()
    {
        player = GetComponentInParent<Player>();
        _fireRate = weaponData.fireRate;
    }

    protected override void Start()
    {
        base.Start();
        
        LookAtMouseState = new LookAtMouseState(player, this, StateMachine, "");
        FireState = new FireState(firePoint, weaponData,this, this, StateMachine, "");

        StateMachine.Initialize(LookAtMouseState);
        SoundManager.Instance.sfxSounds.Add(weaponData.sound);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        _fireRate = _fireRate > 0 ? _fireRate - Time.fixedDeltaTime : 0;
        
        if (InputHandler.Instance.AttackInput && _fireRate <= 0)
        {
            StateMachine.ChangeState(FireState);
            _fireRate = weaponData.fireRate;
        }
    }
}