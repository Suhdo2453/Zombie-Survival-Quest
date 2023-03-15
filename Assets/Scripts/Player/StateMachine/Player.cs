using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public Rigidbody2D RB;
    public Animator Anim;
    public InputHandler InputHandler { get; private set; }
    
    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 workSpaceVector;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<InputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;
        
       // StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicUpdate();
    }
}
