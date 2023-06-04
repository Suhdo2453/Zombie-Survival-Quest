using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponStateMachine StateMachine;
    public D_Weapon weaponData;
    public Animator Anim { get; private set; }

    private Vector2 workspaceVector;

    protected virtual void Start()
    {
        //Anim =  GetComponent<Animator>();
        
        StateMachine = new WeaponStateMachine();
    }

    protected virtual void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    protected virtual void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }
}
