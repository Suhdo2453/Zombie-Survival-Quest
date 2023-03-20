using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState IdleState { get; private set; }
    public E1_MoveToTargetState MoveToTargetState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveToTarget moveToTargetData;
    public override void Start()
    {
        base.Start();
        
        

        IdleState = new E1_IdleState(this, StateMachine, idleStateData, this, "idle");
        MoveToTargetState =  new E1_MoveToTargetState(this, StateMachine, moveToTargetData, this, "moveToTarget");
        
        StateMachine.Intitialize(IdleState);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
