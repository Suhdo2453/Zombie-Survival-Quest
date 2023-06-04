using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : WeaponState
{
    private D_Weapon weaponData;
    private Weapon_1 weapon1;
    private Vector3 currentRotation;
    private float rotationSpeed = 1500f;

    public event OnExit onExit;
    
    public ReloadState(Weapon_1 weapon1, D_Weapon weaponData, Weapon weapon, WeaponStateMachine stateMachine, string animBoolName) : base(weapon, stateMachine, animBoolName)
    {
        this.weaponData = weaponData;
        this.weapon1 = weapon1;
    }

    public override void Enter()
    {
        base.Enter();

        // Lấy góc quay hiện tại của đối tượng
        currentRotation = weapon1.transform.rotation.eulerAngles;
        SoundManager.Instance.PlaySFX("ReloadSound", true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if ((Time.time - StartTime) >= weaponData.reloadTime)
        {
            StateMachine.ChangeState(weapon1.LookAtMouseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        
        // Cập nhật góc quay theo trục Z
        currentRotation.z += rotationSpeed * Time.deltaTime;

        // Gán lại góc quay mới vào component Transform
        weapon1.transform.rotation = Quaternion.Euler(currentRotation);

    }

    public override void Exit()
    {
        base.Exit();
        if (onExit != null) onExit();
        SoundManager.Instance.StopSFX();
    }

    public delegate void OnExit();
}
