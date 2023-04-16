using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    [SerializeField] private PlayerData PlayerData;

    public Rigidbody2D RB;
    public Animator Anim;
    public InputHandler InputHandler { get; private set; }

    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }

    private Vector2 workSpaceVector;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, PlayerData, "idleState");
        MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "moveState");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<InputHandler>();
        RB = GetComponent<Rigidbody2D>();
        FacingDirection = 1;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.currentState.LogicUpdate();
        FacingToMouse();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicUpdate();
    }

    public void SetVelocityZero()
    {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocity(Vector2 velocity)
    {
        workSpaceVector = velocity;
        RB.velocity = workSpaceVector;
        CurrentVelocity = workSpaceVector;
    }

    public void CheckIfShouldFlip(Vector2 inputDirection)
    {
        if (inputDirection != Vector2.zero && RoundFloat(inputDirection.x) == -FacingDirection)
            Flip();
    }

    public void FacingToMouse()
    {
        if ((InputHandler.MousePosition.x < transform.position.x)&& FacingDirection==1)
        {
            // Lật player sang trái
            Flip();
        }
        else if ((InputHandler.MousePosition.x > transform.position.x)&& FacingDirection==-1)
        {
            // Lật player sang phải
            Flip();
        }
    }

    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180f, 0.0f);
    }

    public static int RoundFloat(float num)
    {
        return num > 0 ? Mathf.CeilToInt(num) : Mathf.FloorToInt(num);
    }
}