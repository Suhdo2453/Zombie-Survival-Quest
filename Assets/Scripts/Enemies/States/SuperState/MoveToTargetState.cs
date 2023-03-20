using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTargetState : EnemyState
{
    protected D_MoveToTarget MoveToTargetData;
    private Vector3 currentPosition;
    
    public MoveToTargetState(Entity entity, EnemyStateMachine stateMachine,D_MoveToTarget moveToTargetData, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
        MoveToTargetData = moveToTargetData;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        MoveToTarget();
    }

    public override void Enter()
    {
        base.Enter();

        
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void MoveToTarget()
    {
        if (!MoveToTargetData.targetPosition) return;
        
        currentPosition = Entity.transform.position;
        
        Vector3 moveDirection = (MoveToTargetData.targetPosition.position - currentPosition).normalized;
        Vector3 velocity = moveDirection * (MoveToTargetData.moveSpeed * Time.fixedDeltaTime);
        Vector3 newPosition = currentPosition + velocity;
        
        Entity.RB.MovePosition(newPosition);
    }
}
