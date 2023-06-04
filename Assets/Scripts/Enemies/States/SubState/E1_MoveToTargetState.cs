using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveToTargetState : MoveToTargetState
{
    private Enemy1 enemy1;
    
    public E1_MoveToTargetState(Entity entity, EnemyStateMachine stateMachine, D_MoveToTarget moveToTargetData,Enemy1 enemy1, string animBoolName) : base(entity, stateMachine, moveToTargetData, animBoolName)
    {
        this.enemy1 = enemy1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy1.transform.position.Equals(target))
        {
            // attack state
        }
    }
}
