using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyState
{
    protected D_IdleState StateData;

    protected bool IsIdleTimeOver;
    
    protected float IdleTime;
    
    public IdleState(Entity entity, EnemyStateMachine stateMachine,D_IdleState stateData, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
        this.StateData = stateData;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(Time.time >= StartTime + IdleTime)
        {
            IsIdleTimeOver = true;
        }
    }

    public override void Enter()
    {
        base.Enter();
        
        Entity.SetVelocity(0);
        IsIdleTimeOver = false;
        SetRandomTime();
    }

    private void SetRandomTime()
    {
        IdleTime = Random.Range(StateData.minIdleTime, StateData.maxIdleTime);
    }
}
