using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
    private Enemy1 enemy1;
    
    public E1_IdleState(Entity entity, EnemyStateMachine stateMachine, D_IdleState stateData, Enemy1 enemy1, string animBoolName) : base(entity, stateMachine, stateData, animBoolName)
    {
        this.enemy1 = enemy1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (IsIdleTimeOver)
        {
            StateMachine.ChangeState(enemy1.MoveToTargetState);
        }
    }
}
