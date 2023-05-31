using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    public WeaponState currentState { get; private set; }

    public void Initialize(WeaponState startingState)
    {
        currentState = startingState;
        currentState.Enter();
    }

    public void ChangeState(WeaponState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
