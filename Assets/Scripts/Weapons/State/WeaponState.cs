using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState
{
    protected WeaponStateMachine StateMachine;
    protected Weapon weapon;
    
    public float StartTime { get; private set; }

    protected string AnimBoolName;

    public WeaponState(Weapon weapon, WeaponStateMachine stateMachine, string animBoolName)
    {
        StateMachine = stateMachine;
        this.weapon = weapon;
        AnimBoolName = animBoolName;
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Enter()
    {
        StartTime = Time.time;
        //weapon.Anim.SetBool(AnimBoolName, true);
    }

    public virtual void Exit()
    {
        //weapon.Anim.SetBool(AnimBoolName, false);
    }

    public virtual void Enable()
    {
        
    }
}
