using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EnemyStateMachine StateMachine;
    public D_Entity entityData;
    
    public int FacingDirection { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Animator Anim { get; private set; }

    protected bool isDead;
    
    private Vector2 workspaceVector;
    [SerializeField]private float currentHealth;

    public virtual void Start()
    {
        FacingDirection = 1;
        RB = GetComponent<Rigidbody2D>();
        Anim =  GetComponent<Animator>();
        
        StateMachine = new EnemyStateMachine();
    }

    public virtual void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }

    public virtual void OnEnable()
    {
        StateMachine?.currentState.Enable();
        currentHealth = entityData.maxHealth;
        isDead = false;
    }

    public virtual void SetVelocity(float velocity)
    {
        workspaceVector.Set(FacingDirection * velocity, RB.velocity.y);
        RB.velocity = workspaceVector;
    }

    public virtual void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public virtual void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180f, 0f);
    }
    
}
