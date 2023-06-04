using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine StateMachine;
    protected Entity Entity;
    
    public float StartTime { get; private set; }

    protected string AnimBoolName;

    public EnemyState(Entity entity, EnemyStateMachine stateMachine, string animBoolName)
    {
        StateMachine = stateMachine;
        Entity = entity;
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
        Entity.Anim.SetBool(AnimBoolName, true);
    }

    public virtual void Exit()
    {
        Entity.Anim.SetBool(AnimBoolName, false);
    }

    public virtual void Enable()
    {
        
    }
}