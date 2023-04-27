using System.Collections;
using System.Collections.Generic;
using Enemies.States.SubState;
using Ultilites;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState { get; private set; }
    public E1_MoveToTargetState MoveToTargetState { get; private set; }
    public E1_DeadState DeadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveToTarget moveToTargetData;
    public override void Start()
    {
        base.Start();
        
        IdleState = new E1_IdleState(this, StateMachine, idleStateData, this, "idle");
        MoveToTargetState =  new E1_MoveToTargetState(this, StateMachine, moveToTargetData, this, "moveToTarget");
        DeadState = new E1_DeadState(this, StateMachine, "dead");
        
        StateMachine.Intitialize(IdleState);
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);

        if (isDead)
        {
            StateMachine.ChangeState(DeadState);
            ObjectPooler.Instance.CoolObject(gameObject);
        }
    }
}
